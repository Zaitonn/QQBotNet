namespace QQBotNet.Core.Models.Packets.OpenApi.Body;

/// <summary>
/// 帖子创建后消息
/// </summary>
public class ThreadCreateMsg
{
    /// <summary>
    /// 帖子任务ID
    /// </summary>
    public string TaskId { get; set; } = string.Empty;

    /// <summary>
    /// 发帖时间戳，单位：秒
    /// </summary>
    public string CreateTime { get; set; } = string.Empty;
}
