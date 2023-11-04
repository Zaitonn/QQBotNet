namespace QQBotNet.Core.Models.Business.Forums.Contents;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/forum/model.html#emojiinfo</see>
/// </summary>
public class EmojiInfo
{
    /// <summary>
    /// 表情id
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// 表情类型
    /// </summary>
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 链接
    /// </summary>
    public string Url { get; set; } = string.Empty;
}
