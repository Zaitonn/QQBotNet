using System;

namespace QQBotNet.Core.Models.Business.Messages;

/// <summary>
/// 频道消息频率设置对象
/// <br/>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/setting/model.html#messagesetting</see>
/// </summary>
public class MessageSetting
{
    /// <summary>
    /// 是否允许创建私信
    /// </summary>
    public bool DisableCreateDm { get; set; }

    /// <summary>
    /// 是否允许发主动消息
    /// </summary>
    public bool DisablePushMsg { get; set; }

    /// <summary>
    /// 子频道 id 数组
    /// </summary>
    public string[] ChannelIds { get; set; } = Array.Empty<string>();

    /// <summary>
    /// 每个子频道允许主动推送消息最大消息条数
    /// </summary>
    public uint ChannelPushMaxNum { get; set; }
}
