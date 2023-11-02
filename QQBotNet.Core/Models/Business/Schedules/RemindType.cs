namespace QQBotNet.Core.Models.Business.Schedules;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/schedule/model.html#remindtype</see>
/// </summary>
public enum RemindType
{
    /// <summary>
    /// 不提醒
    /// </summary>
    NoRemind,

    /// <summary>
    /// 开始时提醒
    /// </summary>
    RemindWhenStart,

    /// <summary>
    /// 开始前 5 分钟提醒
    /// </summary>
    Remind5MinsBeforeStart,

    /// <summary>
    /// 开始前 15 分钟提醒
    /// </summary>
    Remind15MinsBeforeStart,

    /// <summary>
    /// 开始前 30 分钟提醒
    /// </summary>
    Remind30MinsBeforeStart,

    /// <summary>
    /// 开始前 60 分钟提醒
    /// </summary>
    Remind60MinsBeforeStart,
}
