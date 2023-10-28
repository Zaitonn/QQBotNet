using WebSocket4Net;
using SuperSocket.ClientEngine;
using System;

namespace QQBotNet.Core.Services.Events;

/// <summary>
/// 事件执行器
/// </summary>
public class EventInvoker : IEventInvoker
{
    private readonly BotInstance _botInstance;

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public event EventHandler? WebSocketOpened;

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public event EventHandler? WebSocketClosed;

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public event EventHandler<ErrorEventArgs>? WebSocketError;

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public event EventHandler? WebSocketReconnect;

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public event EventHandler<MessageReceivedEventArgs>? WebSocketRawMessageReceived;

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public event EventHandler<PacketEventArgs>? PacketSent;

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public event EventHandler<PacketEventArgs>? PacketReceived;

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public event EventHandler? Heartbeat;

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public event EventHandler<BotDispatchEventReceivedEventArgs>? BotDispatchEventReceived;

    internal EventInvoker(BotInstance botInstance)
    {
        _botInstance = botInstance;
    }

    internal void OnWebSocketOpened()
    {
        WebSocketOpened?.Invoke(_botInstance, new());
    }

    internal void OnWebSocketClosed()
    {
        WebSocketClosed?.Invoke(_botInstance, new());
    }

    internal void OnWebSocketError(ErrorEventArgs e)
    {
        WebSocketError?.Invoke(_botInstance, e);
    }

    internal void OnWebSocketReconnect()
    {
        WebSocketReconnect?.Invoke(_botInstance, new());
    }

    internal void OnWebSocketRawMessageReceived(MessageReceivedEventArgs e)
    {
        WebSocketRawMessageReceived?.Invoke(_botInstance, e);
    }

    internal void OnPacketSent(PacketEventArgs e)
    {
        PacketSent?.Invoke(_botInstance, e);
    }

    internal void OnPacketReceived(PacketEventArgs e)
    {
        PacketReceived?.Invoke(_botInstance, e);
    }

    internal void OnHeartbeat()
    {
        Heartbeat?.Invoke(_botInstance, new());
    }

    internal void OnBotDispatchEventReceived(BotDispatchEventReceivedEventArgs e)
    {
        BotDispatchEventReceived?.Invoke(_botInstance, e);
    }
}
