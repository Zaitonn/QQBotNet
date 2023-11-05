using QQBotNet.Core.Models.Packets.WebSockets;
using System;

namespace QQBotNet.Core.Services.Operations;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
internal class OperationAttribute : Attribute
{
    internal OperationAttribute(OperationCode operation)
    {
        Operation = operation;
    }

    /// <summary>
    /// WebSocket数据包操作代码
    /// </summary>
    public OperationCode Operation;
}
