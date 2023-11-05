namespace QQBotNet.Core.Models.Business.Audio;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/audio/model.html#audioaction</see>
/// </summary>
public class AudioAction
{
    /// <summary>
    /// 子频道 id
    /// </summary>
    public string ChannelId { get; set; } = string.Empty;

    /// <summary>
    /// 频道 id
    /// </summary>
    public string GuildId { get; set; } = string.Empty;

    /// <summary>
    /// 音频数据的url
    /// </summary>
    public string? AudioUrl { get; set; }

    /// <summary>
    /// 状态文本
    /// </summary>
    public string? Text { get; set; }
}
