using System;

namespace QQBotNet.OneBot.Entity;

public abstract class OneBotEntityBase
{
    protected OneBotEntityBase(uint selfId, string postType)
    {
        SelfId = selfId;
        PostType = postType;
    }

    public long Time { get; set; } = DateTimeOffset.Now.ToUnixTimeSeconds();

    public uint SelfId { get; set; }

    public string PostType { get; set; }
}
