using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using QQBotNet.OneBot.Models.Config;
using QQBotNet.OneBot.Utils;
using WatsonWebsocket;

namespace QQBotNet.OneBot.Network;

public sealed class ForwardWSService : IOneBotService
{
    private readonly WatsonWsServer _websocketServer;
    private readonly Connection _connection;

    public event EventHandler<MsgRecvEventArgs>? OnMessageReceived;

    public ForwardWSService(uint botAppId, Connection connection)
    {
        _connection = connection;
        _websocketServer = new(new(_connection.Address));

        _websocketServer.ClientConnected += OnClientConnected;
        _websocketServer.ClientDisconnected += (_, e) =>
            Logger.Info<ForwardWSService>(
                $"{e.Client.IpPort} 从正向WebSocket（{_connection.Address}）断开"
            );
        _websocketServer.ServerStopped += (_, _) =>
            Logger.Info<ForwardWSService>($"正向WebSocket（{_connection.Address}）服务器已关闭");
        _websocketServer.MessageReceived += (_, e) =>
        {
            var message = Encoding.UTF8.GetString(e.Data);
            Logger.Debug<ForwardWSService>($"收到信息: {message}");
            OnMessageReceived?.Invoke(this, new(message));
        };
    }

    public void OnClientConnected(object? sender, ConnectionEventArgs e)
    {
        if (
            !string.IsNullOrEmpty(_connection.Authorization)
            && e.HttpRequest.Headers["Authorization"] != _connection.Authorization
            && e.HttpRequest.Headers["Authorization"] != $"Bearer {_connection.Authorization}"
        )
        {
            _websocketServer.DisconnectClient(e.Client.Guid);
            Logger.Warn<ForwardWSService>(
                $"{e.Client.IpPort} 尝试连接正向WebSocket（{_connection.Address}）失败：缺少\"Authorization\"头或不匹配"
            );
        }
        else
            Logger.Info<ForwardWSService>(
                $"{e.Client.IpPort} 连接到正向WebSocket（{_connection.Address}）"
            );
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        try
        {
            await _websocketServer.StartAsync(cancellationToken);
            Logger.Info<ForwardWSService>($"正向WebSocket（{_connection.Address}）服务器启动成功");
        }
        catch (Exception e)
        {
            Logger.Warn<ForwardWSService>($"正向WebSocket（{_connection.Address}）服务器启动失败：{e.Message}");
            Logger.Debug<ForwardWSService>($"正向WebSocket（{_connection.Address}）服务器启动失败：{e}");
        }
    }

    public Task StopAsync()
    {
        _websocketServer.Stop();
        return Task.CompletedTask;
    }

    public Task SendJsonAsync(string json, CancellationToken cancellationToken = default)
    {
        var clients = _websocketServer.ListClients();
        clients
            .ToList()
            .ForEach(
                async (client) =>
                    await _websocketServer.SendAsync(client.Guid, json, token: cancellationToken)
            );

        return Task.CompletedTask;
    }
}
