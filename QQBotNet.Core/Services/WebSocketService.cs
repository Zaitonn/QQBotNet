using QQBotNet.Core.Entity;
using QQBotNet.Core.Entity.Back;
using QQBotNet.Core.Entity.WebSockets;
using QQBotNet.Core.Services.Operations;
using QQBotNet.Core.Utils;
using WebSocket4Net;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Timers;
using System.Reflection;

namespace QQBotNet.Core.Services;

public sealed class WebSocketService : IBotService
{
    public readonly WebSocket WebSocketClient;

    private readonly Dictionary<OperationCode, IOperation> _operations;

    /// <summary>
    /// 下行消息序列号
    /// </summary>
    public long SerialNumber { get; private set; }

    /// <summary>
    /// 心跳间隔
    /// </summary>
    public int HeartbeatInterval { get; internal set; }

    /// <summary>
    /// 会话信息
    /// </summary>
    public Session? Session;

    private readonly BotInstance _instance;

    /// <summary>
    /// 当前WebSocket连接地址
    /// </summary>
    public readonly string Url;

    internal Timer? _timer;

    internal WebSocketService(BotInstance instance, string url)
    {
        if (url is null)
        {
            throw new ArgumentNullException(nameof(url));
        }

        _instance = instance;
        Url = url;

        WebSocketClient = new(url);

        WebSocketClient.Opened += (_, e) => _instance.Invoker.OnWebSocketOpened();
        WebSocketClient.Closed += (_, e) => _instance.Invoker.OnWebSocketClosed();
        WebSocketClient.Error += (_, e) => _instance.Invoker.OnWebSocketError(e);
        WebSocketClient.MessageReceived += async (_, e) => await HandlePacket(e);
        WebSocketClient.MessageReceived += (_, e) =>
            _instance.Invoker.OnWebSocketRawMessageReceived(e);

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

    private async Task HandlePacket(MessageReceivedEventArgs e)
    {
        var packet = JsonSerializer.Deserialize<Packet>(e.Message);
        if (packet is not null)
        {
            if (
                _operations.TryGetValue(packet.OperationCode, out IOperation? operation)
                && operation is not null
            )
                await operation.HandleOperationAsync(packet, _instance);

            if (packet.SerialNumber is not null)
                SerialNumber = packet.SerialNumber.Value;

            _instance.Invoker.OnPacketReceived(new(packet));
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

        _instance.Invoker.OnPacketSent(new(packet));
    }

    /// <summary>
    /// 设置会话
    /// </summary>
    /// <param name="session">会话对象</param>
    internal void SetSession(Session? session)
    {
        Session = session;
    }

    /// <summary>
    /// 启动定时器
    /// </summary>
    internal void StartTimer()
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
        _instance.Invoker.OnHeartbeat();
    }
}
