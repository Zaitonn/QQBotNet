using QQBotNet.Core.Services.ApisV2;
using QQBotNet.Core.Utils.Extensions;
using System;
using System.Net.Http;

namespace QQBotNet.Core.Services;

/// <summary>
/// Http服务
/// </summary>
public sealed class HttpService : IDisposable
{
    internal HttpService(BotInstance instance)
    {
        Instance = instance;

        _httpClient = new()
        {
            BaseAddress = new($"https://{(instance.IsSandbox ? Constants.SandboxSite : Constants.Site)}")
        };
        _httpClient.DefaultRequestHeaders.Clear();

        _useV2AppAccessToken = !string.IsNullOrEmpty(instance.AppSecret);

        _httpClient.DefaultRequestHeaders.Add("X-Union-Appid", instance.BotAppId.ToString());

        if (_useV2AppAccessToken)
            UpdateAppAccessToken();
        else
            _httpClient.DefaultRequestHeaders.Authorization = new(
                "Bot",
                $"{instance.BotAppId}.{instance.BotToken}"
            );
    }

    private readonly HttpClient _httpClient;

    private readonly bool _useV2AppAccessToken;

    internal readonly BotInstance Instance;

    private string? _appAccessToken;

    private int _expireTime = 7200;

    /// <summary>
    /// 应用凭证创建时间
    /// </summary>
    public DateTime AppAccessTokenCreatedTime { get; private set; }

    /// <summary>
    /// 应用凭证
    /// </summary>
    public string? AppAccessToken
    {
        get
        {
            UpdateAppAccessToken();
            return _appAccessToken;
        }
    }

    /// <summary>
    /// Http客户端（已设置BaseAddress）
    /// </summary>
    public HttpClient HttpClient
    {
        get
        {
            if (_useV2AppAccessToken)
                UpdateAppAccessToken();

            return _httpClient;
        }
    }

    /// <summary>
    /// 更新应用凭证
    /// </summary>
    public void UpdateAppAccessToken()
    {
        if (
            !string.IsNullOrEmpty(_appAccessToken)
            && (DateTime.Now - AppAccessTokenCreatedTime).TotalSeconds < _expireTime - 30
        )
            return;

        var result = this.GetAppAccessTokenAsync().WaitResult();

        _appAccessToken = result?.AccessToken ?? throw new NullReferenceException();
        _expireTime = result?.ExpiresIn ?? 7200;
        AppAccessTokenCreatedTime = DateTime.Now;

        HttpClient.DefaultRequestHeaders.Authorization = new("QQBot", _appAccessToken);
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public void Dispose()
    {
        HttpClient.Dispose();
    }
}
