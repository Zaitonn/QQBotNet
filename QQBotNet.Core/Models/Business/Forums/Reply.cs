namespace QQBotNet.Core.Models.Business.Forums;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/forum/model.html#reply</see>
/// </summary>
public class Reply : ItemBase
{
    /// <summary>
    /// 回复内容
    /// </summary>
    public ReplyInfo ReplyInfo { get; set; } = new();
}
