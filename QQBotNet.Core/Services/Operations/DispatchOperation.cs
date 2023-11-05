using QQBotNet.Core.Models.Packets.WebSockets;
using QQBotNet.Core.Services.Events;
using System.Threading.Tasks;
using System;
using System.Text.Json;
using QQBotNet.Core.Utils.Json;

namespace QQBotNet.Core.Services.Operations;

/// <summary>
/// <see cref="OperationCode.Dispatch"/>事件处理器
/// </summary>
[Operation(OperationCode.Dispatch)]
public class DispatchOperation : IOperation
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public Task HandleOperationAsync(BotInstance botInstance, Packet packet)
    {
        if (!Enum.TryParse(packet.Type, true, out DispatchEventType type))
            throw new NotSupportedException($"未知事件类型: {packet.Type}");

        switch (type)
        {
            case DispatchEventType.READY:
                if (botInstance.WebSocketService is not null)
                {
                    botInstance.WebSocketService.StartTimer();
                    botInstance.WebSocketService.Session = JsonSerializer.Deserialize<Session>(
                        packet.Data,
                        JsonSerializerOptionsFactory.UnsafeSnakeCase
                    );
                }
                break;

            case DispatchEventType.RESUMED:
                return Task.CompletedTask;

            default:
                botInstance.EventDispatcher.Dispatch(type, packet);
                break;
        }

        return Task.CompletedTask;
    }
}
