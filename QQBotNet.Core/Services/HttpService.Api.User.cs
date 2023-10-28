using QQBotNet.Core.Models.Business;
using QQBotNet.Core.Utils;
using QQBotNet.Core.Utils.Extensions;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace QQBotNet.Core.Services;

public sealed partial class HttpService
{
    /// <summary>
    /// 获取用户详情
    /// <br/>
    /// 用于获取当前用户（机器人）详情
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/user/me.html</see>
    /// </summary>
    /// <returns>User对象</returns>
    public async Task<User?> GetCurrentUserAsync()
    {
        return await (
            await _httpClient.SendAsync(
                new(HttpMethod.Get, "/users/@me")
                {
                    Content = new StringContent(string.Empty).WithJsonHeader()
                }
            )
        ).Content.ReadFromJsonAsync<User>(JsonSerializerOptionsFactory.UnsafeSnakeCase);
    }
}
