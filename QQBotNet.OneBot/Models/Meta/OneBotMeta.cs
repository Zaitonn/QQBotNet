namespace QQBotNet.OneBot.Models.Meta;

public abstract class OneBotMeta : OneBotModelsBase
{
    protected OneBotMeta(uint selfId, string metaEventType)
        : base(selfId, "meta_event")
    {
        MetaEventType = metaEventType;
    }

    public string MetaEventType { get; set; }
}
