namespace QQBotNet.Core.Models.Business.Messages.Keyboard;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/message/message_keyboard.html#renderdata</see>
/// </summary>
public class RenderData
{
    /// <summary>
    /// 按纽上的文字
    /// </summary>
    public string Label { get; set; } = string.Empty;

    /// <summary>
    /// 点击后按纽上文字
    /// </summary>
    public string VisitedLabel { get; set; } = string.Empty;

    /// <summary>
    /// 按钮样式
    /// </summary>
    public RenderStyle Style { get; set; }
}
