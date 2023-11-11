using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace QQBotNet.Core.Utils.Json;

/// <summary>
/// 毫秒级时间戳转换器
/// </summary>
public class MsTimestampConverter : JsonConverter<DateTime>
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public override DateTime Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return reader.TokenType switch
        {
            JsonTokenType.Number => ParseToDateTime((long)reader.GetDouble()),
            JsonTokenType.String => ParseToDateTime(long.Parse(reader.GetString()!)),
            _ => throw new InvalidOperationException()
        };
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue((value - new DateTime(1970, 0, 0)).TotalMilliseconds.ToString());
    }

    private static DateTime ParseToDateTime(long timestamp) =>
        new DateTime(1970, 1, 1).AddMilliseconds(timestamp);
}
