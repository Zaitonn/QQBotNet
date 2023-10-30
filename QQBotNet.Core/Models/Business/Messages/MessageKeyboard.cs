using QQBotNet.Core.Models.Business.Messages.Keyboard;

namespace QQBotNet.Core.Models.Business.Messages;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/message/model.html#MessageKeyboard</see>
/// </summary>
public class MessageKeyboard
{
    /// <summary>
    /// keyboard 模板 id
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// 自定义 keyboard 内容，与 id 参数互斥,参数都传值将报错
    /// </summary>
    public InlineKeyboard? Content { get; set; }
}
