namespace QQBotNet.Core.Models.Business.Permission;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/api_permissions/model.html#%E6%8E%A5%E5%8F%A3%E6%9D%83%E9%99%90%E9%9C%80%E6%B1%82%E5%AF%B9%E8%B1%A1-apipermissiondemand</see>
/// </summary>
public class ApiPermissionDemand
{
    /// <summary>
    /// 接口权限需求授权链接发送的子频道 id
    /// </summary>
    public string ChannelId { get; set; } = string.Empty;

    /// <summary>
    /// 申请接口权限的频道 id
    /// </summary>
    public string GuildId { get; set; } = string.Empty;

    /// <summary>
    /// 接口权限链接中的接口权限描述信息
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// 接口权限链接中的机器人可使用功能的描述信息
    /// </summary>
    public string? Desc { get; set; }

    /// <summary>
    /// 权限接口唯一标识
    /// </summary>
    public ApiPermissionDemandIdentify? ApiIdentify { get; set; }
}
