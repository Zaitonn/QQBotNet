using System.Threading.Tasks;

namespace QQBotNet.Core.Utils.Extensions;

internal static class TaskWaiterExtension
{
    /// <summary>
    /// 等待任务结果
    /// </summary>
    public static T WaitResult<T>(this Task<T> task) => task.GetAwaiter().GetResult();
}
