namespace QQBotNet.Core.Services.Operations.DispatchEvent;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/gateway/guild.html</see>
/// </summary>
public enum DispatchEventType
{
    Null,

    /// <summary>
    /// 准备就绪
    /// </summary>
    READY,

    /// <summary>
    /// 恢复连接
    /// </summary>
    RESUMED,

    /// <summary>
    /// 机器人被加入到某个频道
    /// </summary>
    GUILD_CREATE,

    /// <summary>
    /// 频道信息变更
    /// </summary>
    GUILD_UPDATE,

    /// <summary>
    /// 频道被解散 或 机器人被移除
    /// </summary>
    GUILD_DELETE,

    /// <summary>
    /// 子频道被创建
    /// </summary>
    CHANNEL_CREATE,

    /// <summary>
    /// 子频道信息变更
    /// </summary>
    CHANNEL_UPDATE,

    /// <summary>
    /// 子频道被删除
    /// </summary>
    CHANNEL_DELETE,

    /// <summary>
    /// 新用户加入频道
    /// </summary>
    GUILD_MEMBER_ADD,

    /// <summary>
    /// 用户的频道属性发生变化
    /// </summary>
    GUILD_MEMBER_UPDATE,

    /// <summary>
    /// 用户离开频道
    /// </summary>
    GUILD_MEMBER_REMOVE,

    /// <summary>
    /// 用户发送消息，@当前机器人或回复机器人消息
    /// </summary>
    AT_MESSAGE_CREATE,

    /// <summary>
    /// 消息审核通过
    /// </summary>
    MESSAGE_AUDIT_PASS,

    /// <summary>
    /// 消息审核不通过
    /// </summary>
    MESSAGE_AUDIT_REJECT,

    /// <summary>
    /// 用户通过私信发消息给机器人
    /// </summary>
    DIRECT_MESSAGE_CREATE,

    /// <summary>
    /// 用户对消息进行表情表态
    /// </summary>
    MESSAGE_REACTION_ADD,

    /// <summary>
    /// 用户对消息进行取消表情表态
    /// </summary>
    MESSAGE_REACTION_REMOVE,

    /// <summary>
    /// 音频开始播放
    /// </summary>
    AUDIO_START,

    /// <summary>
    /// 音频开始结束时
    /// </summary>
    AUDIO_FINISH,

    /// <summary>
    /// 机器人上麦时
    /// </summary>
    AUDIO_ON_MIC,

    /// <summary>
    /// 机器人下麦时
    /// </summary>
    AUDIO_OFF_MIC,

    /// <summary>
    /// 用户在话题子频道内发帖、评论、回复评论
    /// </summary>
    FORUM_EVENT,

    /// <summary>
    /// 主题创建
    /// </summary>
    FORUM_THREAD_CREATE,

    /// <summary>
    /// 主题更新
    /// </summary>
    FORUM_THREAD_UPDATE,

    /// <summary>
    /// 主题删除
    /// </summary>
    FORUM_THREAD_DELETE,

    /// <summary>
    /// 帖子创建
    /// </summary>
    FORUM_POST_CREATE,

    /// <summary>
    /// 帖子删除
    /// </summary>
    FORUM_POST_DELETE,

    /// <summary>
    /// 回复创建
    /// </summary>
    FORUM_REPLY_CREATE,

    /// <summary>
    /// 回复删除
    /// </summary>
    FORUM_REPLY_DELETE,

    /// <summary>
    /// 帖子审核事件
    /// </summary>
    FORUM_PUBLISH_AUDIT_RESULT,

    /// <summary>
    /// 开放论坛用户在话题子频道内发帖、评论、回复评论
    /// </summary>
    OPEN_FORUM_EVENT,

    /// <summary>
    /// 开放论坛主题创建
    /// </summary>
    OPEN_FORUM_THREAD_CREATE,

    /// <summary>
    /// 开放论坛主题更新
    /// </summary>
    OPEN_FORUM_THREAD_UPDATE,

    /// <summary>
    /// 开放论坛主题删除
    /// </summary>
    OPEN_FORUM_THREAD_DELETE,

    /// <summary>
    /// 开放论坛帖子创建
    /// </summary>
    OPEN_FORUM_POST_CREATE,

    /// <summary>
    /// 开放论坛帖子删除
    /// </summary>
    OPEN_FORUM_POST_DELETE,

    /// <summary>
    /// 开放论坛回复创建
    /// </summary>
    OPEN_FORUM_REPLY_CREATE,

    /// <summary>
    /// 开放论坛回复删除
    /// </summary>
    OPEN_FORUM_REPLY_DELETE,

    /// <summary>
    /// 开放论坛帖子审核事件
    /// </summary>
    OPEN_FORUM_PUBLISH_AUDIT_RESULT,

    /// <summary>
    /// 用户进入音视频/直播子频道
    /// </summary>
    AUDIO_OR_LIVE_CHANNEL_MEMBER_ENTER,

    /// <summary>
    /// 用户离开音视频/直播子频道
    /// </summary>
    AUDIO_OR_LIVE_CHANNEL_MEMBER_EXIT,

    /// <summary>
    /// 用户在单聊发送消息给机器人
    /// </summary>
    C2C_MESSAGE_CREATE,

    /// <summary>
    /// 用户在群聊@机器人发送消息
    /// </summary>
    GROUP_AT_MESSAGE_CREATE,

    /// <summary>
    /// 用户在频道私信内发送消息给机器人
    /// </summary>
    MESSAGE_CREATE
}
