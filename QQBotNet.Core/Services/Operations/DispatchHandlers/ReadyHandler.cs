using QQBotNet.Core.Entity.Back;
using QQBotNet.Core.Entity.WebSockets;
using QQBotNet.Core.Utils;
using System.Text.Json;
using System.Threading.Tasks;

namespace QQBotNet.Core.Services.Operations.DispatchEvent;

[DispatchHandler(DispatchEventType.READY)]
public class ReadyHandler : IOperation
{
    public Task HandleOperationAsync(IPacket packet, BotInstance botInstance)
    {
        botInstance.WebSocketService?.StartTimer();
        botInstance.WebSocketService?.SetSession(
            JsonSerializer.Deserialize<Session>(packet.Data, JsonSerializerOptionsFactory.SnakeCase)
        );
        return Task.CompletedTask;
    }
}
