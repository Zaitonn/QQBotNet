using QQBotNet.Core.Models.Business;
using QQBotNet.Core.Utils;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace QQBotNet.Core.Services;

public sealed partial class HttpService
{
    /// <summary>
    /// 获取频道详情
    /// <br/>
    /// 用于获取 guild_id 指定的频道的详情
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/guild/get_guild.html</see>
    /// </summary>
    /// <returns>Guild对象</returns>
    public async Task<Guild?> GetGuildAsync(string guildId)
    {
        return await _httpClient.GetFromJsonAsync<Guild>(
            $"/guild_id/{guildId}",
            JsonSerializerOptionsFactory.UnsafeSnakeCase
        );
    }
}
