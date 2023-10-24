using QQBotNet.Core.Services.Operations.DispatchEvent;
using System;
using System.Text.Json.Nodes;

namespace QQBotNet.Core.Services.Events;

public class BotDispatchEventReceivedEventArgs : EventArgs
{
    public BotDispatchEventReceivedEventArgs(DispatchEventType eventType, JsonNode? data)
    {
        Event = eventType;
        Data = data;
    }

    public readonly JsonNode? Data;

    public readonly DispatchEventType Event;
}
