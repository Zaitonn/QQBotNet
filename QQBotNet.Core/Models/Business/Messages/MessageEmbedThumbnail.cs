namespace QQBotNet.Core.Models.Business.Messages;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/message/model.html#messageembedthumbnail</see>
/// </summary>
public class MessageEmbedThumbnail
{
    /// <summary>
    /// 图片地址
    /// </summary>
    public string Url { get; set; } = string.Empty;
}
