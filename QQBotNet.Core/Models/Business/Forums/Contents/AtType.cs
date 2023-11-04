namespace QQBotNet.Core.Models.Business.Forums.Contents;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/forum/model.html#attype</see>
/// </summary>
public enum AtType
{
    /// <summary>
    /// at特定人
    /// </summary>
    ExplicitUser = 1,

    /// <summary>
    /// at角色组所有人
    /// </summary>
    RoleGroup = 2,

    /// <summary>
    /// at频道所有人
    /// </summary>
    Guild = 3,
}
