using QQBotNet.Core.Models.Packets.OpenApi;
using QQBotNet.Core.Models.Packets.OpenApi.Body;
using QQBotNet.Core.Utils;
using QQBotNet.Core.Utils.Extensions;
using System;
using System.Drawing;
using System.Net.Http;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace QQBotNet.Core.Services.Apis;

/// <summary>
/// 频道身份组Api
/// </summary>
public static class RolesApi
{
    /// <summary>
    /// 获取频道身份组列表
    /// <br/>
    /// 获取指定的频道下的身份组列表
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/guild/get_guild_roles.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="guildId">频道ID</param>
    /// <returns>Role对象数组和默认分组上限</returns>
    public static async Task<HttpPacket<RolesInfo>> GetGuildRolesAsync(
        this HttpService httpService,
        string guildId
    )
    {
        return await httpService.HttpClient.RequestJson<RolesInfo>(
            HttpMethod.Get,
            $"/guilds/{guildId.Encode()}/roles"
        );
    }

    /// <summary>
    /// 创建频道身份组
    /// <br/>
    /// 在指定的频道下创建一个身份组
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/guild/post_guild_role.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="guildId">频道ID</param>
    /// <param name="name">名称</param>
    /// <param name="color">ARGB 的 HEX 十六进制颜色值转换后的十进制数值</param>
    /// <param name="hoist">在成员列表中单独展示</param>
    /// <returns>Role对象</returns>
    public static async Task<HttpPacket<RoleInfo>> CreateGuildRoleAsync(
        this HttpService httpService,
        string guildId,
        string? name = null,
        uint color = 0,
        bool hoist = false
    )
    {
        return await httpService.HttpClient.RequestJson<RoleInfo>(
            HttpMethod.Post,
            $"/guilds/{guildId.Encode()}/roles",
            new JsonObject
            {
                { "name", name },
                { "color", color },
                { "hoist", hoist ? 1 : 0 },
            }
        );
    }

#if !NETSTANDARD // ColorTranslator 在netstandard2.1不可用

    /// <summary>
    /// 创建频道身份组
    /// <br/>
    /// 在指定的频道下创建一个身份组
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/guild/post_guild_role.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="guildId">频道ID</param>
    /// <param name="name">名称</param>
    /// <param name="color">C# <see cref="Color"/>对象</param>
    /// <param name="hoist">在成员列表中单独展示</param>
    /// <returns>Role对象</returns>
    public static async Task<HttpPacket<RoleInfo>> CreateGuildRoleAsync(
        this HttpService httpService,
        string guildId,
        string? name = null,
        Color color = default,
        bool hoist = false
    )
    {
        return await httpService.HttpClient.RequestJson<RoleInfo>(
            HttpMethod.Post,
            $"/guilds/{guildId.Encode()}/roles",
            new JsonObject
            {
                { "name", name },
                { "color", Convert.ToInt32(ColorTranslator.ToHtml(color).TrimStart('#')) },
                { "hoist", hoist ? 1 : 0 },
            }
        );
    }
#endif

    /// <summary>
    /// 修改频道身份组
    /// <br/>
    /// 修改频道下指定的身份组
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/guild/patch_guild_role.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="guildId">频道ID</param>
    /// <param name="roleId">身份组ID</param>
    /// <param name="name">名称</param>
    /// <param name="color">ARGB 的 HEX 十六进制颜色值转换后的十进制数值</param>
    /// <param name="hoist">在成员列表中单独展示</param>
    /// <returns>Role对象</returns>
    public static async Task<HttpPacket<RoleInfo>> EditGuildRoleAsync(
        this HttpService httpService,
        string guildId,
        string roleId,
        string? name = null,
        uint color = 0,
        bool hoist = false
    )
    {
        return await httpService.HttpClient.RequestJson<RoleInfo>(
            HttpMethodEx.Patch,
            $"/guilds/{guildId.Encode()}/roles/{roleId.Encode()}",
            name is null
                ? new JsonObject { { "color", color }, { "hoist", hoist ? 1 : 0 } }
                : new()
                {
                    { "name", name },
                    { "color", color },
                    { "hoist", hoist ? 1 : 0 }
                }
        );
    }

    /// <summary>
    /// 删除频道身份组
    /// <br/>
    /// 删除频道下指定的身份组
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/guild/delete_guild_role.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="guildId">频道ID</param>
    /// <param name="roleId">身份组ID</param>
    public static async Task<HttpPacket> DeleteGuildRoleAsync(
        this HttpService httpService,
        string guildId,
        string roleId
    )
    {
        return await httpService.HttpClient.RequestJsonWithNoResult(
            HttpMethod.Delete,
            $"/guilds/{guildId.Encode()}/roles/{roleId.Encode()}"
        );
    }

    /// <summary>
    /// 创建频道身份组成员
    /// <br/>
    /// 将频道下的用户添加到身份组
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/guild/put_guild_member_role.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="guildId">频道ID</param>
    /// <param name="userId">用户ID</param>
    /// <param name="roleId">身份组ID</param>
    /// <param name="channelId">如果要增加的身份组ID是[5-子频道管理员]，需要使用channelId来指定具体是哪个子频道</param>
    public static async Task<HttpPacket> AddMemberToGuildRoleAsync(
        this HttpService httpService,
        string guildId,
        string userId,
        string roleId,
        string? channelId = null
    )
    {
        return await httpService.HttpClient.RequestJsonWithNoResult(
            HttpMethod.Put,
            $"/guilds/{guildId.Encode()}/members/{userId.Encode()}/roles/{roleId.Encode()}",
            string.IsNullOrEmpty(channelId)
                ? null
                : new JsonObject
                {
                    {
                        "channel",
                        new JsonObject { { "id", channelId } }
                    }
                }
        );
    }

    /// <summary>
    /// 删除频道身份组成员
    /// <br/>
    /// 将用户从频道的身份组中移除
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/guild/delete_guild_member_role.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="guildId">频道ID</param>
    /// <param name="userId">用户ID</param>
    /// <param name="roleId">身份组ID</param>
    /// <param name="channelId">如果要增加的身份组ID是[5-子频道管理员]，需要使用channelId来指定具体是哪个子频道</param>
    public static async Task<HttpPacket> DeleteMemberFromGuildRoleAsync(
        this HttpService httpService,
        string guildId,
        string userId,
        string roleId,
        string? channelId = null
    )
    {
        return await httpService.HttpClient.RequestJsonWithNoResult(
            HttpMethod.Delete,
            $"/guilds/{guildId.Encode()}/members/{userId.Encode()}/roles/{roleId.Encode()}",
            string.IsNullOrEmpty(channelId)
                ? null
                : new JsonObject
                {
                    {
                        "channel",
                        new JsonObject { { "id", channelId } }
                    }
                }
        );
    }
}
