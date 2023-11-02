using QQBotNet.Core.Models.Business.Schedules;
using QQBotNet.Core.Models.Packets.OpenApi;
using QQBotNet.Core.Utils.Extensions;
using System.Net.Http;
using System.Threading.Tasks;

#if NETFRAMEWORK
using System;
#endif

namespace QQBotNet.Core.Services.Apis;

/// <summary>
/// 日程Api
/// </summary>
public static class ScheduleApi
{
    /// <summary>
    /// 获取频道日程列表
    /// <br/>
    /// 获取指定的子频道中当天的日程列表
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/schedule/get_schedules.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="channelId">子频道ID</param>
    /// <param name="since">起始时间戳</param>
    /// <returns><see cref="Schedule"/>数组</returns>
    public static async Task<HttpPacket<Schedule[]>> GetSchedulesAsync(
        this HttpService httpService,
        string channelId,
        uint? since = null
    )
    {
        return await httpService.HttpClient.RequestJson<Schedule[]>(
            HttpMethod.Get,
            since is null
                ? $"/channels/{channelId.Encode()}/schedules"
                : $"/channels/{channelId.Encode()}/schedules?since={since}"
        );
    }

    /// <summary>
    /// 获取日程详情
    /// <br/>
    /// 获取日程子频道下指定的的日程的详情
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/schedule/get_schedule.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="channelId">子频道ID</param>
    /// <param name="scheduleId">日程ID</param>
    /// <returns><see cref="Schedule"/>数组</returns>
    public static async Task<HttpPacket<Schedule[]>> GetScheduleAsync(
        this HttpService httpService,
        string channelId,
        string scheduleId
    )
    {
        return await httpService.HttpClient.RequestJson<Schedule[]>(
            HttpMethod.Get,
            $"/channels/{channelId.Encode()}/schedules/{scheduleId.Encode()}"
        );
    }

    /// <summary>
    /// 创建日程
    /// <br/>
    /// 在指定的日程子频道下创建一个日程
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/schedule/post_schedule.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="channelId">子频道ID</param>
    /// <param name="schedule">日程，不需要带<see cref="Schedule.Id"/></param>
    /// <returns><see cref="Schedule"/></returns>
    public static async Task<HttpPacket<Schedule>> CreateScheduleAsync(
        this HttpService httpService,
        string channelId,
        Schedule schedule
    )
    {
        return await httpService.HttpClient.RequestJson<Schedule>(
            HttpMethod.Post,
            $"/channels/{channelId.Encode()}/schedules",
            schedule,
            true
        );
    }

#pragma warning disable CS1998

    /// <summary>
    /// 修改日程
    /// <br/>
    /// 修改指定的日程子频道下指定的日程的详情
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/schedule/patch_schedule.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="channelId">子频道ID</param>
    /// <param name="schedule">日程，不需要带<see cref="Schedule.Id"/></param>
    /// <param name="scheduleId">日程ID</param>
    /// <returns><see cref="Schedule"/></returns>
#if NETFRAMEWORK
    [Obsolete("此版本的Net框架下不支持Patch方法", true)]
#endif
    public static async Task<HttpPacket<Schedule>> EditScheduleAsync(
        this HttpService httpService,
        string channelId,
        string scheduleId,
        Schedule schedule
    )
    {
#if NETFRAMEWORK
        throw new NotSupportedException("此版本的Net框架下不支持Patch方法");
#else
        return await httpService.HttpClient.RequestJson<Schedule>(
            HttpMethod.Patch,
            $"/channels/{channelId.Encode()}/schedules/{scheduleId.Encode()}",
            schedule,
            true
        );
#endif
    }

#pragma warning restore CS1998

    /// <summary>
    /// 删除日程
    /// <br/>
    /// 删除日程子频道下指定的日程
    /// <br/>
    /// <see>https://bot.q.qq.com/wiki/develop/api/openapi/schedule/delete_schedule.html</see>
    /// </summary>
    /// <param name="httpService">Http服务</param>
    /// <param name="channelId">子频道ID</param>
    /// <param name="scheduleId">日程ID</param>
    public static async Task<HttpPacket> DeleteScheduleAsync(
        this HttpService httpService,
        string channelId,
        string scheduleId
    )
    {
        return await httpService.HttpClient.RequestJsonWithNoResult(
            HttpMethod.Delete,
            $"/channels/{channelId.Encode()}/schedules/{scheduleId.Encode()}"
        );
    }
}
