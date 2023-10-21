using System.Text.Json;
using QQBotNet.Core.Entity.WebSockets;

namespace QQBotNet.Core.Services.Operations;

[Operation(OperationCode.Hello)]
public class HelloOperation : IOperation
{
    public void HandleOperation(Packet packet, WebSocketService service)
    {
        service.SendPacket(
            new()
            {
                Operation = OperationCode.Identify,
                Data = JsonSerializer.SerializeToNode(
                    new Identification
                    {
                        Token = $"{service.Info.BotAppId}.{service.Info.BotToken}",
                        Shard = new[] { 0, 1 }
                    }
                )
            }
        );
    }
}
