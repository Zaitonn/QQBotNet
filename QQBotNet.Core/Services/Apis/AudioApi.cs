using QQBotNet.Core.Models.Business.Announcement;
using QQBotNet.Core.Models.Packets.OpenApi;
using QQBotNet.Core.Utils.Json;
using QQBotNet.Core.Utils.Extensions;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using QQBotNet.Core.Models.Business.Audio;

namespace QQBotNet.Core.Services.Apis;

/// <summary>
/// 音频Api
/// </summary>
public static class AudioApi
{
    /// <summary>
    /// 音频控制
    /// <br/>
    /// 控制子频道下的音频
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/audio/audio_control.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="channelId">子频道ID</param>
    /// <param name="audioControl">音频控制</param>
    public static async Task<HttpPacket> ControlAudioAsync(
        this HttpService httpService,
        string channelId,
        AudioControl audioControl
    )
    {
        return await httpService.HttpClient.RequestJsonWithNoResult(
            HttpMethod.Post,
            $"/channels/{channelId.Encode()}/audio",
            audioControl,
            true
        );
    }

    /// <summary>
    /// 机器人上麦
    /// <br/>
    /// 机器人在对应的语音子频道上麦
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/audio/put_mic.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="channelId">子频道ID</param>
    public static async Task<HttpPacket> OpenMicAsync(
        this HttpService httpService,
        string channelId
    )
    {
        return await httpService.HttpClient.RequestJsonWithNoResult(
            HttpMethod.Put,
            $"/channels/{channelId.Encode()}/mic"
        );
    }

    /// <summary>
    /// 机器人下麦
    /// <br/>
    /// 机器人在对应的语音子频道下麦
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/audio/delete_mic.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="channelId">子频道ID</param>
    public static async Task<HttpPacket> CloseMicAsync(
        this HttpService httpService,
        string channelId
    )
    {
        return await httpService.HttpClient.RequestJsonWithNoResult(
            HttpMethod.Delete,
            $"/channels/{channelId.Encode()}/mic"
        );
    }
}
