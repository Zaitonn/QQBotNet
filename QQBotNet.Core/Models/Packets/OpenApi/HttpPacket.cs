namespace QQBotNet.Core.Models.Packets.OpenApi;

/// <summary>
/// HttpApi的数据包（泛型）
/// </summary>
public class HttpPacket<T> : HttpPacket
{
    /// <summary>
    /// 数据主体
    /// </summary>
    public T? Data { get; internal init; }
}

/// <summary>
/// HttpApi的数据包
/// </summary>
public class HttpPacket
{
    /// <summary>
    /// 状态码
    /// </summary>
    public int? Code { get; set; }

    /// <summary>
    /// 错误消息
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// 此次请求是否成功
    /// </summary>
    public bool Success => Code is null && string.IsNullOrEmpty(Message);
}
