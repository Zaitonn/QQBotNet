namespace QQBotNet.Core.Models.Packets.WebSockets;

/// <summary>
/// 会话对象
/// </summary>
public class Session
{
    /// <summary>
    /// 版本
    /// </summary>
    public int Version { get; set; }

    /// <summary>
    /// 会话Id
    /// </summary>
    public string SessionId { get; set; } = string.Empty;

    /// <summary>
    /// 用户对象
    /// </summary>
    public BotUser User { get; set; } = new();
}
