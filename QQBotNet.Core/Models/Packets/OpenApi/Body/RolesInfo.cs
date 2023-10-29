using System;
using QQBotNet.Core.Models.Business.Guilds;

namespace QQBotNet.Core.Models.Packets.OpenApi.Body;

/// <summary>
/// 权限组列表
/// </summary>
public class RolesInfo
{
    /// <summary>
    /// 频道 id
    /// </summary>
    public string GuildId { get; set; } = string.Empty;

    /// <summary>
    /// 一组频道身份组对象
    /// </summary>
    public Role[] Roles { get; set; } = Array.Empty<Role>();

    /// <summary>
    /// 默认分组上限
    /// </summary>
    public int RoleNumLimit { get; set; }
}
