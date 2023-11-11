using System.Threading.Tasks;

namespace QQBotNet.Core.Utils.Extensions;

internal static class TaskWaiterExtension
{
    public static T WaitResult<T>(this Task<T> task) => task.GetAwaiter().GetResult();
}
