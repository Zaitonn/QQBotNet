using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace QQBotNet.Core.Entity.WebSockets;

public class Packet : IPacket
{
    /// <summary>
    /// 长连接维护 OpCode
    /// </summary>
    [JsonPropertyName("op")]
    public OperationCode OperationCode { get; set; }

    /// <summary>
    /// 事件内容
    /// </summary>
    [JsonPropertyName("d")]
    public JsonNode? Data { get; set; }

    /// <summary>
    /// 事件类型
    /// </summary>
    [JsonPropertyName("t")]
    public string? Type { get; set; }

    /// <summary>
    /// 下行消息序列号
    /// </summary>
    [JsonPropertyName("s")]
    public long? SerialNumber { get; set; }
}
