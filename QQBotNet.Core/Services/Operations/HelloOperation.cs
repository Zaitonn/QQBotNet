using QQBotNet.Core.Models.Packets.WebSockets;
using QQBotNet.Core.Utils.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace QQBotNet.Core.Services.Operations;

[OperationHandler(OperationCode.Hello)]
internal class HelloOperation : IOperation
{
    public async Task HandleOperationAsync(BotInstance botInstance, Packet packet)
    {
        if (botInstance.WebSocketService?.Session is null)
            await botInstance.WebSocketService!.SendPacket(
                new()
                {
                    OperationCode = OperationCode.Identify,
                    Data = JsonSerializer.SerializeToNode(
                        new Identification
                        {
                            Token = $"{botInstance.BotAppId}.{botInstance.BotToken}",
                            Shard = botInstance.Shard ?? new[] { 0, 1 },
                            Intents = botInstance.EventIntents,
                        },
                        JsonSerializerOptionsFactory.UnsafeSnakeCase
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
                        JsonSerializerOptionsFactory.UnsafeSnakeCase
                    )
                }
            );

        int? heartbeatInterval = packet
            .Convert<HeartbeatInfo>(JsonSerializerOptionsFactory.UnsafeSnakeCase)
            .Data?.HeartbeatInterval;
        botInstance.WebSocketService.HeartbeatInterval = heartbeatInterval ?? 0;
    }
}
