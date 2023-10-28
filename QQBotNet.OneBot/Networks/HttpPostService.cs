using QQBotNet.Core.Utils;
using QQBotNet.OneBot.Models.Config;
using QQBotNet.OneBot.Models.Meta;
using QQBotNet.OneBot.Utils;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace QQBotNet.OneBot.Network;

public sealed class HttpPostService : OneBotServiceBase, IOneBotService
{
#pragma warning disable CS0067
    public event EventHandler<MsgRecvEventArgs>? OnMessageReceived;
#pragma warning restore CS0067

    private readonly HttpClient _httpClient;

    public HttpPostService(uint botAppId, Connection connection)
    {
        BotAppId = botAppId;
        _httpClient = new HttpClient { BaseAddress = new(connection.Address) };
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "QQBotNet");

        if (!string.IsNullOrEmpty(connection.Authorization))
            _httpClient.DefaultRequestHeaders.Authorization = new(
                "Bearer",
                connection.Authorization
            );
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var lifecycle = new OneBotLifecycle(BotAppId, "enable");
        await SendJsonAsync(lifecycle, cancellationToken);
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        var lifecycle = new OneBotLifecycle(BotAppId, "disable");
        await SendJsonAsync(lifecycle, cancellationToken);
    }

    public async Task SendJsonAsync<T>(T json, CancellationToken cancellationToken)
    {
        string payload = JsonSerializer.Serialize(
            json,
            JsonSerializerOptionsFactory.UnsafeSnakeCase
        );
        try
        {
            await _httpClient.PostAsync(
                string.Empty,
                new StringContent(payload, Encoding.UTF8),
                cancellationToken
            );
        }
        catch (Exception e)
        {
            Logger.Warn<HttpPostService>($"Post请求失败 {e}");
        }
    }
}
