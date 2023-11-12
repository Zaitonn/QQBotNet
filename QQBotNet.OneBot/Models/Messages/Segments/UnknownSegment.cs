namespace QQBotNet.OneBot.Models.Messages.Segments;

public class UnknownSegment : ISegment<object>
{
    public string Type => "unknown";

    public object Data { get; set; } = new();

    public override string ToString()
    {
        return "[不支持的消息]";
    }
}
