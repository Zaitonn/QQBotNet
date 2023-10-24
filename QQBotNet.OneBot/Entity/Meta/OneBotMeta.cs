namespace QQBotNet.OneBot.Entity.Meta;

public abstract class OneBotMeta : OneBotEntityBase
{
    protected OneBotMeta(uint selfId, string metaEventType)
        : base(selfId, "meta_event")
    {
        MetaEventType = metaEventType;
    }

    public string MetaEventType { get; set; }
}
