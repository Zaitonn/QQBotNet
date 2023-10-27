using System;

namespace QQBotNet.Core.Models.Business.Messages;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/message/model.html#messagearkobj</see>
/// </summary>
public class MessageArkObj
{
    public string Key { get; set; } = string.Empty;

    public string Value { get; set; } = string.Empty;

    /// <summary>
    /// ark objkv列表
    /// </summary>
    public MessageArkObjKv[] ObjKv = Array.Empty<MessageArkObjKv>();
}
