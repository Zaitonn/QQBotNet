using System;

namespace QQBotNet.Core.Models.Business.Messages.Keyboard;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/message/message_keyboard.html#inlinekeyboard</see>
/// </summary>
public class InlineKeyboard
{
    /// <summary>
    /// 数组的一项代表消息按钮组件的一行，最多含有 5 行
    /// </summary>
    public InlineKeyboardRow[] Rows { get; set; } = Array.Empty<InlineKeyboardRow>();
}
