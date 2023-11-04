using QQBotNet.Core.Models;
using QQBotNet.Core.Models.Packets.WebSockets;
using QQBotNet.Core.Services;
using QQBotNet.Core.Services.Apis;
using QQBotNet.Core.Services.Events;
using QQBotNet.Core.Utils.Extensions;
using System;

namespace QQBotNet.Core;

/// <summary>
/// 机器人实例
/// </summary>
public sealed class BotInstance : IDisposable
{
    /// <summary>
    /// WebSocket服务
    /// </summary>
    public readonly WebSocketService WebSocketService;

    /// <summary>
    /// Http服务
    /// </summary>
    public readonly HttpService HttpService;

    /// <summary>
    /// 事件调用器
    /// </summary>
    public readonly EventInvoker Invoker;

    /// <summary>
    /// 是否为沙箱环境
    /// </summary>
    public readonly bool IsSandbox;

    ///  <summary>
    /// 开发者ID
    /// </summary>
    public readonly uint BotAppId;

    /// <summary>
    /// 机器人令牌
    /// </summary>
    public readonly string BotToken;

    /// <summary>
    /// WebSocket连接地址
    /// </summary>
    public string? WebSocketUrl => WebSocketService?.Url;

    /// <summary>
    /// 事件订阅intents
    /// </summary>
    public readonly EventIntent EventIntents;

    /// <summary>
    /// 机器人实例
    /// </summary>
    /// <param name="botAppId">开发者ID</param>
    /// <param name="botToken">机器人令牌</param>
    /// <param name="eventIntents">事件订阅intents</param>
    /// /// <param name="isSandbox">是否为沙箱环境</param>
    public BotInstance(
        uint botAppId,
        string botToken,
        EventIntent eventIntents =
            EventIntent.ForumEvent
            | EventIntent.GuildMessages
            | EventIntent.GuildMessageReactions
            | EventIntent.GuildMembers,
        bool isSandbox = false
    )
    {
        if (botAppId == 0)
            throw new ArgumentOutOfRangeException(nameof(botAppId));

        if (botToken is null)
            throw new ArgumentNullException(nameof(botToken));

        if (string.IsNullOrEmpty(botToken))
            throw new ArgumentException($"{nameof(botToken)} 不能为空", nameof(botToken));

        BotAppId = botAppId;
        BotToken = botToken;
        EventIntents = eventIntents;
        IsSandbox = isSandbox;
        Invoker = new(this);
        HttpService = new(this, IsSandbox);

        try
        {
            WebSocketService = new(
                this,
                HttpService.GetWebSocketUrlAsync().WaitResult().Data?.Url
                    ?? throw new NotSupportedException("机器人WebSocket地址为空")
            );
        }
        catch (Exception e)
        {
            throw new BotInstanceException("初始化失败", e);
        }
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public void Dispose()
    {
        HttpService?.Dispose();
        WebSocketService?.Dispose();
    }
}
