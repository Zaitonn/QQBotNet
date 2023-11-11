namespace QQBotNet.Core.Services.Events;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/gateway/guild.html</see>
/// </summary>
public enum DispatchEventType
{
    /// <summary>
    /// 空
    /// </summary>
    NULL,

    /// <summary>
    /// 准备就绪
    /// </summary>
    READY,

    /// <summary>
    /// 恢复连接
    /// </summary>
    RESUMED,

    #region 频道 GUILD

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

    #endregion

    #region 用户 GUILD_MEMBER

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

    #endregion

    #region 私域消息事件 GUILD_MESSAGES

    /// <summary>
    /// 发送消息事件，代表频道内的全部消息，而不只是 at 机器人的消息。内容与<see cref="AT_MESSAGE_CREATE"/>相同
    /// </summary>
    MESSAGE_CREATE,

    /// <summary>
    /// 用户撤回消息？
    /// </summary>
    MESSAGE_DELETE,

    #endregion

    #region 公域消息事件 PUBLIC_GUILD_MESSAGES

    /// <summary>
    /// 用户发送消息，@当前机器人或回复机器人消息
    /// </summary>
    AT_MESSAGE_CREATE,

    /// <summary>
    /// 删除（撤回）消息事件
    /// </summary>
    PUBLIC_MESSAGE_DELETE,

    #endregion

    #region 消息审核 MESSAGE_AUDIT

    /// <summary>
    /// 消息审核通过
    /// </summary>
    MESSAGE_AUDIT_PASS,

    /// <summary>
    /// 消息审核不通过
    /// </summary>
    MESSAGE_AUDIT_REJECT,

    #endregion

    #region 私信消息 DIRECT_MESSAGE

    /// <summary>
    /// 用户通过私信发消息给机器人
    /// </summary>
    DIRECT_MESSAGE_CREATE,

    /// <summary>
    /// 用户撤回私信消息
    /// </summary>
    DIRECT_MESSAGE_DELETE,

    #endregion

    #region 表情表态 GUILD_MESSAGE_REACTIONS

    /// <summary>
    /// 用户对消息进行表情表态
    /// </summary>
    MESSAGE_REACTION_ADD,

    /// <summary>
    /// 用户对消息进行取消表情表态
    /// </summary>
    MESSAGE_REACTION_REMOVE,

    #endregion

    #region 公域论坛事件 OPEN_FORUMS_EVENT

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

    #endregion

    #region 私域论坛事件 FORUMS_EVENT

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

    #endregion

    #region 互动事件 INTERACTION

    /// <summary>
    /// 互动事件创建时
    /// </summary>
    INTERACTION_CREATE,

    #endregion

    #region 音频 AUDIO_ACTION

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

    #endregion

    #region 音视频/直播子频道成员进出事件 AUDIO_OR_LIVE_CHANNEL_MEMBER

    /// <summary>
    /// 用户进入音视频/直播子频道
    /// </summary>
    AUDIO_OR_LIVE_CHANNEL_MEMBER_ENTER,

    /// <summary>
    /// 用户离开音视频/直播子频道
    /// </summary>
    AUDIO_OR_LIVE_CHANNEL_MEMBER_EXIT,

    #endregion

    #region 全域机器人

    /// <summary>
    /// 用户在群聊@机器人发送消息
    /// </summary>
    GROUP_AT_MESSAGE_CREATE,

    /// <summary>
    /// 用户在单聊发送消息给机器人
    /// </summary>
    C2C_MESSAGE_CREATE,

    /// <summary>
    /// 机器人被添加到群聊
    /// </summary>
    GROUP_ADD_ROBOT,

    /// <summary>
    /// 机器人被移出群聊
    /// </summary>
    GROUP_DEL_ROBOT,

    /// <summary>
    /// 群管理员主动在机器人资料页操作关闭通知
    /// </summary>
    GROUP_MSG_REJECT,

    /// <summary>
    /// 群管理员主动在机器人资料页操作开启通知
    /// </summary>
    GROUP_MSG_RECEIVE,

    /// <summary>
    /// 用户添加机器人'好友'到消息列表
    /// </summary>
    FRIEND_ADD,

    /// <summary>
    /// 用户删除机器人'好友'
    /// </summary>
    FRIEND_DEL,

    /// <summary>
    /// 用户在机器人资料卡手动关闭"主动消息"推送
    /// </summary>
    C2C_MSG_REJECT,

    /// <summary>
    /// 用户在机器人资料卡手动开启"主动消息"推送开关
    /// </summary>
    C2C_MSG_RECEIVE,

    #endregion
}
