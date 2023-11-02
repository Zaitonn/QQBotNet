using QQBotNet.Core.Models.Business.Messages;
using QQBotNet.Core.Models.Packets.OpenApi;
using QQBotNet.Core.Utils.Json;
using QQBotNet.Core.Utils.Extensions;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace QQBotNet.Core.Services.Apis;

/// <summary>
/// 消息Api
/// </summary>
public static class MessageApi
{
    /// <summary>
    /// 获取频道消息频率设置
    /// <br/>
    /// 获取机器人在频道内的消息频率设置
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/setting/message_setting.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="guildId">频道ID</param>
    /// <returns>频道消息频率设置对象</returns>
    public static async Task<HttpPacket<MessageSetting>> GetMessageSettingAsync(
        this HttpService httpService,
        string guildId
    )
    {
        return await httpService.HttpClient.RequestJson<MessageSetting>(
            HttpMethod.Get,
            $"/guilds/{guildId.Encode()}/message/setting"
        );
    }

    /// <summary>
    /// 获取指定消息
    /// <br/>
    /// 获取子频道下的消息的详情
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/message/get_message_of_id.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="channelId">子频道ID</param>
    /// <param name="messageId">消息ID</param>
    /// <returns><see cref="Message"/></returns>
    public static async Task<HttpPacket<Message>> GetMessageAsync(
        this HttpService httpService,
        string channelId,
        string messageId
    )
    {
        return await httpService.HttpClient.RequestJson<Message>(
            HttpMethod.Get,
            $"/channels/{channelId.Encode()}/messages/{messageId.Encode()}"
        );
    }

    private static async Task<HttpPacket<Message>> SendMessageAsync(
        this HttpService httpService,
        string id,
        bool isDms,
        string? content = null,
        string? messageId = null,
        string? eventId = null,
        MessageEmbed? messageEmbed = null,
        MessageArk? messageArk = null,
        MessageReference? messageReference = null,
        MessageMarkdown? messageMarkdown = null,
        MessageKeyboard? messageKeyboard = null,
        string? imageUrl = null,
        byte[]? fileImage = null
    )
    {
        var body = new JsonObject
        {
            { "content", content },
            { "image_url", imageUrl },
            { "msg_id", messageId },
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
            }
        };

        var endpoint = isDms ? $"/dms/{id.Encode()}/messages" : $"/channels/{id.Encode()}/messages";

        if (fileImage is null || fileImage.Length == 0)
            return await httpService.HttpClient.RequestJson<Message>(
                HttpMethod.Post,
                endpoint,
                body,
                true
            );

        var multipartFormDataContent = new MultipartFormDataContent
        {
            JsonContent.Create(
                body,
                options: JsonSerializerOptionsFactory.UnsafeSnakeCaseAndIgnoreNull
            ),
            { new ByteArrayContent(fileImage), "file_image" }
        };
        multipartFormDataContent.Headers.ContentType = new("muiltform/form-data");

