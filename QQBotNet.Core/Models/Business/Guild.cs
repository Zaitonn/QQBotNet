using System;

namespace QQBotNet.Core.Models.Business;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/guild/model.html</see>
/// </summary>
public class Guild
{
    /// <summary>
    /// 频道ID
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// 频道名称
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 频道头像地址
    /// </summary>
    public string Icon { get; set; } = string.Empty;

    /// <summary>
    /// 创建人用户ID
    /// </summary>
    public string OwnerId { get; set; } = string.Empty;

    /// <summary>
    /// 当前人是否是创建人
    /// </summary>
    public bool Owner { get; set; }

    /// <summary>
    /// 成员数
    /// </summary>
    public int MemberCount { get; set; }

    /// <summary>
    /// 最大成员数
    /// </summary>
    public int MaxMembers { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// 加入时间
    /// </summary>
    public DateTime JoinedAt { get; set; }
}
