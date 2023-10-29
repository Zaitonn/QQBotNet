namespace QQBotNet.Core.Models.Business.Channels;

/// <summary>
/// 子频道权限对象
/// <br/>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/channel_permissions/model.html</see>
/// </summary>
public class ChannelPermissions
{
    /// <summary>
    /// 子频道ID
    /// </summary>
    public string ChannelId { get; set; } = string.Empty;

    /// <summary>
    /// 用户 id
    /// </summary>
    public string? UserId { get; set; }

    /// <summary>
    /// 身份组 id
    /// </summary>
    public string? RoleId { get; set; }

    /// <summary>
    /// 用户拥有的子频道权限
    /// </summary>
    public string Permissions { get; set; } = string.Empty;

    /// <summary>
    /// 用户拥有的子频道权限枚举值
    /// </summary>
    public PermissionType PermissionType =>
        int.TryParse(Permissions, out int r) ? (PermissionType)r : PermissionType.View;
}
