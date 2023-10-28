using QQBotNet.Core.Models.Packets.WebSockets;
using System.Threading.Tasks;

namespace QQBotNet.Core.Services.Operations;

/// <summary>
/// 操作接口
/// </summary>
public interface IOperation
{
    /// <summary>
    /// 异步处理操作
    /// </summary>
    /// <param name="packet">数据包</param>
    /// <param name="botInstance">机器人实例</param>
    public Task HandleOperationAsync(IPacket packet, BotInstance botInstance);
}
