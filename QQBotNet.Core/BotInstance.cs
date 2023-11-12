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
    public WebSocketService WebSocketService { get; }

    /// <summary>
    /// Http服务
    /// </summary>
    public HttpService HttpService { get; }

    /// <summary>
    /// 事件调用器
    /// </summary>
    public EventDispatcher EventDispatcher { get; }

    /// <summary>
    /// 是否为沙箱环境
    /// </summary>
    public bool IsSandbox { get; }

    ///  <summary>
    /// 开发者ID
    /// </summary>
    public uint BotAppId { get; }

    internal readonly string BotToken;

    internal readonly string? AppSecret;

    /// <summary>
    /// WebSocket连接地址
    /// </summary>
    public string? WebSocketUrl => WebSocketService?.Url;

    /// <summary>
    /// 事件订阅intents
    /// </summary>
    public EventIntent EventIntents { get; }

    /// <summary>
    /// 使用v2的api验证
    /// </summary>
    public bool UseV2AppAccessToken { get; }

    /// <summary>
    /// 分片设置
    /// <br/>
    /// 新设定的值将在下一次重新连接中应用；你可以使用<see cref="WebSocketService.Stop()"/>断开连接并清空会话缓存后重连
    /// </summary>
    public int[]? Shard { get; set; }

    /// <summary>
    /// 机器人实例
    /// </summary>
    /// <param name="botAppId">开发者ID</param>
    /// <param name="botToken">机器人令牌</param>
    /// <param name="appSecret">机器人密钥，若提供则使用apiv2的验证方式</param>
    /// <param name="eventIntents">事件订阅intents</param>
    /// <param name="isSandbox">是否为沙箱环境</param>
    /// <param name="shard">分片设置</param>
    public BotInstance(
        uint botAppId,
        string botToken,
        string? appSecret = null,
        EventIntent eventIntents =
            EventIntent.ForumEvent
            | EventIntent.GuildMessages
            | EventIntent.GuildMessageReactions
            | EventIntent.GuildMembers
            | EventIntent.DirectMessage,
        bool isSandbox = false,
        int[]? shard = null
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
        AppSecret = appSecret;
        EventIntents = eventIntents;
        IsSandbox = isSandbox;
        Shard = shard;
        EventDispatcher = new(this);
        HttpService = new(this);

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
