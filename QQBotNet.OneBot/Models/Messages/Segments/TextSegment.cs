namespace QQBotNet.OneBot.Models.Messages.Segments;

public class TextSegment : ISegment<TextSegmentData>
{
    public string Type => "text";

    public TextSegmentData Data { get; set; } = new();

    public override string ToString()
    {
        return Data.Text;
    }
}
