using Microsoft.Extensions.Hosting;
using QQBotNet.Core;
using QQBotNet.Core.Services.Events;
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
            _instance = new(_config.BotInfo.BotAppId, _config.BotInfo.BotToken, _config.Sandbox);
        }
        catch
        {
            Logger.Warn<QQBotNetApp>("\"botAppId\"或\"botToken\"不正确");
            throw;
        }
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public Task StartAsync(CancellationToken cancellationToken = default)
    {
        Logger.Info<QQBotNetApp>("QQBotNet.OneBot已启动");

        try
        {
            _instance.Start();
        }
        catch (Exception e)
        {
            Logger.Error<QQBotNetApp>($"启动机器人实例时出现问题:\n{e.Message}");
            Logger.Error<QQBotNetApp>("请检查必要信息是否填写正确");
            return Task.CompletedTask;
        }

        Logger.Info<QQBotNetApp>("机器人实例已启动");

        _instance.Invoker.WebSocketOpened += (_, _) =>
            Logger.Info<EventInvoker>($"WebSocket: 已连接至\"{_instance.WebSocketUrl}\"");
        _instance.Invoker.WebSocketReconnect += (_, _) =>
            Logger.Info<EventInvoker>($"WebSocket: 正在重连");
        _instance.Invoker.WebSocketError += (_, e) =>
            Logger.Error<EventInvoker>("WebSocket: 出现错误", e.Exception);
        _instance.Invoker.PacketSent += (_, e) =>
            Logger.Debug<EventInvoker>($"WebSocket: 发送消息:{JsonSerializer.Serialize(e.Packet)}");
        _instance.Invoker.WebSocketRawMessageReceived += (_, e) =>
            Logger.Debug<EventInvoker>($"WebSocket: 接收消息:{e.Message}");

        _instance.Invoker.WebSocketClosed += (_, _) => Logger.Warn<EventInvoker>("WebSocket: 已断开");
        _instance.Invoker.Heartbeat += (_, _) => Logger.Info<EventInvoker>("WebSocket: 接收到心跳事件");

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _instance.Dispose();
        Logger.Info<QQBotNetApp>("机器人实例已关闭");
        Logger.Info<QQBotNetApp>("QQBotNet.OneBot已关闭");
        return Task.CompletedTask;
    }
}
