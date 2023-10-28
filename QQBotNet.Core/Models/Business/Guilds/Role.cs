namespace QQBotNet.Core.Models.Business.Guilds;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/guild/role_model.html</see>
/// </summary>
public class Role
{
    /// <summary>
    /// 身份组ID
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// ARGB的HEX十六进制颜色值转换后的十进制数值
    /// </summary>
    public uint Color { get; set; }

    /// <summary>
    /// 是否在成员列表中单独展示: 0-否, 1-是
    /// </summary>
    public uint Hoist { get; set; }

    /// <summary>
    /// 是否在成员列表中单独展示: 0-否, 1-是
    /// </summary>
    public bool HoistBool => Hoist == 1;

    /// <summary>
    /// 人数
    /// </summary>
    public uint Number { get; set; }

    /// <summary>
    /// 成员上限
    /// </summary>
    public uint MemberLimit { get; set; }
}
