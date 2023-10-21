using System.Text.Json.Serialization;

namespace QQBotNet.Core.Entity.Send;

public class Authentication
{
    public string AppId { get; init; } = string.Empty;

    public string ClientSecret { get; init; } = string.Empty;
}
