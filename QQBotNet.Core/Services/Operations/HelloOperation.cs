using QQBotNet.Core.Models.Packets.OpenApi;
using QQBotNet.Core.Models.Packets.WebSockets;
using QQBotNet.Core.Utils;
using System.Text.Json;
using System.Threading.Tasks;

namespace QQBotNet.Core.Services.Operations;

/// <summary>
/// <see cref="OperationCode.Hello"/>事件处理器
/// </summary>
[Operation(OperationCode.Hello)]
public class HelloOperation : IOperation
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
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
                            Token = $"{botInstance.BotAppId}.{botInstance.BotToken}",
                            Shard = new[] { 0, 1 },
                            Intents =
                                EventIntent.ForumEvent
                                | EventIntent.GuildMessages
                                | EventIntent.GuildMessageReactions,
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
