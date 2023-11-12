using QQBotNet.Core;
using QQBotNet.Core.Services;
using QQBotNet.Core.Services.Events;
using QQBotNet.Core.Utils.Json;
using QQBotNet.OneBot.Models.Config;
using QQBotNet.OneBot.Network;
using QQBotNet.OneBot.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace QQBotNet.OneBot;

public sealed class QQBotNetApp : IDisposable
{
    public readonly AppConfig AppConfig;

    private readonly BotInstance _instance;

    private readonly CancellationTokenSource _tokenSource = new();

    private readonly List<IOneBotService> _services = new();

    private readonly Business.EventHandler _eventHandler;

    internal QQBotNetApp(AppConfig appConfig)
    {
        Logger.EnableDebugLog = appConfig.DebugLog;
        Console.CancelKeyPress += (_, _) => Stop();

        AppConfig = appConfig;
        _instance = new(
            AppConfig.BotInfo.BotAppId,
            AppConfig.BotInfo.BotToken,
            isSandbox: AppConfig.Sandbox
        );
        _eventHandler = new(this);

        _instance.EventDispatcher.WebSocketOpened += (_, _) =>
            Logger.Info<WebSocketService>($"已连接至\"{_instance.WebSocketUrl}\"");
        _instance.EventDispatcher.WebSocketReconnect += (_, _) =>
            Logger.Info<WebSocketService>($"正在重连");
        _instance.EventDispatcher.PacketSent += (_, e) =>
            Logger.Debug<WebSocketService>($"发送消息：{JsonSerializer.Serialize(e.Packet)}");
        _instance.EventDispatcher.WebSocketRawMessageReceived += (_, e) =>
            Logger.Debug<WebSocketService>($"接收消息：{Encoding.UTF8.GetString(e.Data)}");

        _instance.EventDispatcher.WebSocketClosed += (_, _) => Logger.Warn<WebSocketService>("已断开");
        _instance.EventDispatcher.Heartbeat += (_, _) => Logger.Info<WebSocketService>("发送心跳事件");
        _instance.EventDispatcher.Exception += (_, e) => Logger.Error<EventDispatcher>("出现异常：", e);
        _instance.EventDispatcher.BotDispatchEventReceived += HandleDispatchEvent;
        _instance.EventDispatcher.MessageCreated += _eventHandler.HandleMessageCreated;

        foreach (var connection in AppConfig.Connections)
        {
            if (!connection.Enable)
                continue;

            IOneBotService? service;
            try
            {
                service = connection.Type switch
                {
                    "http-post" => new HttpPostService(AppConfig.BotInfo.BotAppId, connection),
                    "reverse-websocket"
                        => new ReverseWSService(AppConfig.BotInfo.BotAppId, connection),
                    "websocket" => new ForwardWSService(AppConfig.BotInfo.BotAppId, connection),
                    _ => null
                };
            }
            catch (Exception e)
            {
                Logger.Error<QQBotNetApp>($"初始化{connection.Type}服务时出现问题: {e.Message}");
                continue;
            }

            if (service is null)
            {
                Logger.Warn<QQBotNetApp>($"配置项中发现未知的连接类型: {connection.Type}");
                continue;
            }

            _services.Add(service);
            Logger.Info<QQBotNetApp>($"新的{connection.Type}的连接方式已添加（{connection.Address}）");
        }
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public async Task RunAsync()
    {
        try
        {
            _instance.WebSocketService.Start();
            Logger.Info<BotInstance>("机器人实例已启动");
        }
        catch (Exception e)
        {
            Logger.Error<QQBotNetApp>($"启动机器人实例时出现问题:\n{e.Message}");
            Logger.Error<QQBotNetApp>("请检查必要信息是否填写正确");
            throw;
        }

        lock (_services)
            _services.ForEach(async (service) => await service.StartAsync(_tokenSource.Token));

        do
        {
            await Task.Delay(114514, _tokenSource.Token);
        } while (!_tokenSource.Token.IsCancellationRequested);
    }

    public void Stop()
    {
        _instance.Dispose();
        Logger.Info<BotInstance>("机器人实例已关闭");

        lock (_services)
            _services.ForEach(async (service) => await service.StopAsync());

        _tokenSource.Cancel();
        Logger.Info<QQBotNetApp>("QQBotNet.OneBot已关闭");
    }

    public void Broadcast<T>(T packet)
    {
        var payload = JsonSerializer.Serialize(
            packet,
            JsonSerializerOptionsFactory.UnsafeSnakeCase
        );
        lock (_services)
            _services.ForEach((service) => service.SendJsonAsync(payload, _tokenSource.Token));
    }

    private void HandleDispatchEvent(object? sender, BotDispatchEventReceivedEventArgs e)
    {
        if (e.Event == DispatchEventType.READY && _instance.WebSocketService.Session is not null)
            Logger.Info<QQBotNetApp>(
                $"机器人登录成功：[{_instance.WebSocketService.Session.User.Username}]({_instance.WebSocketService.Session.User.Id})"
            );
    }
}
