using System.Threading.Tasks;

namespace QQBotNet.Core.Utils.Extensions;

public static class TaskWaiter
{
    public static T WaitResult<T>(this Task<T> task) => task.GetAwaiter().GetResult();
}
