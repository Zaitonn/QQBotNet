namespace QQBotNet.Core.Entity.Back;

public class Session
{
    public int Version { get; set; }

    public string SessionId { get; set; } = string.Empty;

    public User User { get; set; } = new();
}

public class User
{
    public string Id { get; set; } = string.Empty;

    public string Username { get; set; } = string.Empty;

    public bool Bot { get; set; }

    public int Status { get; set; }
}
