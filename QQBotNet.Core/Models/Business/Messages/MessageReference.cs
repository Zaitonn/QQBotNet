namespace QQBotNet.Core.Models.Business.Messages;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/message/model.html#messagereference</see>
/// </summary>
public class MessageReference
{
    /// <summary>
    /// 需要引用回复的消息 id
    /// </summary>
    public string MessageId { get; set; } = string.Empty;

    /// <summary>
    /// 是否忽略获取引用消息详情错误
    /// </summary>
    public bool IgnoreGetMessageError { get; set; }
}
