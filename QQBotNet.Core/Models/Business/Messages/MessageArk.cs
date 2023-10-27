using System;

namespace QQBotNet.Core.Models.Business.Messages;

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
