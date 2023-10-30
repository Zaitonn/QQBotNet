using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace QQBotNet.Core.Utils;

/// <summary>
/// Json序列化选项工厂
/// </summary>
public static class JsonSerializerOptionsFactory
{
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

    /// <summary>
    /// 蛇形命名规则（忽略null）
    /// </summary>
    public static readonly JsonSerializerOptions UnsafeSnakeCaseAndIgnoreNull =
        new(UnsafeSnakeCase) { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };

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
