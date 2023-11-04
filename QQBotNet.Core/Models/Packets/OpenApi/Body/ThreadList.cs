using QQBotNet.Core.Models.Business.Forums;
using QQBotNet.Core.Utils.Json;
using System;
using System.Text.Json.Serialization;

namespace QQBotNet.Core.Models.Packets.OpenApi.Body;

/// <summary>
/// 帖子列表
/// </summary>
public class ThreadList
{
    /// <summary>
    /// 帖子列表对象
    /// </summary>
    public Thread[] Threads { get; set; } = Array.Empty<Thread>();

    /// <summary>
    /// 是否拉取完毕
    /// </summary>
    [JsonConverter(typeof(BooleanConverter))]
    public bool IsFinish { get; set; }
}
