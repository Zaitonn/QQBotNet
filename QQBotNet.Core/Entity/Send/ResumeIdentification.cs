namespace QQBotNet.Core.Entity.Send;

public class ResumeIdentification
{
    /// <summary>
    /// 连接凭证
    /// </summary>
    public string Token { get; set; } = string.Empty;

    /// <summary>
    /// 会话ID
    /// </summary>
    public string SessionId { get; set; } = string.Empty;

    public long Seq { get; set; }
}
