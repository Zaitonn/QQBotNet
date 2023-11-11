using System;
using System.Text.Json.Serialization;
using QQBotNet.Core.Utils.Json;

namespace QQBotNet.Core.Models.Business.Messages;

/// <summary>
/// v2Api的消息数据包
/// </summary>
public class MessageV2
{
    /// <summary>
    /// 平台方消息ID，可以用于被动消息发送
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// 消息内容
    /// </summary>
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// 消息生产时间
    /// </summary>
    [JsonConverter(typeof(TimestampConverter))]
    public DateTime Timestamp { get; set; }

    /// <summary>
    /// 富媒体文件附件
    /// </summary>
    public MessageAttachment[] Attachments { get; set; } = Array.Empty<MessageAttachment>();

    /// <summary>
    /// 群聊的 openid（仅群聊）
    /// </summary>
    public string? GroupOpenid { get; set; }

    /// <summary>
    /// 发送者
    /// </summary>
    public MessageAuthor Author { get; set; } = new();
}
