using QQBotNet.Core.Utils;
using QQBotNet.OneBot.Models.Config;
using QQBotNet.OneBot.Models.Meta;
using QQBotNet.OneBot.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WebSocket4Net;
using Timer = System.Threading.Timer;

namespace QQBotNet.OneBot.Network;

public sealed class ReverseWSService : OneBotServiceBase, IOneBotService
{
    public event EventHandler<MsgRecvEventArgs>? OnMessageReceived;

    private readonly WebSocket _websocket;

    private readonly Timer _timer;

    public ReverseWSService(uint botAppId, Connection connection)
    {
        var headers = new Dictionary<string, string>
        {
            { "X-Client-Role", "Universal" },
            { "X-Self-ID", botAppId.ToString() }
        };

        if (!string.IsNullOrEmpty(connection.Authorization))
            headers.Add("Authorization", $"Bearer {connection.Authorization}");

        _websocket = new(
            connection.Address,
            customHeaderItems: headers.ToList(),
            userAgent: Constants.UserAgent
        );

        _timer = new(OnHeartbeat, null, int.MaxValue, 5000);
        _websocket.MessageReceived += (_, e) =>
        {
            Logger.Debug<ReverseWSService>($"收到信息: {e.Message}");
            OnMessageReceived?.Invoke(this, new(e.Message ?? ""));
        };
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await _websocket.OpenAsync();

        var lifecycle = new OneBotLifecycle(BotAppId, "connect");
        await SendJsonAsync(lifecycle, cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer.Dispose();
        _websocket.Dispose();

        return Task.CompletedTask;
    }

    public Task SendJsonAsync<T>(T json, CancellationToken cancellationToken)
    {
        _websocket.Send(
            JsonSerializer.Serialize(json, JsonSerializerOptionsFactory.UnsafeSnakeCase)
        );
        return Task.CompletedTask;
    }

    private void OnHeartbeat(object? sender)
    {
        var status = new OneBotStatus(true, true);
        var heartBeat = new OneBotHeartBeat(BotAppId, 5000, status);

        SendJsonAsync(heartBeat, CancellationToken.None);
    }
}
