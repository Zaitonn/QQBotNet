using System.Net.Http;

namespace QQBotNet.Core.Utils;

/// <summary>
/// 一个帮助器类，它用于检索并比较标准 HTTP 方法并且用于创建新的 HTTP 方法。
/// </summary>
internal static class HttpMethodEx
{
    /// <summary>
    /// 获取 HTTP PATCH 协议方法。
    /// </summary>
#if !NETFRAMEWORK
    public static readonly HttpMethod Patch = HttpMethod.Patch;
#else
    public static readonly HttpMethod Patch = new("PATCH");
#endif
}
