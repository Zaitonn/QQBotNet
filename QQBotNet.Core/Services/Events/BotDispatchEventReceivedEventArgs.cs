using QQBotNet.Core.Services.Operations.DispatchEvent;
using QQBotNet.Core.Utils;
using System;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace QQBotNet.Core.Services.Events;

public class BotDispatchEventReceivedEventArgs : EventArgs
{
    internal BotDispatchEventReceivedEventArgs(DispatchEventType eventType, JsonNode? data)
    {
        Event = eventType;
        Data = data;
    }

    public readonly JsonNode? Data;

    public readonly DispatchEventType Event;
}

public class BotDispatchEventReceivedEventArgs<T> : EventArgs
{
    internal BotDispatchEventReceivedEventArgs(DispatchEventType eventType, JsonNode? data)
    {
        Event = eventType;
        Data = JsonSerializer.Deserialize<T>(data, JsonSerializerOptionsFactory.UnsafeSnakeCase);
    }

    public readonly T? Data;

    public readonly DispatchEventType Event;
}
