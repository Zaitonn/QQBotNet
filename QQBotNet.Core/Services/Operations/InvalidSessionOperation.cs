using QQBotNet.Core.Models.Packets.WebSockets;
using System.Threading.Tasks;

namespace QQBotNet.Core.Services.Operations;

[OperationHandler(OperationCode.InvalidSession)]
internal class InvalidSessionOperation : IOperation
{
    public Task HandleOperationAsync(BotInstance botInstance, Packet packet)
    {
        botInstance.WebSocketService.Session = null;
        return Task.CompletedTask;
    }
}
