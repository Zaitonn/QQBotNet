using System;

namespace QQBotNet.Core.Models.Business.Messages.Keyboard;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/message/message_keyboard.html#inlinekeyboardrow</see>
/// </summary>
public class InlineKeyboardRow
{
    /// <summary>
    /// 数组的一项代表一个按钮，每个InlineKeyboardRow最多含有5个Button
    /// </summary>
    public Button[] Buttons { get; set; } = Array.Empty<Button>();
}
