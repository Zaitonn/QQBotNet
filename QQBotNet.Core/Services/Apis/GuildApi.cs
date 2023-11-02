using QQBotNet.Core.Models.Business.Guilds;
using QQBotNet.Core.Models.Packets.OpenApi;
using QQBotNet.Core.Utils.Extensions;
using System.Net.Http;
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
    /// 获取指定的频道的详情
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/guild/get_guild.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="guildId">频道ID</param>
    /// <returns>Guild对象</returns>
    public static async Task<HttpPacket<Guild>> GetGuildAsync(
        this HttpService httpService,
        string guildId
    )
    {
        return await httpService.HttpClient.RequestJson<Guild>(
            HttpMethod.Get,
            $"/guilds/{guildId.Encode()}"
        );
    }
}
