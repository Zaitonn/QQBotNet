using QQBotNet.Core.Constants;
using System.Net.Http;
using System.Timers;

namespace QQBotNet.Core.Services;

public sealed partial class HttpService : IBotService
{
    public readonly HttpClient AuthenticationHttpClient;

    public readonly HttpClient InterfaceHttpClient;

    private readonly Timer _timer;

    private readonly BotInstance _instance;

    public string AccessToken { get; private set; } = string.Empty;

    internal HttpService(BotInstance instance, bool isSandbox)
    {
        AuthenticationHttpClient = new();
        InterfaceHttpClient = new()
        {
            BaseAddress = new($"https://{(isSandbox ? Urls.SandboxSite : Urls.Site)}")
        };
        InterfaceHttpClient.DefaultRequestHeaders.Clear();
        InterfaceHttpClient.DefaultRequestHeaders.TryAddWithoutValidation(
            "X-Union-Appid",
            instance.BotAppId.ToString()
        );

        _timer = new(60_000);
        _timer.Elapsed += async (_, _) => await GetAppAccessToken();

        _instance = instance;
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
