using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace QQBotNet.OneBot;

public sealed class QQBotNetApp : IHost
{
    private readonly IHost _hostApp;

    public IServiceProvider Services => _hostApp.Services;
    public WorkerService Worker => Services.GetRequiredService<WorkerService>();

    public readonly ILogger<QQBotNetApp> Logger;

    internal QQBotNetApp(IHost host)
    {
        _hostApp = host;
        Logger = Services.GetRequiredService<ILogger<QQBotNetApp>>();
    }

    public void Dispose()
    {
        _hostApp.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task StartAsync(CancellationToken cancellationToken = default)
    {
        Logger.LogInformation("QQBotNet.OneBot已启动");
        await Worker.StartAsync(cancellationToken);
    }

    public async Task StopAsync(CancellationToken cancellationToken = default)
    {
        await Worker.StopAsync(cancellationToken);        
        await _hostApp.StopAsync(cancellationToken);
        Logger.LogInformation("QQBotNet.OneBot已关闭");
    }
}
