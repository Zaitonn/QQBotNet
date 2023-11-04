namespace QQBotNet.Core.Models.Business.Forums.Contents;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/forum/model.html#platimage</see>
/// </summary>
public class PlatImage
{
    /// <summary>
    /// 架平图片链接
    /// </summary>
    public string Url { get; set; } = string.Empty;

    /// <summary>
    /// 图片高度
    /// </summary>
    public uint Height { get; set; }

    /// <summary>
    /// 图片宽度
    /// </summary>
    public uint Width { get; set; }

    /// <summary>
    /// 图片ID
    /// </summary>
    public string ImageId { get; set; } = string.Empty;
}
