namespace QQBotNet.Core.Models.Business.Reactions;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/reaction/model.html#reactiontarget</see>
/// </summary>
public class ReactionTarget
{
    /// <summary>
    /// 表态对象ID
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// 表态对象类型
    /// </summary>
    public ReactionTargetType Type { get; set; }
}
