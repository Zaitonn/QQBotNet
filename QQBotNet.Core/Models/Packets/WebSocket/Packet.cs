using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace QQBotNet.Core.Models.Packets.WebSockets;

public class Packet<T> : IPacket<T>
{
    [JsonPropertyName("op")]
    public OperationCode OperationCode { get; set; }

    [JsonPropertyName("d")]
    public T? Data { get; set; }

    [JsonPropertyName("t")]
    public string? Type { get; set; }

    [JsonPropertyName("s")]
    public long? SerialNumber { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }
}

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

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    public Packet<T> Convert<T>(JsonSerializerOptions? options = null) =>
        new()
        {
            OperationCode = OperationCode,
            Type = Type,
            SerialNumber = SerialNumber,
            Data = JsonSerializer.Deserialize<T>(Data, options)
        };
}
