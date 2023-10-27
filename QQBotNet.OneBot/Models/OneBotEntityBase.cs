using System;

namespace QQBotNet.OneBot.Models;

public abstract class OneBotModelsBase
{
    protected OneBotModelsBase(uint selfId, string postType)
    {
        SelfId = selfId;
        PostType = postType;
    }

    public long Time { get; set; } = DateTimeOffset.Now.ToUnixTimeSeconds();

    public uint SelfId { get; set; }

    public string PostType { get; set; }
}
