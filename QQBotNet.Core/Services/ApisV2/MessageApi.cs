using QQBotNet.Core.Models.Business.Messages;
using QQBotNet.Core.Models.Packets.OpenApi;
using QQBotNet.Core.Utils.Json;
using QQBotNet.Core.Utils.Extensions;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System;

namespace QQBotNet.Core.Services.ApisV2;

/// <summary>
/// 消息Api
/// </summary>
public static class MessageApi
{
    private static async Task<HttpPacket<MessageResult>> SendMessageAsync(
        this HttpService httpService,
        string openid,
        bool isToUser,
        string? content = null,
        int msgType = 0,
        string? msgId = null,
        string? eventId = null,
        int msgSeq = 1,
        MessageEmbed? messageEmbed = null,
        MessageArk? messageArk = null,
        MessageReference? messageReference = null,
        MessageMarkdown? messageMarkdown = null,
        MessageKeyboard? messageKeyboard = null
    )
    {
        var body = new JsonObject
        {
            { "content", content },
            { "msg_id", msgId },
            { "event_id", eventId },
            {
                "markdown",
                JsonSerializer.SerializeToNode(
                    messageMarkdown,
                    JsonSerializerOptionsFactory.UnsafeSnakeCaseAndIgnoreNull
                )
            },
            {
                "embed",
                JsonSerializer.SerializeToNode(
                    messageEmbed,
                    JsonSerializerOptionsFactory.UnsafeSnakeCaseAndIgnoreNull
                )
            },
            {
                "ark",
                JsonSerializer.SerializeToNode(
                    messageArk,
                    JsonSerializerOptionsFactory.UnsafeSnakeCaseAndIgnoreNull
                )
            },
            {
                "message_reference",
                JsonSerializer.SerializeToNode(
                    messageReference,
                    JsonSerializerOptionsFactory.UnsafeSnakeCaseAndIgnoreNull
                )
            },
            {
                "keyboard",
                JsonSerializer.SerializeToNode(
                    messageKeyboard,
                    JsonSerializerOptionsFactory.UnsafeSnakeCaseAndIgnoreNull
                )
            },
            { "event_id", eventId },
            { "msg_id", msgId },
            { "msg_seq", msgSeq },
            { "msg_type", msgType },
        };

        return await httpService.HttpClient.RequestJson<MessageResult>(
            HttpMethod.Post,
            $"/v2/{(isToUser ? "users" : "groups")}/{openid.Encode()}/messages",
            body,
            true
        );
    }

    #region 用户

    /// <summary>
    /// 发送消息
    /// <br/>
    /// 单独发动消息给用户
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api-231017/server-inter/message/send-receive/send.html#%E5%8D%95%E8%81%8A</see>
    /// <br/>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="openid">QQ 用户的 openid</param>
    /// <param name="content">消息内容</param>
    /// <param name="msgId">前置收到的消息ID，用于发送被动消息</param>
    /// <param name="eventId">【暂未支持】前置收到的事件ID，用于发送被动消息</param>
    /// <param name="msgSeq">回复消息的序号，与 msg_id 联合使用，避免相同消息id回复重复发送，不填默认是1。相同的 msg_id + msg_seq 重复发送会失败</param>
    /// <returns><see cref="Message"/></returns>
    public static async Task<HttpPacket<MessageResult>> SendMessageToUserAsync(
        this HttpService httpService,
        string openid,
        string content,
        string? msgId = null,
        string? eventId = null,
        int msgSeq = 1
    )
    {
        return await httpService.SendMessageAsync(
            openid,
            false,
            content,
            0,
            msgId,
            eventId,
            msgSeq
        );
    }

