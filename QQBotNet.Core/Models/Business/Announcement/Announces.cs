using System;

namespace QQBotNet.Core.Models.Business.Announcement;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/announces/model.html#announces</see>
/// </summary>
public class Announces
{
    /// <summary>
    /// 消息 id
    /// </summary>
    public string MessageId { get; set; } = string.Empty;

    /// <summary>
    ///  子频道 id
    /// </summary>
    public string ChannelId { get; set; } = string.Empty;

    /// <summary>
    /// 频道 id
    /// </summary>
    public string GuildId { get; set; } = string.Empty;

    /// <summary>
    /// 公告类别
    /// </summary>
    public AnnouncesType AnnouncesType { get; set; }

    /// <summary>
    /// 推荐子频道详情列表
    /// </summary>
    public RecommendChannel[] RecommendChannels { get; set; } = Array.Empty<RecommendChannel>();
}
