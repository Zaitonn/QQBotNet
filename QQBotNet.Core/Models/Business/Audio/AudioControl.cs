namespace QQBotNet.Core.Models.Business.Audio;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/audio/model.html#audiocontrol</see>
/// </summary>
public class AudioControl
{
    /// <summary>
    /// 音频数据的url
    /// </summary>
    public string? AudioUrl { get; set; }

    /// <summary>
    /// 状态文本
    /// </summary>
    public string? Text { get; set; }

    /// <summary>
    /// 播放状态
    /// </summary>
    public AudioStatus Status { get; set; }
}
