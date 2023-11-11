using QQBotNet.Core.Utils.Json;
using System;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace QQBotNet.Core.Services.Events;

/// <summary>
/// 机器人分发事件的事件参数
/// </summary>
public class BotDispatchEventReceivedEventArgs : BotDispatchEventReceivedEventArgs<JsonNode>
{
    internal BotDispatchEventReceivedEventArgs(
        DispatchEventType dispatchEventType,
        JsonNode? data,
        string? id
    )
    {
        Event = dispatchEventType;
        Id = id;
        Data = data;
    }
}

/// <summary>
/// 机器人分发事件的事件参数
/// </summary>
public class BotDispatchEventReceivedEventArgs<T> : EventArgs
{
    /// <summary>
    /// 内部构造函数
    /// </summary>
    protected internal BotDispatchEventReceivedEventArgs() { }

    internal BotDispatchEventReceivedEventArgs(
        DispatchEventType dispatchEventType,
        JsonNode? data,
        string? id
    )
    {
        Event = dispatchEventType;
        Id = id;
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

    /// <summary>
    /// 事件Id
    /// </summary>
    public string? Id { get; set; }
}
