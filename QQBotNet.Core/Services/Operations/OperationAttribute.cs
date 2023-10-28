using QQBotNet.Core.Models.Packets.WebSockets;
using System;

namespace QQBotNet.Core.Services.Operations;

/// <summary>
/// 操作属性
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public class OperationAttribute : Attribute
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
