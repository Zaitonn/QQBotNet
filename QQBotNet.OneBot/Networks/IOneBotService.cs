using System;
using System.Threading;
using System.Threading.Tasks;

namespace QQBotNet.OneBot.Network;

public interface IOneBotService
{
    public event EventHandler<MsgRecvEventArgs> OnMessageReceived;

    public Task SendJsonAsync(string json, CancellationToken cancellationToken = default);

    public Task StartAsync(CancellationToken cancellationToken);

    public Task StopAsync();
}
