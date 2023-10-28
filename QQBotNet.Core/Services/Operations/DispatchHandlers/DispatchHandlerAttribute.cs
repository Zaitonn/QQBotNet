using System;

namespace QQBotNet.Core.Services.Operations.DispatchEvent;

/// <summary>
/// 分发事件属性
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class DispatchHandlerAttribute : Attribute
{
    internal DispatchHandlerAttribute(DispatchEventType dispatchEvent)
    {
        Event = dispatchEvent;
    }

    /// <summary>
    /// 分发事件类型
    /// </summary>
    public readonly DispatchEventType Event;
}
