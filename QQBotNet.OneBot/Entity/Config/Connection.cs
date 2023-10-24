namespace QQBotNet.OneBot.Entity.Config;

public class Connection
{
    public string Type { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string? Authorization { get; set; }
}
