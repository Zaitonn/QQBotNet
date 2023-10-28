namespace QQBotNet.Core.Models.Packets.OpenApi;

/// <summary>
/// 心跳信息
/// </summary>
public class HeartbeatInfo
{
    /// <summary>
    /// 心跳间隔
    /// </summary>
    public int? HeartbeatInterval { get; set; }
}
