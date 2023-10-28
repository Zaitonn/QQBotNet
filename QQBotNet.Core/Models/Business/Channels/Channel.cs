namespace QQBotNet.Core.Models.Business.Channels;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/channel/model.html</see>
/// </summary>
public class Channel
{
    /// <summary>
    /// 子频道ID
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// 频道 id
    /// </summary>
    public string GuildId { get; set; } = string.Empty;

    /// <summary>
    /// 子频道名称
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 子频道类型
    /// </summary>
    public ChannelType Type { get; set; }

    /// <summary>
    /// 子频道子类型
    /// </summary>
    public ChannelSubType SubType { get; set; }

    /// <summary>
    /// 排序值 
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/channel/model.html#%E6%9C%89%E5%85%B3-position-%E7%9A%84%E8%AF%B4%E6%98%8E</see>
    /// </summary>
    public int Position { get; set; }

    /// <summary>
    /// 所属分组 id，仅对子频道有效
    /// </summary>
    public string? ParentId { get; set; }

    /// <summary>
    /// 创建人ID
    /// </summary>
    public string OwnerId { get; set; } = string.Empty;

    /// <summary>
    /// 子频道私密类型
    /// </summary>
    public PrivateType PrivateType { get; set; }

    /// <summary>
    /// 子频道发言权限
    /// </summary>
    public SpeakPermission SpeakPermission { get; set; }

    /// <summary>
    /// 用于标识应用子频道应用类型，仅应用子频道时会使用该字段
    /// </summary>
    public string? ApplicationId { get; set; }
}
