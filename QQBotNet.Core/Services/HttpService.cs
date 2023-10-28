using System;
using System.Net.Http;

namespace QQBotNet.Core.Services;

/// <summary>
/// Http服务
/// </summary>
public sealed class HttpService : IDisposable
{
    internal readonly HttpClient HttpClient;

    private readonly BotInstance _instance;

    internal HttpService(BotInstance instance, bool isSandbox)
    {
        _instance = instance;
        HttpClient = new()
        {
            BaseAddress = new($"https://{(isSandbox ? Constants.SandboxSite : Constants.Site)}")
        };
        HttpClient.DefaultRequestHeaders.Clear();
        HttpClient.DefaultRequestHeaders.Authorization = new(
            "Bot",
            $"{_instance.BotAppId}.{_instance.BotToken}"
        );
        HttpClient.DefaultRequestHeaders.Add("X-Union-Appid", _instance.BotAppId.ToString());
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public void Dispose()
    {
        HttpClient.Dispose();
    }
}
