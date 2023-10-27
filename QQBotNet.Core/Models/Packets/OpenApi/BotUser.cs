namespace QQBotNet.Core.Models.Packets.OpenApi;

public class BotUser
{
    public string Id { get; set; } = string.Empty;

    public string Username { get; set; } = string.Empty;

    public bool Bot { get; set; }

    public int Status { get; set; }
}
