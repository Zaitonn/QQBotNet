using System;

namespace QQBotNet.Core.Models.Business.Messages;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/message/model.html</see>
/// </summary>
public class Message
{
    /// <summary>
    /// 消息 id
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// 子频道 id
    /// </summary>
    public string ChannelId { get; set; } = string.Empty;

    /// <summary>
    /// 频道 id
    /// </summary>
    public string GuildId { get; set; } = string.Empty;

    /// <summary>
    /// 消息内容
    /// </summary>
    public string? Content { get; set; }

    /// <summary>
    /// 消息创建时间
    /// </summary>
    public string Timestamp { get; set; } = string.Empty;

    /// <summary>
    /// 消息编辑时间
    /// </summary>
    public string EditedTimestamp { get; set; } = string.Empty;

    /// <summary>
    /// 是否是@全员消息
    /// </summary>
    public bool MentionEveryone { get; set; }

    /// <summary>
    /// 消息创建者
    /// </summary>
    public User Author { get; set; } = new();

    /// <summary>
    /// 用于消息间的排序，seq 在同一子频道中按从先到后的顺序递增，不同的子频道之间消息无法排序
    /// </summary>
    [Obsolete("目前只在消息事件中有值，2022年8月1日后续废弃")]
    public int? Seq { get; set; }

    /// <summary>
    /// 子频道消息 seq，用于消息间的排序，seq 在同一子频道中按从先到后的顺序递增，不同的子频道之间消息无法排序
    /// </summary>
    public int SeqInChannel { get; set; }

    /// <summary>
    /// 用于私信场景下识别真实的来源频道id
    /// </summary>
    public string? SrcGuildId { get; set; }

    /// <summary>
    /// embed
    /// </summary>
    public MessageEmbed[]? Embeds { get; set; }

    /// <summary>
    /// 消息中@的人
    /// </summary>
    public User[]? Mentions { get; set; }

    /// <summary>
    /// 附件
    /// </summary>
    public MessageAttachment[]? Attachments { get; set; }

    /// <summary>
    /// 消息创建者的member信息
    /// </summary>
    public Member Member { get; set; } = new();

    /// <summary>
    /// ark消息
    /// </summary>
    public MessageArk? Ark { get; set; }

    /// <summary>
    /// 引用消息对象
    /// </summary>
    public MessageReference? MessageReference { get; set; }
}
