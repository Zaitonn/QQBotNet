using System;

namespace QQBotNet.Core.Services.Operations.DispatchEvent;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class DispatchHandlerAttribute : Attribute
{
    public DispatchHandlerAttribute(DispatchEventType dispatchEvent)
    {
        Event = dispatchEvent;
    }

    public readonly DispatchEventType Event;
}
