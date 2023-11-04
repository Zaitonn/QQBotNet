using System;

namespace QQBotNet.Core.Models.Business.Forums.Contents;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/forum/model.html#richtext</see>
/// </summary>
public class RichText
{
    /// <summary>
    /// 段落，一段落一行，段落内无元素的为空行
    /// </summary>
    public Paragraph[] Paragraphs { get; set; } = Array.Empty<Paragraph>();
}
