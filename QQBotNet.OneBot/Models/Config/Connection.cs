namespace QQBotNet.OneBot.Models.Config;

public class Connection
{
    public bool Enable { get; set; }

    public string Type { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string? Authorization { get; set; }
}
