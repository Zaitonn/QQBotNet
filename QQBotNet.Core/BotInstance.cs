using QQBotNet.Core.Entity;
using QQBotNet.Core.Services;
using QQBotNet.Core.Utils.Extensions;
using System;

namespace QQBotNet.Core;

public sealed class BotInstance : IDisposable
{
    public readonly WebSocketService WebSocketService;

    public readonly HttpService HttpService;

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
        BotInfo = new()
        {
            BotAppId = botAppId ?? throw new ArgumentNullException(nameof(botAppId)),
            BotToken = botToken ?? throw new ArgumentNullException(nameof(botToken)),
            BotSecret = botSecret ?? throw new ArgumentNullException(nameof(botSecret)),
        };

        IsSandbox = isSandbox;

        HttpService = new(BotInfo, IsSandbox);
        HttpService.Start();

        WebSocketService = new(BotInfo,HttpService.GetWebSocketUrl().WaitResult());
        WebSocketService.Start();
    }

    public void Dispose()
    {
        HttpService.Dispose();
        WebSocketService.Dispose();
    }
}
