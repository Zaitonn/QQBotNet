using System.Text.Json.Serialization;

namespace QQBotNet.Core.Entity.WebSockets;

public class HeartbeatInfo
{
    public int? HeartbeatInterval { get; set; }
}
