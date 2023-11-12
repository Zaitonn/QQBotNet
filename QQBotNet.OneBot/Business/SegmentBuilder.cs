using System.Collections.Generic;
using System.Text;
using QQBotNet.Core.Models.Business.Messages;
using QQBotNet.OneBot.Models.Messages.Segments;

namespace QQBotNet.OneBot.Business;

public static class SegmentBuilder
{
    public static ISegment[] Parse(Message message)
    {
        var list = new List<ISegment>();

        if (message.Content is not null)
            // TODO： 分割艾特和表情
            list.Add(new TextSegment { Data = { Text = message.Content } });

        if (message.Attachments is not null)
            foreach (var attachment in message.Attachments)
            {
                if (attachment.ContentType?.StartsWith("image/") ?? false)
                {
                    list.Add(new ImageSegment { Data = new() { Url = attachment.Url } });
                }
                switch (attachment.ContentType)
                {
                    default:
                        list.Add(new UnknownSegment { Data = attachment });
                        break;
                }
            }

        return list.ToArray();
    }

    public static string ToStringWithCQCode(this ISegment[] segments)
    {
        var stringBuilder = new StringBuilder();

        foreach (var segment in segments)
        {
            stringBuilder.Append(segment.ToString());
        }

        return stringBuilder.ToString();
    }
}
