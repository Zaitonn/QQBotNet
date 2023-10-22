using QQBotNet.Core.Entity.WebSockets;
using System;

namespace QQBotNet.Core.Services.EventArg;

public class PacketSentEventArgs : EventArgs
{
    public PacketSentEventArgs(Packet packet)
    {
        Packet = packet;
    }

    public readonly Packet Packet;
}
