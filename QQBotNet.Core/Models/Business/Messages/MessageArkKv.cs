using System;

namespace QQBotNet.Core.Models.Business.Messages;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/message/model.html#messagearkkv/see>
/// </summary>
public class MessageArkKv
{
    public string Key { get; set; } = string.Empty;

    public string Value { get; set; } = string.Empty;

    /// <summary>
    /// ark obj类型的列表
    /// </summary>
    public MessageArkObj[] Obj = Array.Empty<MessageArkObj>();
}
