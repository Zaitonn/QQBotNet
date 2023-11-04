namespace QQBotNet.Core.Models.Business.Forums;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/forum/model.html#threadinfo</see>
/// </summary>
public class ThreadInfo : InfoBase
{
    /// <summary>
    /// 帖子标题
    /// </summary>
    public string Title { get; set; } = string.Empty;
}
