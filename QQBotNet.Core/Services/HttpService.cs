using QQBotNet.Core.Constants;
using QQBotNet.Core.Entity;
using System.Net.Http;
using System.Timers;

namespace QQBotNet.Core.Services;

public sealed partial class HttpService : IBotService
{
    public readonly HttpClient AuthenticationHttpClient;

    public readonly HttpClient InterfaceHttpClient;

    private readonly SensitiveInfo _info;

    private readonly Timer _timer;

    public string AccessToken { get; private set; } = string.Empty;

    internal HttpService(SensitiveInfo info, bool isSandbox)
    {
        _info = info;

        AuthenticationHttpClient = new();
        InterfaceHttpClient = new()
        {
            BaseAddress = new($"https://{(isSandbox ? Urls.SandboxSite : Urls.Site)}")
        };
        InterfaceHttpClient.DefaultRequestHeaders.Clear();
        InterfaceHttpClient.DefaultRequestHeaders.TryAddWithoutValidation(
            "X-Union-Appid",
            _info.BotAppId
        );

        _timer = new(60_000);
        _timer.Elapsed += async (_, _) => await GetAppAccessToken();
    }

    public void Dispose()
    {
        InterfaceHttpClient.Dispose();
        _timer.Dispose();
    }

    public void Start()
    {
        _timer.Start();
        GetAppAccessToken().Wait();
    }

    public void Stop()
    {
        _timer.Stop();
    }
}
