using QQBotNet.Core.Models.Business.Action;
using QQBotNet.Core.Models.Business.Audio;
using QQBotNet.Core.Models.Business.Channels;
using QQBotNet.Core.Models.Business.Forums;
using QQBotNet.Core.Models.Business.Guilds;
using QQBotNet.Core.Models.Business.Members;
using QQBotNet.Core.Models.Business.Messages;
using QQBotNet.Core.Models.Business.Reactions;
using QQBotNet.Core.Models.Packets.WebSockets;
using System;
using WebSocket4Net;

namespace QQBotNet.Core.Services.Events;

/// <summary>
/// 事件分发
/// </summary>
public sealed class EventDispatcher
{
    internal EventDispatcher(BotInstance botInstance)
    {
        _botInstance = botInstance;
    }

    private readonly BotInstance _botInstance;

    /// <summary>
    /// WebSocket开启
    /// </summary>
    public event EventHandler? WebSocketOpened;

    internal void OnWebSocketOpened()
    {
        WebSocketOpened?.Invoke(_botInstance, new());
    }

    /// <summary>
    /// WebSocket关闭
    /// </summary>
    public event EventHandler? WebSocketClosed;

    internal void OnWebSocketClosed()
    {
        WebSocketClosed?.Invoke(_botInstance, new());
    }

    /// <summary>
    /// WebSocket重连
    /// </summary>
    public event EventHandler? WebSocketReconnect;

    internal void OnWebSocketReconnect()
    {
        WebSocketReconnect?.Invoke(_botInstance, new());
    }

    /// <summary>
    /// 接收到消息
    /// </summary>
    public event EventHandler<MessageReceivedEventArgs>? WebSocketRawMessageReceived;

    internal void OnWebSocketRawMessageReceived(MessageReceivedEventArgs e)
    {
        WebSocketRawMessageReceived?.Invoke(_botInstance, e);
    }

    /// <summary>
    /// 发送数据包
    /// </summary>
    public event EventHandler<PacketEventArgs>? PacketSent;

    internal void OnPacketSent(PacketEventArgs e)
    {
        PacketSent?.Invoke(_botInstance, e);
    }

    /// <summary>
    /// 收到数据包
    /// </summary>
    public event EventHandler<PacketEventArgs>? PacketReceived;

    internal void OnPacketReceived(PacketEventArgs e)
    {
        PacketReceived?.Invoke(_botInstance, e);
    }

    /// <summary>
    /// 发送心跳事件
    /// </summary>
    public event EventHandler? Heartbeat;

    internal void OnHeartbeat()
    {
        Heartbeat?.Invoke(_botInstance, new());
    }

    /// <summary>
    /// 接收到调度事件
    /// </summary>
    public event EventHandler<BotDispatchEventReceivedEventArgs>? BotDispatchEventReceived;

    /// <summary>
    /// 发生异常
    /// </summary>
    public event EventHandler<Exception>? Exception;

    internal void OnException(Exception e)
    {
        try
        {
            Exception?.Invoke(_botInstance, e);
        }
        catch { }
    }

    #region 调度事件

    /// <summary>
    /// 接收到以下音频调度事件
    /// <br/>
    /// - <see cref="DispatchEventType.AUDIO_START"/><br/>
    /// - <see cref="DispatchEventType.AUDIO_FINISH"/><br/>
    /// - <see cref="DispatchEventType.AUDIO_ON_MIC"/><br/>
    /// - <see cref="DispatchEventType.AUDIO_OFF_MIC"/><br/>
    /// </summary>
    public event EventHandler<BotDispatchEventReceivedEventArgs<AudioAction>>? AudioUpdated;

    /// <summary>
    /// 接收到以下音视频/直播子频道成员进出调度事件
    /// <br/>
    /// - <see cref="DispatchEventType.AUDIO_OR_LIVE_CHANNEL_MEMBER_ENTER"/><br/>
    /// - <see cref="DispatchEventType.AUDIO_OR_LIVE_CHANNEL_MEMBER_EXIT"/><br/>
    /// </summary>
    public event EventHandler<
        BotDispatchEventReceivedEventArgs<MemberWithGuildIdAndChannelId>
    >? AudioMemberUpdated;

    /// <summary>
    /// 接收到以下子频道调度事件
    /// <br/>
    /// - <see cref="DispatchEventType.CHANNEL_CREATE"/><br/>
    /// - <see cref="DispatchEventType.CHANNEL_DELETE"/><br/>
    /// - <see cref="DispatchEventType.CHANNEL_UPDATE"/><br/>
    /// </summary>
    public event EventHandler<BotDispatchEventReceivedEventArgs<Channel>>? ChannelChanged;

