using System;

namespace QQBotNet.Core.Models.Business.Messages.Keyboard;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/message/message_keyboard.html#permission</see>
/// </summary>
public class Permission
{
    /// <summary>
    /// 权限类型
    /// </summary>
    public PermissionType Type { get; set; }

    /// <summary>
    /// 有权限的身份组id的列表
    /// </summary>
    public string[] SpecifyRoleIds { get; set; } = Array.Empty<string>();

    /// <summary>
    /// 有权限的用户id的列表
    /// </summary>
    public string[] SpecifyUserIds { get; set; } = Array.Empty<string>();
}
