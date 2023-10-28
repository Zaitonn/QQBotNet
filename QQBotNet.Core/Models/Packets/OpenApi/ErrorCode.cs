namespace QQBotNet.Core.Models.Packets.OpenApi;

/// <summary>
/// <see>https://bot.q.qq.com/wiki/develop/api/openapi/error/error.html#%E9%94%99%E8%AF%AF%E7%A0%81%E5%A4%84%E7%90%86</see>
/// </summary>
public enum ErrorCode
{
    /// <summary>
    /// 账号异常
    /// </summary>
    UnknownAccount = 10001,

    /// <summary>
    /// 子频道异常
    /// </summary>
    UnknownChannel = 10003,

    /// <summary>
    /// 频道异常
    /// </summary>
    UnknownGuild = 10004,

    /// <summary>
    /// 检查是否是管理员失败，系统错误，一般重试一次会好，最多只能重试一次
    /// </summary>
    ErrorCheckAdminFailed = 11281,

    /// <summary>
    /// 检查是否是管理员未通过，该接口需要管理员权限，但是用户在添加机器人的时候并未授予该权限，属于逻辑错误，可以提示用户进行授权
    /// </summary>
    ErrorCheckAdminNotPass = 11282,

    /// <summary>
    /// 参数中的 appid 错误，开发者填的 token 错误，appid 无法识别
    /// </summary>
    ErrorWrongAppid = 11251,

    /// <summary>
    /// 检查应用权限失败，系统错误，一般重试一次会好，最多只能重试一次
    /// </summary>
    ErrorCheckAppPrivilegeFailed = 11252,

    /// <summary>
    /// 检查应用权限不通过，该机器人应用未获得调用该接口的权限，需要向平台申请
    /// </summary>
    ErrorCheckAppPrivilegeNotPass = 11253,

    /// <summary>
    /// 应用接口被封禁，该机器人虽然获得了该接口权限，但是被封禁了。
    /// </summary>
    ErrorInterfaceForbidden = 11254,

    /// <summary>
    /// 参数中缺少 appid，同 11251
    /// </summary>
    ErrorWrongAppid2 = 11261,

    /// <summary>
    /// 当前接口不支持使用机器人 Bot Token 调用
    /// </summary>
    ErrorCheckRobot = 11262,

    /// <summary>
    /// 检查频道权限失败，系统错误，一般重试一次会好，最多只能重试一次
    /// </summary>
    ErrorCheckGuildAuth = 11263,

    /// <summary>
    /// 检查小站权限未通过，管理员添加机器人的时候未授予该接口权限，属于逻辑错误，可提示用户进行授权，如果已经给予授权，请检查传递的 guild id 是否正确
    /// </summary>
    ErrorGuildAuthNotPass = 11264,

    /// <summary>
    /// 机器人已经被封禁
    /// </summary>
    ErrorRobotHasBaned = 11265,

    /// <summary>
    /// 参数中缺少 token
    /// </summary>
    ErrorWrongToken = 11241,

    /// <summary>
    /// 校验 token 失败，系统错误，一般重试一次会好，最多只能重试一次
    /// </summary>
    ErrorCheckTokenFailed = 11242,

    /// <summary>
    /// 校验 token 未通过，用户填充的 token 错误，需要开发者进行检查
    /// </summary>
    ErrorCheckTokenNotPass = 11243,

    /// <summary>
    /// 检查用户权限失败，当前接口不支持使用 Bearer Token 调用
    /// </summary>
    ErrorCheckUserAuth = 11273,

    /// <summary>
    /// 检查用户权限未通过，用户 OAuth 授权时未给与该接口权限，可提示用户重新进行授权
    /// </summary>
    ErrorUserAuthNotPass = 11274,

    /// <summary>
    /// 无 appid ，同 11251
    /// </summary>
    ErrorWrongAppid3 = 11275,

    /// <summary>
    /// HTTP Header 无效
    /// </summary>
    ErrorGetHTTPHeader = 11301,

    /// <summary>
    /// HTTP Header 无效
    /// </summary>
    ErrorGetHeaderUIN = 11302,

    /// <summary>
    /// 获取昵称失败
    /// </summary>
    ErrorGetNick = 11303,

    /// <summary>
    /// 获取头像失败
    /// </summary>
    ErrorGetAvatar = 11304,

    /// <summary>
    /// 获取频道 ID 失败
    /// </summary>
    ErrorGetGuildID = 11305,

    /// <summary>
    /// 获取频道信息失败
    /// </summary>
    ErrorGetGuildInfo = 11306,

    /// <summary>
    /// 替换 id 失败
    /// </summary>
    ReplaceIDFailed = 12001,

    /// <summary>
    /// 请求体错误
    /// </summary>
    RequestInvalid = 12002,

    /// <summary>
    /// 回包错误
    /// </summary>
    ResponseInvalid = 12003,

    /// <summary>
    /// 子频道消息触发限频
    /// </summary>
    ChannelHitWriteRateLimit = 20028,

    /// <summary>
    /// 消息为空
    /// </summary>
    CannotSendEmptyMessage = 50006,

    /// <summary>
    /// form-data 内容异常
    /// </summary>
    InvalidFormBody = 50035,

    /// <summary>
    /// 带有markdown消息只支持 markdown 或者 keyboard 组合
    /// </summary>
    NotSupportMarkdown = 50037,

    /// <summary>
    /// 非同频道同子频道
    /// </summary>
    NotChildChannel = 50038,

