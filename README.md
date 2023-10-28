
# QQBotNet

> **WARNING**  
>此仓库和腾讯公司没有从属关系，仅作个人学习开发和使用。

## 目录

- [QQBotNet.Core](#qqbotnetcore) QQ机器人的**非官方**C# SDK
- [QQBotNet.OneBot](#qqbotnetonebot) QQ机器人基于Net6.0的OneBot实现

## QQBotNet.Core

[![Nuget](https://img.shields.io/nuget/v/QQBotNet.Core)](https://www.nuget.org/packages/QQBotNet.Core)
[![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/QQBotNet.Core)](https://www.nuget.org/packages/QQBotNet.Core)
[![C#](https://img.shields.io/badge/Core-%20.NET_6-blue)](#qqbotnet)

QQ机器人的**非官方**C# SDK

🚧暂未完工

[Nuget](https://www.nuget.org/packages/QQBotNet.Core)

```ps
dotnet add package QQBotNet.Core
```

### 进度

- HttpApi
  - [x] 获取WebSocket接入点
  - [x] 频道
  - [x] 权限组
  - [x] 子频道
  - [x] 用户
- WebSocket
  - [x] 鉴权连接
  - [x] 维持心跳

## QQBotNet.OneBot

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
  run <botAppId> <botToken> <botSecret>  使用命令行参数运行

```

### 进度

- 传参
  - [x] `config.json`
  - [x] 命令行参数`run`
- 通信
  - [ ] Http
  - [x] Http-Post
  - [ ] 正向WebSocket
  - [x] 反向WebSocket
- 事件
  - [ ] 收到消息
- API
  - [ ] 发送消息

## 相关链接

- [QQ机器人文档](https://bot.q.qq.com/wiki/)
- [QQ机器人后台](https://q.qq.com/)

## 参考借鉴

- [Lagrange.Core](https://github.com/Linwenxuan05/Lagrange.Core)
- [QQBot Python SDK](https://bot.q.qq.com/wiki/develop/pythonsdk/)
