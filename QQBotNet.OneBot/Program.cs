using QQBotNet.OneBot.Utils;
using System;
using System.CommandLine;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QQBotNet.OneBot;

public static class Program
{
    public static int Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        if (Environment.OSVersion.Platform == PlatformID.Win32NT)
        {
            AssemblyName assemblyName = Assembly.GetCallingAssembly().GetName();
            Console.Title = $"{assemblyName.Name} v{assemblyName.Version}";
        }

        AppDomain.CurrentDomain.UnhandledException += (_, e) =>
            Logger.Error<AppDomain>("发生了未经处理的异常: " + (e.ExceptionObject as Exception)?.Message);

        TaskScheduler.UnobservedTaskException += (_, e) =>
            Logger.Error<TaskScheduler>("", e.Exception);

        return CommandHelper.Create().Invoke(args);
    }
}
