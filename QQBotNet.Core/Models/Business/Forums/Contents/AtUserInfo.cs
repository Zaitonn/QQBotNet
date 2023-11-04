namespace QQBotNet.Core.Models.Business.Forums.Contents;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/forum/model.html#atuserinfo</see>
/// </summary>
public class AtUserInfo
{
    /// <summary>
    /// 身份组ID
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// 用户昵称
    /// </summary>
    public string Nick { get; set; } = string.Empty;
}
