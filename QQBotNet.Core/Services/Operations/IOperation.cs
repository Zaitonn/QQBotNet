using QQBotNet.Core.Models.Packets.WebSockets;
using System.Threading.Tasks;

namespace QQBotNet.Core.Services.Operations;

internal interface IOperation
{
    public Task HandleOperationAsync(BotInstance botInstance, Packet packet);
}
