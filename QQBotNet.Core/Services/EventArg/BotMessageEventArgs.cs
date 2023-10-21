using System;

namespace QQBotNet.Core.Services.EventArg;

public class BotMessageEventArgs : EventArgs
{
    public BotMessageEventArgs(string message)
    {
        Message = message;
    }

    public readonly string Message;
}
