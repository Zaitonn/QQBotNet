namespace QQBotNet.Core.Models.Business;

/// <summary>
/// 撤回消息的时间范围
/// </summary>
public enum DeleteHistoryMsgDays
{
    /// <summary>
    /// 3天
    /// </summary>
    Three = 3,

    /// <summary>
    /// 7天
    /// </summary>
    Seven = 7,

    /// <summary>
    /// 15天
    /// </summary>
    Fifteen = 15,

    /// <summary>
    /// 30天
    /// </summary>
    Thirty = 30,

    /// <summary>
    /// 所有
    /// </summary>
    All = -1,

    /// <summary>
    /// 不撤回
    /// </summary>
    None = 0,
}
