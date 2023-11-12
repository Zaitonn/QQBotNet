using QQBotNet.Core.Models.Packets.WebSockets;
using QQBotNet.Core.Services.Operations;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Timers;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Text.Encodings.Web;
using WatsonWebsocket;

namespace QQBotNet.Core.Services;

/// <summary>
/// WebSocket服务
/// </summary>
public sealed class WebSocketService
{
    private readonly WatsonWsClient _webSocketClient;

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
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

    /// <summary>
    /// 当前WebSocket连接地址
    /// </summary>
    public string Url { get; init; }

    /// <summary>
    /// WebSocket连接状态
    /// </summary>
    public bool IsConnected => _webSocketClient.Connected;

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

        _webSocketClient = new(new(url));

        _webSocketClient.ServerConnected += (_, _) => _reconnectTimer?.Start();
        _webSocketClient.ServerConnected += (_, _) => _instance.EventDispatcher.OnWebSocketOpened();
        _webSocketClient.ServerDisconnected += (_, _) =>
            _instance.EventDispatcher.OnWebSocketClosed();
        _webSocketClient.MessageReceived += async (_, e) => await HandlePacket(e);
        _webSocketClient.MessageReceived += (_, e) =>
            _instance.EventDispatcher.OnWebSocketRawMessageReceived(e);

        _operations = new();

        foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
        {
            var attribute = type.GetCustomAttribute<OperationHandlerAttribute>();
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
    public void Start() => _webSocketClient.Start();

    /// <summary>
    /// 关闭WebSocket连接
    /// </summary>
    public void Stop()
    {
        SerialNumber = 0;
        HeartbeatInterval = 0;
        Session = null;
        _webSocketClient?.Stop();
        _reconnectTimer?.Stop();
    }

    private async Task HandlePacket(MessageReceivedEventArgs e)
    {
        var packet = JsonSerializer.Deserialize<Packet>(e.Data);
        if (packet is not null)
        {
            if (
                _operations.TryGetValue(packet.OperationCode, out IOperation? operation)
                && operation is not null
            )
                try
                {
                    await operation.HandleOperationAsync(_instance, packet);
                }
                catch (Exception ex)
                {
                    _instance.EventDispatcher.OnException(ex);
                }

            if (packet.SerialNumber is not null)
                SerialNumber = packet.SerialNumber.Value;

            try
            {
                _instance.EventDispatcher.OnPacketReceived(new(packet));
            }
            catch (Exception ex)
            {
                _instance.EventDispatcher.OnException(ex);
            }
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

        var _packet = new Packet
        {
            SerialNumber = SerialNumber,
            Type = null,
            Data = packet.Data,
            Id = packet.Id,
            OperationCode = packet.OperationCode,
        };

        try
        {
            await _webSocketClient.SendAsync(
                JsonSerializer.Serialize(_packet, _packetJsonSerializerOptions)
            );
            _instance.EventDispatcher.OnPacketSent(new(_packet));
        }
        catch (Exception e)
        {
            _instance.EventDispatcher.OnException(e);
        }
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
        _instance.EventDispatcher.OnHeartbeat();
    }

    private void TryReconnect()
    {
        if (Session == null || IsConnected)
        {
            return;
        }

        _webSocketClient.Start();
        _instance.EventDispatcher.OnWebSocketReconnect();
    }
}
