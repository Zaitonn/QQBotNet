using QQBotNet.Core.Models.Business.Channels;
using QQBotNet.Core.Utils;
using QQBotNet.Core.Utils.Extensions;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
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
    /// 用于获取 guildId 指定的频道下的子频道列表。
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/guild/get_guild.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="guildId">频道ID</param>
    /// <returns>Channel对象数组</returns>
    public static async Task<Channel[]?> GetChannelsAsync(
        this HttpService httpService,
        string guildId
    )
    {
        return await httpService.HttpClient.GetFromJsonAsync<Channel[]>(
            $"/guilds/{guildId.Encode()}/channels",
            JsonSerializerOptionsFactory.UnsafeSnakeCase
        );
    }

    /// <summary>
    /// 获取子频道详情
    /// <br/>
    /// 用于获取 channelId 指定的子频道的详情。
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/channel/get_channel.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="channelId">子频道ID</param>
    /// <returns>Channel对象</returns>
    public static async Task<Channel?> GetChannelAsync(
        this HttpService httpService,
        string channelId
    )
    {
        return await httpService.HttpClient.GetFromJsonAsync<Channel>(
            $"/channels/{channelId.Encode()}",
            JsonSerializerOptionsFactory.UnsafeSnakeCase
        );
    }

    /// <summary>
    /// 创建子频道（仅私域机器人可用）
    /// <br/>
    /// 用于在 guildId 指定的频道下创建一个子频道。
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/channel/post_channels.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="guildId">频道ID</param>
    /// <param name="newChannel">子频道对象</param>
    /// <returns>Channel对象</returns>
    public static async Task<Channel?> CreateChannelAsync(
        this HttpService httpService,
        string guildId,
        NewChannel newChannel
    )
    {
        return await (
            await httpService.HttpClient.PostJsonAsync(
                $"/guilds/{guildId.Encode()}/channels",
                newChannel,
                JsonSerializerOptionsFactory.UnsafeSnakeCase
            )
        ).Content.ReadFromJsonAsync<Channel>(JsonSerializerOptionsFactory.UnsafeSnakeCase);
    }

#pragma warning disable CS1998

    /// <summary>
    /// 修改子频道（仅私域机器人可用）
    /// <br/>
    /// 用于修改 channelId 指定的子频道的信息。
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
    public static async Task<Channel?> EditChannelAsync(
        this HttpService httpService,
        string channelId,
        EditedChannel editedChannel
    )
    {
#if NETFRAMEWORK
        throw new NotSupportedException("此版本的Net框架下不支持Patch方法");
#else
        return await (
            await httpService.HttpClient.SendAsync(
                new(HttpMethod.Patch, $"/channels/{channelId.Encode()}")
                {
                    Content = new StringContent(
                        JsonSerializer.Serialize(
                            editedChannel,
                            JsonSerializerOptionsFactory.UnsafeSnakeCase
                        )
                    ).WithJsonHeader()
                }
            )
        ).Content.ReadFromJsonAsync<Channel>(JsonSerializerOptionsFactory.UnsafeSnakeCase);
#endif
    }

#pragma warning restore CS1998

    /// <summary>
    /// 删除子频道（仅私域机器人可用）
    /// <br/>
    /// 用于删除 channelId 指定的子频道。
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/channel/delete_channel.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="channelId">子频道ID</param>
    public static async Task DeleteChannelAsync(this HttpService httpService, string channelId)
    {
        await httpService.HttpClient.SendAsync(
            new(HttpMethod.Delete, $"/channels/{channelId.Encode()}")
            {
                Content = new StringContent(string.Empty).WithJsonHeader()
            }
        );
    }

    /// <summary>
    /// 获取在线成员数
    /// <br/>
    /// 用于删除 channelId 指定的子频道。
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/channel/get_online_nums.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="channelId">子频道ID</param>
    /// <returns>在线成员数</returns>
    public static async Task<int> GetChannelOnlineNumAsync(
        this HttpService httpService,
        string channelId
    )
    {
        var responce = await (
            await httpService.HttpClient.SendAsync(
                new(HttpMethod.Get, $"/channels/{channelId.Encode()}/online_nums")
                {
                    Content = new StringContent(string.Empty).WithJsonHeader()
                }
            )
        ).Content.ReadAsStringAsync();

        var num = (int?)JsonSerializer.Deserialize<JsonNode>(responce)?["online_nums"];

        if (!num.HasValue)
            throw new NotSupportedException($"返回获得的\"online_nums\"为空");

        return num.Value;
    }
}
