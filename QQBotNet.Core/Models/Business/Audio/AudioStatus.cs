namespace QQBotNet.Core.Models.Business.Audio;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/audio/model.html#status</see>
/// </summary>
public enum AudioStatus
{
    /// <summary>
    /// 开始播放操作
    /// </summary>
    Start,

    /// <summary>
    /// 暂停播放操作
    /// </summary>
    Pause,

    /// <summary>
    /// 继续播放操作
    /// </summary>
    Resume,

    /// <summary>
    /// 停止播放操作
    /// </summary>
    Stop
}
