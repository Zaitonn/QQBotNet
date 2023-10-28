using QQBotNet.Core.Models.Business.Guilds;
using QQBotNet.Core.Utils;
using QQBotNet.Core.Utils.Extensions;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

#if NETFRAMEWORK
using System;
#endif

namespace QQBotNet.Core.Services.Apis;

/// <summary>
/// 频道身份组Api
/// </summary>
public static class RolesApi
{
    /// <summary>
    /// 获取频道身份组列表
    /// <br/>
    /// 用于获取guildId指定的频道下的身份组列表
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/user/me.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="guildId">频道ID</param>
    /// <returns>Role对象数组和默认分组上限</returns>
    public static async Task<(Role[]? Roles, string Limit)> GetGuildRolesAsync(
        this HttpService httpService,
        string guildId
    )
    {
        var jsonNode = await (
            await httpService.HttpClient.SendAsync(
                new(HttpMethod.Get, $"/guilds/{guildId.Encode()}/roles")
                {
                    Content = new StringContent(string.Empty).WithJsonHeader()
                }
            )
        ).Content.ReadFromJsonAsync<JsonNode>();

        return (
            JsonSerializer.Deserialize<Role[]>(
                jsonNode?["roles"],
                JsonSerializerOptionsFactory.UnsafeSnakeCase
            ),
            jsonNode?["role_num_limit"]?.ToString() ?? string.Empty
        );
    }

    /// <summary>
    /// 创建频道身份组
    /// <br/>
    /// 用于在guildId指定的频道下创建一个身份组
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/guild/post_guild_role.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="guildId">频道ID</param>
    /// <param name="name">名称</param>
    /// <param name="color">ARGB 的 HEX 十六进制颜色值转换后的十进制数值</param>
    /// <param name="hoist">在成员列表中单独展示</param>
    /// <returns>Role对象</returns>
    public static async Task<Role?> CreateGuildRoleAsync(
        this HttpService httpService,
        string guildId,
        string? name = null,
        uint color = 0,
        bool hoist = false
    )
    {
        var jsonNode = await (
            await httpService.HttpClient.PostJsonAsync(
                $"/guilds/{guildId.Encode()}/roles",
                new JsonObject
                {
                    { "name", name },
                    { "color", color },
                    { "hoist", hoist ? 1 : 0 },
                },
                new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull }
            )
        ).Content.ReadFromJsonAsync<JsonNode>();

        return JsonSerializer.Deserialize<Role>(
            jsonNode?["role"],
            JsonSerializerOptionsFactory.UnsafeSnakeCase
        );
    }

#pragma warning disable CS1998

    /// <summary>
    /// 修改频道身份组
    /// <br/>
    /// 用于修改频道guildId下roleId指定的身份组
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
#if NETFRAMEWORK
    [Obsolete("此版本的Net框架下不支持Patch方法", true)]
#endif
    public static async Task<Role?> EditGuildRoleAsync(
        this HttpService httpService,
        string guildId,
        string roleId,
        string? name = null,
        uint color = 0,
        bool hoist = false
    )
    {
#if NETFRAMEWORK
        throw new NotSupportedException("此版本的Net框架下不支持Patch方法");
#else
        var jsonNode = await (
            await httpService.HttpClient.SendAsync(
                new(HttpMethod.Patch, $"/guilds/{guildId.Encode()}/roles/{roleId.Encode()}")
                {
                    Content = new StringContent(
                        new JsonObject()
                        {
                            { "name", name },
                            { "color", color },
                            { "hoist", hoist ? 1 : 0 },
                        }.ToJsonString(
                            new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull }
                        )
                    )
                }
            )
        ).Content.ReadFromJsonAsync<JsonNode>();

        return JsonSerializer.Deserialize<Role>(
            jsonNode?["role"],
            JsonSerializerOptionsFactory.UnsafeSnakeCase
        );
#endif
    }

#pragma warning restore CS1998

    /// <summary>
    /// 修改频道身份组
    /// <br/>
    /// 用于修改频道guildId下roleId指定的身份组
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/guild/patch_guild_role.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="guildId">频道ID</param>
    /// <param name="roleId">身份组ID</param>
    public static async Task DeleteGuildRoleAsync(
        this HttpService httpService,
        string guildId,
        string roleId
    )
    {
        await httpService.HttpClient.SendAsync(
            new(HttpMethod.Delete, $"/guilds/{guildId.Encode()}/roles/{roleId.Encode()}")
            {
                Content = new StringContent(string.Empty).WithJsonHeader()
            }
        );
    }
}
