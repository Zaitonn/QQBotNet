namespace QQBotNet.Core.Models.Packets.OpenApi;

/// <summary>
/// 应用接口凭证
/// </summary>
public class AppAccessToken
{
    /// <summary>
    /// 获取到的凭证
    /// </summary>
    public string AccessToken { get; set; } = string.Empty;

    /// <summary>
    /// 凭证有效时间
    /// </summary>
    public int ExpiresIn { get; set; }
}
