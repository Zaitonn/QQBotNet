using QQBotNet.Core.Models.Business.Schedules;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace QQBotNet.Core.Utils.Json;

/// <summary>
/// Converter for tx's shit of string enum bug
/// </summary>
public class RemindTypeConverter : JsonConverter<RemindType>
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public override RemindType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return reader.TokenType switch
        {
            JsonTokenType.Number => (RemindType)reader.GetUInt64(),
            JsonTokenType.String => (RemindType)int.Parse(reader.GetString()!),
            _ => throw new InvalidOperationException()
        };
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public override void Write(
        Utf8JsonWriter writer,
        RemindType value,
        JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(((int)value).ToString());
    }
}
