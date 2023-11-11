using System;
using System.Text.Json.Serialization;
using QQBotNet.Core.Utils.Json;

namespace QQBotNet.Core.Models.Business.Action;

/// <summary>
/// 群组动作数据包
/// </summary>
public class GroupAction
{
    /// <summary>
    /// 时间戳
    /// </summary>
    [JsonConverter(typeof(TimestampConverter))]
    public DateTime Timestamp { get; set; }

    /// <summary>
    /// 群聊的openid
    /// </summary>
    public string GroupOpenid { get; set; } = string.Empty;

    /// <summary>
    /// 操作机器人进群/退群的群成员openid
    /// </summary>
    public string OpMemberOpenid { get; set; } = string.Empty;
}
