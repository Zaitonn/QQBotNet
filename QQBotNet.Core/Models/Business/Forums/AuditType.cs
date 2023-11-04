namespace QQBotNet.Core.Models.Business.Forums;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/forum/model.html#audittype</see>
/// </summary>
public enum AuditType
{
    /// <summary>
    /// 帖子
    /// </summary>
    Thread = 1,

    /// <summary>
    /// 评论
    /// </summary>
    Post = 2,

    /// <summary>
    /// 回复
    /// </summary>
    Reply = 3,
}
