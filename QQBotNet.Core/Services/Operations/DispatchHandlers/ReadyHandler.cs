using QQBotNet.Core.Entity.WebSockets;
using System.Threading.Tasks;

namespace QQBotNet.Core.Services.Operations.DispatchHandlers;

[DispatchHandler("READY")]
public class ReadyHandler : IOperation
{
    public Task HandleOperationAsync(IPacket packet, WebSocketService websocketService)
    {
        websocketService.StartTimer();
        return Task.CompletedTask;
    }
}
