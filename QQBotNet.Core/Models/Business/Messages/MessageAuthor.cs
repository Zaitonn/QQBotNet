namespace QQBotNet.Core.Models.Business.Messages;

/// <summary>
/// 消息作者
/// </summary>
public class MessageAuthor
{
    /// <summary>
    /// 用户在本群的MemberOpenid（仅群聊）
    /// </summary>
    public string? MemberOpenid { get; set; }

    /// <summary>
    /// 用户openid（仅私聊）
    /// </summary>
    public string? UserOpenid { get; set; }
}
