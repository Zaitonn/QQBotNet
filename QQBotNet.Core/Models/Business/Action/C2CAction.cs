using System;
using System.Text.Json.Serialization;
using QQBotNet.Core.Utils.Json;

namespace QQBotNet.Core.Models.Business.Action;

/// <summary>
/// 私聊动作数据包
/// </summary>
public class C2CAction
{
    /// <summary>
    /// 时间戳
    /// </summary>
    [JsonConverter(typeof(TimestampConverter))]
    public DateTime Timestamp { get; set; }

    /// <summary>
    /// 用户openid
    /// </summary>
    public string Openid { get; set; } = string.Empty;
}
