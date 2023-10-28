using QQBotNet.Core.Models.Packets.OpenApi;
using QQBotNet.Core.Models.Packets.WebSockets;
using QQBotNet.Core.Utils;
using System.Text.Json;
using System.Threading.Tasks;

namespace QQBotNet.Core.Services.Operations.DispatchEvent;

/// <summary>
/// <see cref="DispatchEventType.READY"/>事件处理器
/// </summary>
[DispatchHandler(DispatchEventType.READY)]
public class ReadyHandler : IOperation
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public Task HandleOperationAsync(IPacket packet, BotInstance botInstance)
    {
        if (botInstance.WebSocketService is not null)
        {
            botInstance.WebSocketService.StartTimer();
            botInstance.WebSocketService.Session = JsonSerializer.Deserialize<Session>(
                packet.Data,
                JsonSerializerOptionsFactory.UnsafeSnakeCase
            );
        }
        return Task.CompletedTask;
    }
}
