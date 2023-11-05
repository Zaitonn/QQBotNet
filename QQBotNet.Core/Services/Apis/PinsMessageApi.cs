using QQBotNet.Core.Models.Business.Messages;
using QQBotNet.Core.Models.Packets.OpenApi;
using QQBotNet.Core.Utils.Extensions;
using System.Net.Http;
using System.Threading.Tasks;

namespace QQBotNet.Core.Services.Apis;

/// <summary>
/// 精华消息Api
/// </summary>
public static class PinsMessageApi
{
    /// <summary>
    /// 添加精华消息
    /// <br/>
    /// 添加子频道内的精华消息
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/pins/put_pins_message.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="channelId">子频道ID</param>
    /// <param name="messageId">消息ID</param>
    /// <returns><see cref="PinsMessage"/></returns>
    public static async Task<HttpPacket<PinsMessage>> AddPinsMessageAsync(
        this HttpService httpService,
        string channelId,
        string messageId
    )
    {
        return await httpService.HttpClient.RequestJson<PinsMessage>(
            HttpMethod.Put,
            $"/channels/{channelId.Encode()}/pins/{messageId.Encode()}"
        );
    }

    /// <summary>
    /// 删除精华消息
    /// <br/>
    /// 删除子频道下指定的精华消息
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/pins/delete_pins_message.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="channelId">子频道ID</param>
    /// <param name="messageId">消息ID</param>
    /// <returns><see cref="PinsMessage"/></returns>
    public static async Task<HttpPacket<PinsMessage>> DeletePinsMessageAsync(
        this HttpService httpService,
        string channelId,
        string messageId = "all"
    )
    {
        return await httpService.HttpClient.RequestJson<PinsMessage>(
            HttpMethod.Delete,
            $"/channels/{channelId.Encode()}/pins/{messageId.Encode()}"
        );
    }

    /// <summary>
    /// 获取精华消息
    /// <br/>
    /// 获取子频道内的精华消息
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/pins/get_pins_message.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="channelId">子频道ID</param>
    /// <returns><see cref="PinsMessage"/></returns>
    public static async Task<HttpPacket<PinsMessage>> GetPinsMessagesAsync(
        this HttpService httpService,
        string channelId
    )
    {
        return await httpService.HttpClient.RequestJson<PinsMessage>(
            HttpMethod.Delete,
            $"/channels/{channelId.Encode()}/pins"
        );
    }
}
