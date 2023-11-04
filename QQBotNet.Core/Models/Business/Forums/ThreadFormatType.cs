namespace QQBotNet.Core.Models.Business.Forums;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/forum/put_thread.html#format</see>
/// </summary>
public enum ThreadFormatType
{
    /// <summary>
    /// 普通文本
    /// </summary>
    Text = 1,

    /// <summary>
    /// HTML
    /// </summary>
    Html = 2,

    /// <summary>
    /// Markdown
    /// </summary>
    Markdown = 3,

    /// <summary>
    /// JSON
    /// </summary>
    Json = 4
}
