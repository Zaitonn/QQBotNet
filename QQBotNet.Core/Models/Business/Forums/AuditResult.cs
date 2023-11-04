using System.Text.Json.Serialization;

namespace QQBotNet.Core.Models.Business.Forums;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/forum/model.html#auditresult</see>
/// </summary>
public class AuditResult : ItemBase
{
    /// <summary>
    /// 主帖ID
    /// </summary>
    public string ThreadId { get; set; } = string.Empty;

    /// <summary>
    /// 帖子ID
    /// </summary>
    public string PostId { get; set; } = string.Empty;

    /// <summary>
    /// 回复ID
    /// </summary>
    public string ReplyId { get; set; } = string.Empty;

    /// <summary>
    /// 审核的类型
    /// </summary>
    public AuditType Type { get; set; }

    /// <summary>
    /// 审核结果
    /// </summary>
    public bool Result => ResultCode == 0;

    /// <summary>
    /// 审核结果代码
    /// </summary>
    [JsonPropertyName("result")]
    public uint ResultCode { get; set; }

    /// <summary>
    /// <see cref="Result"/>不为true时错误信息
    /// </summary>
    public string? ErrMsg { get; set; }
}
