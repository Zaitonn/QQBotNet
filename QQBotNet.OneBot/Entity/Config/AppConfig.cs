using System;

namespace QQBotNet.OneBot.Entity.Config;

public class AppConfig
{
    public string BotAppId { get; set; } = string.Empty;

    public string BotToken { get; set; } = string.Empty;

    public string BotSecret { get; set; } = string.Empty;

    public bool UseEnvironmentVariables { get; set; }

    public bool Sandbox { get; set; }

    public Connection[] Connections { get; set; } = Array.Empty<Connection>();
}
