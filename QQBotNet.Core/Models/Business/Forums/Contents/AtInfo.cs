namespace QQBotNet.Core.Models.Business.Forums.Contents;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/forum/model.html#atinfo</see>
/// </summary>
public class AtInfo
{
    /// <summary>
    /// at类型
    /// </summary>
    public AtType Type { get; set; }

    /// <summary>
    /// 用户
    /// </summary>
    public AtUserInfo? UserInfo { get; set; }

    /// <summary>
    /// 角色组信息
    /// </summary>
    public AtRoleInfo? RoleInfo { get; set; }

    /// <summary>
    /// 频道信息
    /// </summary>
    public AtGuildInfo? GuildInfo { get; set; }
}
