namespace QQBotNet.Core.Models.Business.Messages.Keyboard;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/message/message_keyboard.html#permissiontype</see>
/// </summary>
public enum PermissionType
{
    /// <summary>
    /// 指定用户可操作
    /// </summary>
    SpecificUser,

    /// <summary>
    /// 仅管理者可操作
    /// </summary>
    OnlyAdministrator,

    /// <summary>
    /// 所有人可操作
    /// </summary>
    Everyone,

    /// <summary>
    /// 指定身份组可操作
    /// </summary>
    SpecificRole,
}
