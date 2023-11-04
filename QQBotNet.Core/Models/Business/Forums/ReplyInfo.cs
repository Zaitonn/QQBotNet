namespace QQBotNet.Core.Models.Business.Forums;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/forum/model.html#replyinfo</see>
/// </summary>
public class ReplyInfo : InfoBase
{
    /// <summary>
    /// 帖子ID
    /// </summary>
    public string PostId { get; set; } = string.Empty;

    /// <summary>
    /// 回复ID
    /// </summary>
    public string ReplyId { get; set; } = string.Empty;
}
