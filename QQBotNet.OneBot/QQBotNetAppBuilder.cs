using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace QQBotNet.OneBot;

public sealed class QQBotNetAppBuilder
{
    private IServiceCollection Services => _hostAppBuilder.Services;

    private ConfigurationManager Configuration => _hostAppBuilder.Configuration;

    private readonly HostApplicationBuilder _hostAppBuilder;

    internal QQBotNetAppBuilder()
    {
        _hostAppBuilder = new();

        if (File.Exists("appsettings.json"))
            Configuration.AddJsonFile("appsettings.json");
        else
            throw new NotSupportedException(
                "缺少\"appsettings.json\"。"
                    + "请使用\"QQBotNet.OneBot init\"命令创建此文件或使用\"QQBotNet.OneBot run\"直接传递登录信息"
            );

        AddService();
    }

    internal QQBotNetAppBuilder(string botAppId, string botToken, string botSecret, bool sandBox)
    {
        _hostAppBuilder = new();
        Configuration[nameof(botAppId)] = botAppId;
        Configuration[nameof(botToken)] = botToken;
        Configuration[nameof(botSecret)] = botSecret;
        Configuration[nameof(sandBox)] = sandBox.ToString();

        AddService();
    }

    private void AddService()
    {
        Services.AddSingleton<WorkerService>();
    }

    public QQBotNetApp Build() => new(_hostAppBuilder.Build());
}
