using System;

namespace QQBotNet.Core.Utils.Extensions;

internal static class StringExtension
{
    public static string Encode(this string url) => Uri.EscapeDataString(url);
}
