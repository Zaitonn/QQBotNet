using QQBotNet.Core.Models.Packets.OpenApi;
using QQBotNet.Core.Utils;
using System;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace QQBotNet.Core.Services.Apis;

/// <summary>
/// WebSocket Api
/// </summary>
public static class WssApi
{
    /// <summary>
    /// 获取通用 WSS 接入点
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/wss/url_get.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <returns>WSS 接入地址</returns>
    public static async Task<string?> GetWebSocketUrl(this HttpService httpService)
    {
        var url = await httpService.HttpClient.GetFromJsonAsync<WebSocketUrl>(
            "/gateway",
            JsonSerializerOptionsFactory.UnsafeSnakeCase
        );

        return url?.Url;
    }
}
