namespace QQBotNet.Core.Models.Packets.OpenApi;

/// <summary>
/// 恢复凭证
/// </summary>
public class ResumeIdentification
{
    /// <summary>
    /// 令牌
    /// </summary>
    public string Token { get; set; } = string.Empty;

    /// <summary>
    /// 会话ID
    /// </summary>
    public string SessionId { get; set; } = string.Empty;

    /// <summary>
    /// 消息序列号，用于自动补发
    /// </summary>
    public long Seq { get; set; }
}
