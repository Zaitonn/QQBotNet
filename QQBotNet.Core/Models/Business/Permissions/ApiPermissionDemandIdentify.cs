namespace QQBotNet.Core.Models.Business.Permissions;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/api_permissions/model.html#%E6%8E%A5%E5%8F%A3%E6%9D%83%E9%99%90%E9%9C%80%E6%B1%82%E6%A0%87%E8%AF%86%E5%AF%B9%E8%B1%A1-apipermissiondemandidentify</see>
/// </summary>
public class ApiPermissionDemandIdentify
{
    /// <summary>
    /// API 路径
    /// </summary>
    public string Path { get; set; } = string.Empty;

    /// <summary>
    /// 请求方法
    /// </summary>
    public string Method { get; set; } = string.Empty;
}
