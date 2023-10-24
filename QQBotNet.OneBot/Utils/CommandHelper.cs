using System.Collections.Generic;
using Microsoft.Extensions.Hosting;
using QQBotNet.Core.Utils;
using QQBotNet.OneBot.Entity.Config;
using System.CommandLine;
using System.IO;
using System.Text.Json;
using System;
using System.Linq;

namespace QQBotNet.OneBot.Utils;

internal static class CommandHelper
{
    public static RootCommand Create()
    {
        var rootCommand = new RootCommand("QQBot的OneBot C#实现");
        var initCommand = new Command("init", "创建\"appsettings.json\"");
        var runCommand = new Command("run", "使用命令行参数运行");

        var botAppIdArgument = new Argument<string>("botAppId", "机器人应用ID");
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

        initCommand.SetHandler(CreateAppConfigJson);

        rootCommand.AddCommand(initCommand);
        rootCommand.AddCommand(runCommand);
        rootCommand.SetHandler(Entry);

        return rootCommand;
    }

    private static void Entry(
        string botAppId,
        string botToken,
        string botSecret,
        bool sandBox,
        string[] httpOption,
        string[] httpPostOption,
        string[] wsOption,
        string[] reverseWsOption
    )
    {
        var appsettings = new AppConfig()
        {
            BotAppId = botAppId,
            BotToken = botToken,
            BotSecret = botSecret,
            Sandbox = sandBox,
            Connections = ParseConnection("http", httpOption)
                .Concat(ParseConnection("http-post", httpPostOption))
                .Concat(ParseConnection("websocket", wsOption))
                .Concat(ParseConnection("reverse-websocket", reverseWsOption))
                .ToArray()
        };

        new QQBotNetAppBuilder(appsettings).Build().Run();
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

    private static void CreateAppConfigJson() =>
        File.WriteAllText(
            "config.json",
            JsonSerializer.Serialize(
                new AppConfig
                {
                    BotAppId = "<开发者ID>",
                    BotSecret = "<机器人密钥>",
                    BotToken = "<机器人令牌>"
                },
                JsonSerializerOptionsFactory.CamelCaseWithIndented
            )
        );
}
