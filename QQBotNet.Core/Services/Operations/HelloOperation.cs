using QQBotNet.Core.Entity.Back;
using QQBotNet.Core.Entity.Send;
using QQBotNet.Core.Entity.WebSockets;
using QQBotNet.Core.Utils;
using System.Text.Json;
using System.Threading.Tasks;

namespace QQBotNet.Core.Services.Operations;

[Operation(OperationCode.Hello)]
public class HelloOperation : IOperation
{
    public async Task HandleOperationAsync(IPacket packet, BotInstance botInstance)
    {
        if (botInstance.WebSocketService?.Session is null)
            await botInstance.WebSocketService!.SendPacket(
                new()
                {
                    OperationCode = OperationCode.Identify,
                    Data = JsonSerializer.SerializeToNode(
                        new Identification
                        {
                            Token = $"{botInstance.BotAppId}.{botInstance.BotToken}", // 啥b
                            Shard = new[] { 0, 1 },
                            Intents =
                                EventIntent.ForumEvent
                                | EventIntent.GuildMessages
                                | EventIntent.GuildMessageReactions,
                        },
                        JsonSerializerOptionsFactory.SnakeCase
                    )
                }
            );
        else
            await botInstance.WebSocketService.SendPacket(
                new()
                {
                    OperationCode = OperationCode.Resume,
                    Data = JsonSerializer.SerializeToNode(
                        new ResumeIdentification
                        {
                            Token = $"{botInstance.BotAppId}.{botInstance.BotToken}",
                            SessionId = botInstance.WebSocketService.Session.SessionId,
                            Seq = botInstance.WebSocketService.SerialNumber
                        },
                        JsonSerializerOptionsFactory.SnakeCase
                    )
                }
            );

        int? heartbeatInterval = packet.Data
            .Deserialize<HeartbeatInfo>(JsonSerializerOptionsFactory.SnakeCase)
            ?.HeartbeatInterval;
        botInstance.WebSocketService.HeartbeatInterval = heartbeatInterval ?? 0;
    }
}
