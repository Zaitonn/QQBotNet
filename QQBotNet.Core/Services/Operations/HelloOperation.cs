using System.Text.Json;
using System.Threading.Tasks;
using QQBotNet.Core.Entity.WebSockets;
using QQBotNet.Core.Utils;

namespace QQBotNet.Core.Services.Operations;

[Operation(OperationCode.Hello)]
public class HelloOperation : IOperation
{
    public async Task HandleOperationAsync(IPacket packet, WebSocketService service)
    {
        await service.SendPacket(
            new()
            {
                OperationCode = OperationCode.Identify,
                Data = JsonSerializer.SerializeToNode(
                    new Identification
                    {
                        Token = $"{service.Info.BotAppId}.{service.Info.BotToken}", // 啥b
                        Shard = new[] { 0, 1 },
                        Intents = EventIntent.ForumEvent | EventIntent.GuildMessages,
                    },
                    JsonSerializerOptionsFactory.SnakeCase
                )
            }
        );

        int? heartbeatInterval = packet.Data
            .Deserialize<HeartbeatInfo>(JsonSerializerOptionsFactory.SnakeCase)
            ?.HeartbeatInterval;
        service.HeartbeatInterval = heartbeatInterval ?? 0;
    }
}
