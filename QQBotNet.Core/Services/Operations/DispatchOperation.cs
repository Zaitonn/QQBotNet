using QQBotNet.Core.Entity.WebSockets;
using QQBotNet.Core.Services.Operations.DispatchHandlers;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Reflection;
using System;

namespace QQBotNet.Core.Services.Operations;

[Operation(OperationCode.Dispatch)]
public class DispatchOperation : IOperation
{
    private static readonly Dictionary<string, IOperation> _handlers = new();

    static DispatchOperation()
    {
        foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
        {
            var attribute = type.GetCustomAttribute<DispatchHandlerAttribute>();
            if (
                attribute is not null
                && type is not null
                && !_handlers.ContainsKey(attribute.EventType)
            )
            {
                _handlers.Add(attribute.EventType, (IOperation)Activator.CreateInstance(type)!);
            }
        }
    }

    public async Task HandleOperationAsync(IPacket packet, WebSocketService websocketService)
    {
        if (
            !string.IsNullOrEmpty(packet.Type)
            && _handlers.TryGetValue(packet.Type!, out IOperation? o)
        )
            await o.HandleOperationAsync(packet, websocketService);
    }
}
