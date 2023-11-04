using QQBotNet.Core.Models.Packets.OpenApi;
using QQBotNet.Core.Utils.Json;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace QQBotNet.Core.Utils.Extensions;

internal static class ApiExtension
{
    private static HttpPacket<T> Wrap<T>(
        this JsonNode? jsonNode,
        HttpResponseMessage httpResponseMessage
    )
        where T : notnull
    {
        if (jsonNode is JsonObject jsonObject)
        {
            if (jsonObject.ContainsKey("code"))
                return jsonObject.Deserialize<HttpPacket<T>>(
                        JsonSerializerOptionsFactory.UnsafeSnakeCase
                    ) ?? new();

            return new()
            {
                Data = jsonObject.Deserialize<T>(JsonSerializerOptionsFactory.UnsafeSnakeCase),
                Response = httpResponseMessage
            };
        }

        if (jsonNode is JsonArray jsonArray)
            return new()
            {
                Data = jsonArray.Deserialize<T>(JsonSerializerOptionsFactory.UnsafeSnakeCase),
                Response = httpResponseMessage
            };

        if (jsonNode is null)
        {
            if (typeof(T).BaseType != typeof(Array))
                return new() { Response = httpResponseMessage };

            return new()
            {
                Data = (T?)Activator.CreateInstance(typeof(T), 0),
                Response = httpResponseMessage
            };
            // 啥比Api一天到晚返回空响应😅😅😅你没事吧
        }

        throw new InvalidOperationException();
    }

    public static async Task<HttpPacket<T>> Request<T>(
        this HttpClient httpClient,
        HttpMethod httpMethod,
        string endpoint,
        HttpContent? body
    )
        where T : notnull
    {
        var response = await httpClient.SendAsync(new(httpMethod, endpoint) { Content = body });
        var jsonNode = await response.Content.ReadFromJsonAsync<JsonNode>();

        return jsonNode.Wrap<T>(response);
    }

    public static async Task<HttpPacket<T>> RequestJson<T>(
        this HttpClient httpClient,
        HttpMethod httpMethod,
        string endpoint,
        object? body = null,
        bool ignoreNull = false
    )
        where T : notnull
    {
        var response = await httpClient.SendAsync(
            new(httpMethod, endpoint)
            {
                Content = body is null
                    ? null
                    : JsonContent
                        .Create(
                            body,
                            options: ignoreNull
                                ? JsonSerializerOptionsFactory.UnsafeSnakeCaseAndIgnoreNull
                                : JsonSerializerOptionsFactory.UnsafeSnakeCase
                        )
                        .WithJsonHeader()
            }
        );
        var jsonNode = await response.Content.ReadFromJsonAsync<JsonNode>();
        return jsonNode.Wrap<T>(response);
    }

    public static async Task<HttpPacket> RequestJsonWithNoResult<T>(
        this HttpClient httpClient,
        HttpMethod httpMethod,
        string endpoint,
        T? body,
        bool ignoreNull = false
    )
    {
        var response = await httpClient.SendAsync(
            new(httpMethod, endpoint)
            {
                Content = body is null
                    ? null
                    : JsonContent
                        .Create(
                            body,
                            options: ignoreNull
                                ? JsonSerializerOptionsFactory.UnsafeSnakeCaseAndIgnoreNull
                                : JsonSerializerOptionsFactory.UnsafeSnakeCase
                        )
                        .WithJsonHeader()
            }
        );
        var packet =
            await response.Content.ReadFromJsonAsync<HttpPacket>(
                JsonSerializerOptionsFactory.UnsafeSnakeCase
            ) ?? new();

        packet.Response = response;
        return packet;
    }

    public static async Task<HttpPacket> RequestJsonWithNoResult(
        this HttpClient httpClient,
        HttpMethod httpMethod,
        string endpoint,
        bool ignoreNull = false
    ) => await RequestJsonWithNoResult<object>(httpClient, httpMethod, endpoint, null, ignoreNull);
}
