using System;

namespace QQBotNet.Core.Models.Business.Forums.Contents;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/forum/model.html#paragraph</see>
/// </summary>
public class Paragraph
{
    /// <summary>
    /// 元素列表
    /// </summary>
    public Elem[] Elems { get; set; } = Array.Empty<Elem>();

    /// <summary>
    /// 段落属性
    /// </summary>
    public ParagraphProps Props { get; set; } = new();
}
