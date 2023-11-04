using System;
using Xunit;

namespace QQBotNet.Core.Tests;

public class Ctor
{
    [Fact]
    public void ShouldThrowWhenCreatingInstanceWithZeroAsBotAppId()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new BotInstance(0, string.Empty));
    }

    [Fact]
    public void ShouldThrowWhenCreatingInstanceWithNullBotToken()
    {
        Assert.Throws<ArgumentNullException>(() => new BotInstance(114514, null!));
    }

    [Fact]
    public void ShouldThrowWhenCreatingInstanceWithEmptyBotToken()
    {
        Assert.Throws<ArgumentException>(() => new BotInstance(114514, string.Empty));
    }
}
