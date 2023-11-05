namespace QQBotNet.Core.Models.Business.Members;

/// <summary>
/// 成员（携带GuildId）
/// <br/>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/member/model.html#MemberWithGuildID</see>
/// </summary>
public class MemberWithGuildId : Member
{
    /// <summary>
    /// 频道 id
    /// </summary>
    public string GuildId { get; set; } = string.Empty;

    /// <summary>
    /// 操作人（事件专属）
    /// </summary>
    public string? OpUserId { get; set; }
}
