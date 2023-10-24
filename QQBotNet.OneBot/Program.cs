using QQBotNet.OneBot.Utils;
using System;
using System.CommandLine;
using System.Text;

namespace QQBotNet.OneBot;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
        CommandHelper.Create().Invoke(args);
    }
}
