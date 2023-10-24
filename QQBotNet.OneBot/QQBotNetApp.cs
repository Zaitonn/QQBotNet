using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using QQBotNet.Core;
using QQBotNet.OneBot.Entity.Config;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace QQBotNet.OneBot;

public sealed class QQBotNetApp : IHost
{
    private readonly IHost _hostApp;

    public IServiceProvider Services => _hostApp.Services;

    private AppConfig Config => Services.GetRequiredService<AppConfig>();

    private readonly ILogger<QQBotNetApp> _logger;

    private readonly BotInstance _instance;

    internal QQBotNetApp(IHost host)
    {
        _hostApp = host;
        _logger = Services.GetRequiredService<ILogger<QQBotNetApp>>();

        try
        {
            _instance = new(
                Config.BotAppId,
                Config.BotToken,
                Config.BotSecret,
                Config.Sandbox
            );
        }
        catch (Exception e)
        {
            _logger.LogError("初始化机器人实例时出现问题:\n{}", e.Message);
            throw;
        }
    }

    public void Dispose()
    {
        _hostApp.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task StartAsync(CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("QQBotNet.OneBot已启动");

        try
        {
            await _instance.StartAsync();
        }
        catch (Exception e)
        {
            _logger.LogError("启动机器人实例时出现问题:\n{}", e.Message);
            _logger.LogError("请检查必要信息是否填写正确");
            return;
        }

        _logger.LogInformation("机器人实例已启动");

        _instance.Invoker.WebSocketOpened += (_, _) =>
            _logger.LogInformation("WebSocket:已连接至\"{}\"", _instance.WebSocketUrl);
        _instance.Invoker.WebSocketError += (_, e) =>
            _logger.LogWarning(e.Exception, "WebSocket:出现错误");
        _instance.Invoker.PacketSent += (_, e) =>
            _logger.LogDebug("WebSocket:发送消息:{}", JsonSerializer.Serialize(e.Packet));
        _instance.Invoker.WebSocketRawMessageReceived += (_, e) =>
            _logger.LogDebug("WebSocket:接收消息:{}", e.Message);

        _instance.Invoker.WebSocketClosed += (_, _) => _logger.LogWarning("WebSocket:已断开");
        _instance.Invoker.Heartbeat += (_, _) => _logger.LogInformation("WebSocket:接收到心跳事件");
    }

    public async Task StopAsync(CancellationToken cancellationToken = default)
    {
        _instance.Dispose();
        _logger.LogInformation("机器人实例已关闭");
        await _hostApp.StopAsync(cancellationToken);
        _logger.LogInformation("QQBotNet.OneBot已关闭");
    }
}
