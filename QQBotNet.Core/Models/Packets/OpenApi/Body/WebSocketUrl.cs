namespace QQBotNet.Core.Models.Packets.OpenApi.Body;

/// <summary>
/// WebSocketUrl数据包
/// </summary>
public class WebSocketUrl
{
    /// <summary>
    /// WebSocket连接地址
    /// </summary>
    public string Url { get; set; } = string.Empty;
}
