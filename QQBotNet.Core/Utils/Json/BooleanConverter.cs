using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace QQBotNet.Core.Utils.Json;

/// <summary>
/// 布尔值转换器
/// </summary>
public class BooleanConverter : JsonConverter<bool>
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public override bool Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return reader.TokenType switch
        {
            JsonTokenType.Number => reader.GetInt64() == 1,
            JsonTokenType.String => bool.Parse(reader.GetString()!),
            _ => throw new InvalidOperationException()
        };
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value ? 1 : 0);
    }
}
