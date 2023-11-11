using QQBotNet.Core.Utils.Json;
using QQBotNet.OneBot.Models.Config;
using QQBotNet.OneBot.Models.Meta;
using QQBotNet.OneBot.Utils;
using System;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Timer = System.Timers.Timer;
using WatsonWebsocket;

namespace QQBotNet.OneBot.Network;

public sealed class ReverseWSService : OneBotServiceBase, IOneBotService
{
    public event EventHandler<MsgRecvEventArgs>? OnMessageReceived;

    private readonly WatsonWsClient _websocketClient;

    private readonly Timer _heatbeatTimer;

    private readonly Timer _reconnectTimer;

    private readonly string _url;

    public ReverseWSService(uint botAppId, Connection connection)
    {
        _url = connection.Address;
        _websocketClient = new(new(_url));
        _websocketClient.ConfigureOptions(
            (options) =>
            {
                options.SetRequestHeader("X-Client-Role", "Universal");
                options.SetRequestHeader("X-Self-ID", botAppId.ToString());

                if (!string.IsNullOrEmpty(connection.Authorization))
                    options.SetRequestHeader("Authorization", $"Bearer {connection.Authorization}");
            }
        );

        _heatbeatTimer = new(5_000) { Enabled = true };
        _heatbeatTimer.Elapsed += (_, _) => OnHeartbeat();

        _reconnectTimer = new(15_000) { Enabled = true };
        _reconnectTimer.Elapsed += async (_, _) => await StartAsync(CancellationToken.None);

        _websocketClient.MessageReceived += (_, e) =>
        {
            var message = Encoding.UTF8.GetString(e.Data);
            Logger.Debug<ReverseWSService>($"收到信息: {message}");
            OnMessageReceived?.Invoke(this, new(message));
        };

        _websocketClient.ServerConnected += (_, _) =>
            Logger.Info<ReverseWSService>($"反向WebSocket（{_url}）已连接");
        _websocketClient.ServerDisconnected += (_, _) =>
            Logger.Warn<ReverseWSService>($"反向WebSocket（{_url}）已断开");
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        if (_websocketClient.Connected)
            return;

        try
        {
            if (!await _websocketClient.StartWithTimeoutAsync(10, cancellationToken))
                throw new InvalidOperationException("连接超时");
        }
        catch (Exception e)
        {
            Logger.Warn<ReverseWSService>($"反向WebSocket（{_url}）连接失败：{e.Message}");
            Logger.Debug<ReverseWSService>($"反向WebSocket（{_url}）连接失败：\n{e}");
            return;
        }

        var lifecycle = new OneBotLifecycle(BotAppId, "connect");
        await SendJsonAsync(lifecycle, CancellationToken.None);
    }

    public Task StopAsync()
    {
        _heatbeatTimer.Dispose();
        _websocketClient.Dispose();

        return Task.CompletedTask;
    }

    public Task SendJsonAsync<T>(T json, CancellationToken cancellationToken)
    {
        if (_websocketClient.Connected)
            _websocketClient.SendAsync(
                JsonSerializer.Serialize(json, JsonSerializerOptionsFactory.UnsafeSnakeCase),
                WebSocketMessageType.Text,
                cancellationToken
            );

        return Task.CompletedTask;
    }

    private void OnHeartbeat()
    {
        var status = new OneBotStatus(true, true);
        var heartBeat = new OneBotHeartBeat(BotAppId, 5000, status);

        SendJsonAsync(heartBeat, CancellationToken.None);
    }
}
