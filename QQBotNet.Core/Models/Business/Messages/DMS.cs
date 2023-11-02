using System;

namespace QQBotNet.Core.Models.Business.Messages;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/dms/model.html</see>
/// </summary>
public class DMS
{
    /// <summary>
    ///  子频道 id
    /// </summary>
    public string ChannelId { get; set; } = string.Empty;

    /// <summary>
    /// 频道 id
    /// </summary>
    public string GuildId { get; set; } = string.Empty;

    /// <summary>
    /// 创建私信会话时间戳
    /// </summary>
    public DateTime CreateTime { get; set; }
}
