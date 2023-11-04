namespace QQBotNet.Core.Models.Business.Forums.Contents;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/forum/model.html#richobject</see>
/// </summary>
public class RichObject
{
    /// <summary>
    /// 富文本类型
    /// </summary>
    public RichType Type { get; set; }

    /// <summary>
    /// 文本
    /// </summary>
    public TextInfo? TextInfo { get; set; }

    /// <summary>
    /// 表情
    /// </summary>
    public EmojiInfo? EmojiInfo { get; set; }

    /// <summary>
    /// 链接
    /// </summary>
    public UrlInfo? UrlInfo { get; set; }

    /// <summary>
    /// 提到的子频道
    /// </summary>
    public ChannelInfo? ChannelInfo { get; set; }

    /// <summary>
    /// @ 内容
    /// </summary>
    public AtInfo? AtInfo { get; set; }
}
