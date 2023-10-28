using QQBotNet.Core.Services;
using QQBotNet.Core.Services.Events;
using System;

namespace QQBotNet.Core;

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
    /// 机器人密钥
    /// </summary>
    public readonly string BotSecret;

    /// <summary>
    /// WebSocket连接地址
    /// </summary>
    public string? WebSocketUrl => WebSocketService?.Url;

    /// <summary>
    /// 机器人实例
    /// </summary>
    /// <param name="botAppId">开发者ID</param>
    /// <param name="botToken">机器人令牌</param>
    /// <param name="botSecret">机器人密钥</param>
    /// <param name="isSandbox">是否为沙箱环境</param>
    public BotInstance(uint botAppId, string botToken, string botSecret, bool isSandbox = false)
    {
        EnsureNotEmptyOrNull(botToken, nameof(botToken));
        EnsureNotEmptyOrNull(botSecret, nameof(botSecret));

        BotAppId = botAppId;
        BotToken = botToken;
        BotSecret = botSecret;
        IsSandbox = isSandbox;
        Invoker = new(this);
        HttpService = new(this, IsSandbox);
        WebSocketService = new(this, HttpService.GetWebSocketUrl().GetAwaiter().GetResult());
    }

    /// <summary>
    /// 异步启动
    /// </summary>
    public void Start()
    {
        WebSocketService.Start();
    }

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
