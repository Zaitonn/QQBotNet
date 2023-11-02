using QQBotNet.Core.Models.Business.Announcement;
using QQBotNet.Core.Models.Packets.OpenApi;
using QQBotNet.Core.Utils.Json;
using QQBotNet.Core.Utils.Extensions;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace QQBotNet.Core.Services.Apis;

/// <summary>
/// 公告Api
/// </summary>
public static class AnnouncesApi
{
    /// <summary>
    /// 创建频道公告
    /// <br/>
    /// 创建频道全局公告
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/announces/post_guild_announces.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="guildId">频道ID</param>
    /// <param name="messageId">消息id，有值则优选将某条消息设置为成员公告</param>
    /// <param name="channelId">子频道id，messageId有值则为必填</param>
    /// <param name="announcesType">公告类别</param>
    /// <param name="recommendChannels">推荐子频道列表，会一次全部替换推荐子频道列表</param>
    /// <returns>Announces对象</returns>
    public static async Task<HttpPacket<Announces>> CreateAnnouncesAsync(
        this HttpService httpService,
        string guildId,
        string? messageId = null,
        string? channelId = null,
        AnnouncesType? announcesType = null,
        RecommendChannel[]? recommendChannels = null
    )
    {
        return await httpService.HttpClient.RequestJson<Announces>(
            HttpMethod.Post,
            $"/guilds/{guildId.Encode()}/announces",
            new JsonObject
            {
                { "message_id", messageId },
                { "channel_id", channelId },
                { "announces_type", (int?)announcesType },
                {
                    "recommend_channels",
                    JsonSerializer.SerializeToNode(
                        recommendChannels,
                        JsonSerializerOptionsFactory.UnsafeSnakeCase
                    )
                },
            },
            true
        );
    }

    /// <summary>
    /// 删除频道公告
    /// <br/>
    /// 删除频道下指定的全局公告
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/announces/delete_guild_announces.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="guildId">频道ID</param>
    /// <param name="messageId">消息id</param>
    public static async Task<HttpPacket> DeleteAnnouncesAsync(
        this HttpService httpService,
        string guildId,
        string messageId = "all"
    )
    {
        return await httpService.HttpClient.RequestJsonWithNoResult(
            HttpMethod.Post,
            $"/guilds/{guildId.Encode()}/announces/{messageId.Encode()}"
        );
    }
}
