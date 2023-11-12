namespace QQBotNet.OneBot.Models.Events;

public interface IEventPacket
{
    public string PostType { get; }

    public string? NoticeType { get; }

    public string? MessageType { get; }

    public string? SubType { get; }
}
