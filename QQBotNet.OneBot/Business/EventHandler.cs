using QQBotNet.Core.Models.Business.Messages;
using QQBotNet.Core.Services.Events;
using QQBotNet.OneBot.Models.Events;
using QQBotNet.OneBot.Utils;

namespace QQBotNet.OneBot.Business;

public class EventHandler
{
    private readonly QQBotNetApp _app;

    public EventHandler(QQBotNetApp app)
    {
        _app = app;
    }

    public void HandleMessageCreated(object? sender, BotDispatchEventReceivedEventArgs<Message> e)
    {
        if (e.Data is null)
            return;

        var isPrivateMsg = e.Event == DispatchEventType.DIRECT_MESSAGE_CREATE;

        if (isPrivateMsg)
            Logger.Info<EventHandler>(
                $"收到子频道私聊({e.Data.GuildId}>{e.Data.ChannelId})消息 {e.Data.Author.Username}({e.Data.Author.Id}): {e.Data.Content}"
            );
        else
            Logger.Info<EventHandler>(
                $"收到子频道({e.Data.GuildId}>{e.Data.ChannelId})消息 {e.Data.Author.Username}({e.Data.Author.Id}): {e.Data.Content}"
            );

        var segments = SegmentBuilder.Parse(e.Data);

        var @event = new GuildMessageEvent
        {
            GuildId = e.Data.GuildId,
            ChannelId = e.Data.ChannelId,
            UserId = e.Data.Author.Id,
            MessageId = e.Data.Id,
            RawMessage = e.Data.Content ?? string.Empty,
            Message = _app.AppConfig.UseArrayAsPostFormat
                ? segments
                : segments.ToStringWithCQCode(),
            Sender =
            {
                UserId = ulong.TryParse(e.Data.Author.Id, out ulong i) ? i : 0,
                Avatar = e.Data.Author.Avatar,
                IsBot = e.Data.Author.Bot,
                NickName = e.Data.Author.Username,
                Roles = e.Data.Member.Roles,
                JoinedAt = e.Data.Member.JoinedAt,
            }
        };

        if (_app.AppConfig.ParseGuildAsGroup)
        {
            var groupEvent = (GroupMessageEvent)@event;
            groupEvent.MessageType = isPrivateMsg ? "private" : "group";
            _app.Broadcast(groupEvent);
        }
        else
            _app.Broadcast(@event);
    }
}
