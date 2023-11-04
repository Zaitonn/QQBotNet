namespace QQBotNet.Core.Models.Business.Forums.Contents;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/forum/model.html#urlelem</see>
/// </summary>
public class URLElem
{
    /// <summary>
    /// URL链接
    /// </summary>
    public string Url { get; set; } = string.Empty;

    /// <summary>
    /// URL描述
    /// </summary>
    public string Desc { get; set; } = string.Empty;
}
