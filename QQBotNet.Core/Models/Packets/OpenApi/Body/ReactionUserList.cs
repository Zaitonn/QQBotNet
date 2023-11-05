using QQBotNet.Core.Models.Business;
using System;

namespace QQBotNet.Core.Models.Packets.OpenApi.Body;

/// <summary>
/// 指定表情表态的用户列表
/// </summary>
public class ReactionUserList
{
    /// <summary>
    /// 用户对象
    /// </summary>
    public User[] Users { get; set; } = Array.Empty<User>();

    /// <summary>
    /// 分页参数，用于拉取下一页
    /// </summary>
    public string? Cookie { get; set; }

    /// <summary>
    /// 是否已拉取完成到最后一页，true代表完成
    /// </summary>
    public bool IsEnd { get; set; }
}
