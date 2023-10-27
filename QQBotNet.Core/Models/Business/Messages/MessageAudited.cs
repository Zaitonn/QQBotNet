using System;

namespace QQBotNet.Core.Models.Business.Messages;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/message/model.html#%E6%B6%88%E6%81%AF%E5%AE%A1%E6%A0%B8%E5%AF%B9%E8%B1%A1-messageaudited</see>
/// </summary>
public class MessageAudited
{
    /// <summary>
    /// 消息 id，只有审核通过事件才会有值
    /// </summary>
    public string MessageId { get; set; } = string.Empty;

    /// <summary>
    ///  子频道 id
    /// </summary>
    public string ChannelId { get; set; } = string.Empty;

    /// <summary>
    /// 频道 id
    /// </summary>
    public string GuildId { get; set; } = string.Empty;

    /// <summary>
    /// 消息审核 id
    /// </summary>
    public string AuditId { get; set; } = string.Empty;

    /// <summary>
    /// 子频道消息 seq，用于消息间的排序，seq 在同一子频道中按从先到后的顺序递增，不同的子频道之间消息无法排序
    /// </summary>
    public int SeqInChannel { get; set; }

    /// <summary>
    /// 消息审核时间
    /// </summary>
    public DateTime AuditTime { get; set; }

    /// <summary>
    /// 消息创建时间
    /// </summary>
    public DateTime CreateTime { get; set; }
}
