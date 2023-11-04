namespace QQBotNet.Core.Models.Business.Forums.Contents;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/forum/model.html#textelem</see>
/// </summary>
public class TextElem
{
    /// <summary>
    /// 正文
    /// </summary>
    public string Text { get; set; } = string.Empty;

    /// <summary>
    /// 文本属性
    /// </summary>
    public TextProps Props { get; set; } = new();
}
