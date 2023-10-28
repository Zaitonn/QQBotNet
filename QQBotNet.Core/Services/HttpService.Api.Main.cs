using QQBotNet.Core.Models.Packets.OpenApi;
using QQBotNet.Core.Utils;
using System;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace QQBotNet.Core.Services;

public sealed partial class HttpService
{
    /// <summary>
    /// 获取通用 WSS 接入点
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/wss/url_get.html</see>
    /// </summary>
    /// <returns>WSS 接入地址</returns>
    public async Task<string> GetWebSocketUrl()
    {
        var url = await _httpClient.GetFromJsonAsync<WebSocketUrl>(
            "/gateway",
            JsonSerializerOptionsFactory.UnsafeSnakeCase
        );

        if (string.IsNullOrEmpty(url?.Url))
            throw new NullReferenceException("Empty url");

        return url!.Url;
    }
}
