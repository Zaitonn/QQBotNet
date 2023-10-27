using QQBotNet.Core.Models.Packets.WebSockets;
using System;

namespace QQBotNet.Core.Services.Operations;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public class OperationAttribute : Attribute
{
    public OperationAttribute(OperationCode operation)
    {
        Operation = operation;
    }

    public OperationCode Operation;
}
