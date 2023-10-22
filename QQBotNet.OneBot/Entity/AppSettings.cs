namespace QQBotNet.OneBot.Entity;

public class AppSettings
{
    public string BotAppId { get; set; } = string.Empty;

    public string BotToken { get; set; } = string.Empty;

    public string BotSecret { get; set; } = string.Empty;

    public bool Sandbox { get; set; }
}
