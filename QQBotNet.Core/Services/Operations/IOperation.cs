using System.Threading.Tasks;
using QQBotNet.Core.Entity.WebSockets;

namespace QQBotNet.Core.Services.Operations;

public interface IOperation
{
    public void HandleOperation(Packet packet, WebSocketService websocketService);
}
