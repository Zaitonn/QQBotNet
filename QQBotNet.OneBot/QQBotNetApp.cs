using Microsoft.Extensions.Hosting;
using QQBotNet.Core;
using QQBotNet.OneBot.Models.Config;
using QQBotNet.OneBot.Utils;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace QQBotNet.OneBot;

public sealed class QQBotNetApp : IHost
{
    private readonly IHost _hostApp;

    public IServiceProvider Services => _hostApp.Services;

    private readonly AppConfig _config;

    private readonly BotInstance _instance;

    internal QQBotNetApp(IHost host, AppConfig appConfig)
    {
        Logger.EnableDebugLog = appConfig.DebugLog;
        _hostApp = host;
        _config = appConfig;
        try
        {
            _instance = new(
                _config.BotInfo.BotAppId,
                _config.BotInfo.BotToken,
                _config.BotInfo.BotSecret,
                _config.Sandbox
            );
        }
        catch (Exception e)
        {
            Logger.Warn<QQBotNetApp>($"初始化机器人实例时出现问题:\n{e.Message}");
            throw;
        }
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public async Task StartAsync(CancellationToken cancellationToken = default)
    {
        Logger.Info<QQBotNetApp>("QQBotNet.OneBot已启动");

        try
        {
            await _instance.StartAsync();
        }
        catch (Exception e)
        {
            Logger.Error<QQBotNetApp>($"启动机器人实例时出现问题:\n{e.Message}");
            Logger.Error<QQBotNetApp>("请检查必要信息是否填写正确");
            return;
        }

        Logger.Info<QQBotNetApp>("机器人实例已启动");

        _instance.Invoker.WebSocketOpened += (_, _) =>
            Logger.Info<QQBotNetApp>($"WebSocket: 已连接至\"{_instance.WebSocketUrl}\"");
        _instance.Invoker.WebSocketError += (_, e) =>
            Logger.Error<QQBotNetApp>("WebSocket: 出现错误", e.Exception);
        _instance.Invoker.PacketSent += (_, e) =>
            Logger.Debug<QQBotNetApp>($"WebSocket: 发送消息:{JsonSerializer.Serialize(e.Packet)}");
        _instance.Invoker.WebSocketRawMessageReceived += (_, e) =>
            Logger.Debug<QQBotNetApp>($"WebSocket: 接收消息:{e.Message}");

        _instance.Invoker.WebSocketClosed += (_, _) => Logger.Warn<QQBotNetApp>("WebSocket: 已断开");
        _instance.Invoker.Heartbeat += (_, _) => Logger.Info<QQBotNetApp>("WebSocket: 接收到心跳事件");
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _instance.Dispose();
        Logger.Info<QQBotNetApp>("机器人实例已关闭");
        Logger.Info<QQBotNetApp>("QQBotNet.OneBot已关闭");
        return Task.CompletedTask;
    }
}
