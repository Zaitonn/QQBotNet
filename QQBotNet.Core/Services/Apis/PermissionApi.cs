using QQBotNet.Core.Models.Business.Permission;
using QQBotNet.Core.Models.Packets.OpenApi;
using QQBotNet.Core.Models.Packets.OpenApi.Body;
using QQBotNet.Core.Utils;
using QQBotNet.Core.Utils.Extensions;
using QQBotNet.Core.Utils.Json;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace QQBotNet.Core.Services.Apis;

/// <summary>
/// 权限Api
/// </summary>
public static class PermissionApi
{
    /// <summary>
    /// 获取频道可用权限列表
    /// <br/>
    /// 获取机器人在频道内可以使用的权限列表
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/api_permissions/get_guild_api_permission.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="guildId">频道ID</param>
    /// <returns>机器人可用权限列表</returns>
    public static async Task<HttpPacket<ApiPermissionList>> GetApiPermissionsAsync(
        this HttpService httpService,
        string guildId
    )
    {
        return await httpService.HttpClient.RequestJson<ApiPermissionList>(
            HttpMethod.Get,
            $"/guilds/{guildId}/api_permission"
        );
    }

    /// <summary>
    /// 创建频道 API 接口权限授权链接
    /// <br/>
    /// 创建 API 接口权限授权链接，该链接指向guildId对应的频道
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/api_permissions/post_api_permission_demand.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="guildId">频道ID</param>
    /// <param name="channelId">授权链接发送的子频道 id</param>
    /// <param name="desc">机器人申请对应的 API 接口权限后可以使用功能的描述</param>
    /// <param name="apiIdentify">api 权限需求标识对象</param>
    /// <returns>权限授权链接对象</returns>
    public static async Task<HttpPacket<ApiPermissionDemand>> CreateApiPermissionsAsync(
        this HttpService httpService,
        string guildId,
        string channelId,
        string desc,
        ApiPermissionDemandIdentify apiIdentify
    )
    {
        return await httpService.HttpClient.RequestJson<ApiPermissionDemand>(
            HttpMethod.Post,
            $"/guilds/{guildId}/api_permission/demand",
            new JsonObject
            {
                { "channel_id", channelId },
                { "desc", desc },
                {
                    "api_identify",
                    JsonSerializer.SerializeToNode(
                        apiIdentify,
                        JsonSerializerOptionsFactory.UnsafeSnakeCase
                    )
                },
            }
        );
    }
}
