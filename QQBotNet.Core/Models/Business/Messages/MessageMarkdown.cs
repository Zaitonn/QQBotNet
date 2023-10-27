namespace QQBotNet.Core.Models.Business.Messages;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/message/model.html#messagemarkdown</see>
/// </summary>
public class MessageMarkdown
{
    /// <summary>
    /// markdown 模板 id
    /// </summary>
    public int TemplateId { get; set; }

    /// <summary>
    /// markdown 自定义模板 id
    /// </summary>
    public string? CustomTemplateId { get; set; }

    /// <summary>
    /// 原生 markdown 内容。与上面三个参数互斥
    /// </summary>
    public string? Content { get; set; }
}
