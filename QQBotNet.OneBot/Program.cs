using Microsoft.Extensions.Hosting;
using QQBotNet.Core.Utils;
using QQBotNet.OneBot.Entity;
using System;
using System.CommandLine;
using System.IO;
using System.Text;
using System.Text.Json;

namespace QQBotNet.OneBot;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        var rootCommand = new RootCommand("QQBot的OneBot实现");
        var runCommand = new Command("run", "使用命令行参数运行");
        var initCommand = new Command("init", "创建\"appsettings.json\"");

        var botAppIdArgument = new Argument<string>("botAppId", "机器人应用ID");
        var botTokenArgument = new Argument<string>("botToken", "机器人令牌");
        var botSecretArgument = new Argument<string>("botSecret", "机器人密钥");
        var sandboxOption = new Option<bool>(new[] { "--sandbox", "-sb" }, "使用官方提供的沙箱环境");

        runCommand.AddArgument(botAppIdArgument);
        runCommand.AddArgument(botTokenArgument);
        runCommand.AddArgument(botSecretArgument);
        runCommand.AddOption(sandboxOption);
        runCommand.SetHandler(
            Entry,
            botAppIdArgument,
            botTokenArgument,
            botSecretArgument,
            sandboxOption
        );

        initCommand.SetHandler(CreateAppSettingsJson);

        rootCommand.AddCommand(initCommand);
        rootCommand.AddCommand(runCommand);
        rootCommand.SetHandler(Entry);
        rootCommand.Invoke(args);
    }

    private static void Entry(string botAppId, string botToken, string botSecret, bool sandBox) =>
        new QQBotNetAppBuilder(botAppId, botToken, botSecret, sandBox).Build().Run();

    private static void Entry() => new QQBotNetAppBuilder().Build().Run();

    private static void CreateAppSettingsJson() =>
        File.WriteAllText(
            "appsettings.json",
            JsonSerializer.Serialize(
                new AppSettings(),
                JsonSerializerOptionsFactory.CamelCaseWithIndented
            )
        );
}
