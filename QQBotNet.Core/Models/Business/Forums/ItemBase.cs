namespace QQBotNet.Core.Models.Business.Forums;

/// <summary>
/// <see cref="Thread"/>、<see cref="Post"/>和<see cref="Reply"/>的基类
/// </summary>
public abstract class ItemBase
{
    /// <summary>
    /// 作者ID
    /// </summary>
    public string AuthorId { get; set; } = string.Empty;

    /// <summary>
    /// 子频道 id
    /// </summary>
    public string ChannelId { get; set; } = string.Empty;

    /// <summary>
    /// 频道 id
    /// </summary>
    public string GuildId { get; set; } = string.Empty;
}
