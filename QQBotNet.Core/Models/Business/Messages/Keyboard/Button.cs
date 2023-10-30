namespace QQBotNet.Core.Models.Business.Messages.Keyboard;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/message/message_keyboard.html#button</see>
/// </summary>
public class Button
{
    /// <summary>
    /// 按钮 id
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// 用于设定按钮的显示效果
    /// </summary>
    public RenderData RenderData { get; set; } = new();

    /// <summary>
    /// 用于设定按钮点击后的操作
    /// </summary>
    public Action Action { get; set; } = new();
}
