# README

![tfx](./assets/tfx.png)

> Team Development Framework for Microsoft `.NET`

## Intro

"TeamFramework" provides the functions and methods commonly used by authors in their development work.

*"TeamFramework" 提供了作者开发工作中常用的功能、方法。*

- **Catalog**
- [THE MIT LICENSE](LICENSE.md#the-mit-license)
- **Features**
  - 基础库 (**Basic Library**)
    - 项目名称：`Niacomsoft.Private.CoreLib`
    - 命名空间：`Niacomsoft.*`
    - 程序集名称：`Niacomsoft.Private.CoreLib`
    - 描述信息：This library provides most of the functionality of the ".NET" development process. For example: assertions, exceptions, resources, etc. 此类库提供了 “.NET” 开发过程中，大多数的功能。例如：断言、异常、资源等。

  - 核心抽象类库 (**Core Abstractions**)
    - 项目名称：`TFX.Core.Abstractions`
    - 命名空间： `Niacomsoft.TeamFramework.*`
    - 程序集名称：`Niacomsoft.TeamFramework.Core.Abstractions`
    - 描述信息：This library provides the "IServiceDiscover" interface definition and the necessary abstract types. 此类库提供了 “IServiceDiscover”接口定义和必要的抽象类型。

  - 核心类库 (**Core**)
    - 项目名称：`TFX.Core`
    - 命名空间：`Niacomsoft.TeamFramework.*`
    - 程序集名称：`Niacomsoft.TeamFramework.Core`
    - 描述信息：This library provides a basic implementation of interfaces such as "IServiceDiscover". 此类库提供了 “IServiceDiscover”等接口的基本实现。

  - 依赖注入扩展 (**Microsoft DependencyInjection Extensions**)
    - 项目名称：`TFX.Extensions.MicrosoftDI`
    - 命名空间：`Niacomsoft.TeamFramework.Extensions.DependencyInjection`
    - 程序集名称：`Niacomsoft.TeamFramework.Extensions.DependencyInjection`
    - 描述信息：This library provides a collection of extension methods. This library depends on "Microsoft DependencyInjection". 此类库提供了依赖注入扩展方法集合。此类库依赖于微软官方的依赖注入框架。

  - 依赖注入扩展 (**Microsoft UnityContainer Extensions**)
    - 项目名称：`TFX.Extensions.UnityContainer`
    - 命名空间：`Niacomsoft.TeamFramework.Extensions.DependencyInjection`
    - 程序集名称：`Niacomsoft.TeamFramework.Extensions.UnityContainer`
    - 描述信息：This library provides a collection of extension methods. This libary depends on "Microsoft UnityContainer". 此类库提供了依赖注入扩展方法集合。此类库依赖于 “Microsoft UnityContainer”。

  - 运行时日志抽象 (**Logging Abstractions**)
    - 项目名称：`TFX.Extensions.Logging.Abstractions`
    - 命名空间：`Niacomsoft.TeamFramework.Extensions.Logging`
    - 程序集名称：`Niacomsoft.TeamFramework.Extensions.Logging.Abstractions`
    - 描述信息：This library provides interface definitions and abstract method definitions for recording runtime logs. 此类库提供了记录运行时日志的接口定义、抽象方法定义。

  - 基于 `NLog` 的运行时日志 (**Logging Based NLog**)
    - 项目名称：`TFX.Extensions.Logging.NLog`
    - 命名空间：`Niacomsoft.TeamFramework.Extensions.Logging`
    - 程序集名称：`Niacomsoft.TeamFramework.Extensions.Logging.NLog`
    - 描述信息：This library provides methods for logging runtime. This library depends on "NLog".  此类库提供了记录运行时日志的方法。此类库依赖于 “NLog”。
  - 主机环境抽象 (**Hosting Environment Abstractions**)
    - 项目名称：`TFX.Extensions.HostingEnvironment.Abstractions`
    - 命名空间：`Niacomsoft.TeamFramework.Extensions.Hosting`
    - 程序集名称：`Niacomsoft.TeamFramework.Extensions.HostingEnvironment.Abstractions`
    - 描述信息：This library provides interfaces and abstractions for accessing information about the host environment. 此类库提供了访问主机环境信息相关的接口、抽象方法。
  - 主机环境信息实现 (**Microsoft .NET Hosting**)
    - 项目名称：`TFX.Extensions.HostingEnvironment.MicrosoftHosting`
    - 命名空间：`Niacomsoft.TeamFramework.Extensions.Hosting`
    - 程序集名称：`Niacomsoft.TeamFramework.Extensions.HostingEnvironment`
    - 描述信息：This library provides methods for accessing information about the host environment. This library depends on `Microsoft.Extensions.Hosting`. 此类库提供了访问主机环境信息相关的方法。此类库依赖于 `Microsoft.Extensions.Hosting`。
  - 基于 `App.config` 的主机环境信息的实现 (**Hosting Environment Based-on Configuration**)
    - 项目名称：`TFX.Extensions.HostingEnvironment.ConfigurationManager`
    - 命名空间：`Niacomsoft.TeamFramework.Extensions.Hosting`
    - 程序集名称：`Niacomsoft.TeamFramework.Extensions.HostingEnvironment.Configuration`
    - 描述信息：This library provides a way to read host environment information from the `app.config / web.config` file. 此类库提供了从 `app.config / web.config` 文件中读取主机环境信息的方法。
  - 数据序列化抽象 (**Data Serialization Abstractions**)
    - 项目名称：`TFX.Extensions.Serialization.Abstractions`
    - 命名空间：`Niacomsoft.TeamFramework.Extensions.Serialization`
    - 程序集名称：`Niacomsoft.TeamFramework.Extensions.Serialization.Abstractions`
    - 描述信息：This library provides definitions of data serialization service interfaces and abstract methods. 此类库提供了数据序列化服务接口、抽象方法的定义。
  - 二进制数据序列化 (**Binary Data Serialization**)
    - 项目名称：`TFX.Extensions.Serialization.Binary`
    - 命名空间：`Niacomsoft.TeamFramework.Extensions.Serialization`
    - 程序集名称：`Niacomsoft.TeamFramework.Extensions.Serialization.Binary`
    - 描述信息：This library provides a binary serialization method based on `BinaryFormatter`. 此类库提供了基于 `BinaryFormatter` 的二进制序列化方法。




## Badges

![GitHub commit activity](https://img.shields.io/github/commit-activity/y/niacomsoft/teamframework-dotnet?style=for-the-badge&logo=github&label=Git%20Commits) ![GitHub top language](https://img.shields.io/github/languages/top/niacomsoft/teamframework-dotnet?style=for-the-badge&label=CSharp) ![GitHub repo size](https://img.shields.io/github/repo-size/niacomsoft/teamframework-dotnet?style=for-the-badge) ![GitHub Release](https://img.shields.io/github/v/release/niacomsoft/teamframework-dotnet?include_prereleases&display_name=tag&style=for-the-badge&logo=github)

----



>   **© 2023 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.**