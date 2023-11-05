namespace QQBotNet.Core.Models.Business.Reactions;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/reaction/model.html#reactiontargettype</see>
/// </summary>
public enum ReactionTargetType
{
    /// <summary>
    /// 消息
    /// </summary>
    Message,

    /// <summary>
    /// 帖子
    /// </summary>
    Thread,

    /// <summary>
    /// 评论
    /// </summary>
    Post,

    /// <summary>
    /// 回复
    /// </summary>
    Reply,
}
