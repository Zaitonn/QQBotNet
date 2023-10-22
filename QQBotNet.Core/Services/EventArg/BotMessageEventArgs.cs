using System;
using System.Text.Json.Nodes;
using QQBotNet.Core.Entity.WebSockets;

namespace QQBotNet.Core.Services.EventArg;

public class BotMessageEventArgs : EventArgs
{
    public BotMessageEventArgs(OperationCode operationCode, JsonNode? data, string? type)
    {
        OperationCode = operationCode;
        Data = data;
        Type = type;
    }

    public readonly JsonNode? Data;

    public readonly OperationCode OperationCode;

    public readonly string? Type;
}
