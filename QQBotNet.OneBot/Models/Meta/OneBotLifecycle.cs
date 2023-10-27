namespace QQBotNet.OneBot.Models.Meta;

public class OneBotLifecycle : OneBotMeta
{
    public OneBotLifecycle(uint selfId, string subType)
        : base(selfId, "lifecycle")
    {
        SubType = subType;
    }

    public string SubType { get; set; }
}
