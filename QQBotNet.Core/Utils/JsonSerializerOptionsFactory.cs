using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace QQBotNet.Core.Utils;

public static class JsonSerializerOptionsFactory
{
    /// <summary>
    /// 小驼峰命名规则
    /// </summary>
    public static readonly JsonSerializerOptions CamelCase =
        new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

    /// <summary>
    /// 蛇形命名规则
    /// </summary>
    public static readonly JsonSerializerOptions UnsafeSnakeCase =
        new()
        {
            PropertyNamingPolicy = new SnakeCaseJsonNamingPolicy(),
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            NumberHandling = JsonNumberHandling.AllowReadingFromString
        };

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
