namespace QQBotNet.OneBot.Models.Meta;

public class OneBotHeartBeat : OneBotMeta
{
    public OneBotHeartBeat(uint selfId, int interval, object status)
        : base(selfId, "heartbeat")
    {
        Interval = interval;
        Status = status;
    }

    public int Interval { get; set; }

    public object Status { get; set; }
}
