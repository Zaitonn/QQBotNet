namespace QQBotNet.OneBot.Models.Messages.Segments;

public class ImageSegment : ISegment<ImageSegmentData>
{
    public string Type => "image";

    public ImageSegmentData Data { get; set; } = new();

    public override string ToString()
    {
        return $"[CQ:image,url={Data.Url ?? "null"},file={Data.Url ?? "null"}]";
    }
}
