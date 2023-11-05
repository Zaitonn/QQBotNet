namespace QQBotNet.Core.Models.Business;

/// <summary>
/// 用户对象
/// <br/>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/user/model.html#user</see>
/// </summary>
public class User
{
    /// <summary>
    /// 用户 id
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// 用户名
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// 用户头像地址
    /// </summary>
    public string Avatar { get; set; } = string.Empty;

    /// <summary>
    /// 是否是机器人
    /// </summary>
    public bool Bot { get; set; }

    /// <summary>
    /// 特殊关联应用的openid，需要特殊申请并配置后才会返回。如需申请，请联系平台运营人员。
    /// </summary>
    public string? UnionOpenid { get; set; }

    /// <summary>
    /// 机器人关联的互联应用的用户信息，与union_openid关联的应用是同一个。如需申请，请联系平台运营人员。
    /// </summary>
    public string? UnionUserAccount { get; set; }
}
