using System.Text.Json.Nodes;

namespace QQBotNet.Core.Entity.WebSockets;

public interface IPacket
{
    OperationCode OperationCode { get; set; }
    JsonNode? Data { get; set; }
    string? Type { get; set; }
    long? SerialNumber { get; set; }
}
