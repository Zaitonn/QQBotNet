using System.Text.Json.Serialization;

namespace QQBotNet.Core.Entity.WebSockets;

public class Identification
{
    /// <summary>
    /// 连接凭证
    /// </summary>
    [JsonInclude]
    public string Token { get; set; } = string.Empty;

    /// <summary>
    /// 此次连接所需要接收的事件
    /// </summary>
    [JsonInclude]
    public long Intents { get; set; }

    /// <summary>
    /// 分片逻辑
    /// </summary>
    [JsonInclude]
    public int[] Shard { get; set; } = { };
}