    /// <summary>
    /// 接收到以下主题调度事件
    /// <br/>
    /// - <see cref="DispatchEventType.FORUM_THREAD_CREATE"/><br/>
    /// - <see cref="DispatchEventType.FORUM_THREAD_DELETE"/><br/>
    /// - <see cref="DispatchEventType.FORUM_THREAD_UPDATE"/><br/>
    /// - <see cref="DispatchEventType.OPEN_FORUM_THREAD_CREATE"/><br/>
    /// - <see cref="DispatchEventType.OPEN_FORUM_THREAD_DELETE"/><br/>
    /// - <see cref="DispatchEventType.OPEN_FORUM_THREAD_UPDATE"/><br/>
    /// </summary>
    public event EventHandler<BotDispatchEventReceivedEventArgs<Thread>>? ThreadChanged;

    /// <summary>
    /// 接收到以下帖子调度事件
    /// <br/>
    /// - <see cref="DispatchEventType.FORUM_POST_CREATE"/><br/>
    /// - <see cref="DispatchEventType.FORUM_POST_DELETE"/><br/>
    /// - <see cref="DispatchEventType.OPEN_FORUM_POST_CREATE"/><br/>
    /// - <see cref="DispatchEventType.OPEN_FORUM_POST_DELETE"/><br/>
    /// </summary>
    public event EventHandler<BotDispatchEventReceivedEventArgs<Post>>? PostUpdated;

    /// <summary>
    /// 接收到以下回复调度事件
    /// <br/>
    /// - <see cref="DispatchEventType.FORUM_REPLY_CREATE"/><br/>
    /// - <see cref="DispatchEventType.FORUM_REPLY_DELETE"/><br/>
    /// - <see cref="DispatchEventType.OPEN_FORUM_REPLY_CREATE"/><br/>
    /// - <see cref="DispatchEventType.OPEN_FORUM_REPLY_DELETE"/><br/>
    /// </summary>
    public event EventHandler<BotDispatchEventReceivedEventArgs<Reply>>? ReplyUpdated;

    /// <summary>
    /// 接收到以下帖子审核调度事件
    /// <br/>
    /// - <see cref="DispatchEventType.FORUM_PUBLISH_AUDIT_RESULT"/><br/>
    /// - <see cref="DispatchEventType.OPEN_FORUM_PUBLISH_AUDIT_RESULT"/><br/>
    /// </summary>
    public event EventHandler<BotDispatchEventReceivedEventArgs<AuditResult>>? ForumAudited;

    /// <summary>
    /// 接收到以下频道调度事件
    /// <br/>
    /// - <see cref="DispatchEventType.GUILD_CREATE"/><br/>
    /// - <see cref="DispatchEventType.GUILD_DELETE"/><br/>
    /// - <see cref="DispatchEventType.GUILD_UPDATE"/><br/>
    /// </summary>
    public event EventHandler<BotDispatchEventReceivedEventArgs<Guild>>? GuildChanged;

    /// <summary>
    /// 接收到以下频道成员调度事件
    /// <br/>
    /// - <see cref="DispatchEventType.GUILD_MEMBER_ADD"/><br/>
    /// - <see cref="DispatchEventType.GUILD_MEMBER_REMOVE"/><br/>
    /// - <see cref="DispatchEventType.GUILD_MEMBER_UPDATE"/><br/>
    /// </summary>
    public event EventHandler<BotDispatchEventReceivedEventArgs<MemberWithGuildId>>? MemberChanged;

    /// <summary>
    /// 接收到以下调度事件
    /// <br/>
    /// - <see cref="DispatchEventType.MESSAGE_CREATE"/><br/>
    /// - <see cref="DispatchEventType.DIRECT_MESSAGE_CREATE"/><br/>
    /// - <see cref="DispatchEventType.AT_MESSAGE_CREATE"/>
    /// </summary>
    public event EventHandler<BotDispatchEventReceivedEventArgs<Message>>? MessageCreated;

    /// <summary>
    /// 接收到以下调度事件
    /// <br/>
    /// - <see cref="DispatchEventType.MESSAGE_DELETE"/><br/>
    /// - <see cref="DispatchEventType.DIRECT_MESSAGE_DELETE"/><br/>
    /// - <see cref="DispatchEventType.PUBLIC_MESSAGE_DELETE"/>
    /// </summary>
    public event EventHandler<BotDispatchEventReceivedEventArgs<Message>>? MessageDeleted;

