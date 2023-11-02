using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace QQBotNet.Core.Models.Packets.WebSockets;

/// <summary>
/// WebSocket数据包
/// </summary>
public class Packet<T> : IPacket<T>
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    [JsonPropertyName("op")]
    public OperationCode OperationCode { get; init; }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    [JsonPropertyName("d")]
    public T? Data { get; init; }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    [JsonPropertyName("t")]
    public string? Type { get; init; }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    [JsonPropertyName("s")]
    public long? SerialNumber { get; init; }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }
}

/// <summary>
/// <inheritdoc/>
/// </summary>
public class Packet : Packet<JsonNode>, IPacket
{
    /// <summary>
    /// 转换为指定数据类型的数据包
    /// </summary>
    /// <param name="options">序列号选项</param>
    /// <typeparam name="T">数据属性的类型</typeparam>
    /// <returns>指定数据类型的数据包</returns>
    public Packet<T> Convert<T>(JsonSerializerOptions? options = null) =>
        new()
        {
            OperationCode = OperationCode,
            Type = Type,
            SerialNumber = SerialNumber,
            Data = JsonSerializer.Deserialize<T>(Data, options)
        };
}
