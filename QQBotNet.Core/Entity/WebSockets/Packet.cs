using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace QQBotNet.Core.Entity.WebSockets;

public class Packet : IPacket
{
    [JsonPropertyName("op")]
    public OperationCode OperationCode { get; set; }

    [JsonPropertyName("d")]
    public JsonNode? Data { get; set; }

    [JsonPropertyName("t")]
    public string? Type { get; set; }

    [JsonPropertyName("s")]
    public long? SerialNumber { get; set; }
}
