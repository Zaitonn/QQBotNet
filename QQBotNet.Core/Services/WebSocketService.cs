using QQBotNet.Core.Models.Packets.WebSockets;
using QQBotNet.Core.Services.Operations;
using WebSocket4Net;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Timers;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Text.Encodings.Web;

namespace QQBotNet.Core.Services;

/// <summary>
/// WebSocket服务
/// </summary>
public sealed class WebSocketService
{
    private readonly WebSocket _webSocketClient;

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
    public Session? Session { get; internal set; }

    private readonly BotInstance _instance;

    private static readonly JsonSerializerOptions _packetJsonSerializerOptions =
        new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

    /// <summary>
    /// 当前WebSocket连接地址
    /// </summary>
    public readonly string Url;

    private Timer? _reconnectTimer;

    private Timer? _heartbeatTimer;

    private bool _disposed;

    internal WebSocketService(BotInstance instance, string url)
    {
        if (url is null)
        {
            throw new ArgumentNullException(nameof(url));
        }

        _instance = instance;
        Url = url;

        _webSocketClient = new(url);

        _webSocketClient.Opened += (_, _) => _instance.Invoker.OnWebSocketOpened();
        _webSocketClient.Closed += (_, _) => _instance.Invoker.OnWebSocketClosed();
        _webSocketClient.Error += (_, e) => _instance.Invoker.OnWebSocketError(e);
        _webSocketClient.MessageReceived += async (_, e) => await HandlePacket(e);
        _webSocketClient.MessageReceived += (_, e) =>
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

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public void Dispose()
    {
        _webSocketClient.Dispose();
        _heartbeatTimer?.Dispose();
        _reconnectTimer?.Dispose();
        Session = null;
        _disposed = true;
    }

    /// <summary>
    /// 启动WebSocket连接
    /// </summary>
    public void Start() => _webSocketClient.Open();

    /// <summary>
    /// 关闭WebSocket连接
    /// </summary>
    public void Stop()
    {
        _webSocketClient.Close();
        _reconnectTimer?.Close();
        Session = null;
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
        if (_disposed)
            return;

        packet.SerialNumber = SerialNumber;
        packet.Type = null;
        await Task.Run(
            () =>
                _webSocketClient.Send(
                    JsonSerializer.Serialize(packet, _packetJsonSerializerOptions)
                )
        );

        _instance.Invoker.OnPacketSent(new(packet));
    }

    /// <summary>
    /// 启动定时器
    /// </summary>
    internal void StartTimer()
    {
        _heartbeatTimer?.Dispose();
        _heartbeatTimer = new(HeartbeatInterval);
        _heartbeatTimer.Elapsed += async (_, _) => await SendHeartbeat();
        _heartbeatTimer.Start();

        _reconnectTimer?.Dispose();
        _reconnectTimer = new(10000);
        _reconnectTimer.Elapsed += (_, _) => TryReconnect();
        _reconnectTimer.Start();
    }

    private async Task SendHeartbeat()
    {
        await SendPacket(
            new() { OperationCode = OperationCode.Heartbeat, Data = JsonValue.Create(SerialNumber) }
        );
        _instance.Invoker.OnHeartbeat();
    }

    private void TryReconnect()
    {
        if (Session == null || _webSocketClient.State != WebSocketState.Closed)
        {
            return;
        }

        _webSocketClient.Open();
        _instance.Invoker.OnWebSocketReconnect();
    }
}
