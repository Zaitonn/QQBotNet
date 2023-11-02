using System;
using System.Net.Http;

namespace QQBotNet.Core.Services;

/// <summary>
/// Http服务
/// </summary>
public sealed class HttpService : IDisposable
{
    /// <summary>
    /// Http客户端（已设置BaseAddress）
    /// </summary>
    public readonly HttpClient HttpClient;

    internal HttpService(BotInstance instance, bool isSandbox)
    {
        HttpClient = new()
        {
            BaseAddress = new($"https://{(isSandbox ? Constants.SandboxSite : Constants.Site)}")
        };
        HttpClient.DefaultRequestHeaders.Clear();
        HttpClient.DefaultRequestHeaders.Authorization = new(
            "Bot",
            $"{instance.BotAppId}.{instance.BotToken}"
        );
        HttpClient.DefaultRequestHeaders.Add("X-Union-Appid", instance.BotAppId.ToString());
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public void Dispose()
    {
        HttpClient.Dispose();
    }
}
