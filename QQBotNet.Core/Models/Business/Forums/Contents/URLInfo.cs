namespace QQBotNet.Core.Models.Business.Forums.Contents;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/forum/model.html#urlinfo</see>
/// </summary>
public class UrlInfo
{
    /// <summary>
    /// URL链接
    /// </summary>
    public string Url { get; set; } = string.Empty;

    /// <summary>
    /// 链接显示文本
    /// </summary>
    public string? DisplayText { get; set; } 
}