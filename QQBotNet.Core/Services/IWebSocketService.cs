using QQBotNet.Core.Services.EventArg;
using WebSocket4Net;
using System;
using SuperSocket.ClientEngine;

namespace QQBotNet.Core.Services;

public interface IWebSocketService
{
    public event EventHandler<MessageReceivedEventArgs> RawMessageReceived;

    public event EventHandler<BotMessageEventArgs> BotMessageReceived;

    public event EventHandler<EventArgs> Opened;

    public event EventHandler<EventArgs> Closed;

    public event EventHandler<ErrorEventArgs> Error;
}
