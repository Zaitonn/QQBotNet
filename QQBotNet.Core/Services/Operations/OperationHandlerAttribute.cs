using QQBotNet.Core.Models.Packets.WebSockets;
using System;

namespace QQBotNet.Core.Services.Operations;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
internal class OperationHandlerAttribute : Attribute
{
    internal OperationHandlerAttribute(OperationCode operation)
    {
        Operation = operation;
    }

    public OperationCode Operation;
}
