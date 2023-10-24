using QQBotNet.Core.Entity.WebSockets;
using System;

namespace QQBotNet.Core.Services.Events;

public class PacketEventArgs : EventArgs
{
    public PacketEventArgs(Packet packet)
    {
        Packet = packet;
    }

    public readonly Packet Packet;
}
