namespace QQBotNet.OneBot.Models.Messages.Segments;

public interface ISegment<T> : ISegment
{
    public T Data { get; set; }
}

public interface ISegment
{
    public string Type { get; }
}
