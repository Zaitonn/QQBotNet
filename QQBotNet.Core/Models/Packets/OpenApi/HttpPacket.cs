using System.Net;
using System.Net.Http;
using System.Text.Json.Nodes;

namespace QQBotNet.Core.Models.Packets.OpenApi;

/// <summary>
/// HttpApi的数据包（泛型）
/// </summary>
public class HttpPacket<T>
    where T : notnull
{
    /// <summary>
    /// 数据主体
    /// <br/>
    /// 若"T"为数组则此项不为null
    /// </summary>
    public T? Data { get; init; }

    /// <summary>
    /// 状态码
    /// </summary>
    public int? Code { get; init; }

    /// <summary>
    /// 错误消息
    /// </summary>
    public string? Message { get; init; }

    /// <summary>
    /// 本地错误消息对照
    /// </summary>
    public string? LocalMessage => ErrorCode.GetMessage(Code);

    /// <summary>
    /// 此次请求是否成功
    /// </summary>
    public bool Success => Code is null && string.IsNullOrEmpty(Message);

    /// <summary>
    /// 响应
    /// </summary>
    public HttpResponseMessage? Response { get; internal set; }
}

/// <summary>
/// HttpApi的数据包
/// </summary>
public class HttpPacket : HttpPacket<JsonNode> { }
