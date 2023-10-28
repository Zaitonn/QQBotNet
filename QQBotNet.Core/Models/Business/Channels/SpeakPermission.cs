namespace QQBotNet.Core.Models.Business.Channels;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/channel/model.html#speakpermission</see>
/// </summary>
public enum SpeakPermission
{
    /// <summary>
    /// 无效类型
    /// </summary>
    Invalid,

    /// <summary>
    /// /// 所有人
    /// </summary>
    Everyone,

    /// <summary>
    /// 群主管理员+指定成员
    /// </summary>
    Specific
}
