using QQBotNet.Core.Entity;
using QQBotNet.Core.Services;
using System;
using System.Threading.Tasks;

namespace QQBotNet.Core;

public sealed class BotInstance : IDisposable
{
    public WebSocketService? WebSocketService { get; private set; }

    public HttpService? HttpService { get; private set; }

    public readonly bool IsSandbox;

    internal readonly SensitiveInfo BotInfo;

    /// <summary>
    /// 机器人实例
    /// </summary>
    /// <param name="botAppId">开发者ID</param>
    /// <param name="botToken">机器人令牌</param>
    /// <param name="botSecret">机器人密钥</param>
    /// <param name="isSandbox">是否为沙箱环境</param>
    public BotInstance(string botAppId, string botToken, string botSecret, bool isSandbox = false)
    {
        EnsureNotEmptyOrNull(botAppId, nameof(botAppId));
        EnsureNotEmptyOrNull(botToken, nameof(botToken));
        EnsureNotEmptyOrNull(botSecret, nameof(botSecret));

        BotInfo = new()
        {
            BotAppId = botAppId,
            BotToken = botToken,
            BotSecret = botSecret
        };

        IsSandbox = isSandbox;
    }

    /// <summary>
    /// 异步启动
    /// </summary>
    public async Task StartAsync()
    {
        HttpService = new(BotInfo, IsSandbox);
        HttpService.Start();

        WebSocketService = new(BotInfo, await HttpService.GetWebSocketUrl());
        WebSocketService.Start();
    }

    public void Dispose()
    {
        HttpService?.Dispose();
        WebSocketService?.Dispose();
    }

    private static void EnsureNotEmptyOrNull(string? input, string name)
    {
        if (input is null)
            throw new ArgumentNullException(name);

        if (string.IsNullOrEmpty(input))
            throw new ArgumentException($"{name} can't be empty.", name);
    }
}
