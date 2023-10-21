namespace QQBotNet.Core.Entity;

public readonly struct SensitiveInfo
{
    public string BotAppId { get; init; }

    public string BotToken { get; init; }

    public string BotSecret { get; init; }
}
