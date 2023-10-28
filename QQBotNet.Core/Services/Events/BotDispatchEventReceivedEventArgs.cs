using QQBotNet.Core.Services.Operations.DispatchEvent;
using QQBotNet.Core.Utils;
using System;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace QQBotNet.Core.Services.Events;

/// <summary>
/// 机器人分发事件的事件参数
/// </summary>
public class BotDispatchEventReceivedEventArgs : EventArgs
{
    internal BotDispatchEventReceivedEventArgs(DispatchEventType eventType, JsonNode? data)
    {
        Event = eventType;
        Data = data;
    }

    /// <summary>
    /// 数据主体
    /// </summary>
    public readonly JsonNode? Data;

    /// <summary>
    /// 分发的事件类型
    /// </summary>
    public readonly DispatchEventType Event;
}

/// <summary>
/// 机器人分发事件的事件参数
/// </summary>
public class BotDispatchEventReceivedEventArgs<T> : EventArgs
{
    internal BotDispatchEventReceivedEventArgs(DispatchEventType eventType, JsonNode? data)
    {
        Event = eventType;
        Data = JsonSerializer.Deserialize<T>(data, JsonSerializerOptionsFactory.UnsafeSnakeCase);
    }

    /// <summary>
    /// 数据主体
    /// </summary>
    public readonly T? Data;

    /// <summary>
    /// 分发的事件类型
    /// </summary>
    public readonly DispatchEventType Event;
}
