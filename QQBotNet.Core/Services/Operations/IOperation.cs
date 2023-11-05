using QQBotNet.Core.Models.Packets.WebSockets;
using System.Threading.Tasks;

namespace QQBotNet.Core.Services.Operations;

internal interface IOperation
{
    /// <summary>
    /// 异步处理操作
    /// </summary>
    /// <param name="botInstance">机器人实例</param>
    /// <param name="packet">数据包</param>
    public Task HandleOperationAsync(BotInstance botInstance, Packet packet);
}
