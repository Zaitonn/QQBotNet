using QQBotNet.Core.Models.Packets.OpenApi;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace QQBotNet.Core.Utils.Extensions;

internal static class ApiExtension
{
    public static HttpPacket<T> Wrap<T>(
        this JsonNode? jsonNode,
        JsonSerializerOptions? options = null
    )
        where T : notnull
    {
        if (jsonNode is JsonObject jsonObject)
        {
            if (jsonObject.ContainsKey("code"))
                return jsonObject.Deserialize<HttpPacket<T>>(
                        options ?? JsonSerializerOptionsFactory.UnsafeSnakeCase
                    ) ?? new();

            return new()
            {
                Data = jsonObject.Deserialize<T>(
                    options ?? JsonSerializerOptionsFactory.UnsafeSnakeCase
                )
            };
        }

        if (jsonNode is JsonArray jsonArray)
            return new()
            {
                Data = jsonArray.Deserialize<T>(
                    options ?? JsonSerializerOptionsFactory.UnsafeSnakeCase
                )
            };

        throw new InvalidOperationException();
    }

    public static async Task<HttpPacket<T>> RequestJson<T>(
        this HttpClient httpClient,
        HttpMethod httpMethod,
        string endpoint,
        object? body = null
    )
        where T : notnull
    {
        var response = await httpClient.SendAsync(
            new(httpMethod, endpoint)
            {
                Content = body is null
                    ? null
                    : JsonContent
                        .Create(body, options: JsonSerializerOptionsFactory.UnsafeSnakeCase)
                        .WithJsonHeader()
            }
        );
        var jsonNode =
            (await response.Content.ReadFromJsonAsync<JsonNode>())
            ?? throw new InvalidOperationException("返回数据为空");

        return jsonNode.Wrap<T>();
    }

    public static async Task<HttpPacket> RequestJsonWithNoResult<T>(
        this HttpClient httpClient,
        HttpMethod httpMethod,
        string endpoint,
        T? body
    )
    {
        var response = await httpClient.SendAsync(
            new(httpMethod, endpoint)
            {
                Content = body is null
                    ? null
                    : JsonContent
                        .Create(body, options: JsonSerializerOptionsFactory.UnsafeSnakeCase)
                        .WithJsonHeader()
            }
        );
        var packet =
            await response.Content.ReadFromJsonAsync<HttpPacket>(
                JsonSerializerOptionsFactory.UnsafeSnakeCase
            ) ?? throw new InvalidOperationException("返回数据为空");

        return packet;
    }

    public static async Task<HttpPacket> RequestJsonWithNoResult(
        this HttpClient httpClient,
        HttpMethod httpMethod,
        string endpoint
    ) => await RequestJsonWithNoResult<object>(httpClient, httpMethod, endpoint, null);
}
