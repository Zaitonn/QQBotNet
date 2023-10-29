using QQBotNet.Core.Services.Operations.DispatchEvent;
using QQBotNet.Core.Utils;
using System;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace QQBotNet.Core.Services.Events;

/// <summary>
/// 机器人分发事件的事件参数
/// </summary>
public class BotDispatchEventReceivedEventArgs : BotDispatchEventReceivedEventArgs<JsonNode>
{
    internal BotDispatchEventReceivedEventArgs(DispatchEventType eventType, JsonNode? data)
    {
        Event = eventType;
        Data = data;
    }
}

/// <summary>
/// 机器人分发事件的事件参数
/// </summary>
public class BotDispatchEventReceivedEventArgs<T> : EventArgs
{
    internal BotDispatchEventReceivedEventArgs() { }

    internal BotDispatchEventReceivedEventArgs(DispatchEventType eventType, JsonNode? data)
    {
        Event = eventType;
        Data = JsonSerializer.Deserialize<T>(data, JsonSerializerOptionsFactory.UnsafeSnakeCase);
    }

    /// <summary>
    /// 数据主体
    /// </summary>
    public T? Data { get; init; }

    /// <summary>
    /// 分发的事件类型
    /// </summary>
    public DispatchEventType Event { get; init; }
}
