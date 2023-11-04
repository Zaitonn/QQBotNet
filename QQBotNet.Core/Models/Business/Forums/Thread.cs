namespace QQBotNet.Core.Models.Business.Forums;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/forum/model.html#thread</see>
/// </summary>
public class Thread : ItemBase
{
    /// <summary>
    /// 主帖内容
    /// </summary>
    public ThreadInfo ThreadInfo { get; set; } = new();
}
