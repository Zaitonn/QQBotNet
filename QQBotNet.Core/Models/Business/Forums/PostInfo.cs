namespace QQBotNet.Core.Models.Business.Forums;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/forum/model.html#postinfo</see>
/// </summary>
public class PostInfo : InfoBase
{
    /// <summary>
    /// 帖子ID
    /// </summary>
    public string PostId { get; set; } = string.Empty;
}
