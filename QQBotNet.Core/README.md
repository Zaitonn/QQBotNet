
# QQBotNet.Core

[![Nuget](https://img.shields.io/nuget/v/QQBotNet.Core)](https://www.nuget.org/packages/QQBotNet.Core)
[![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/QQBotNet.Core)](https://www.nuget.org/packages/QQBotNet.Core)

QQ机器人的**非官方**C# SDK

## 安装

[Nuget](https://www.nuget.org/packages/QQBotNet.Core)

```ps
dotnet add package QQBotNet.Core
```

## 使用方法

```cs
using QQBotNet.Core;
using QQBotNet.Core.Services.Apis;

// 初始化实例
var botInstance = new BotInstance(114514, "1919810"); 

// 启动WebSocket服务
botInstance.WebSocketService.Start();

// 消息处理
botInstance.EventDispatcher.MessageCreated += async (_, e) =>
    await botInstance.HttpService.SendMessageAsync(e.Data!.ChannelId, "hello");
  
Task.Delay(20000).Wait();
// 释放相关资源
botInstance.Dispose();
```

## 优点

- 所有`public`类和成员均有XML注释
- 所有[OpenApi](./QQBotNet.Core/Services/Apis/)使用[扩展方法](https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/extension-methods)声明且支持异步调用
- 实体类和API全覆盖
- 优化了tx的\*\*的API返回格式
- 支持多Net框架
  - .NET
  - .NET Core
  - .NET Standard
  - .NET Framework
  - Mono
  - Xamarin

## 主要的命名空间

- `QQBotNet.Core`
  - `BotInstance` 机器人实例类
  - `Constants` 常量
- `QQBotNet.Core.Models.Business` 业务相关实体类
  - `QQBotNet.Core.Models.Business.Announcement`
  - `QQBotNet.Core.Models.Business.Audio`
  - `QQBotNet.Core.Models.Business.Channels`
  - `QQBotNet.Core.Models.Business.Forums`
  - `QQBotNet.Core.Models.Business.Guilds`
  - `QQBotNet.Core.Models.Business.Members`
  - `QQBotNet.Core.Models.Business.Messages`
  - `QQBotNet.Core.Models.Business.Messages.Keyboard`
  - `QQBotNet.Core.Models.Business.Permissions`
  - `QQBotNet.Core.Models.Business.Reactions`
  - `QQBotNet.Core.Models.Business.Schedules`
- `QQBotNet.Core.Models.Packets` 业务相关实体类
  - `QQBotNet.Core.Models.Packets.OpenApi`
  - `QQBotNet.Core.Models.Packets.WebSocket`
- `QQBotNet.Core.Services` Http服务和WebSocket服务
  - `QQBotNet.Core.Services.Apis` Http服务的Api扩展类
  - `QQBotNet.Core.Services.Events` 事件分发
- `QQBotNet.Core.Services.Utils.Extensions` 工具扩展类

## 进度

- HttpApi
  - [x] [用户](https://bot.q.qq.com/wiki/develop/api/openapi/user/model.html)
  - [x] [频道](https://bot.q.qq.com/wiki/develop/api/openapi/guild/model.html)
  - [x] [子频道](https://bot.q.qq.com/wiki/develop/api/openapi/channel/model.html)
  - [x] [频道身份组](https://bot.q.qq.com/wiki/develop/api/openapi/guild/role_model.html)
  - [x] [子频道权限](https://bot.q.qq.com/wiki/develop/api/openapi/channel_permissions/model.html)
  - [x] [成员](https://bot.q.qq.com/wiki/develop/api/openapi/member/model.html)
  - [x] [消息](https://bot.q.qq.com/wiki/develop/api/openapi/message/model.html)
  - [x] [消息频率](https://bot.q.qq.com/wiki/develop/api/openapi/setting/model.html)
  - [x] [私信](https://bot.q.qq.com/wiki/develop/api/openapi/dms/model.html)
  - [x] [禁言](https://bot.q.qq.com/wiki/develop/api/openapi/guild/patch_guild_mute.html)
  - [x] [公告](https://bot.q.qq.com/wiki/develop/api/openapi/announces/model.html)
  - [x] [精华消息](https://bot.q.qq.com/wiki/develop/api/openapi/pins/model.html)
  - [x] [日程](https://bot.q.qq.com/wiki/develop/api/openapi/schedule/model.html)
  - [x] [表情](https://bot.q.qq.com/wiki/develop/api/openapi/reaction/model.html)
  - [x] [音频](https://bot.q.qq.com/wiki/develop/api/openapi/audio/model.html)
  - [x] [帖子](https://bot.q.qq.com/wiki/develop/api/openapi/forum/model.html)
  - [x] [API权限查询](https://bot.q.qq.com/wiki/develop/api/openapi/api_permissions/model.html)
  - [x] [获取WebSocket接入点](https://bot.q.qq.com/wiki/develop/api/openapi/wss/url_get.html)
  - [x] [获取带分片 WSS 接入点](https://bot.q.qq.com/wiki/develop/api/openapi/wss/shard_url_get.html)
- WebSocket
  - [x] 鉴权连接
  - [x] 维持心跳
  - [x] 二级事件分发
  - [x] 分片连接
