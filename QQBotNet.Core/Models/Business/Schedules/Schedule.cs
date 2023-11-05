using QQBotNet.Core.Models.Business.Members;
using QQBotNet.Core.Utils.Json;
using System;
using System.Text.Json.Serialization;

namespace QQBotNet.Core.Models.Business.Schedules;

/// <summary>
/// 日程对象
/// <br/>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/schedule/model.html</see>
/// </summary>
public class Schedule
{
    /// <summary>
    /// 日程 id
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// 日程名称
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 日程描述
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// 日程开始时间
    /// </summary>
    [JsonConverter(typeof(StringTimestampConverter))]
    public DateTime StartTimestamp { get; set; }

    /// <summary>
    /// 日程结束时间
    /// </summary>
    [JsonConverter(typeof(StringTimestampConverter))]
    public DateTime EndTimestamp { get; set; }

    /// <summary>
    /// 创建者
    /// </summary>
    public Member? Creator { get; set; }

    /// <summary>
    ///  日程开始时跳转到的子频道 id
    /// </summary>
    public string JumpChannelId { get; set; } = string.Empty;

    /// <summary>
    /// 日程提醒类型
    /// </summary>
    [JsonConverter(typeof(RemindTypeConverter))]
    public RemindType RemindType { get; set; }
}
