namespace QQBotNet.Core.Models.Business.Forums.Contents;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/forum/model.html#elem</see>
/// </summary>
public class Elem
{
    /// <summary>
    /// 元素类型
    /// </summary>
    public ElemType Type { get; set; }

    /// <summary>
    /// URL元素
    /// </summary>
    public URLElem? URL { get; set; }

    /// <summary>
    /// 视频元素
    /// </summary>
    public VideoElem? Video { get; set; }

    /// <summary>
    /// 图片元素
    /// </summary>
    public ImageElem? Image { get; set; }

    /// <summary>
    /// 文本元素
    /// </summary>
    public TextElem? Text { get; set; }
}
