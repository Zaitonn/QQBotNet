using QQBotNet.Core.Models.Packets.OpenApi;
using QQBotNet.Core.Models.Packets.OpenApi.Body;
using QQBotNet.Core.Utils.Extensions;
using System.Net.Http;
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
    public static async Task<HttpPacket<WebSocketUrl>> GetWebSocketUrlAsync(
        this HttpService httpService
    )
    {
        return await httpService.HttpClient.RequestJson<WebSocketUrl>(HttpMethod.Get, "/gateway");
    }
}
