using System;

namespace QQBotNet.Core.Models.Business.Channels;

/// <summary>
/// 权限
/// <br/>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/channel_permissions/model.html#permissions</see>
/// </summary>
[Flags]
public enum PermissionType
{
    /// <summary>
    /// 可查看
    /// </summary>
    View = 1,

    /// <summary>
    /// 可管理
    /// </summary>
    Manage = 2,

    /// <summary>
    /// 可发言
    /// </summary>
    Chat = 4,

    /// <summary>
    /// 可直播
    /// </summary>
    Live = 8
}
