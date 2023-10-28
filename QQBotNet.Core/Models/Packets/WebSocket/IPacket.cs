using System.Text.Json;
using System.Text.Json.Nodes;

namespace QQBotNet.Core.Models.Packets.WebSockets;

/// <summary>
/// <inheritdoc/>
/// </summary>
public interface IPacket : IPacket<JsonNode>
{
    /// <summary>
    /// 转换Data属性类型
    /// </summary>
    public Packet<T> Convert<T>(JsonSerializerOptions? options = null);
}

/// <summary>
/// 数据包接口
/// </summary>
/// <typeparam name="T">Data类型</typeparam>
public interface IPacket<T>
{
    /// <summary>
    /// 长连接维护 OpCode
    /// </summary>
    public OperationCode OperationCode { get; }

    /// <summary>
    /// 事件内容
    /// </summary>
    public T? Data { get; }

    /// <summary>
    /// 事件类型
    /// </summary>
    public string? Type { get; }

    /// <summary>
    /// 下行消息序列号
    /// </summary>
    public long? SerialNumber { get; }

    /// <summary>
    /// 消息事件ID
    /// </summary>
    public string? Id { get; }
}
