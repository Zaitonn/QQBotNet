using System;

namespace QQBotNet.Core.Models.Packets.WebSockets;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/gateway/intents.html</see>
/// </summary>
[Flags]
public enum EventIntent
{
    /// <summary>
    /// 频道更新
    /// </summary>
    Guilds = 1 << 0,

    /// <summary>
    /// 频道成员变动
    /// </summary>
    GuildMembers = 1 << 1,

    /// <summary>
    /// 频道消息
    /// 仅 *私域* 机器人能够设置此 intents。
    /// </summary>
    GuildMessages = 1 << 9,

    /// <summary>
    /// 频道消息表情
    /// </summary>
    GuildMessageReactions = 1 << 10,

    /// <summary>
    /// 消息
    /// </summary>
    DirectMessage = 1 << 12,

    /// <summary>
    /// 公域论坛事件
    /// </summary>
    OpenForumsEvent = 1 << 18,

    /// <summary>
    /// 音视频/直播子频道成员进出事件
    /// </summary>
    AudioOrLiveChannelMember = 1 << 19,

    /// <summary>
    /// 用户在群聊@机器人发送消息 或 用户在单聊发送消息给机器人
    /// </summary>
    [Obsolete("可能不可用")]
    GroupAtMessageOrPrivateMessage = 1 << 25,

    /// <summary>
    /// 互动事件
    /// </summary>
    Interaction = 1 << 26,

    /// <summary>
    /// 消息审核通过
    /// </summary>
    MessageAudit = 1 << 27,

    /// <summary>
    /// 论坛事件
    /// 仅 *私域* 机器人能够设置此 intents。
    /// </summary>
    ForumEvent = 1 << 28,

    /// <summary>
    /// 音频事件
    /// </summary>
    AudioAction = 1 << 29,

    /// <summary>
    /// 消息事件，此为公域的消息事件
    /// </summary>
    PublicGuildMessages = 1 << 30,
}
