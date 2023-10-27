namespace QQBotNet.Core.Models.Packets.OpenApi;

public class AuthenticationResult
{
    public string AccessToken { get; set; } = string.Empty;

    public string ExpiresIn { get; set; } = string.Empty;
}
