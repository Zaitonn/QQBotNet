using QQBotNet.OneBot.Models.Config;
using System.CommandLine;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System;
using Microsoft.Extensions.Hosting;

namespace QQBotNet.OneBot.Utils;

internal static class CommandHelper
{
    public static RootCommand Create()
    {
        var rootCommand = new RootCommand("QQBot的OneBot C#实现");
        var configCommand = new Command("cfg", "创建\"config.json\"");
        var runCommand = new Command("run", "使用命令行参数运行");

        var botAppIdArgument = new Argument<uint>("botAppId", "机器人应用ID");
        var botTokenArgument = new Argument<string>("botToken", "机器人令牌");
        var botSecretArgument = new Argument<string>("botSecret", "机器人密钥");
        var sandboxOption = new Option<bool>(new[] { "--sandbox", "-sb" }, "使用官方提供的沙箱环境");

        var httpOption = new Option<string[]>(new[] { "--http", "-ht" }, "正向HTTP地址")
        {
            AllowMultipleArgumentsPerToken = true,
            Arity = ArgumentArity.ZeroOrMore
        };
        var httpPostOption = new Option<string[]>(new[] { "--http-post", "-hp" }, "反向Http-Post地址")
        {
            AllowMultipleArgumentsPerToken = true,
            Arity = ArgumentArity.ZeroOrMore
        };
        var wsOption = new Option<string[]>(new[] { "--websocket", "-ws" }, "正向WebSocket地址")
        {
            AllowMultipleArgumentsPerToken = true,
            Arity = ArgumentArity.ZeroOrMore
        };
        var reverseWsOption = new Option<string[]>(
            new[] { "--reverse-websocket", "-rws" },
            "反向WebSocket地址"
        )
        {
            AllowMultipleArgumentsPerToken = true,
            Arity = ArgumentArity.ZeroOrMore
        };

        runCommand.AddArgument(botAppIdArgument);
        runCommand.AddArgument(botTokenArgument);
        runCommand.AddArgument(botSecretArgument);
        runCommand.AddOption(sandboxOption);
        runCommand.AddOption(httpOption);
        runCommand.AddOption(httpPostOption);
        runCommand.AddOption(wsOption);
        runCommand.AddOption(reverseWsOption);
        runCommand.SetHandler(
            Entry,
            botAppIdArgument,
            botTokenArgument,
            botSecretArgument,
            sandboxOption,
            httpOption,
            httpPostOption,
            wsOption,
            reverseWsOption
        );

        configCommand.SetHandler(CreateAppConfigJson);

        rootCommand.AddCommand(configCommand);
        rootCommand.AddCommand(runCommand);
        rootCommand.SetHandler(Entry);

        return rootCommand;
    }

    private static void Entry(
        uint botAppId,
        string botToken,
        string botSecret,
        bool sandBox,
        string[] httpOption,
        string[] httpPostOption,
        string[] wsOption,
        string[] reverseWsOption
    )
    {
        var appConfig = new AppConfig()
        {
            BotInfo =
            {
                BotAppId = botAppId,
                BotToken = botToken,
                BotSecret = botSecret
            },
            Sandbox = sandBox,
            Connections = ParseConnection("http", httpOption)
                .Concat(ParseConnection("http-post", httpPostOption))
                .Concat(ParseConnection("websocket", wsOption))
                .Concat(ParseConnection("reverse-websocket", reverseWsOption))
                .ToArray()
        };

        new QQBotNetAppBuilder(appConfig).Build();
    }

    private static IEnumerable<Connection> ParseConnection(string type, string[] items)
    {
        var connections = new List<Connection>();
        foreach (var addr in items)
        {
            connections.Add(new() { Type = type, Address = addr });
        }

        return connections;
    }

    private static void Entry() => new QQBotNetAppBuilder().Build().Run();

    private static void CreateAppConfigJson()
    {
        Stream stream =
            Assembly
                .GetExecutingAssembly()
                .GetManifestResourceStream("QQBotNet.OneBot.Sources.DefaultConfig.jsonc")
            ?? throw new NullReferenceException(
                "\"QQBotNet.OneBot.Sources.DefaultConfig.jsonc\" is null. "
                    + "Please check the building environment."
            );

        using var fileStream = new FileStream("config.json", FileMode.OpenOrCreate);
        var bytes = new byte[stream.Length];
        _ = stream.Read(bytes, 0, bytes.Length);
        fileStream.Write(bytes);
    }
}