    /// <summary>
    /// 发送markdown消息
    /// <br/>
    /// 单独发动消息给用户
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api-231017/server-inter/message/send-receive/send.html#%E5%8D%95%E8%81%8A</see>
    /// <br/>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="openid">QQ 用户的 openid</param>
    /// <param name="messageMarkdown">markdown类型消息</param>
    /// <param name="msgId">前置收到的消息ID，用于发送被动消息</param>
    /// <param name="eventId">【暂未支持】前置收到的事件ID，用于发送被动消息</param>
    /// <param name="msgSeq">回复消息的序号，与 msg_id 联合使用，避免相同消息id回复重复发送，不填默认是1。相同的 msg_id + msg_seq 重复发送会失败</param>
    /// <returns><see cref="Message"/></returns>
    public static async Task<HttpPacket<MessageResult>> SendMessageToUserAsync(
        this HttpService httpService,
        string openid,
        MessageMarkdown messageMarkdown,
        string? msgId = null,
        string? eventId = null,
        int msgSeq = 1
    )
    {
        return await httpService.SendMessageAsync(
            openid,
            false,
            null,
            2,
            msgId,
            eventId,
            msgSeq,
            messageMarkdown: messageMarkdown
        );
    }

    /// <summary>
    /// 发送ark消息
    /// <br/>
    /// 单独发动消息给用户
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api-231017/server-inter/message/send-receive/send.html#%E5%8D%95%E8%81%8A</see>
    /// <br/>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="openid">QQ 用户的 openid</param>
    /// <param name="messageArk">ark类型消息</param>
    /// <param name="msgId">前置收到的消息ID，用于发送被动消息</param>
    /// <param name="eventId">【暂未支持】前置收到的事件ID，用于发送被动消息</param>
    /// <param name="msgSeq">回复消息的序号，与 msg_id 联合使用，避免相同消息id回复重复发送，不填默认是1。相同的 msg_id + msg_seq 重复发送会失败</param>
    /// <returns><see cref="Message"/></returns>
    public static async Task<HttpPacket<MessageResult>> SendMessageToUserAsync(
        this HttpService httpService,
        string openid,
        MessageArk messageArk,
        string? msgId = null,
        string? eventId = null,
        int msgSeq = 1
    )
    {
        return await httpService.SendMessageAsync(
            openid,
            false,
            null,
            3,
            msgId,
            eventId,
            msgSeq,
            messageArk: messageArk
        );
    }

    /// <summary>
    /// 发送引用消息
    /// <br/>
    /// 单独发动消息给用户
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api-231017/server-inter/message/send-receive/send.html#%E5%8D%95%E8%81%8A</see>
    /// <br/>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="openid">QQ 用户的 openid</param>
    /// <param name="messageReference">Reference类型消息</param>
    /// <param name="msgId">前置收到的消息ID，用于发送被动消息</param>
    /// <param name="eventId">【暂未支持】前置收到的事件ID，用于发送被动消息</param>
    /// <param name="msgSeq">回复消息的序号，与 msg_id 联合使用，避免相同消息id回复重复发送，不填默认是1。相同的 msg_id + msg_seq 重复发送会失败</param>
    /// <returns><see cref="Message"/></returns>
    public static Task<HttpPacket<MessageResult>> SendMessageToUserAsync(
        this HttpService httpService,
        string openid,
        MessageReference messageReference,
        string? msgId = null,
        string? eventId = null,
        int msgSeq = 1
    )
    {
        throw new NotImplementedException();
    }

    #endregion

    #region 群聊


    /// <summary>
    /// 发送消息
    /// <br/>
    /// 发动消息到群
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api-231017/server-inter/message/send-receive/send.html#%E7%BE%A4%E8%81%8A</see>
    /// <br/>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="openid">群聊的 openid</param>
    /// <param name="content">消息内容</param>
    /// <param name="msgId">前置收到的消息ID，用于发送被动消息</param>
    /// <param name="eventId">【暂未支持】前置收到的事件ID，用于发送被动消息</param>
    /// <param name="msgSeq">回复消息的序号，与 msg_id 联合使用，避免相同消息id回复重复发送，不填默认是1。相同的 msg_id + msg_seq 重复发送会失败</param>
    /// <returns><see cref="Message"/></returns>
    public static async Task<HttpPacket<MessageResult>> SendMessageToGroupAsync(
        this HttpService httpService,
        string openid,
        string content,
        string? msgId = null,
        string? eventId = null,
        int msgSeq = 1
    )
    {
        return await httpService.SendMessageAsync(
            openid,
            false,
            content,
            0,
            msgId,
            eventId,
            msgSeq
        );
    }

