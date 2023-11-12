namespace QQBotNet.OneBot.Models.Events;

public interface IGuildEventPacket : IEventPacket
{
    public string GuildId { get; }

    public string ChannelId { get; }

    public string UserId { get; }
}
