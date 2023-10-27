namespace QQBotNet.Core.Models.Business.Messages;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/message/model.html#messageattachment</see>
/// </summary>
public class MessageAttachment
{
    /// <summary>
    /// 下载地址
    /// </summary>
    public string Url { get; set; } = string.Empty;

    /// <summary>
    /// 内容类型（官方文档未记载）
    /// </summary>
    public string? ContentType { get; set; }

    /// <summary>
    /// 文件名（官方文档未记载）
    /// </summary>
    public string? Filename { get; set; }

    /// <summary>
    /// 文件Id（官方文档未记载）
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// 图片高度（官方文档未记载）
    /// </summary>
    public int? Height { get; set; }

    /// <summary>
    /// 图片宽度（官方文档未记载）
    /// </summary>
    public int? Width { get; set; }

    /// <summary>
    /// 文件大小（官方文档未记载）
    /// </summary>
    public int? Size { get; set; }
}
