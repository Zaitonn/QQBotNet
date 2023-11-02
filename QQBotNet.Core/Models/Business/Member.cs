using System;

namespace QQBotNet.Core.Models.Business;

/// <summary>
/// 成员
/// <br/>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/member/model.html#member</see>
/// </summary>
public class Member
{
    /// <summary>
    /// 用户的频道基础信息，只有成员相关接口中会填充此信息
    /// </summary>
    public User? User { get; set; }

    /// <summary>
    /// 用户的昵称
    /// </summary>
    public string Nick { get; set; } = string.Empty;

    /// <summary>
    /// 用户在频道内的身份组ID
    /// </summary>
    public string[] Roles { get; set; } = Array.Empty<string>();

    /// <summary>
    /// 用户加入频道的时间
    /// </summary>
    public DateTime JoinedAt { get; set; }

    /// <summary>
    /// 频道 id
    /// </summary>
    public string? GuildId { get; set; }
}
