using System;

namespace QQBotNet.Core.Models.Business.Messages;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/pins/model.html#pinsmessage</see>
/// </summary>
public class PinsMessage
{
    /// <summary>
    /// 子频道内精华消息 id 数组
    /// </summary>
    public string[] MessageIds { get; set; } = Array.Empty<string>();

    /// <summary>
    ///  子频道 id
    /// </summary>
    public string ChannelId { get; set; } = string.Empty;

    /// <summary>
    /// 频道 id
    /// </summary>
    public string GuildId { get; set; } = string.Empty;
}
