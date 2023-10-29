using QQBotNet.Core.Models.Business.Channels;
using QQBotNet.Core.Models.Packets.OpenApi;
using QQBotNet.Core.Models.Packets.OpenApi.Body;
using QQBotNet.Core.Utils.Extensions;
using System;
using System.Net.Http;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace QQBotNet.Core.Services.Apis;

/// <summary>
/// 子频道Api
/// </summary>
public static class ChannelApi
{
    /// <summary>
    /// 获取子频道列表
    /// <br/>
    /// 获取指定的频道下的子频道列表
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/guild/get_guild.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="guildId">频道ID</param>
    /// <returns>Channel对象数组</returns>
    public static async Task<HttpPacket<Channel[]>> GetChannelsAsync(
        this HttpService httpService,
        string guildId
    )
    {
        return await httpService.HttpClient.RequestJson<Channel[]>(
            HttpMethod.Get,
            $"/guilds/{guildId.Encode()}/channels"
        );
    }

    /// <summary>
    /// 获取子频道详情
    /// <br/>
    /// 获取指定的子频道的详情
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/channel/get_channel.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="channelId">子频道ID</param>
    /// <returns>Channel对象</returns>
    public static async Task<HttpPacket<Channel>> GetChannelAsync(
        this HttpService httpService,
        string channelId
    )
    {
        return await httpService.HttpClient.RequestJson<Channel>(
            HttpMethod.Get,
            $"/channels/{channelId.Encode()}"
        );
    }

    /// <summary>
    /// 创建子频道（仅私域机器人可用）
    /// <br/>
    /// 在指定的频道下创建一个子频道
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/channel/post_channels.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="guildId">频道ID</param>
    /// <param name="newChannel">子频道对象</param>
    /// <returns>Channel对象</returns>
    public static async Task<HttpPacket<Channel>> CreateChannelAsync(
        this HttpService httpService,
        string guildId,
        NewChannel newChannel
    )
    {
        return await httpService.HttpClient.RequestJson<Channel>(
            HttpMethod.Post,
            $"/guilds/{guildId.Encode()}/channels",
            newChannel ?? throw new ArgumentNullException(nameof(newChannel))
        );
    }

#pragma warning disable CS1998

    /// <summary>
    /// 修改子频道（仅私域机器人可用）
    /// <br/>
    /// 修改指定的子频道的信息
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/channel/patch_channel.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="channelId">子频道ID</param>
    /// <param name="editedChannel">子频道对象</param>
    /// <returns>Channel对象</returns>

#if NETFRAMEWORK
    [Obsolete("此版本的Net框架下不支持Patch方法", true)]
#endif
    public static async Task<HttpPacket<Channel>> EditChannelAsync(
        this HttpService httpService,
        string channelId,
        EditedChannel editedChannel
    )
    {
#if NETFRAMEWORK
        throw new NotSupportedException("此版本的Net框架下不支持Patch方法");
#else
        return await httpService.HttpClient.RequestJson<Channel>(
            HttpMethod.Patch,
            $"/channels/{channelId.Encode()}",
            editedChannel
        );
#endif
    }

#pragma warning restore CS1998

    /// <summary>
    /// 删除子频道（仅私域机器人可用）
    /// <br/>
    /// 删除指定的子频道
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/channel/delete_channel.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="channelId">子频道ID</param>
    public static async Task<HttpPacket> DeleteChannelAsync(
        this HttpService httpService,
        string channelId
    )
    {
        return await httpService.HttpClient.RequestJsonWithNoResult(
            HttpMethod.Delete,
            $"/channels/{channelId.Encode()}"
        );
    }

    /// <summary>
    /// 获取在线成员数
    /// <br/>
    /// 查询音视频/直播子频道的在线成员数
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/channel/get_online_nums.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="channelId">子频道ID</param>
    /// <returns>在线成员数</returns>
    public static async Task<HttpPacket<OnlineNum>> GetChannelOnlineNumAsync(
        this HttpService httpService,
        string channelId
    )
    {
        return await httpService.HttpClient.RequestJson<OnlineNum>(
            HttpMethod.Get,
            $"/channels/{channelId.Encode()}/online_nums"
        );
    }

    /// <summary>
    /// 获取子频道用户权限
    /// <br/>
    /// 获取子频道下用户的权限
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/channel_permissions/get_channel_permissions.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="channelId">子频道ID</param>
    /// <param name="userId">用户ID</param>
    /// <returns>子频道用户权限</returns>
    public static async Task<HttpPacket<ChannelPermissions>> GetChannelMemberPermissionAsync(
        this HttpService httpService,
        string channelId,
        string userId
    )
    {
        return await httpService.HttpClient.RequestJson<ChannelPermissions>(
            HttpMethod.Get,
            $"/channels/{channelId.Encode()}/members/{userId.Encode()}/permissions"
        );
    }

    /// <summary>
    /// 修改子频道权限
    /// <br/>
    /// 修改子频道下用户的权限
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/channel_permissions/put_channel_permissions.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="channelId">子频道ID</param>
    /// <param name="userId">用户ID</param>
    /// <param name="add">赋予用户的权限</param>
    /// <param name="remove">删除用户的权限</param>
    public static async Task<HttpPacket> EditChannelMemberPermissionAsync(
        this HttpService httpService,
        string channelId,
        string userId,
        PermissionType add,
        PermissionType remove
    )
    {
        return await httpService.HttpClient.RequestJsonWithNoResult(
            HttpMethod.Put,
            $"/channels/{channelId.Encode()}/members/{userId.Encode()}/permissions",
            new JsonObject { { "add", (int)add }, { "remove", (int)remove } }
        );
    }

    /// <summary>
    /// 获取子频道身份组权限
    /// <br/>
    /// 获取子频道下身份组的权限
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/channel_permissions/get_channel_roles_permissions.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="channelId">子频道ID</param>
    /// <param name="roleId">身份组ID</param>
    /// <returns>子频道身份组权限</returns>
    public static async Task<HttpPacket<ChannelPermissions>> GetChannelRolePermissionAsync(
        this HttpService httpService,
        string channelId,
        string roleId
    )
    {
        return await httpService.HttpClient.RequestJson<ChannelPermissions>(
            HttpMethod.Get,
            $"/channels/{channelId.Encode()}/roles/{roleId.Encode()}/permissions"
        );
    }

    /// <summary>
    /// 修改子频道身份组权限
    /// <br/>
    /// 修改子频道下身份组的权限
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/channel_permissions/put_channel_roles_permissions.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="channelId">子频道ID</param>
    /// <param name="roleId">身份组ID</param>
    /// <param name="add">赋予用户的权限</param>
    /// <param name="remove">删除用户的权限</param>
    public static async Task<HttpPacket> EditChannelRolePermissionAsync(
        this HttpService httpService,
        string channelId,
        string roleId,
        PermissionType add,
        PermissionType remove
    )
    {
        return await httpService.HttpClient.RequestJsonWithNoResult(
            HttpMethod.Put,
            $"/channels/{channelId.Encode()}/roles/{roleId.Encode()}/permissions",
            new JsonObject { { "add", (int)add }, { "remove", (int)remove }, }
        );
    }
}
