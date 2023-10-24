using QQBotNet.Core.Entity.WebSockets;
using System;

namespace QQBotNet.Core.Entity.Send;

public class Identification
{
    /// <summary>
    /// 连接凭证
    /// </summary>
    public string Token { get; set; } = string.Empty;

    /// <summary>
    /// 此次连接所需要接收的事件
    /// </summary>
    public EventIntent Intents { get; set; }

    /// <summary>
    /// 分片逻辑
    /// </summary>
    public int[] Shard { get; set; } = Array.Empty<int>();
}
