using System;

namespace QQBotNet.Core.Models.Business.Messages;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/message/model.html#messagearkkv</see>
/// </summary>
public class MessageArk
{
    /// <summary>
    /// ark模板id（需要先申请）
    /// </summary>
    public int TemplateId { get; set; }

    /// <summary>
    /// kv值列表
    /// </summary>
    public MessageArkKv[] Kv = Array.Empty<MessageArkKv>();
}
