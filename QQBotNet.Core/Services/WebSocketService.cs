using QQBotNet.Core.Entity.WebSockets;
using QQBotNet.Core.Services.EventArg;
using QQBotNet.Core.Services.Operations;
using QQBotNet.Core.Utils;
using WebSocket4Net;
using SuperSocket.ClientEngine;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using QQBotNet.Core.Entity;

namespace QQBotNet.Core.Services;

public sealed class WebSocketService : IBotService, IWebSocketService
{
    public readonly WebSocket WebSocketClient;

    public event EventHandler<MessageReceivedEventArgs>? RawMessageReceived;
    public event EventHandler<BotMessageEventArgs>? BotMessageReceived;
    public event EventHandler<EventArgs>? Opened;
    public event EventHandler<EventArgs>? Closed;
    public event EventHandler<ErrorEventArgs>? Error;

    internal readonly SensitiveInfo Info;

    private Dictionary<OperationCode, IOperation> _operations;

    /// <summary>
    /// 下行消息序列号
    /// </summary>
    public long SerialNumber { get; private set; }

    internal WebSocketService(SensitiveInfo info, string url)
    {
        if (url is null)
        {
            throw new ArgumentNullException(nameof(url));
        }

        WebSocketClient = new(url);
        WebSocketClient.MessageReceived += HandlePacket;
        WebSocketClient.MessageReceived += (_, e) => RawMessageReceived?.Invoke(this, e);
        WebSocketClient.Opened += (_, e) => Opened?.Invoke(this, e);
        WebSocketClient.Closed += (_, e) => Closed?.Invoke(this, e);
        WebSocketClient.Error += (_, e) => Error?.Invoke(this, e);

        _operations = new();
        foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
        {
            var attribute = type.GetCustomAttribute<OperationAttribute>();
            if (attribute is not null && type is not null)
            {
                var operation = (IOperation)Activator.CreateInstance(type)!;
            }
        }
        Info = info;
    }

    public void Dispose()
    {
        WebSocketClient.Dispose();
    }

    public void Start()
    {
        WebSocketClient.Open();
    }

    public void Stop()
    {
        WebSocketClient.Close();
    }

    /// <summary>
    /// 处理数据包
    /// </summary>
    internal void HandlePacket(object? sender, MessageReceivedEventArgs e)
    {
        var packet = JsonSerializer.Deserialize<Packet>(e.Message);
        if (packet is not null)
        {
            if (
                _operations.TryGetValue(packet.Operation, out IOperation? operation)
                && operation is not null
            )
                operation.HandleOperation(packet, this);
            SerialNumber = packet.SerialNumber;
        }
    }

    /// <summary>
    /// 发送数据包
    /// </summary>
    /// <param name="packet">数据包</param>
    public void SendPacket(Packet packet)
    {
        packet.SerialNumber = SerialNumber;
        packet.Type = null;
        WebSocketClient.Send(
            JsonSerializer.Serialize(packet, JsonSerializerOptionsFactory.IgnoreNull)
        );
    }
}
