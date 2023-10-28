namespace QQBotNet.Core.Models.Business.Channels;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/channel/model.html#privatetype</see>
/// </summary>
public enum PrivateType
{
    /// <summary>
    /// 公开频道
    /// </summary>
    Public,

    /// <summary>
    /// 群主管理员可见
    /// </summary>
    Private,

    /// <summary>
    /// 群主管理员+指定成员
    /// </summary>
    Specific
}
