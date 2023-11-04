namespace QQBotNet.Core.Models.Business.Forums.Contents;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/forum/model.html#richtype</see>
/// </summary>
public enum RichType
{
    /// <summary>
    /// 普通文本
    /// </summary>
    Text = 1,

    /// <summary>
    /// at信息
    /// </summary>
    At = 2,

    /// <summary>
    /// url信息
    /// </summary>
    Url = 3,

    /// <summary>
    /// 表情
    /// </summary>
    Emoji = 4,

    /// <summary>
    /// 子频道
    /// </summary>
    Channel = 5,

    /// <summary>
    /// 视频
    /// </summary>
    Video = 10,

    /// <summary>
    /// 图片
    /// </summary>
    Image = 11
}
