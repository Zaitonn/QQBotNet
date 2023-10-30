namespace QQBotNet.Core.Models.Business.Messages.Keyboard;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/message/message_keyboard.html#action</see>
/// </summary>
public class Action
{
    /// <summary>
    /// 操作类型
    /// </summary>
    public ActionType Type { get; set; }

    /// <summary>
    /// 用于设定操作按钮所需的权限
    /// </summary>
    public Permission Permission { get; set; } = new();

    /// <summary>
    /// 可点击的次数, 默认不限
    /// </summary>
    public int? ClickLimit { get; set; }

    /// <summary>
    /// 操作相关数据
    /// </summary>
    public string Data { get; set; } = string.Empty;

    /// <summary>
    /// 是否弹出子频道选择器
    /// </summary>
    public bool AtBotShowChannelList { get; set; }
}
