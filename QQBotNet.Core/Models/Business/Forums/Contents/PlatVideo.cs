namespace QQBotNet.Core.Models.Business.Forums.Contents;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/forum/model.html#platvideo</see>
/// </summary>
public class PlatVideo
{
    /// <summary>
    /// URL链接
    /// </summary>
    public string Url { get; set; } = string.Empty;

    /// <summary>
    /// 视频高度
    /// </summary>
    public uint Height { get; set; }

    /// <summary>
    /// 视频宽度
    /// </summary>
    public uint Width { get; set; }

    /// <summary>
    /// 视频ID
    /// </summary>
    public string VideoId { get; set; } = string.Empty;

    /// <summary>
    /// 视频时长
    /// </summary>
    public uint Duration { get; set; }

    /// <summary>
    /// 视频封面图属性
    /// </summary>
    public PlatImage? Cover { get; set; }
}
