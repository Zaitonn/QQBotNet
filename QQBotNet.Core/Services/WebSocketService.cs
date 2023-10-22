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
using System.Timers;
using System.Text.Json.Nodes;

namespace QQBotNet.Core.Services;

public sealed class WebSocketService : IBotService, IWebSocketService
{
    public readonly WebSocket WebSocketClient;

    public event EventHandler<MessageReceivedEventArgs>? RawMessageReceived;
    public event EventHandler<BotMessageEventArgs>? BotMessageReceived;
    public event EventHandler<PacketSentEventArgs>? Sent;
    public event EventHandler<EventArgs>? Opened;
    public event EventHandler<EventArgs>? Closed;
    public event EventHandler<ErrorEventArgs>? Error;
    public event EventHandler<EventArgs>? Heartbeat;

    internal readonly SensitiveInfo Info;

    private readonly Dictionary<OperationCode, IOperation> _operations;

    /// <summary>
    /// 下行消息序列号
    /// </summary>
    public long SerialNumber { get; private set; }

    /// <summary>
    /// 心跳间隔
    /// </summary>
    public int HeartbeatInterval
    {
        get => _heartbeatInterval;
        internal set => _heartbeatInterval = value;
    }

    /// <summary>
    /// 当前WebSocket连接地址
    /// </summary>
    public readonly string Url;

    internal Timer? _timer;

    private int _heartbeatInterval;

    internal WebSocketService(SensitiveInfo info, string url)
    {
        if (url is null)
        {
            throw new ArgumentNullException(nameof(url));
        }

        WebSocketClient = new(url);
        WebSocketClient.MessageReceived += async (_, e) => await HandlePacket(e);
        WebSocketClient.MessageReceived += (_, e) => RawMessageReceived?.Invoke(this, e);
        WebSocketClient.Opened += (_, e) => Opened?.Invoke(this, e);
        WebSocketClient.Closed += (_, e) => Closed?.Invoke(this, e);
        WebSocketClient.Error += (_, e) => Error?.Invoke(this, e);

        _operations = new();
        foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
        {
            var attribute = type.GetCustomAttribute<OperationAttribute>();
            if (
                attribute is not null
                && type is not null
                && !_operations.ContainsKey(attribute.Operation)
            )
            {
                _operations.Add(attribute.Operation, (IOperation)Activator.CreateInstance(type)!);
            }
        }
        Info = info;
        Url = url;
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
    internal async Task HandlePacket(MessageReceivedEventArgs e)
    {
        var packet = JsonSerializer.Deserialize<Packet>(e.Message);
        if (packet is not null)
        {
            if (
                _operations.TryGetValue(packet.OperationCode, out IOperation? operation)
                && operation is not null
            )
                await operation.HandleOperationAsync(packet, this);

            if (packet.SerialNumber is not null)
                SerialNumber = packet.SerialNumber.Value;

            BotMessageReceived?.Invoke(this, new(packet.OperationCode, packet.Data, packet.Type));
        }
    }

    /// <summary>
    /// 发送数据包
    /// </summary>
    /// <param name="packet">数据包</param>
    public async Task SendPacket(Packet packet)
    {
        packet.SerialNumber = SerialNumber;
        packet.Type = null;
        await Task.Run(
            () =>
                WebSocketClient.Send(
                    JsonSerializer.Serialize(packet, JsonSerializerOptionsFactory.IgnoreNull)
                )
        );

        Sent?.Invoke(this, new(packet));
    }

    /// <summary>
    /// 启动定时器
    /// </summary>
    public void StartTimer()
    {
        _timer?.Dispose();
        _timer = new(HeartbeatInterval);
        _timer.Elapsed += async (_, _) => await SendHeartbeat();
        _timer.Start();
    }

    private async Task SendHeartbeat()
    {
        await SendPacket(
            new() { OperationCode = OperationCode.Heartbeat, Data = JsonValue.Create(SerialNumber) }
        );
        Heartbeat?.Invoke(this, new());
    }
}
