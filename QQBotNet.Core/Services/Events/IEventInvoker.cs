using WebSocket4Net;
using SuperSocket.ClientEngine;
using System;

namespace QQBotNet.Core.Services.Events;

/// <summary>
/// 事件执行器接口
/// </summary>
public interface IEventInvoker
{
    /// <summary>
    /// WebSocket开启
    /// </summary>
    public event EventHandler WebSocketOpened;

    /// <summary>
    /// WebSocket关闭
    /// </summary>
    public event EventHandler WebSocketClosed;

    /// <summary>
    /// WebSocket错误
    /// </summary>
    public event EventHandler<ErrorEventArgs> WebSocketError;

    /// <summary>
    /// WebSocket重连
    /// </summary>
    public event EventHandler WebSocketReconnect;

    /// <summary>
    /// 接收到消息
    /// </summary>
    public event EventHandler<MessageReceivedEventArgs> WebSocketRawMessageReceived;

    /// <summary>
    /// 发送数据包
    /// </summary>
    public event EventHandler<PacketEventArgs> PacketSent;

    /// <summary>
    /// 收到数据包
    /// </summary>
    public event EventHandler<PacketEventArgs> PacketReceived;

    /// <summary>
    /// 心跳事件
    /// </summary>
    public event EventHandler Heartbeat;

    /// <summary>
    /// 接收到调度事件
    /// </summary>
    public event EventHandler<BotDispatchEventReceivedEventArgs> BotDispatchEventReceived;
}
