using Spectre.Console;
using System;

namespace QQBotNet.OneBot.Utils;

public class Logger
{
    internal static bool EnableDebugLog;

    public static void Info() => Console.WriteLine();

    public static void Info<T>(string? line)
    {
        AnsiConsole.MarkupLineInterpolated(
            $"{DateTime.Now:T} [cadetblue_1][[INFO]][/]  [[{typeof(T)}]] {line}"
        );
    }

    public static void Warn<T>(string? line)
    {
        AnsiConsole.MarkupLineInterpolated(
            $"{DateTime.Now:T} [yellow bold][[WARN]]  [[{typeof(T)}]] {line}[/]"
        );
    }

    public static void Error<T>(string? message, Exception e)
    {
        AnsiConsole.MarkupLineInterpolated(
            $"{DateTime.Now:T} [red bold][[ERROR]] [[{typeof(T)}]] {message}\n{e}[/]"
        );
    }

    public static void Error<T>(string? line)
    {
        AnsiConsole.MarkupLineInterpolated(
            $"{DateTime.Now:T} [red bold][[ERROR]] [[{typeof(T)}]] {line}[/]"
        );
    }

    public static void Debug<T>(string? line)
    {
        if (EnableDebugLog)
            AnsiConsole.MarkupLineInterpolated(
                $"{DateTime.Now:T} [mediumpurple4 bold][[DEBUG]][/] [[{typeof(T)}]] {line}"
            );
        System.Diagnostics.Debug.WriteLine($"[{typeof(T)}] {line}");
    }
}
