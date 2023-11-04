using QQBotNet.Core.Models.Business.Forums;
using QQBotNet.Core.Models.Business.Guilds;
using QQBotNet.Core.Models.Packets.OpenApi;
using QQBotNet.Core.Models.Packets.OpenApi.Body;
using QQBotNet.Core.Utils.Extensions;
using System.Net.Http;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace QQBotNet.Core.Services.Apis;

/// <summary>
/// 帖子Api
/// </summary>
public static class ForumApi
{
    /// <summary>
    /// 获取帖子列表
    /// <br/>
    /// 获取子频道下的帖子列表
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/forum/get_threads_list.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="channelId">子频道ID</param>
    /// <returns>帖子列表</returns>
    public static async Task<HttpPacket<ThreadList>> GetThreadListAsync(
        this HttpService httpService,
        string channelId
    )
    {
        return await httpService.HttpClient.RequestJson<ThreadList>(
            HttpMethod.Get,
            $"/channels/{channelId.Encode()}/threads"
        );
    }

    /// <summary>
    /// 获取帖子详情
    /// <br/>
    /// 获取子频道下的帖子详情
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/forum/get_thread.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="channelId">子频道ID</param>
    /// <param name="threadId">帖子ID</param>
    /// <returns>帖子列表</returns>
    public static async Task<HttpPacket<ThreadInfo>> GetThreadAsync(
        this HttpService httpService,
        string channelId,
        string threadId
    )
    {
        return await httpService.HttpClient.RequestJson<ThreadInfo>(
            HttpMethod.Get,
            $"/channels/{channelId.Encode()}/threads/{threadId.Encode()}"
        );
    }

    /// <summary>
    /// 发表帖子
    /// <br/>
    /// 在子频道下发表帖子
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/forum/put_thread.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="channelId">子频道ID</param>
    /// <param name="title">帖子标题</param>
    /// <param name="content">帖子内容</param>
    /// <param name="format">帖子文本格式</param>
    /// <returns>帖子信息</returns>
    public static async Task<HttpPacket<ThreadInfo>> CreateThreadAsync(
        this HttpService httpService,
        string channelId,
        string title,
        string content,
        ThreadFormatType format
    )
    {
        return await httpService.HttpClient.RequestJson<ThreadInfo>(
            HttpMethod.Put,
            $"/channels/{channelId.Encode()}/threads",
            new JsonObject
            {
                { "title", title },
                { "content", content },
                { "format", (int)format },
            }
        );
    }

    /// <summary>
    /// 删除帖子
    /// <br/>
    /// 删除指定子频道下的某个帖子
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/forum/delete_thread.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="channelId">子频道ID</param>
    /// <param name="threadId">帖子ID</param>
    public static async Task<HttpPacket> DeleteThreadAsync(
        this HttpService httpService,
        string channelId,
        string threadId
    )
    {
        return await httpService.HttpClient.RequestJsonWithNoResult(
            HttpMethod.Delete,
            $"/channels/{channelId.Encode()}/threads/{threadId.Encode()}"
        );
    }
}
