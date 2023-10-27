using System;

namespace QQBotNet.Core.Services.Operations.DispatchEvent;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class DispatchHandlerAttribute : Attribute
{
    internal DispatchHandlerAttribute(DispatchEventType dispatchEvent)
    {
        Event = dispatchEvent;
    }

    public readonly DispatchEventType Event;
}
