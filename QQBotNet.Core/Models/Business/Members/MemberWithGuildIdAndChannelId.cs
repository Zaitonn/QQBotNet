using QQBotNet.Core.Models.Business.Channels;

namespace QQBotNet.Core.Models.Business.Members;

/// <summary>
/// 成员（携带ChannelId）
/// <br/>
/// <see>https://bot.q.qq.com/wiki/develop/api/gateway/audio_or_live_channel_member.html#audio-or-live-channel-member-enter</see>
/// </summary>
public class MemberWithGuildIdAndChannelId : MemberWithGuildId
{
    /// <summary>
    /// 子频道类型
    /// </summary>
    public ChannelType Type { get; set; }

    /// <summary>
    /// 子频道 id
    /// </summary>
    public string ChannelId { get; set; } = string.Empty;
}