    /// <summary>
    /// 发送markdown消息
    /// <br/>
    /// 发动消息到群
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api-231017/server-inter/message/send-receive/send.html#%E7%BE%A4%E8%81%8A</see>
    /// <br/>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="openid">群聊的 openid</param>
    /// <param name="messageMarkdown">markdown类型消息</param>
    /// <param name="msgId">前置收到的消息ID，用于发送被动消息</param>
    /// <param name="eventId">【暂未支持】前置收到的事件ID，用于发送被动消息</param>
    /// <param name="msgSeq">回复消息的序号，与 msg_id 联合使用，避免相同消息id回复重复发送，不填默认是1。相同的 msg_id + msg_seq 重复发送会失败</param>
    /// <returns><see cref="Message"/></returns>
    public static async Task<HttpPacket<MessageResult>> SendMessageToGroupAsync(
        this HttpService httpService,
        string openid,
        MessageMarkdown messageMarkdown,
        string? msgId = null,
        string? eventId = null,
        int msgSeq = 1
    )
    {
        return await httpService.SendMessageAsync(
            openid,
            false,
            null,
            2,
            msgId,
            eventId,
            msgSeq,
            messageMarkdown: messageMarkdown
        );
    }

    /// <summary>
    /// 发送ark消息
    /// <br/>
    /// 发动消息到群
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api-231017/server-inter/message/send-receive/send.html#%E7%BE%A4%E8%81%8A</see>
    /// <br/>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="openid">群聊的 openid</param>
    /// <param name="messageArk">ark类型消息</param>
    /// <param name="msgId">前置收到的消息ID，用于发送被动消息</param>
    /// <param name="eventId">【暂未支持】前置收到的事件ID，用于发送被动消息</param>
    /// <param name="msgSeq">回复消息的序号，与 msg_id 联合使用，避免相同消息id回复重复发送，不填默认是1。相同的 msg_id + msg_seq 重复发送会失败</param>
    /// <returns><see cref="Message"/></returns>
    public static async Task<HttpPacket<MessageResult>> SendMessageToGroupAsync(
        this HttpService httpService,
        string openid,
        MessageArk messageArk,
        string? msgId = null,
        string? eventId = null,
        int msgSeq = 1
    )
    {
        return await httpService.SendMessageAsync(
            openid,
            false,
            null,
            3,
            msgId,
            eventId,
            msgSeq,
            messageArk: messageArk
        );
    }

    /// <summary>
    /// 发送引用消息
    /// <br/>
    /// 发动消息到群
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api-231017/server-inter/message/send-receive/send.html#%E7%BE%A4%E8%81%8A</see>
    /// <br/>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="openid">群聊的 openid</param>
    /// <param name="messageReference">Reference类型消息</param>
    /// <param name="msgId">前置收到的消息ID，用于发送被动消息</param>
    /// <param name="eventId">【暂未支持】前置收到的事件ID，用于发送被动消息</param>
    /// <param name="msgSeq">回复消息的序号，与 msg_id 联合使用，避免相同消息id回复重复发送，不填默认是1。相同的 msg_id + msg_seq 重复发送会失败</param>
    /// <returns><see cref="Message"/></returns>
    public static Task<HttpPacket<MessageResult>> SendMessageToGroupAsync(
        this HttpService httpService,
        string openid,
        MessageReference messageReference,
        string? msgId = null,
        string? eventId = null,
        int msgSeq = 1
    )
    {
        throw new NotImplementedException();
    }

    #endregion
}
