using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace QQBotNet.Core.Utils.Json;

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
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            NumberHandling = JsonNumberHandling.AllowReadingFromString
        };

    /// <summary>
    /// 蛇形命名规则（忽略null）
    /// </summary>
    public static readonly JsonSerializerOptions UnsafeSnakeCaseAndIgnoreNull =
        new(UnsafeSnakeCase) { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault };
}
