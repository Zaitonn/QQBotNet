using System.Text.Json.Serialization;
using QQBotNet.OneBot.Models.Messages;

namespace QQBotNet.OneBot.Models.Events;

public class GroupMessageEvent : IEventPacket
{
    public ulong GroupId { get; set; }

    public ulong UserId { get; set; }

    public string PostType => "message";

    public string? MessageType { get; set; } = "group";

    public string? SubType => "normal";

    [JsonIgnore]
    public string? NoticeType => null;

    public string RawMessage { get; set; } = string.Empty;

    public object? Message { get; set; }

    public string MessageId { get; set; } = string.Empty;

    public Sender Sender { get; set; } = new();

    public static explicit operator GroupMessageEvent(GuildMessageEvent guildMessageEvent)
    {
        return new()
        {
            GroupId = ulong.TryParse(guildMessageEvent.ChannelId, out ulong i) ? i : 0,
            UserId = ulong.TryParse(guildMessageEvent.UserId, out i) ? i : 0,
            Message = guildMessageEvent.Message,
            RawMessage = guildMessageEvent.RawMessage,
            MessageId = guildMessageEvent.MessageId,
            Sender = guildMessageEvent.Sender
        };
    }
}
