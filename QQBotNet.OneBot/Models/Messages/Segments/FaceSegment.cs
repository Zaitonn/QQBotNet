namespace QQBotNet.OneBot.Models.Messages.Segments;

public class FaceSegment : ISegment<FaceSegmentData>
{
    public string Type => "face";

    public FaceSegmentData Data { get; set; } = new();

    public override string ToString()
    {
        return $"[CQ:face,id={Data.Id}]";
    }
}
