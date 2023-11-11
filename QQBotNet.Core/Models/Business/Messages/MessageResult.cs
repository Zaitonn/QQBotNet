using QQBotNet.Core.Utils.Json;
using System;
using System.Text.Json.Serialization;

namespace QQBotNet.Core.Models.Business.Messages;

/// <summary>
/// v2Api的消息发送结果
/// </summary>
public class MessageResult
{
    /// <summary>
    /// 发送时间
    /// </summary>
    [JsonConverter(typeof(TimestampConverter))]
    public DateTime Timestamp { get; set; }

    /// <summary>
    /// 消息唯一ID
    /// </summary>
    public string Id { get; set; } = string.Empty;
}
