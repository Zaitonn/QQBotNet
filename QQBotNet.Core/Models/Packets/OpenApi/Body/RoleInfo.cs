using QQBotNet.Core.Models.Business.Guilds;

namespace QQBotNet.Core.Models.Packets.OpenApi.Body;

/// <summary>
/// 权限组信息
/// </summary>
public class RoleInfo
{
    /// <summary>
    /// 身份组ID
    /// </summary>
    public string RoleId { get; set; } = string.Empty;

    /// <summary>
    /// 所创建/修改的频道身份组对象
    /// </summary>
    public Role Role { get; set; } = new();

    /// <summary>
    /// 频道ID
    /// </summary>
    public string? GuildId { get; set; }
}
