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

    /// <summary>
    /// 建议的 shard 数
    /// </summary>
    public int? Shards { get; set; }

    /// <summary>
    /// 创建 Session 限制信息
    /// </summary>
    public SessionStartLimit? SessionStartLimit { get; set; }
}
