using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using QQBotNet.Core;
using QQBotNet.Core.Utils;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace QQBotNet.OneBot;

public sealed class WorkerService : IHostedService
{
    private readonly IConfiguration _config;
    private readonly ILogger<QQBotNetApp> _logger;
    private readonly BotInstance _instance;

    public WorkerService(IConfiguration config, ILogger<QQBotNetApp> logger)
    {
        _config = config;
        _logger = logger;
        try
        {
            _instance = new(
                config["botAppId"]!,
                config["botToken"]!,
                config["botSecret"]!,
                config.GetValue<bool>("sandbox")
            );
        }
        catch (Exception e)
        {
            _logger.LogWarning("初始化机器人实例时出现问题:\n{}", e.Message);
            throw;
        }
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await _instance.StartAsync();
        _logger.LogInformation("机器人实例已启动");

        _instance.WebSocketService!.Opened += (_, _) =>
            _logger.LogInformation("WebSocket已连接至\"{}\"", _instance.WebSocketService?.Url);
        _instance.WebSocketService!.Error += (_, e) =>
            _logger.LogWarning(e.Exception, "WebSocket出现错误");
        _instance.WebSocketService!.Closed += (_, _) => _logger.LogInformation("WebSocket已断开");
        _instance.WebSocketService!.Sent += (_, e) =>
            _logger.LogInformation("发送消息:{}", JsonSerializer.Serialize(e.Packet));
        _instance.WebSocketService!.RawMessageReceived += (_, e) =>
            _logger.LogInformation("接收消息:{}", e.Message);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _instance.Dispose();
        _logger.LogInformation("机器人实例已关闭并释放");
        return Task.CompletedTask;
    }
}
