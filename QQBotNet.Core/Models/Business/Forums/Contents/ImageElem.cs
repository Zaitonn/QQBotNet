namespace QQBotNet.Core.Models.Business.Forums.Contents;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/forum/model.html#imageelem</see>
/// </summary>
public class ImageElem
{
    /// <summary>
    /// 第三方图片链接
    /// </summary>
    public string ThirdUrl { get; set; } = string.Empty;

    /// <summary>
    /// 宽度比例（缩放比，在屏幕里显示的比例）
    /// </summary>
    public double WidthPercent { get; set; }
}
