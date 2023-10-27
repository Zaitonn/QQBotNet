namespace QQBotNet.Core.Models.Packets.OpenApi;

public class WebSocketUrl : HttpApiPacketBase
{
    public string Url { get; set; } = string.Empty;
}