    /// <summary>
    /// 接收到以下消息审核调度事件
    /// <br/>
    /// - <see cref="DispatchEventType.MESSAGE_AUDIT_PASS"/><br/>
    /// - <see cref="DispatchEventType.MESSAGE_AUDIT_REJECT"/>
    /// </summary>
    public event EventHandler<BotDispatchEventReceivedEventArgs<Message>>? MessageAudited;

    /// <summary>
    /// 接收到以下表情表态调度事件
    /// <br/>
    /// - <see cref="DispatchEventType.MESSAGE_REACTION_ADD"/><br/>
    /// - <see cref="DispatchEventType.MESSAGE_REACTION_REMOVE"/><br/>
    /// </summary>
    public event EventHandler<BotDispatchEventReceivedEventArgs<MessageReaction>>? ReactionUpdated;

    /// <summary>
    /// 接收到以下群聊消息调度事件
    /// <br/>
    /// - <see cref="DispatchEventType.GROUP_AT_MESSAGE_CREATE"/><br/>
    /// </summary>
    public event EventHandler<BotDispatchEventReceivedEventArgs<MessageV2>>? GroupAtMessageCreated;

    /// <summary>
    /// 接收到以下私聊消息调度事件
    /// <br/>
    /// - <see cref="DispatchEventType.C2C_MESSAGE_CREATE"/><br/>
    /// </summary>
    public event EventHandler<BotDispatchEventReceivedEventArgs<MessageV2>>? C2CMessageCreated;

    /// <summary>
    /// 接收到以下群聊调度事件
    /// <br/>
    /// - <see cref="DispatchEventType.GROUP_ADD_ROBOT"/><br/>
    /// - <see cref="DispatchEventType.GROUP_DEL_ROBOT"/><br/>
    /// - <see cref="DispatchEventType.GROUP_MSG_RECEIVE"/><br/>
    /// - <see cref="DispatchEventType.GROUP_MSG_REJECT"/><br/>
    /// </summary>
    public event EventHandler<BotDispatchEventReceivedEventArgs<GroupAction>>? GroupUpdated;

    /// <summary>
    /// 接收到以下私聊调度事件
    /// <br/>
    /// - <see cref="DispatchEventType.FRIEND_ADD"/><br/>
    /// - <see cref="DispatchEventType.FRIEND_DEL"/><br/>
    /// - <see cref="DispatchEventType.C2C_MSG_RECEIVE"/><br/>
    /// - <see cref="DispatchEventType.C2C_MSG_REJECT"/><br/>
    /// </summary>
    public event EventHandler<BotDispatchEventReceivedEventArgs<C2CAction>>? C2CUpdated;

    #endregion

