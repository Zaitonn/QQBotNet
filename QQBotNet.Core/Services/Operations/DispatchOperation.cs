using QQBotNet.Core.Models.Packets.WebSockets;
using QQBotNet.Core.Services.Operations.DispatchEvent;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Reflection;
using System;

namespace QQBotNet.Core.Services.Operations;

[Operation(OperationCode.Dispatch)]
public class DispatchOperation : IOperation
{
    private static readonly Dictionary<DispatchEventType, IOperation> _handlers = new();

    static DispatchOperation()
    {
        foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
        {
            var attribute = type.GetCustomAttribute<DispatchHandlerAttribute>();
            if (
                attribute is not null && type is not null && !_handlers.ContainsKey(attribute.Event)
            )
            {
                _handlers.Add(attribute.Event, (IOperation)Activator.CreateInstance(type)!);
            }
        }
    }

    public async Task HandleOperationAsync(IPacket packet, BotInstance botInstance)
    {
        if (!Enum.TryParse(packet.Type, true, out DispatchEventType result))
            throw new NotSupportedException($"未知事件类型: {packet.Type}");

        if (_handlers.TryGetValue(result, out IOperation? o))
            await o.HandleOperationAsync(packet, botInstance);
    }
}
