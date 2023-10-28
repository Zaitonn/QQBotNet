using QQBotNet.Core.Models.Business;
using QQBotNet.Core.Models.Business.Guilds;
using QQBotNet.Core.Utils;
using QQBotNet.Core.Utils.Extensions;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace QQBotNet.Core.Services.Apis;

/// <summary>
/// 用户Api
/// </summary>
public static class UsersApi
{
    /// <summary>
    /// 获取用户详情
    /// <br/>
    /// 用于获取当前用户（机器人）详情
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/user/me.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <returns><see cref="User"/>对象</returns>
    public static async Task<User?> GetCurrentUserAsync(this HttpService httpService)
    {
        return await (
            await httpService.HttpClient.SendAsync(
                new(HttpMethod.Get, "/users/@me")
                {
                    Content = new StringContent(string.Empty).WithJsonHeader()
                }
            )
        ).Content.ReadFromJsonAsync<User>(JsonSerializerOptionsFactory.UnsafeSnakeCase);
    }

    /// <summary>
    /// 获取用户频道列表
    /// <br/>
    /// 用于获取当前用户（机器人）所加入的频道列表，支持分页
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/user/guilds.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="beforeGuildId">读此 guild id 之前的数据</param>
    /// <param name="limit">每次拉取多少条数据（最大100）</param>
    /// <returns><see cref="Guild"/>数组</returns>
    public static async Task<Guild[]?> GetCurrentUserGuildsBeforeAsync(
        this HttpService httpService,
        string beforeGuildId,
        int limit = 100
    )
    {
        return await (
            await httpService.HttpClient.SendAsync(
                new(
                    HttpMethod.Get,
                    $"/users/@me/guilds?before={beforeGuildId.Encode()}&limit={limit}"
                )
                {
                    Content = new StringContent(string.Empty).WithJsonHeader()
                }
            )
        ).Content.ReadFromJsonAsync<Guild[]>(JsonSerializerOptionsFactory.UnsafeSnakeCase);
    }

    /// <summary>
    /// 获取用户频道列表
    /// <br/>
    /// 用于获取当前用户（机器人）所加入的频道列表，支持分页
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/user/guilds.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="afterGuildId">读此 guild id 之后的数据</param>
    /// <param name="limit">每次拉取多少条数据（最大100）</param>
    /// <returns><see cref="Guild"/>数组</returns>
    public static async Task<Guild[]?> GetCurrentUserGuildsAfterAsync(
        this HttpService httpService,
        string afterGuildId,
        int limit = 100
    )
    {
        return await (
            await httpService.HttpClient.SendAsync(
                new(
                    HttpMethod.Get,
                    $"/users/@me/guilds?after={afterGuildId.Encode()}&limit={limit}"
                )
                {
                    Content = new StringContent(string.Empty).WithJsonHeader()
                }
            )
        ).Content.ReadFromJsonAsync<Guild[]>(JsonSerializerOptionsFactory.UnsafeSnakeCase);
    }
}
