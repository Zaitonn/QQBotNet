using System;

namespace QQBotNet.OneBot.Models.Config;

public class AppConfig
{
    public BotInfo BotInfo { get; set; } = new();

    public bool UseEnvironmentVariables { get; set; }

    public bool Sandbox { get; set; }

    public Connection[] Connections { get; set; } = Array.Empty<Connection>();

    public bool DebugLog { get; set; }
}
