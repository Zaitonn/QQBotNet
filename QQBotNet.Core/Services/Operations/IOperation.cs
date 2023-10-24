using System.Threading.Tasks;
using QQBotNet.Core.Entity.WebSockets;

namespace QQBotNet.Core.Services.Operations;

public interface IOperation
{
    /// <summary>
    /// 异步处理操作
    /// </summary>
    /// <param name="packet">数据包</param>
    /// <param name="botInstance">机器人实例</param>
    public Task HandleOperationAsync(IPacket packet, BotInstance botInstance);
}
