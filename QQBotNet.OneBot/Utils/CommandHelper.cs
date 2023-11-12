using QQBotNet.OneBot.Models.Config;
using System.CommandLine;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Json.Serialization;

namespace QQBotNet.OneBot.Utils;

internal static class CommandHelper
{
    public static RootCommand Create()
    {
        var rootCommand = new RootCommand(
            "QQBot的OneBot C#实现 \nhttps://github.com/Zaitonn/QQBotNet"
        );
        var configCommand = new Command("cfg", "创建\"config.json\"");
        var runCommand = new Command("run", "使用命令行参数运行");
        var runWithEnvCommand = new Command("rune", "读取环境变量运行");

        var botAppIdArgument = new Argument<uint>("botAppId", "机器人应用ID");
        var botTokenArgument = new Argument<string>("botToken", "机器人令牌");
        var appSecretArgument = new Argument<string?>("appSecret", "机器人密钥（可选，提供此值后Api服务将使用v2的验证方式）")
        {
            Arity = ArgumentArity.ZeroOrOne
        };
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
        runCommand.AddArgument(appSecretArgument);
        runCommand.AddOption(sandboxOption);
        runCommand.AddOption(httpOption);
        runCommand.AddOption(httpPostOption);
        runCommand.AddOption(wsOption);
        runCommand.AddOption(reverseWsOption);
        runCommand.SetHandler(
            Entry,
            botAppIdArgument,
            botTokenArgument,
            appSecretArgument,
            sandboxOption,
            httpOption,
            httpPostOption,
            wsOption,
            reverseWsOption
        );

        runWithEnvCommand.AddOption(sandboxOption);
        runWithEnvCommand.AddOption(httpOption);
        runWithEnvCommand.AddOption(httpPostOption);
        runWithEnvCommand.AddOption(wsOption);
        runWithEnvCommand.AddOption(reverseWsOption);
        runWithEnvCommand.SetHandler(
            Entry,
            sandboxOption,
            httpOption,
            httpPostOption,
            wsOption,
            reverseWsOption
        );

        configCommand.SetHandler(CreateAppConfigJson);

        rootCommand.AddCommand(configCommand);
        rootCommand.AddCommand(runCommand);
        rootCommand.AddCommand(runWithEnvCommand);
        rootCommand.SetHandler(Entry);

        return rootCommand;
    }

    private static async Task Entry(
        bool sandBox,
        string[] httpOption,
        string[] httpPostOption,
        string[] wsOption,
        string[] reverseWsOption
    )
    {
        var appConfig = new AppConfig()
        {
            BotInfo = ReadEnvironmentVariables(),
            Sandbox = sandBox,
            Connections = ParseConnection("http", httpOption)
                .Concat(ParseConnection("http-post", httpPostOption))
                .Concat(ParseConnection("websocket", wsOption))
                .Concat(ParseConnection("reverse-websocket", reverseWsOption))
                .ToArray()
        };

        await new QQBotNetApp(appConfig).RunAsync();
    }

    private static async Task Entry(
        uint botAppId,
        string botToken,
        string? appSecret,
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
                AppSecret = appSecret
            },
            Sandbox = sandBox,
            Connections = ParseConnection("http", httpOption)
                .Concat(ParseConnection("http-post", httpPostOption))
                .Concat(ParseConnection("websocket", wsOption))
                .Concat(ParseConnection("reverse-websocket", reverseWsOption))
                .ToArray()
        };

        await new QQBotNetApp(appConfig).RunAsync();
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

    private static async Task Entry() => await new QQBotNetApp(ReadConfig()).RunAsync();

    private static void CreateAppConfigJson()
    {
        Stream stream =
            Assembly
                .GetExecutingAssembly()
                .GetManifestResourceStream("QQBotNet.OneBot.Sources.DefaultConfig.jsonc")
            ?? throw new NullReferenceException(
                "程序集嵌入文件 \"QQBotNet.OneBot.Sources.DefaultConfig.jsonc\" 为空。 " + "请检查编译环境"
            );

        using var fileStream = new FileStream("config.json", FileMode.OpenOrCreate);
        var bytes = new byte[stream.Length];
        _ = stream.Read(bytes, 0, bytes.Length);
        fileStream.Write(bytes);
    }

    private static AppConfig ReadConfig()
    {
        if (File.Exists("config.json"))
        {
            var appConfig =
                JsonSerializer.Deserialize<AppConfig>(
                    File.ReadAllText("config.json"),
                    new JsonSerializerOptions
                    {
                        AllowTrailingCommas = true,
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        WriteIndented = true,
                        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                        ReadCommentHandling = JsonCommentHandling.Skip,
                        NumberHandling = JsonNumberHandling.AllowReadingFromString,
                    }
                ) ?? throw new JsonException("转换\"config.json\"出现空值");

            if (appConfig.UseEnvironmentVariables)
                appConfig.BotInfo = ReadEnvironmentVariables();

            return appConfig;
        }

        Logger.Warn<QQBotNetApp>(
            "Tips: 请使用\"QQBotNet.OneBot cfg\"命令创建此文件或使用\"QQBotNet.OneBot run\"直接传递登录信息"
        );
        throw new NotSupportedException("缺少\"config.json\"。");
    }

    private static BotInfo ReadEnvironmentVariables()
    {
        var env = Environment.GetEnvironmentVariables();

        return new()
        {
            BotAppId = uint.Parse(
                env["QQBOTNET_APPID"]?.ToString()
                    ?? throw new ArgumentNullException("QQBOTNET_APPID", "环境变量\"QQBOTNET_APPID\"为空")
            ),
            BotToken =
                env["QQBOTNET_TOKEN"]?.ToString()
                ?? throw new ArgumentNullException("QQBOTNET_TOKEN", "环境变量\"QQBOTNET_TOKEN\"为空"),
            AppSecret = env["QQBOTNET_SECRET"]?.ToString()
        };
    }
}
