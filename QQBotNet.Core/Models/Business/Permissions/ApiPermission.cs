namespace QQBotNet.Core.Models.Business.Permissions;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/api_permissions/model.html#%E6%8E%A5%E5%8F%A3%E6%9D%83%E9%99%90%E5%AF%B9%E8%B1%A1-apipermission</see>
/// </summary>
public class ApiPermission
{
    /// <summary>
    /// API 路径
    /// </summary>
    public string Path { get; set; } = string.Empty;

    /// <summary>
    /// 请求方法
    /// </summary>
    public string Method { get; set; } = string.Empty;

    /// <summary>
    /// API 接口名称
    /// </summary>
    public string Desc { get; set; } = string.Empty;

    /// <summary>
    /// 授权状态，为 1 时已授权
    /// </summary>
    public uint AuthStatus { get; set; }
}
