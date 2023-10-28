using System;

namespace QQBotNet.Core.Models.Business.Messages;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/message/model.html#messagearkobj</see>
/// </summary>
public class MessageArkObj
{
    /// <summary>
    /// 键
    /// </summary>
    public string Key { get; set; } = string.Empty;

    /// <summary>
    /// 值
    /// </summary>
    public string Value { get; set; } = string.Empty;

    /// <summary>
    /// ark objkv列表
    /// </summary>
    public MessageArkObjKv[] ObjKv = Array.Empty<MessageArkObjKv>();
}
