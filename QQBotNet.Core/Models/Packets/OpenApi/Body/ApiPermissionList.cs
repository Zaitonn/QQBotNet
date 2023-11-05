using System;
using QQBotNet.Core.Models.Business.Permissions;

namespace QQBotNet.Core.Models.Packets.OpenApi.Body;

/// <summary>
/// 机器人可用权限列表
/// </summary>
public class ApiPermissionList
{
    /// <summary>
    /// 机器人可用权限列表
    /// </summary>
    public ApiPermission[] Apis { get; set; } = Array.Empty<ApiPermission>();
}
