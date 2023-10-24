using System.Text.Json.Nodes;

namespace QQBotNet.Core.Entity.WebSockets;

public interface IPacket
{
    /// <summary>
    /// 长连接维护 OpCode
    /// </summary>
    public OperationCode OperationCode { get; }

    /// <summary>
    /// 事件内容
    /// </summary>
    public JsonNode? Data { get; }

    /// <summary>
    /// 事件类型
    /// </summary>
    public string? Type { get; }

    /// <summary>
    /// 下行消息序列号
    /// </summary>
    public long? SerialNumber { get; }
}
