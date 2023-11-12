<img src="QQBotNet.Core/Sources/logo256.png" width="150" align="right">

# QQBotNet

[![C#](https://img.shields.io/badge/QQBotNet.Core-%20.NET_6-blue)](#qqbotnetcore)
[![C#](https://img.shields.io/badge/QQBotNet.OneBot-%20.NET_6-blue)](#qqbotnetonebot)
[![wakatime](https://wakatime.com/badge/user/724e95cb-6b0f-48fb-9f96-915cce8cc845/project/018b503b-48a3-4da8-b352-834ea2e59215.svg)](https://wakatime.com/badge/user/724e95cb-6b0f-48fb-9f96-915cce8cc845/project/018b503b-48a3-4da8-b352-834ea2e59215)

> **WARNING**  
>此仓库与腾讯公司**没有从属关系**，仅作个人学习开发和使用。

## 目录

- [QQBotNet.Core](#qqbotnetcore) QQ机器人的**非官方**C# SDK
- [QQBotNet.OneBot](#qqbotnetonebot) QQ机器人基于Net6.0的OneBot实现

## QQBotNet.Core

[![Nuget](https://img.shields.io/nuget/v/QQBotNet.Core)](https://www.nuget.org/packages/QQBotNet.Core)
[![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/QQBotNet.Core)](https://www.nuget.org/packages/QQBotNet.Core)

QQ机器人的**非官方**C# SDK

### 安装

[Nuget](https://www.nuget.org/packages/QQBotNet.Core)

```ps
dotnet add package QQBotNet.Core
```

### 使用方法

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

### 优点

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

### 主要命名空间

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

### 进度

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
  - [x] v2群聊/私聊Api
- WebSocket
  - [x] 鉴权连接
  - [x] 维持心跳
  - [x] 二级事件分发
  - [x] 分片连接

## QQBotNet.OneBot

[![OneBot 12](https://img.shields.io/badge/OneBot-12-black?logo=data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAHAAAABwCAMAAADxPgR5AAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAAxQTFRF////29vbr6+vAAAAk1hCcwAAAAR0Uk5T////AEAqqfQAAAKcSURBVHja7NrbctswDATQXfD//zlpO7FlmwAWIOnOtNaTM5JwDMa8E+PNFz7g3waJ24fviyDPgfhz8fHP39cBcBL9KoJbQUxjA2iYqHL3FAnvzhL4GtVNUcoSZe6eSHizBcK5LL7dBr2AUZlev1ARRHCljzRALIEog6H3U6bCIyqIZdAT0eBuJYaGiJaHSjmkYIZd+qSGWAQnIaz2OArVnX6vrItQvbhZJtVGB5qX9wKqCMkb9W7aexfCO/rwQRBzsDIsYx4AOz0nhAtWu7bqkEQBO0Pr+Ftjt5fFCUEbm0Sbgdu8WSgJ5NgH2iu46R/o1UcBXJsFusWF/QUaz3RwJMEgngfaGGdSxJkE/Yg4lOBryBiMwvAhZrVMUUvwqU7F05b5WLaUIN4M4hRocQQRnEedgsn7TZB3UCpRrIJwQfqvGwsg18EnI2uSVNC8t+0QmMXogvbPg/xk+Mnw/6kW/rraUlvqgmFreAA09xW5t0AFlHrQZ3CsgvZm0FbHNKyBmheBKIF2cCA8A600aHPmFtRB1XvMsJAiza7LpPog0UJwccKdzw8rdf8MyN2ePYF896LC5hTzdZqxb6VNXInaupARLDNBWgI8spq4T0Qb5H4vWfPmHo8OyB1ito+AysNNz0oglj1U955sjUN9d41LnrX2D/u7eRwxyOaOpfyevCWbTgDEoilsOnu7zsKhjRCsnD/QzhdkYLBLXjiK4f3UWmcx2M7PO21CKVTH84638NTplt6JIQH0ZwCNuiWAfvuLhdrcOYPVO9eW3A67l7hZtgaY9GZo9AFc6cryjoeFBIWeU+npnk/nLE0OxCHL1eQsc1IciehjpJv5mqCsjeopaH6r15/MrxNnVhu7tmcslay2gO2Z1QfcfX0JMACG41/u0RrI9QAAAABJRU5ErkJggg==)](https://12.onebot.dev/)

QQ机器人基于Net6.0的OneBot实现（🚧暂未完工）

```txt
C:\>QQBotNet.OneBot.exe -h
Description:
  QQBot的OneBot实现

Usage:
  QQBotNet.OneBot [command] [options]

Options:
  --version       Show version information
  -?, -h, --help  Show help and usage information

Commands:
  cfg                                    创建"config.json"
  run <botAppId> <botToken> <appSecret>  使用命令行参数运行

```

### 进度

- 传参
  - [x] `config.json`
  - [x] 命令行参数`run`
- 通信
  - [ ] Http
  - [x] Http-Post
  - [x] 正向WebSocket
  - [x] 反向WebSocket
- 事件
  - [x] 收到消息
- API
  - [ ] 发送消息

## 相关链接

- [QQ机器人文档](https://bot.q.qq.com/wiki/)
- [QQ机器人后台](https://q.qq.com/)

## 参考借鉴

- [Masuda.Net](https://github.com/ssccinng/Masuda.Net)
- [Lagrange.Core](https://github.com/Linwenxuan05/Lagrange.Core)
- [QQBot Python SDK](https://bot.q.qq.com/wiki/develop/pythonsdk/)
