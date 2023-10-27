using QQBotNet.OneBot.Utils;
using System;
using System.CommandLine;
using System.Reflection;
using System.Text;

namespace QQBotNet.OneBot;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            Console.Title = "QQBotNet.OneBot v" + Assembly.GetCallingAssembly().GetName().Version;

        CommandHelper.Create().Invoke(args);
    }
}
