namespace QQBotNet.Core.Models.Business.Forums.Contents;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/forum/model.html#atguildinfo</see>
/// </summary>
public class AtGuildInfo
{
    /// <summary>
    /// 频道ID
    /// </summary>
    public string GuildId { get; set; } = string.Empty;

    /// <summary>
    /// 频道名称
    /// </summary>
    public string GuildName { get; set; } = string.Empty;
}
