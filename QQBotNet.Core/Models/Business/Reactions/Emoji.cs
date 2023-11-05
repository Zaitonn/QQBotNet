namespace QQBotNet.Core.Models.Business.Reactions;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/emoji/model.html#%E8%A1%A8%E6%83%85%E5%AF%B9%E8%B1%A1</see>
/// </summary>
public class Emoji
{
    /// <summary>
    /// 表情Id
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// 表情类型
    /// </summary>
    public EmojiType Type { get; set; }
}
