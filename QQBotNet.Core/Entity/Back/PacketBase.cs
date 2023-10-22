namespace QQBotNet.Core.Entity.Back;

public abstract class PacketBase
{
    public int Code { get; set; }

    public string? Message { get; set; }
}
