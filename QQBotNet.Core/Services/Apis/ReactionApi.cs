using QQBotNet.Core.Models.Business.Reactions;
using QQBotNet.Core.Models.Packets.OpenApi;
using QQBotNet.Core.Models.Packets.OpenApi.Body;
using QQBotNet.Core.Utils.Extensions;
using System.Net.Http;
using System.Threading.Tasks;

namespace QQBotNet.Core.Services.Apis;

/// <summary>
/// 表情表态Api
/// </summary>
public static class ReactionApi
{
    /// <summary>
    /// 发表表情表态
    /// <br/>
    /// 对消息进行表情表态
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/reaction/put_message_reaction.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="channelId">子频道ID</param>
    /// <param name="messageId">消息ID</param>
    /// <param name="type">表情类型</param>
    /// <param name="id">表情ID</param>
    public static async Task<HttpPacket> PostReactionAsync(
        this HttpService httpService,
        string channelId,
        string messageId,
        EmojiType type,
        string id
    )
    {
        return await httpService.HttpClient.RequestJsonWithNoResult(
            HttpMethod.Put,
            $"/channels/{channelId.Encode()}/messages/{messageId.Encode()}/reactions/{(int)type}/{id}"
        );
    }

    /// <summary>
    /// 删除自己的表情表态
    /// <br/>
    /// 删除自己对消息的表情表态
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/reaction/delete_own_message_reaction.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="channelId">子频道ID</param>
    /// <param name="messageId">消息ID</param>
    /// <param name="type">表情类型</param>
    /// <param name="id">表情ID</param>
    public static async Task<HttpPacket> DeleteReactionAsync(
        this HttpService httpService,
        string channelId,
        string messageId,
        EmojiType type,
        string id
    )
    {
        return await httpService.HttpClient.RequestJsonWithNoResult(
            HttpMethod.Delete,
            $"/channels/{channelId.Encode()}/messages/{messageId.Encode()}/reactions/{(int)type}/{id}"
        );
    }

    /// <summary>
    /// 拉取表情表态用户列表
    /// <br/>
    /// 拉取对消息指定表情表态的用户列表
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/reaction/get_reaction_users.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="channelId">子频道ID</param>
    /// <param name="messageId">消息ID</param>
    /// <param name="type">表情类型</param>
    /// <param name="id">表情ID</param>
    /// <param name="cookie">上次请求返回的cookie，第一次请求无需填写</param>
    /// <param name="limit">每次拉取数量，默认20，最多50，只在第一次请求时设置</param>
    public static async Task<HttpPacket<ReactionUserList>> GetReactionListAsync(
        this HttpService httpService,
        string channelId,
        string messageId,
        EmojiType type,
        string id,
        string? cookie = null,
        uint limit = 20
    )
    {
        return await httpService.HttpClient.RequestJson<ReactionUserList>(
            HttpMethod.Get,
            string.IsNullOrEmpty(cookie)
                ? $"/channels/{channelId.Encode()}/messages/{messageId.Encode()}/reactions/{(int)type}/{id}?limit={limit}"
                : $"/channels/{channelId.Encode()}/messages/{messageId.Encode()}/reactions/{(int)type}/{id}?cookie={cookie.Encode()}&limit={limit}"
        );
    }
}
