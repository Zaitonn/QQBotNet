using System;

namespace QQBotNet.OneBot.Network;

public class MsgRecvEventArgs : EventArgs
{
    public MsgRecvEventArgs(string data, string? identifier = null)
    {
        Identifier = identifier;
        Data = data;
    }

    public string? Identifier { get; init; }

    public string Data { get; init; }
}
