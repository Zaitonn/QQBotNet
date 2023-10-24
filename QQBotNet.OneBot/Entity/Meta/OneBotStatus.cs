namespace QQBotNet.OneBot.Entity.Meta;

public class OneBotStatus
{
    public OneBotStatus(bool online, bool good)
    {
        Online = online;
        Good = good;
    }

    public bool AppInitialized { get; set; } = true;

    public bool AppEnabled { get; set; } = true;

    public bool AppGood { get; set; } = true;

    public bool Online { get; set; }

    public bool Good { get; set; }
}
