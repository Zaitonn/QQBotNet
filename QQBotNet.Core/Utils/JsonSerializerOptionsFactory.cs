using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace QQBotNet.Core.Utils;

internal static class JsonSerializerOptionsFactory
{
    public static readonly JsonSerializerOptions CamelCase =
        new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

    public static readonly JsonSerializerOptions CamelCaseWithIndented =
        new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true };

    public static readonly JsonSerializerOptions SnakeCase =
        new() { PropertyNamingPolicy = new SnakeCaseJsonNamingPolicy() };

    public static readonly JsonSerializerOptions IgnoreNull =
        new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };

    private class SnakeCaseJsonNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name) =>
            Regex
                .Replace(
                    name,
                    "(?=.)[A-Z]",
                    (match) => $"_{match.Groups[0].Value.ToLowerInvariant()}"
                )
                .TrimStart('_');
    }
}
