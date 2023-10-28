using QQBotNet.Core.Models.Business.Guilds;
using QQBotNet.Core.Utils;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace QQBotNet.Core.Services.Apis;

/// <summary>
/// 频道Api
/// </summary>
public static class GuildApi
{
    /// <summary>
    /// 获取频道详情
    /// <br/>
    /// 用于获取 guildId 指定的频道的详情
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/guild/get_guild.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="guildId">频道ID</param>
    /// <returns>Guild对象</returns>
    public static async Task<Guild?> GetGuildAsync(this HttpService httpService, string guildId)
    {
        return await httpService.HttpClient.GetFromJsonAsync<Guild>(
            $"/guilds/{guildId}",
            JsonSerializerOptionsFactory.UnsafeSnakeCase
        );
    }
}
