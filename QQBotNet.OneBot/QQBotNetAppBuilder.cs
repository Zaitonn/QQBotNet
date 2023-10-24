using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QQBotNet.OneBot.Entity.Config;
using System;
using System.IO;
using System.Text.Json;

namespace QQBotNet.OneBot;

public sealed class QQBotNetAppBuilder
{
    private IServiceCollection Services => _hostAppBuilder.Services;

    private readonly AppConfig _appSettings;

    private readonly HostApplicationBuilder _hostAppBuilder;

    internal QQBotNetAppBuilder()
    {
        _hostAppBuilder = new();

        if (File.Exists("config.json"))
        {
            _appSettings =
                JsonSerializer.Deserialize<AppConfig>(File.ReadAllText("config.json"))
                ?? throw new JsonException("转换\"config.json\"出现空值");
        }
        else
            throw new NotSupportedException(
                "缺少\"config.json\"。"
                    + "请使用\"QQBotNet.OneBot init\"命令创建此文件或使用\"QQBotNet.OneBot run\"直接传递登录信息"
            );

        AddService();
    }

    internal QQBotNetAppBuilder(AppConfig appConfig)
    {
        _hostAppBuilder = new();
        _appSettings = appConfig;
        AddService();
    }

    private void AddService()
    {
        Services.AddSingleton(_appSettings);
    }

    public QQBotNetApp Build() => new(_hostAppBuilder.Build());
}
