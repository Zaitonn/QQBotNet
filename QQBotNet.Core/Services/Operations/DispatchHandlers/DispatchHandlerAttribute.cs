using System;

namespace QQBotNet.Core.Services.Operations.DispatchHandlers;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class DispatchHandlerAttribute : Attribute
{
    public DispatchHandlerAttribute(string eventType)
    {
        EventType = eventType;
    }

    public readonly string EventType;
}
