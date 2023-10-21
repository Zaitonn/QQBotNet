using System;

namespace QQBotNet.Core.Services;

public interface IBotService : IDisposable
{
    /// <summary>
    /// 启动服务
    /// </summary>
    public void Start();

    /// <summary>
    /// 停止服务
    /// </summary>
    public void Stop();
}
