namespace QQBotNet.Core.Models.Business.Forums.Contents;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/forum/model.html#textprops</see>
/// </summary>
public class TextProps
{
    /// <summary>
    /// 加粗
    /// </summary>
    public bool FontBold { get; set; }

    /// <summary>
    /// 斜体
    /// </summary>
    public bool Italic { get; set; }

    /// <summary>
    /// 下划线
    /// </summary>
    public bool Underline { get; set; }
}
