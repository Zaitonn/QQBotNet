namespace QQBotNet.Core.Models.Business.Channels;

public class EditedChannel
{
    /// <summary>
    /// 子频道名称
    /// </summary>
    public string Name { get; set; } = string.Empty;

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
    /// 子频道私密类型
    /// </summary>
    public PrivateType PrivateType { get; set; }

    /// <summary>
    /// 子频道发言权限
    /// </summary>
    public SpeakPermission SpeakPermission { get; set; }
}
