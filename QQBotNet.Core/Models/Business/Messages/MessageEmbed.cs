namespace QQBotNet.Core.Models.Business.Messages;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/message/model.html#messageembed</see>
/// </summary>
public class MessageEmbed
{
    /// <summary>
    /// 标题
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// 消息弹窗内容
    /// </summary>
    public string Prompt { get; set; } = string.Empty;

    /// <summary>
    /// 缩略图
    /// </summary>
    public MessageEmbedThumbnail Thumbnail { get; set; } = new();
}
