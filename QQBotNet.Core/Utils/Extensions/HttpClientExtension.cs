using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace QQBotNet.Core.Utils.Extensions;

internal static class HttpClientExtension
{
    public static async Task<HttpResponseMessage> PostJsonAsync(
        this HttpClient httpClient,
        string url,
        object obj,
        JsonSerializerOptions? options = null
    )
    {
        var content = new StringContent(JsonSerializer.Serialize(obj, options));
        content.Headers.ContentType = new("application/json");
        return await httpClient.PostAsync(url, content);
    }
}