    /// <summary>
    /// 获取消息失败
    /// </summary>
    FailureInGettingMsg = 50039,

    /// <summary>
    /// 消息模版类型错误
    /// </summary>
    ErrorInMsgTemplateType = 50040,

    /// <summary>
    /// markdown 有空值
    /// </summary>
    EmptyMarkdown = 50041,

    /// <summary>
    /// markdown 列表长达最大值
    /// </summary>
    MarkdownListTooLong = 50042,

    /// <summary>
    /// guild_id 转换失败
    /// </summary>
    FailureInParsingGuildId = 50043,

    /// <summary>
    /// 不能回复机器人自己产生的消息
    /// </summary>
    CantReplySelfMsg = 50045,

    /// <summary>
    /// 非 at 机器人消息
    /// </summary>
    NotAtBotMsg = 50046,

    /// <summary>
    /// 非机器人产生的消息 或者 at 机器人消息
    /// </summary>
    CantReplySelfMsgOrNotAtBotMsg = 50047,

    /// <summary>
    /// message id 不能为空
    /// </summary>
    EmptyMessageId = 50048,

    /// <summary>
    /// url 未报备
    /// </summary>
    UrlNotAllowed = 304003,

    /// <summary>
    /// 没有发 ark 消息权限
    /// </summary>
    ArkNotAllowed = 304004,

    /// <summary>
    /// embed 长度超限
    /// </summary>
    EmbedLimit = 304005,

    /// <summary>
    /// 后台配置错误
    /// </summary>
    ServerConfig = 304006,

    /// <summary>
    /// 查询频道异常
    /// </summary>
    GetGuild = 304007,

    /// <summary>
    /// 查询机器人异常
    /// </summary>
    GetBot = 304008,

    /// <summary>
    /// 查询子频道异常
    /// </summary>
    GetChannel = 304009,

    /// <summary>
    /// 图片转存错误
    /// </summary>
    ChangeImageUrl = 304010,

    /// <summary>
    /// 模板不存在
    /// </summary>
    NoTemplate = 304011,

    /// <summary>
    /// 取模板错误
    /// </summary>
    GetTemplate = 304012,

    /// <summary>
    /// 没有模板权限
    /// </summary>
    TemplatePrivilege = 304014,

    /// <summary>
    /// 发消息错误
    /// </summary>
    SendError = 304016,

    /// <summary>
    /// 图片上传错误
    /// </summary>
    UploadError = 304017,

    /// <summary>
    /// 机器人没连上 gateway
    /// </summary>
    SessionNotExist = 304018,

    /// <summary>
    /// @全体成员 次数超限
    /// </summary>
    AtEveryoneLimie = 304019,

    /// <summary>
    /// 文件大小超限
    /// </summary>
    FizeSize = 304020,

    /// <summary>
    /// 下载文件错误
    /// </summary>
    GetFile = 304021,

    /// <summary>
    /// 推送消息时间限制
    /// </summary>
    PushTime = 304022,

    /// <summary>
    /// 推送消息异步调用成功, 等待人工审核
    /// </summary>
    PushMsgAsyncOk = 304023,

    /// <summary>
    /// 回复消息异步调用成功, 等待人工审核
    /// </summary>
    ReplyMsgAsyncOk = 304024,

    /// <summary>
    /// 消息被打击
    /// </summary>
    Beat = 304025,

    /// <summary>
    /// 回复的消息 id 错误
    /// </summary>
    MsgId = 304026,

    /// <summary>
    /// 回复的消息过期
    /// </summary>
    MsgExpire = 304027,

    /// <summary>
    /// 非 At 当前用户的消息不允许回复
    /// </summary>
    MsgProtect = 304028,

    /// <summary>
    /// 调语料服务错误
    /// </summary>
    CorpusError = 304029,

    /// <summary>
    /// 语料不匹配
    /// </summary>
    CorpusNotMatch = 304030,

    /// <summary>
    /// markdown 模版参数错误
    /// </summary>
    ErrorInMarkdownTemplateType = 50054,
}

/*
50049	只能修改含有 keyboard 元素的消息
50050	修改消息时，keyboard 元素不能为空
50051	只能修改机器人自己发送的消息
50053	修改消息错误
50055	无效的 markdown content
50056	不允许发送 markdown content
50057	markdown 参数只支持原生语法或者模版二选一
301000~301099	子频道权限错误
301000	参数错误
301001	查询频道信息错误
301002	查询子频道权限错误
301003	修改子频道权限错误
301004	私密子频道关联的人数到达上限
301005	调用 Rpc 服务失败
301006	非群成员没有查询权限
301007	参数超过数量限制
302000	参数错误
302001	查询频道信息错误
302002	查询日程列表失败
302003	查询日程失败
302004	修改日程失败
302005	删除日程失败
302006	创建日程失败
302007	获取创建者信息失败
302008	子频道 ID 不能为空
302009	频道系统错误，请联系客服
302010	暂无修改日程权限
302011	日程活动已被删除
302012	每天只能创建 10 个日程，明天再来吧！
302013	创建日程触发安全打击
302014	日程持续时间超过 7 天，请重新选择
302015	开始时间不能早于当前时间
302016	结束时间不能早于开始时间
302017	Schedule 对象为空
302018	参数类型转换失败
302019	调用下游失败，请联系客服
302020	日程内容违规、账号违规
302021	频道内当日新增活动达上限
302022	不能绑定非当前频道的子频道
302023	开始时跳转不可绑定日程子频道
302024	绑定的子频道不存在
*/
