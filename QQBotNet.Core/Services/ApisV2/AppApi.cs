using QQBotNet.Core.Models.Packets.OpenApi;
using QQBotNet.Core.Utils.Json;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace QQBotNet.Core.Services.ApisV2;

/// <summary>
/// 消息Api
/// </summary>
public static class AppApi
{
    /// <summary>
    /// 获取接口凭证
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api-231017/dev-prepare/interface-framework/api-use.html#%E8%8E%B7%E5%8F%96%E6%8E%A5%E5%8F%A3%E5%87%AD%E8%AF%81</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="appId">应用ID</param>
    /// <param name="clientSecret">密钥</param>
    /// <returns>应用接口凭证</returns>
    public static async Task<AppAccessToken?> GetAppAccessTokenAsync(
        this HttpService httpService,
        string? appId = null,
        string? clientSecret = null
    )
    {
        using var httpClient = new HttpClient();
        var response = await httpClient.PostAsJsonAsync(
            "https://bots.qq.com/app/getAppAccessToken",
            new JsonObject
            {
                { "appId", appId ?? httpService.Instance.BotAppId.ToString() },
                {
                    "clientSecret",
                    clientSecret
                        ?? httpService.Instance.AppSecret
                        ?? throw new InvalidOperationException("机器人密钥未提供")
                }
            }
        );
        return await response.Content.ReadFromJsonAsync<AppAccessToken>(
            JsonSerializerOptionsFactory.UnsafeSnakeCase
        );
    }
}
