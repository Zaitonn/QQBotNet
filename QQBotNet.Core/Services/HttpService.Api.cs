using QQBotNet.Core.Constants;
using QQBotNet.Core.Entity.Back;
using QQBotNet.Core.Entity.Send;
using QQBotNet.Core.Utils;
using QQBotNet.Core.Utils.Extensions;
using System;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace QQBotNet.Core.Services;

public sealed partial class HttpService : IBotService
{
    /// <summary>
    /// 获取接口凭证
    /// </summary>
    public async Task<string> GetAppAccessToken()
    {
        string response = await (
            await AuthenticationHttpClient.PostJsonAsync(
                Urls.AccessTokenUrl,
                new Authentication
                {
                    AppId = _instance.BotAppId,
                    ClientSecret = _instance.BotSecret
                },
                JsonSerializerOptionsFactory.CamelCase
            )
        ).Content.ReadAsStringAsync();

        if (string.IsNullOrEmpty(response))
            throw new NullReferenceException($"Empty response in {nameof(GetAppAccessToken)}");

        var result =
            JsonSerializer.Deserialize<AuthenticationResult>(
                response,
                JsonSerializerOptionsFactory.SnakeCase
            ) ?? throw new NullReferenceException($"Empty response in {nameof(GetAppAccessToken)}");

        AccessToken = result.AccessToken;
        InterfaceHttpClient.DefaultRequestHeaders.Authorization = new("QQBot", AccessToken);
        return result.AccessToken;
    }

    /// <summary>
    /// 获取通用 WSS 接入点
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/wss/url_get.html</see>
    /// </summary>
    /// <returns>WSS 接入地址</returns>
    public async Task<string> GetWebSocketUrl()
    {
        var url = await InterfaceHttpClient.GetFromJsonAsync<WebSocketUrl>(
            "/gateway",
            JsonSerializerOptionsFactory.CamelCase
        );

        if (string.IsNullOrEmpty(url?.Url))
            throw new NullReferenceException("Empty url");

        return url!.Url;
    }
}
