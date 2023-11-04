namespace QQBotNet.Core.Models.Business.Forums;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/forum/model.html#post</see>
/// </summary>
public class Post : ItemBase
{
    /// <summary>
    /// 帖子内容
    /// </summary>
    public PostInfo PostInfo { get; set; } = new();
}