        return await httpService.HttpClient.Request<Message>(
            HttpMethod.Post,
            endpoint,
            multipartFormDataContent
        );
    }

    /// <summary>
    /// 发送消息
    /// <br/>
    /// 向指定的子频道发送消息
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/message/post_messages.html</see>
    /// <br/>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="channelId">子频道ID</param>
    /// <param name="content">消息内容</param>
    /// <param name="imageUrl">图片url地址，平台会转存该图片，用于下发图片消息</param>
    /// <param name="messageId">回复的消息id</param>
    /// <param name="eventId">回复的事件id</param>
    /// <param name="messageEmbed">embed消息</param>
    /// <param name="messageArk">ark消息</param>
    /// <param name="messageReference">引用消息</param>
    /// <param name="messageMarkdown">markdown 消息</param>
    /// <param name="messageKeyboard">keyboard消息</param>
    /// <param name="fileImage">图片文件</param>
    /// <returns><see cref="Message"/></returns>
    public static async Task<HttpPacket<Message>> SendMessageAsync(
        this HttpService httpService,
        string channelId,
        string? content = null,
        string? messageId = null,
        string? eventId = null,
        MessageEmbed? messageEmbed = null,
        MessageArk? messageArk = null,
        MessageReference? messageReference = null,
        MessageMarkdown? messageMarkdown = null,
        MessageKeyboard? messageKeyboard = null,
        string? imageUrl = null,
        byte[]? fileImage = null
    )
    {
        return await httpService.SendMessageAsync(
            channelId,
            false,
            content,
            messageId,
            eventId,
            messageEmbed,
            messageArk,
            messageReference,
            messageMarkdown,
            messageKeyboard,
            imageUrl,
            fileImage
        );
    }

    /// <summary>
    /// 撤回消息
    /// <br/>
    /// 用于撤回子频道下的消息
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/message/delete_message.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="channelId">子频道ID</param>
    /// <param name="messageId">消息ID</param>
    /// <param name="hidetip">是否隐藏提示小灰条</param>
    /// <returns><see cref="Message"/></returns>
    public static async Task<HttpPacket> DeleteMessageAsync(
        this HttpService httpService,
        string channelId,
        string messageId,
        bool hidetip = false
    )
    {
        return await httpService.HttpClient.RequestJsonWithNoResult(
            HttpMethod.Delete,
            $"/channels/{channelId.Encode()}/messages/{messageId.Encode()}?hidetip={hidetip.ToString().ToLowerInvariant()}"
        );
    }

    /// <summary>
    /// 发送 ARK 模板消息
    /// <br/>
    /// 通过指定 ark 字段发送模板消息
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/message/post_ark_messages.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="channelId">子频道ID</param>
    /// <param name="messageArk">ark 消息</param>
    /// <param name="messageId">回复的消息id</param>
    /// <param name="eventId">回复的事件id</param>
    /// <returns><see cref="Message"/></returns>
    public static async Task<HttpPacket<Message>> SendArkMessageAsync(
        this HttpService httpService,
        string channelId,
        MessageArk messageArk,
        string? messageId = null,
        string? eventId = null
    )
    {
        return await httpService.SendMessageAsync(
            channelId,
            messageArk: messageArk,
            messageId: messageId,
            eventId: eventId
        );
    }

    /// <summary>
    /// 发送Markdown模板消息
    /// <br/>
    /// 发送markdown消息，支持markdown模版和直传markdown语法两种请求格式
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/message/post_markdown_messages.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="channelId">子频道ID</param>
    /// <param name="messageMarkdown">markdown消息</param>
    /// <param name="messageId">回复的消息id</param>
    /// <param name="eventId">回复的事件id</param>
    /// <returns><see cref="Message"/></returns>
    public static async Task<HttpPacket<Message>> SendArkMessageAsync(
        this HttpService httpService,
        string channelId,
        MessageMarkdown messageMarkdown,
        string? messageId = null,
        string? eventId = null
    )
    {
        return await httpService.SendMessageAsync(
            channelId,
            messageMarkdown: messageMarkdown,
            messageId: messageId,
            eventId: eventId
        );
    }

    /// <summary>
    /// 发送引用消息
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/message/post_messages_reference.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="channelId">子频道ID</param>
    /// <param name="content">消息内容</param>
    /// <param name="messageReference">引用消息</param>
    /// <param name="messageId">回复的消息id</param>
    /// <param name="eventId">回复的事件id</param>
    /// <returns><see cref="Message"/></returns>
    public static async Task<HttpPacket<Message>> SendArkMessageAsync(
        this HttpService httpService,
        string channelId,
        string content,
        MessageReference messageReference,
        string? messageId = null,
        string? eventId = null
    )
    {
        return await httpService.SendMessageAsync(
            channelId,
            content,
            messageReference: messageReference,
            messageId: messageId,
            eventId: eventId
        );
    }

    /// <summary>
    /// 发送含有消息按钮组件的消息
    /// <br/>
    /// 通过指定keyboard字段发送带按钮的消息，支持keyboard模版和自定义keyboard两种请求格式
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/message/post_keyboard_messages.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="channelId">子频道ID</param>
    /// <param name="messageMarkdown">markdown消息</param>
    /// <param name="messageKeyboard">keyboard消息</param>
    /// <param name="messageId">回复的消息id</param>
    /// <param name="eventId">回复的事件id</param>
    /// <returns><see cref="Message"/></returns>
    public static async Task<HttpPacket<Message>> SendKeyboardMessageAsync(
        this HttpService httpService,
        string channelId,
        MessageMarkdown messageMarkdown,
        MessageKeyboard messageKeyboard,
        string? messageId = null,
        string? eventId = null
    )
    {
        return await httpService.SendMessageAsync(
            channelId,
            messageMarkdown: messageMarkdown,
            messageKeyboard: messageKeyboard,
            messageId: messageId,
            eventId: eventId
        );
    }

    /// <summary>
    /// 创建私信会话
    /// <br/>
    /// 用于机器人和在同一个频道内的成员创建私信会话
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/dms/post_dms.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="recipientId">接收者 id</param>
    /// <param name="sourceGuildId">源频道 id</param>
    /// <returns><see cref="DMS"/></returns>
    public static async Task<HttpPacket<DMS>> CreateDMSAsync(
        this HttpService httpService,
        string recipientId,
        string sourceGuildId
    )
    {
        return await httpService.HttpClient.RequestJson<DMS>(
            HttpMethod.Post,
            "/users/@me/dms",
            new JsonObject { { "recipient_id", recipientId }, { "source_guild_id", sourceGuildId } }
        );
    }

    /// <summary>
    /// 发送私信
    /// <br/>
    /// 发送私信消息，前提是已经创建了私信会话
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/dms/post_dms_messages.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="dmsGuildId"><see cref="DMS.GuildId"/></param>
    /// <param name="content">消息内容</param>
    /// <param name="imageUrl">图片url地址，平台会转存该图片，用于下发图片消息</param>
    /// <param name="messageId">回复的消息id</param>
    /// <param name="eventId">回复的事件id</param>
    /// <param name="messageEmbed">embed消息</param>
    /// <param name="messageArk">ark消息</param>
    /// <param name="messageReference">引用消息</param>
    /// <param name="messageMarkdown">markdown 消息</param>
    /// <param name="messageKeyboard">keyboard消息</param>
    /// <param name="fileImage">图片文件</param>
    /// <returns><see cref="Message"/></returns>
    public static async Task<HttpPacket<Message>> SendDMSMessageAsync(
        this HttpService httpService,
        string dmsGuildId,
        string? content = null,
        string? messageId = null,
        string? eventId = null,
        MessageEmbed? messageEmbed = null,
        MessageArk? messageArk = null,
        MessageReference? messageReference = null,
        MessageMarkdown? messageMarkdown = null,
        MessageKeyboard? messageKeyboard = null,
        string? imageUrl = null,
        byte[]? fileImage = null
    )
    {
        return await httpService.SendMessageAsync(
            dmsGuildId,
            false,
            content,
            messageId,
            eventId,
            messageEmbed,
            messageArk,
            messageReference,
            messageMarkdown,
            messageKeyboard,
            imageUrl,
            fileImage
        );
    }

    
    /// <summary>
    /// 撤回私信
    /// <br/>
    /// 用于撤回私信频道下的消息
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/dms/delete_dms.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="dmsGuildId"><see cref="DMS.GuildId"/></param>
    /// <param name="messageId">消息ID</param>
    /// <param name="hidetip">是否隐藏提示小灰条</param>
    /// <returns><see cref="Message"/></returns>
    public static async Task<HttpPacket> DeleteDMSMessageAsync(
        this HttpService httpService,
        string dmsGuildId,
        string messageId,
        bool hidetip = false
    )
    {
        return await httpService.HttpClient.RequestJsonWithNoResult(
            HttpMethod.Delete,
            $"/dms/{dmsGuildId.Encode()}/messages/{messageId.Encode()}?hidetip={hidetip.ToString().ToLowerInvariant()}"
        );
    }
}
