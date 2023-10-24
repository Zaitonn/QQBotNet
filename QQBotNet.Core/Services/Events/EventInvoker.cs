using WebSocket4Net;
using SuperSocket.ClientEngine;
using System;

namespace QQBotNet.Core.Services.Events;

public class EventInvoker : IEventInvoker
{
    private readonly BotInstance _botInstance;

    public event EventHandler? WebSocketOpened;
    public event EventHandler? WebSocketClosed;
    public event EventHandler<ErrorEventArgs>? WebSocketError;
    public event EventHandler? WebSocketReconnect;
    public event EventHandler<MessageReceivedEventArgs>? WebSocketRawMessageReceived;
    public event EventHandler<PacketEventArgs>? PacketSent;
    public event EventHandler<PacketEventArgs>? PacketReceived;
    public event EventHandler? Heartbeat;
    public event EventHandler<BotDispatchEventReceivedEventArgs>? BotDispatchEventReceived;

    internal EventInvoker(BotInstance botInstance)
    {
        _botInstance = botInstance;
    }

    internal void OnWebSocketOpened() => WebSocketOpened?.Invoke(_botInstance, new());

    internal void OnWebSocketClosed() => WebSocketClosed?.Invoke(_botInstance, new());

    internal void OnWebSocketError(ErrorEventArgs e) => WebSocketError?.Invoke(_botInstance, e);

    internal void OnWebSocketReconnect() => WebSocketReconnect?.Invoke(_botInstance, new());

    internal void OnWebSocketRawMessageReceived(MessageReceivedEventArgs e) =>
        WebSocketRawMessageReceived?.Invoke(_botInstance, e);

    internal void OnPacketSent(PacketEventArgs e) => PacketSent?.Invoke(_botInstance, e);

    internal void OnPacketReceived(PacketEventArgs e) => PacketReceived?.Invoke(_botInstance, e);

    internal void OnHeartbeat() { }

    internal void OnBotDispatchEventReceived(BotDispatchEventReceivedEventArgs e) =>
        BotDispatchEventReceived?.Invoke(_botInstance, e);
}
