
namespace QQBotNet.Core.Entity.Back;

public class AuthenticationResult
{
    public string AccessToken { get; set; } = string.Empty;

    public string ExpiresIn { get; set; } = string.Empty;
}
