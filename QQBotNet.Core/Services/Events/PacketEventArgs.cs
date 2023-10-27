using QQBotNet.Core.Models.Packets.WebSockets;
using System;

namespace QQBotNet.Core.Services.Events;

public class PacketEventArgs : EventArgs
{
    internal PacketEventArgs(Packet packet)
    {
        Packet = packet;
    }

    public readonly Packet Packet;
}
