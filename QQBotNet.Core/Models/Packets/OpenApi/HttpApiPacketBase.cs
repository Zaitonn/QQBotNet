namespace QQBotNet.Core.Models.Packets.OpenApi;

public abstract class HttpApiPacketBase
{
    public int Code { get; set; }

    public string? Message { get; set; }
}
