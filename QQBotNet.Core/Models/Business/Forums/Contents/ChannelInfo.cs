namespace QQBotNet.Core.Models.Business.Forums.Contents;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/forum/model.html#channelinfo</see>
/// </summary>
public class ChannelInfo
{
    /// <summary>
    /// 子频道id
    /// </summary>
    public uint ChannelId { get; set; }

    /// <summary>
    /// 子频道名称
    /// </summary>
    public string ChannelName { get; set; } = string.Empty;
}
