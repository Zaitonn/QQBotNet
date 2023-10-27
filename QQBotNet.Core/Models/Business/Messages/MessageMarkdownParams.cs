using System;

namespace QQBotNet.Core.Models.Business.Messages;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/message/model.html#messagemarkdownparams</see>
/// </summary>
public class MessageMarkdownParams
{
    /// <summary>
    /// markdown 模版 key
    /// </summary>
    public string Key { get; set; } = string.Empty;

    /// <summary>
    /// markdown 模版 key 对应的 values ，列表长度大小为 1，传入多个会报错
    /// </summary>
    public string[] Value { get; set; } = Array.Empty<string>();
}
