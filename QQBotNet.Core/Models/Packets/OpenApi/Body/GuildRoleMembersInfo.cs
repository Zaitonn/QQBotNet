using QQBotNet.Core.Models.Business.Members;
using System;

namespace QQBotNet.Core.Models.Packets.OpenApi.Body;

/// <summary>
/// 频道身份组成员列表
/// </summary>
public class GuildRoleMembersInfo
{
    /// <summary>
    /// 一组用户信息对象
    /// </summary>
    public Member[] Data { get; set; } = Array.Empty<Member>();

    /// <summary>
    /// 下一次请求的分页标识
    /// </summary>
    public string Next { get; set; } = string.Empty;
}
