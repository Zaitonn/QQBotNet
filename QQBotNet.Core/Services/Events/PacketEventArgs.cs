using QQBotNet.Core.Models.Packets.WebSockets;
using System;

namespace QQBotNet.Core.Services.Events;

/// <summary>
/// 数据包事件参数
/// </summary>
public class PacketEventArgs : EventArgs
{
    internal PacketEventArgs(Packet packet)
    {
        Packet = packet;
    }

    /// <summary>
    /// 数据包
    /// </summary>
    public readonly Packet Packet;
}
