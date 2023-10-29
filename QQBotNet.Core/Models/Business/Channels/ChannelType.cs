using System;

namespace QQBotNet.Core.Models.Business.Channels;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/channel/model.html#channeltype</see>
/// </summary>
public enum ChannelType
{
    /// <summary>
    /// 文字子频道
    /// </summary>
    Text = 0,

    /// <summary>
    /// 保留，不可用
    /// </summary>
    [Obsolete("不可用")]
    Reserved1 = 1,

    /// <summary>
    /// 语音子频道
    /// </summary>
    Audio = 2,

    /// <summary>
    /// 保留，不可用
    /// </summary>
    [Obsolete("不可用")]
    Reserved3 = 3,

    /// <summary>
    /// 子频道分组
    /// </summary>
    Grouping = 4,

    /// <summary>
    /// 直播子频道
    /// </summary>
    Live = 10005,

    /// <summary>
    /// 应用子频道
    /// </summary>
    Application = 10006,

    /// <summary>
    /// 论坛子频道
    /// </summary>
    Forum = 10007
}
