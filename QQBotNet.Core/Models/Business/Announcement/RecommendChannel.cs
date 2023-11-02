namespace QQBotNet.Core.Models.Business.Announcement;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/announces/model.html#recommendchannel</see>
/// </summary>
public class RecommendChannel
{
    /// <summary>
    ///  子频道 id
    /// </summary>
    public string ChannelId { get; set; } = string.Empty;

    /// <summary>
    ///  推荐语
    /// </summary>
    public string Introduce { get; set; } = string.Empty;
}
