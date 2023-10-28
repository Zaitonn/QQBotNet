using System;

namespace QQBotNet.Core.Models;

/// <summary>
/// 机器人实例异常
/// </summary>
public class BotInstanceException : Exception
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public BotInstanceException(string? message, Exception? innerException = null)
        : base(message, innerException) { }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public BotInstanceException() { }
}
