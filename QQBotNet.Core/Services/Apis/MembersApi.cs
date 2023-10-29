using QQBotNet.Core.Models.Business;
using QQBotNet.Core.Models.Packets.OpenApi;
using QQBotNet.Core.Models.Packets.OpenApi.Body;
using QQBotNet.Core.Utils.Extensions;
using System.Net.Http;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace QQBotNet.Core.Services.Apis;

/// <summary>
/// 成员Api
/// </summary>
public static class MembersApi
{
    /// <summary>
    /// 获取频道成员列表（仅私域机器人可用）
    /// <br/>
    /// 获取指定的频道中所有成员的详情列表，支持分页
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/member/get_members.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="guildId">频道ID</param>
    /// <param name="after">上一次回包中最后一个<see cref="Member"/>的<see cref="Member.User"/>的Id</param>
    /// <param name="limit">分页大小</param>
    /// <returns>Guild对象</returns>
    public static async Task<HttpPacket<Member[]>> GetGuildMembersAsync(
        this HttpService httpService,
        string guildId,
        string after = "0",
        uint limit = 1
    )
    {
        return await httpService.HttpClient.RequestJson<Member[]>(
            HttpMethod.Get,
            $"/guilds/{guildId.Encode()}/members?after={after.Encode()}&limit={limit}"
        );
    }

    /// <summary>
    /// 获取频道身份组成员列表（仅私域机器人可用）
    /// <br/>
    /// 获取频道中指定身份组下所有成员的详情列表，支持分页
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/member/get_role_members.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="guildId">频道Id</param>
    /// <param name="roleId">身份组Id</param>
    /// <param name="startIndex">将上一次回包中next填入， 如果是第一次请求填 0，默认为 0</param>
    /// <param name="limit">分页大小</param>
    /// <returns>用户信息对象和下一次请求的分页标识</returns>
    public static async Task<HttpPacket<GuildRoleMembersInfo>> GetGuildRoleMembersAsync(
        this HttpService httpService,
        string guildId,
        string roleId,
        string startIndex = "0",
        uint limit = 1
    )
    {
        return await httpService.HttpClient.RequestJson<GuildRoleMembersInfo>(
            HttpMethod.Get,
            $"/guilds/{guildId.Encode()}/roles/{roleId.Encode()}/members?start_index={startIndex.Encode()}&limit={limit}"
        );
    }

    /// <summary>
    /// 获取成员详情
    /// <br/>
    /// 获取指定的频道中指定成员的详细信息
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/member/get_member.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="guildId">频道ID</param>
    /// <param name="userId">用户ID</param>
    /// <returns><see cref="Member"/></returns>
    public static async Task<HttpPacket<Member>> GetGuildMemberAsync(
        this HttpService httpService,
        string guildId,
        string userId
    )
    {
        return await httpService.HttpClient.RequestJson<Member>(
            HttpMethod.Get,
            $"/guilds/{guildId.Encode()}/members/{userId.Encode()}"
        );
    }

    /// <summary>
    /// 删除频道成员（仅私域机器人可用）
    /// <br/>
    /// 删除指定的频道中指定成员
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/member/delete_member.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="guildId">频道ID</param>
    /// <param name="userId">用户ID</param>
    /// <param name="addBlacklist">删除成员的同时，将该用户添加到频道黑名单中</param>
    /// <param name="deleteHistoryMsgDays">删除成员的同时，撤回消息的时间范围</param>
    public static async Task<HttpPacket> DeleteGuildMemberAsync(
        this HttpService httpService,
        string guildId,
        string userId,
        bool addBlacklist = false,
        DeleteHistoryMsgDays deleteHistoryMsgDays = DeleteHistoryMsgDays.None
    )
    {
        return await httpService.HttpClient.RequestJsonWithNoResult(
            HttpMethod.Get,
            $"/guilds/{guildId.Encode()}/members/{userId.Encode()}",
            new JsonObject
            {
                { "add_blacklist", JsonValue.Create(addBlacklist) },
                { "delete_history_msg_days", (int)deleteHistoryMsgDays }
            }
        );
    }
}
