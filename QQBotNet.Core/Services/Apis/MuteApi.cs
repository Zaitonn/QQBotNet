using QQBotNet.Core.Models.Packets.OpenApi;
using QQBotNet.Core.Utils;
using QQBotNet.Core.Utils.Extensions;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace QQBotNet.Core.Services.Apis;

/// <summary>
/// 禁言Api
/// </summary>
public static class MuteApi
{
    /// <summary>
    /// 禁言全员/禁言批量成员
    /// <br/>
    /// 将频道的全体成员（非管理员）禁言/将频道的指定批量成员（非管理员）禁言
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/guild/patch_guild_mute.html</see>
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/guild/patch_guild_mute_multi_member.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="guildId">频道ID</param>
    /// <param name="muteSeconds">禁言时长</param>
    /// <param name="muteEndTimestamp">禁言到期时间戳，绝对时间戳</param>
    /// <param name="userIds">禁言成员的user.id列表</param>
    public static async Task<HttpPacket> MuteAsync(
        this HttpService httpService,
        string guildId,
        ulong? muteEndTimestamp = null,
        ulong? muteSeconds = null,
        string[]? userIds = null
    )
    {
        return await httpService.HttpClient.RequestJsonWithNoResult(
            HttpMethodEx.Patch,
            $"/guilds/{guildId.Encode()}/mute",
            new JsonObject
            {
                { "mute_end_timestamp", muteEndTimestamp?.ToString() },
                { "mute_seconds", muteSeconds?.ToString() },
                { "user_ids", JsonSerializer.SerializeToNode(userIds) }
            },
            true
        );
    }

    /// <summary>
    /// 禁言指定成员
    /// <br/>
    /// 禁言频道下的成员
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/guild/patch_guild_member_mute.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="guildId">频道ID</param>
    /// <param name="userId">用户ID</param>
    /// <param name="muteEndTimestamp">禁言到期时间戳，绝对时间戳</param>
    /// <param name="muteSeconds">禁言时长</param>
    public static async Task<HttpPacket> MuteUserAsync(
        this HttpService httpService,
        string guildId,
        string userId,
        ulong? muteEndTimestamp = null,
        ulong? muteSeconds = null
    )
    {
        return await httpService.HttpClient.RequestJsonWithNoResult(
            HttpMethodEx.Patch,
            $"/guilds/{guildId.Encode()}/members/{userId.Encode()}/mute",
            new JsonObject
            {
                { "mute_end_timestamp", muteEndTimestamp?.ToString() },
                { "mute_seconds", muteSeconds?.ToString() }
            },
            true
        );
    }
}
