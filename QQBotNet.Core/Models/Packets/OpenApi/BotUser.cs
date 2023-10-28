namespace QQBotNet.Core.Models.Packets.OpenApi;

/// <summary>
/// <see cref="Session"/>中的机器人对象
/// </summary>
public class BotUser
{
    /// <summary>
    /// 用户Id
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// 当前用户名称
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// 是否为机器人
    /// </summary>
    public bool Bot { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    public int Status { get; set; }
}