    internal void Dispatch(DispatchEventType dispatchEventType, Packet packet)
    {
        BotDispatchEventReceived?.Invoke(
            _botInstance,
            new(dispatchEventType, packet.Data, packet.Id)
        );

        switch (dispatchEventType)
        {
            case DispatchEventType.GUILD_CREATE:
            case DispatchEventType.GUILD_UPDATE:
            case DispatchEventType.GUILD_DELETE:
                GuildChanged?.Invoke(_botInstance, new(dispatchEventType, packet.Data, packet.Id));
                break;

            case DispatchEventType.CHANNEL_CREATE:
            case DispatchEventType.CHANNEL_UPDATE:
            case DispatchEventType.CHANNEL_DELETE:
                ChannelChanged?.Invoke(
                    _botInstance,
                    new(dispatchEventType, packet.Data, packet.Id)
                );
                break;

            case DispatchEventType.GUILD_MEMBER_ADD:
            case DispatchEventType.GUILD_MEMBER_UPDATE:
            case DispatchEventType.GUILD_MEMBER_REMOVE:
                MemberChanged?.Invoke(_botInstance, new(dispatchEventType, packet.Data, packet.Id));
                break;

            case DispatchEventType.DIRECT_MESSAGE_CREATE:
            case DispatchEventType.MESSAGE_CREATE:
            case DispatchEventType.AT_MESSAGE_CREATE:
                MessageCreated?.Invoke(
                    _botInstance,
                    new(dispatchEventType, packet.Data, packet.Id)
                );
                break;

            case DispatchEventType.DIRECT_MESSAGE_DELETE:
            case DispatchEventType.MESSAGE_DELETE:
            case DispatchEventType.PUBLIC_MESSAGE_DELETE:
                MessageDeleted?.Invoke(
                    _botInstance,
                    new(dispatchEventType, packet.Data, packet.Id)
                );
                break;

            case DispatchEventType.MESSAGE_AUDIT_PASS:
            case DispatchEventType.MESSAGE_AUDIT_REJECT:
                MessageAudited?.Invoke(
                    _botInstance,
                    new(dispatchEventType, packet.Data, packet.Id)
                );
                break;

            case DispatchEventType.MESSAGE_REACTION_ADD:
            case DispatchEventType.MESSAGE_REACTION_REMOVE:
                ReactionUpdated?.Invoke(
                    _botInstance,
                    new(dispatchEventType, packet.Data, packet.Id)
                );
                break;

            case DispatchEventType.FORUM_THREAD_CREATE:
            case DispatchEventType.FORUM_THREAD_UPDATE:
            case DispatchEventType.FORUM_THREAD_DELETE:
            case DispatchEventType.OPEN_FORUM_THREAD_CREATE:
            case DispatchEventType.OPEN_FORUM_THREAD_UPDATE:
            case DispatchEventType.OPEN_FORUM_THREAD_DELETE:
                ThreadChanged?.Invoke(_botInstance, new(dispatchEventType, packet.Data, packet.Id));
                break;

            case DispatchEventType.FORUM_POST_CREATE:
            case DispatchEventType.FORUM_POST_DELETE:
            case DispatchEventType.OPEN_FORUM_POST_CREATE:
            case DispatchEventType.OPEN_FORUM_POST_DELETE:
                PostUpdated?.Invoke(_botInstance, new(dispatchEventType, packet.Data, packet.Id));
                break;

            case DispatchEventType.FORUM_REPLY_CREATE:
            case DispatchEventType.FORUM_REPLY_DELETE:
            case DispatchEventType.OPEN_FORUM_REPLY_CREATE:
            case DispatchEventType.OPEN_FORUM_REPLY_DELETE:
                ReplyUpdated?.Invoke(_botInstance, new(dispatchEventType, packet.Data, packet.Id));
                break;

            case DispatchEventType.FORUM_PUBLISH_AUDIT_RESULT:
            case DispatchEventType.OPEN_FORUM_PUBLISH_AUDIT_RESULT:
                ForumAudited?.Invoke(_botInstance, new(dispatchEventType, packet.Data, packet.Id));
                break;

            case DispatchEventType.AUDIO_START:
            case DispatchEventType.AUDIO_FINISH:
            case DispatchEventType.AUDIO_ON_MIC:
            case DispatchEventType.AUDIO_OFF_MIC:
                AudioUpdated?.Invoke(_botInstance, new(dispatchEventType, packet.Data, packet.Id));
                break;

            case DispatchEventType.AUDIO_OR_LIVE_CHANNEL_MEMBER_ENTER:
            case DispatchEventType.AUDIO_OR_LIVE_CHANNEL_MEMBER_EXIT:
                AudioMemberUpdated?.Invoke(
                    _botInstance,
                    new(dispatchEventType, packet.Data, packet.Id)
                );
                break;

            case DispatchEventType.GROUP_AT_MESSAGE_CREATE:
                GroupAtMessageCreated?.Invoke(
                    _botInstance,
                    new(dispatchEventType, packet.Data, packet.Id)
                );
                break;

            case DispatchEventType.C2C_MESSAGE_CREATE:
                C2CMessageCreated?.Invoke(
                    _botInstance,
                    new(dispatchEventType, packet.Data, packet.Id)
                );
                break;

            case DispatchEventType.GROUP_ADD_ROBOT:
            case DispatchEventType.GROUP_DEL_ROBOT:
            case DispatchEventType.GROUP_MSG_REJECT:
            case DispatchEventType.GROUP_MSG_RECEIVE:
                GroupUpdated?.Invoke(_botInstance, new(dispatchEventType, packet.Data, packet.Id));
                break;

            case DispatchEventType.FRIEND_ADD:
            case DispatchEventType.FRIEND_DEL:
            case DispatchEventType.C2C_MSG_REJECT:
            case DispatchEventType.C2C_MSG_RECEIVE:
                C2CUpdated?.Invoke(_botInstance, new(dispatchEventType, packet.Data, packet.Id));
                break;

            case DispatchEventType.NULL:
            case DispatchEventType.READY:
            case DispatchEventType.RESUMED:
            case DispatchEventType.INTERACTION_CREATE:
            default:
                throw new NotSupportedException();
        }
    }
}
