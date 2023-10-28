using System.Net.Http;

namespace QQBotNet.Core.Services;

public sealed partial class HttpService
{
    private readonly HttpClient _httpClient;

    private readonly BotInstance _instance;

    public string AccessToken { get; private set; } = string.Empty;

    internal HttpService(BotInstance instance, bool isSandbox)
    {
        _instance = instance;
        _httpClient = new()
        {
            BaseAddress = new($"https://{(isSandbox ? Constants.SandboxSite : Constants.Site)}")
        };
        _httpClient.DefaultRequestHeaders.Clear();
        _httpClient.DefaultRequestHeaders.Authorization = new(
            "Bot",
            $"{_instance.BotAppId}.{_instance.BotToken}"
        );
        _httpClient.DefaultRequestHeaders.Add("X-Union-Appid", _instance.BotAppId.ToString());
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}
