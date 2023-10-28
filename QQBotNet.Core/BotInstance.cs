using QQBotNet.Core.Models;
using QQBotNet.Core.Services;
using QQBotNet.Core.Services.Apis;
using QQBotNet.Core.Services.Events;
using QQBotNet.Core.Utils.Extensions;
using System;
using System.Net.Http;

namespace QQBotNet.Core;

/// <summary>
/// 机器人实例
/// </summary>
public sealed class BotInstance : IDisposable
{
    /// <summary>
    /// WebSocket服务
    /// </summary>
    public WebSocketService WebSocketService;

    /// <summary>
    /// Http服务
    /// </summary>
    public HttpService HttpService;

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
    /// 机器人实例
    /// </summary>
    /// <param name="botAppId">开发者ID</param>
    /// <param name="botToken">机器人令牌</param>
    /// <param name="isSandbox">是否为沙箱环境</param>
    public BotInstance(uint botAppId, string botToken, bool isSandbox = false)
    {
        EnsureNotEmptyOrNull(botToken, nameof(botToken));

        BotAppId = botAppId;
        BotToken = botToken;
        IsSandbox = isSandbox;
        Invoker = new(this);
        HttpService = new(this, IsSandbox);

        try
        {
            WebSocketService = new(
                this,
                HttpService.GetWebSocketUrl().WaitResult()
                    ?? throw new NotSupportedException("机器人WebSocket地址为空")
            );
        }
        catch (Exception e)
        {
            throw new BotInstanceException("初始化失败", e);
        }
    }

    /// <summary>
    /// 异步启动
    /// </summary>
    public void Start()
    {
        WebSocketService.Start();
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public void Dispose()
    {
        HttpService?.Dispose();
        WebSocketService?.Dispose();
    }

    private static void EnsureNotEmptyOrNull(string? input, string paramName)
    {
        if (input is null)
            throw new ArgumentNullException(paramName);

        if (string.IsNullOrEmpty(input))
            throw new ArgumentException($"{paramName} can't be empty.", paramName);
    }
}
