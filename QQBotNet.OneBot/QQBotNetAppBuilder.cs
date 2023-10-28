using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QQBotNet.OneBot.Models.Config;
using QQBotNet.OneBot.Network;
using QQBotNet.OneBot.Utils;
using Spectre.Console;
using System;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace QQBotNet.OneBot;

public sealed class QQBotNetAppBuilder
{
    private IServiceCollection Services => _hostAppBuilder.Services;

    private readonly AppConfig _appConfig;

    private readonly HostApplicationBuilder _hostAppBuilder;

    internal QQBotNetAppBuilder()
    {
        _hostAppBuilder = new();

        if (File.Exists("config.json"))
        {
            _appConfig =
                JsonSerializer.Deserialize<AppConfig>(
                    File.ReadAllText("config.json"),
                    new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        WriteIndented = true,
                        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                        ReadCommentHandling = JsonCommentHandling.Skip
                    }
                ) ?? throw new JsonException("转换\"config.json\"出现空值");
        }
        else
        {
            Logger.Error<QQBotNetAppBuilder>(
                "Tips: 请使用\"QQBotNet.OneBot init\"命令创建此文件或使用\"QQBotNet.OneBot run\"直接传递登录信息",
                new NotSupportedException("缺少\"config.json\"。")
            );
            if (AnsiConsole.Profile.Capabilities.Interactive && !Console.IsInputRedirected)
            {
                Console.ReadKey();
            }
            Environment.Exit(-1);
        }

        AddService();
    }

    internal QQBotNetAppBuilder(AppConfig appConfig)
    {
        _hostAppBuilder = new();
        _appConfig = appConfig;
        AddService();
    }

    private void AddService()
    {
        foreach (var connection in _appConfig.Connections)
        {
            IOneBotService? service;
            try
            {
                service = connection.Type switch
                {
                    "http-post" => new HttpPostService(_appConfig.BotInfo.BotAppId, connection),
                    "reverse-websocket"
                        => new ReverseWSService(_appConfig.BotInfo.BotAppId, connection),
                    _ => null
                };
            }
            catch (Exception e)
            {
                Logger.Warn<QQBotNetAppBuilder>($"初始化{connection.Type}服务时出现问题: {e.Message}");
                continue;
            }

            if (service is null)
                Logger.Warn<QQBotNetAppBuilder>($"配置项中发现未知的连接类型: {connection.Type}");
            else
            {
                Services.AddSingleton(service);
                Logger.Info<QQBotNetAppBuilder>(
                    $"新的{connection.Type}的连接方式已添加（{connection.Address}）"
                );
            }
        }
    }

    public QQBotNetApp Build() => new(_hostAppBuilder.Build(), _appConfig);
}
