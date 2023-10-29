using QQBotNet.Core.Models.Business.Messages;
using QQBotNet.Core.Models.Packets.OpenApi;
using QQBotNet.Core.Utils.Extensions;
using System.Net.Http;
using System.Threading.Tasks;

namespace QQBotNet.Core.Services.Apis;

/// <summary>
/// 消息Api
/// </summary>
public static class MessageApi
{
    /// <summary>
    /// 获取频道消息频率设置
    /// <br/>
    /// 获取机器人在频道内的消息频率设置
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/setting/message_setting.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// /// <param name="guildId">频道ID</param>
    /// <returns>频道消息频率设置对象</returns>
    public static async Task<HttpPacket<MessageSetting>> GetMessageSettingAsync(
        this HttpService httpService,
        string guildId
    )
    {
        return await httpService.HttpClient.RequestJson<MessageSetting>(
            HttpMethod.Get,
            $"/guilds/{guildId}/message/setting"
        );
    }
}
