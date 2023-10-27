namespace QQBotNet.Core.Models.Packets.OpenApi;

public class Session
{
    public int Version { get; set; }

    public string SessionId { get; set; } = string.Empty;

    public BotUser User { get; set; } = new();
}
