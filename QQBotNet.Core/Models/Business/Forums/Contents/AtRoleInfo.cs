namespace QQBotNet.Core.Models.Business.Forums.Contents;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/forum/model.html#atroleinfo</see>
/// </summary>
public class AtRoleInfo
{
    /// <summary>
    /// 身份组ID
    /// </summary>
    public uint RoleId { get; set; }

    /// <summary>
    /// 身份组名称
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 颜色值
    /// </summary>
    public uint Color { get; set; }
}
