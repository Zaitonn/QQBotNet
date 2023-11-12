using System;

namespace QQBotNet.OneBot.Models.Messages;

public class Sender
{
    public ulong UserId { get; set; }

    public string NickName { get; set; } = string.Empty;

    public string Sex { get; set; } = "unknown";

    public int Age { get; set; }

    public string Avatar { get; set; } = string.Empty;

    public bool IsBot { get; set; }

    public string? UnionOpenid { get; set; }

    public string? UnionUserAccount { get; set; }

    public string[] Roles { get; set; } = Array.Empty<string>();

    public DateTime JoinedAt { get; set; }
}
