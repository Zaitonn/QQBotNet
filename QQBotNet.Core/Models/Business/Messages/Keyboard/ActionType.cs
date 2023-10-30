namespace QQBotNet.Core.Models.Business.Messages.Keyboard;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/message/message_keyboard.html#actiontype</see>
/// </summary>
public enum ActionType
{
    /// <summary>
    /// http 或 小程序 客户端识别 schem, data字段为链接
    /// </summary>
    Url = 0,

    /// <summary>
    /// 回调后台接口, data 传给后台
    /// </summary>
    BackgroundInterface = 1,

    /// <summary>
    /// at机器人, 根据 at_bot_show_channel_list 决定在当前频道或用户选择频道,自动在输入框 @bot data
    /// </summary>
    AtBot = 2
}
