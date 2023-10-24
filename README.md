<div align="center">

# QQBotNet

QQ机器人的**非官方**C# SDK

[![Nuget](https://img.shields.io/nuget/v/QQBotNet.Core)](https://www.nuget.org/packages/QQBotNet.Core)
[![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/QQBotNet.Core)](https://www.nuget.org/packages/QQBotNet.Core)
[![C#](https://img.shields.io/badge/Core-%20.NET_6-blue)](#qqbotnet)

</div>

> **WARNING**  
>此仓库和腾讯公司没有从属关系，仅作个人学习开发和使用。

## QQBotNet.Core

🚧暂未完工

[Nuget](https://www.nuget.org/packages/QQBotNet.Core)

```ps
dotnet add package QQBotNet.Core
```

### 进度

- Http
  - [x] 获取Access Token
  - [x] 获取WebSocket接入点
- WebSocket
  - [x] 鉴权连接
  - [x] 维持心跳

## QQBotNet.OneBot

🚧暂未完工

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
  init                                   创建"config.json"
  run <botAppId> <botToken> <botSecret>  使用命令行参数运行

```

### 进度

- 传参
  - [x] `config.json`
  - [x] 命令行参数`run`
- 通信
  - [ ] Http
  - [ ] Http-Post
  - [ ] 正向WebSocket
  - [ ] 反向WebSocket
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
