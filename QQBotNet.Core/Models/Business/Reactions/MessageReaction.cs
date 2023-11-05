namespace QQBotNet.Core.Models.Business.Reactions;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/reaction/model.html#messagereaction</see>
/// </summary>
public class MessageReaction
{
    /// <summary>
    /// 子频道 id
    /// </summary>
    public string ChannelId { get; set; } = string.Empty;

    /// <summary>
    /// 频道 id
    /// </summary>
    public string GuildId { get; set; } = string.Empty;

    /// <summary>
    /// 表态对象
    /// </summary>
    public ReactionTarget Target { get; set; } = new();

    /// <summary>
    /// 用户 id
    /// </summary>
    public string UserId { get; set; } = string.Empty;

    /// <summary>
    /// 表态所用表情
    /// </summary>
    public Emoji Emoji { get; set; } = new();
}
