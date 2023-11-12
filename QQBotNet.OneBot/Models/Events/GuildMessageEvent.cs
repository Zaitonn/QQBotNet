using QQBotNet.OneBot.Models.Messages;
using System.Text.Json.Serialization;

namespace QQBotNet.OneBot.Models.Events;

public class GuildMessageEvent : IGuildEventPacket
{
    public string GuildId { get; set; } = string.Empty;

    public string ChannelId { get; set; } = string.Empty;

    public string UserId { get; set; } = string.Empty;

    public string PostType => "message";

    public string? MessageType => "guild";

    public string? SubType => "channel";

    [JsonIgnore]
    public string? NoticeType => null;

    public string RawMessage { get; set; } = string.Empty;

    public object? Message { get; set; }

    public string MessageId { get; set; } = string.Empty;

    public Sender Sender { get; set; } = new();
}
