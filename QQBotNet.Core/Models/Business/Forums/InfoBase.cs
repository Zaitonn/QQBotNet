using System;

namespace QQBotNet.Core.Models.Business.Forums;

/// <summary>
/// 论坛对象信息基类
/// </summary>
public abstract class InfoBase
{
    /// <summary>
    /// 主帖ID
    /// </summary>
    public string ThreadId { get; set; } = string.Empty;

    /// <summary>
    /// 内容
    /// </summary>
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// 发表时间
    /// </summary>
    public DateTime DateTime { get; set; }
}
