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
  - XML 序列化 (**XML Data Serialization**)
    - 项目名称：`TFX.Extensions.Serialization.XML`
    - 命名空间：`Niacomsoft.TeamFramework.Extensions.Serialization`
    - 程序集名称：`Niacomsoft.TeamFramework.Extensions.Serialization.Xml`
    - 描述信息：This library provides an XML data serialization method based on the "`XmlSerializer`". 此类库提供了基于 “`XmlSerializer`” 的 XML 数据序列化方法。
  - JSON 序列化 (**Newtonsoft.Json Serialization**)
    - 项目名称：`TFX.Extensions.Serialization.NewtonsoftJson`
    - 命名空间：`Niacomsoft.TeamFramework.Extensions.Serialization`
    - 程序集名称：`Niacomsoft.TeamFramework.Extensions.Serialization.NewtonsoftJson`
    - 描述信息：This library provides a JSON serialization method based on "`Newtonsoft.Json`". 此类库提供了基于 “`Newtonsoft.Json`” 的 JSON 序列化方法。
  - YAML 序列化 (**YAML Data Serialization**)
    - 项目名称：`TFX.Extensions.Serialization.Yaml`
    - 命名空间：`Niacomsoft.TeamFramework.Extensions.Serialization`
    - 程序集名称：`Niacomsoft.TeamFramework.Extensions.Serialization.Yaml`
    - 描述信息：This library provides YAML serialization methods. 此类库提供了 YAML 序列化方法。
  - 文件系统监控程序抽象 (**File-Monitor Abstractions**)
    - 项目名称：`TFX.Extensions.FileWatcher.Abstractions`
    - 命名空间：`Niacomsoft.TeamFramework.Extensions.IO.Watchers`
    - 程序集名称：`Niacomsoft.TeamFramework.Extensions.FileWatcher.Abstractions`
    - 描述信息：This library provides interfaces and abstract method definitions for scanning files for changes. 此类库提供了扫描文件是否变更的接口、抽象方法定义。
  - 定时的文件系统监控程序 (**Timer-based File-Monitor**)
    - 项目名称：`TFX.Extensions.FileWatcher.Timer`
    - 命名空间：`Niacomsoft.TeamFramework.Extensions.IO.Watchers`
    - 程序集名称：`Niacomsoft.TeamFramework.Extensions.FileWatcher.Timer`
    - 描述信息：This library provides a timer-based method for scanning files for changes at regular intervals. 此类库提供了基于计时器的、定时扫描文件变更的方法。
  - 配置系统抽象 (**Configuration Abstractions**)
    - 项目名称：`TFX.Extensions.Configuration.Abstractions`
    - 命名空间：`Niacomsoft.TeamFramework.Extensions.Configuration`
    - 程序集名称：`Niacomsoft.TeamFramework.Extensions.Configuration.Abstractions`
    - 描述信息：This library provides interfaces and abstract method definitions for accessing configuration system information. 此类库提供了访问配置系统信息的接口、抽象方法定义。
  - 基于 `Microsoft.Extensions.Configuration` 的配置系统 (**Options Configuration**)
    - 项目名称：`TFX.Extensions.Configuration.Options`
    - 命名空间：`Niacomsoft.TeamFramework.Extensions.Configuration`
    - 程序集名称：`Niacomsoft.TeamFramework.Extensions.Configuration.Options`
    - 描述信息：This library provides methods for accessing configuration files based on "Microsoft.Extensions.Configuration Options". 此类库提供了基于“Microsoft.Extensions.Configuration Options”的，访问配置文件的方法。
  - 基于 `App.config` 的访问配置信息的经典方法 (**Classics Configuration**)
    - 项目名称：`TFX.Extensions.Configuration.ConfigurationManager`
    - 命名空间：`Niacomsoft.TeamFramework.Extensions.Configuration`
    - 程序集名称：`Niacomsoft.TeamFramework.Extensions.Configuration.ConfigurationManager`
    - 描述信息：This library provides a way to access configuration files based on the "`ConfigurationManager`". 此类库提供了基于“`ConfigurationManager`”，访问配置文件的方法。
  - 访问自定义格式的配置信息的方法 (**Customized Format Configuration**)
    - 项目名称：`TFX.Extensions.Configuration.Specs`
    - 命名空间：`Niacomsoft.TeamFramework.Extensions.Configuration`
    - 程序集名称：`Niacomsoft.TeamFramework.Extensions.Configuration.Specs`
    - 描述信息：This library provides access to configuration information in JSON, Yaml, XML, and other formats. This library is only available for earlier versions of the .NET Framework. 此类库提供了访问 JSON、Yaml   、XML 等格式的配置信息的方法。它仅适用于低版本的 .NET Framework。
  - 缓存抽象 (**Caching Abstractions**)
    - 项目名称：`TFX.Extensions.Caching.Abstractions`
    - 命名空间：`Niacomsoft.TeamFramework.Extensions.Caching`
    - 程序集名称：`Niacomsoft.TeamFramework.Extensions.Caching.Abstractions`
    - 描述信息：This library provides interfaces and method abstractions for data caching. 此类库提供了数据缓存的接口、方法抽象。
  - 基于 **StackExchange.Redis** 的访问 Redis 数据缓存的方法 (**Redis based-on StackExchange.Redis**)
    - 项目名称：`TFX.Extensions.Caching.StackExchangeRedis`
    - 命名空间：`Niacomsoft.TeamFramework.Extensions.Caching`
    - 程序集名称：`Niacomsoft.TeamFramework.Extensions.Caching.StackExchangeRedis`
    - 描述信息：This library provides methods to access the Redis data cache based on "`StackExchange.Redis`". 这类库提供了基于 “`StackExchange.Redis`” 的访问 Redis 数据缓存的方法。
  - WEB API 模型 (**WebAPI Modeling**)
    - 项目名称：`TFX.Http.Modeling`
    - 命名空间：`Niacomsoft.TeamFramework.Http.Models`
    - 程序集名称：`Niacomsoft.TeamFramework.Http.Modeling`
    - 描述信息：This library provides the basic model definition for ASP.NET WebApi. 此类库提供了 ASP.NET WebApi 的基础模型定义。
  - 消息通信抽象 (**Messaging Communication Abstractions**)
    - 项目名称：`TFX.Extensions.Messaging.Abstractions`
    - 命名空间：`Niacomsoft.TeamFrmework.Extensions.Messaging`
    - 程序集名称：`Niacomsoft.TeamFramework.Extensions.Messaging.Abstractions`
    - 描述信息：This library provides message communication interfaces and abstract method definitions. 此类库提供了消息通信接口、抽象方法定义。
  - RabbitMQ 消息通信 (**Messaging for RabbitMQ**)
    - 项目名称：`TFX.Extensions.Messaging.RabbitMQ`
    - 命名空间：`Niacomsoft.TeamFramework.Extensions.Messaging.RabbitMQ`
    - 程序集名称：`Niacomsoft.TeamFramework.Extensions.Messaging`
    - 描述信息：This library provides `RabbitMQ` message communication methods. 此类库提供了 `RabbitMQ`  的消息通信方法。
  - MQTT 消息通信 (**Messaging for MQTT**)
    - 项目名称：`TFX.Extensions.Messaging.MQTTnet` 和 `TFX.Extensions.Messaging.M2MQTT`
    - 命名空间：`Niacomsoft.TeamFramework.Extensions.Messaging`
    - 程序集名称：`Niacomsoft.TeamFramework.Extensions.Messaging.MQTTnet` & `Niacomsoft.TeamFramework.Extensions.Messaging.M2MQTT`
    - 描述信息：This library provides `MQTT` message communication methods. 此类库提供了 `MQTT` 的消息通信方法。
  - ZeroMQ 消息通信 (**Messaging for ZeroMQ**)
    - 项目名称：`TFX.Extensions.Messaging.ZeroMQ`
    - 命名空间：`Niacomsoft.TeamFramework.Extensions.Messaging`
    - 程序集名称：`Niacomsoft.TeamFramework.Extensions.Messaging.ZeroMQ`
    - 描述信息：This library provides `ZeroMQ (NMQ)` message communication methods. 此类库提供了 `ZeroMQ (NMQ)` 的消息通信方法。
  - Microsoft MessageQueue (MSMQ) 消息通信 (**Messaging for MSMQ**)
    - 项目名称：`TFX.Extensions.Messaging.MSMQ`
    - 命名空间：`Niacomsoft.TeamFramework.Extensions.Messaging`
    - 程序集名称：`Niacomsoft.TeamFramework.Extensions.Messaging.MSMQ`
    - 描述信息：This library provides the message communication methods for `MSMQ`. 此类库提供了 `MSMQ` 的消息通信方法。
  - 文件存储抽象 (**Storage Abstractions**)
    - 项目名称：`TFX.Extensions.FileStorage.Abstractions`
    - 命名空间：`Niacomsoft.TeamFramework.Extensions.IO.Storage`
    - 程序集名称：`Niacomsoft.TeamFramework.Extensions.FileStorage.Abstractions`
    - 描述信息：This library provides interfaces and abstractions for file storage. 此类库提供了文件存储的接口、抽象方法。
  - 本地文件存储 (**Local Storage**)
    - 项目名称：`TFX.Extensions.FileStorage.Local`
    - 命名空间：`Niacomsoft.TeamFramework.Extensions.IO.Storage`
    - 程序集名称：`Niacomsoft.TeamFramework.Extensions.FileStorage.Local`
    - 描述信息：This library provides a way to store files on local disks. 此类库提供了本地磁盘文件存储的方法。
  - FTP 文件存储 (**FTP Storage**)
    - 项目名称：`TFX.Extensions.FileStorage.Ftp`
    - 命名空间：`Niacomsoft.TeamFramework.Extensions.IO.Storage`
    - 程序集名称：`Niacomsoft.TeamFramework.Extensions.FileStorage.Ftp`
    - 描述信息：This library provides FTP file storage. 此类库提供了 FTP 方式的文件存储。
  - 对象存储抽象 (**OSS Abstractions**)
    - 项目名称：`TFX.Extensions.FileStorage.OSS.Abstractions`
    - 命名空间：`Niacomsoft.TeamFramework.Extensions.IO.Storage`
    - 程序集名称：`Niacomsoft.TeamFramework.Extensions.FileStorage.OSS.Abstractions`
    - 描述信息：This library provides an interface and abstraction for file storage based on the "Object Storage Service". 此类库提供了基于 “对象存储服务”的文件存储接口、抽象方法。
  - 阿里云 OSS 存储 (**Aliyun OSS**)
    - 项目名称：`TFX.Extensions.FileStorage.AliyunOSS`
    - 命名空间：`Niacomsoft.TeamFramework.Extensions.IO.Storage`
    - 程序集名称：`Niacomsoft.TeamFramework.Extensions.FileStorage.AliyunOSS`
    - 描述信息：This library provides file storage based on `Alibaba Cloud Object Storage Service`.  此类库提供了基于 “**阿里云对象存储服务**”的文件存储。
  - MinIO 对象存储 (**MinIO OSS**)
    - 项目名称：`TFX.Extensions.FileStorage.Minio`
    - 命名空间：`Niacomsoft.TeamFramework.Extensions.IO.Storage`
    - 程序集名称：`Niacomsoft.TeamFramework.Extensions.FileStorage.MinIO`
    - 描述信息：This library provides file storage for "**MinIO**". 此类库提供了“**MinIO**”的文件存储。
  - ADO.NET 数据库访问抽象 (**ADO.NET Database Access Abstractions**)
    - 项目名称：`TFX.Extensions.Data.Abstractions`
    - 命名空间：`Niacomsoft.TeamFramework.Extensions.Data`
    - 程序集名称：`Niacomsoft.TeamFramework.Extensions.Data.Abstractions`
    - 描述信息：This library provides ADO.NET database access interfaces and abstractions. 此类库提供了 ADO.NET 数据库访问接口和抽象。
  - Dapper ADO.NET 扩展 (**Dapper ADO.NET Extensions**)
    - 项目名称：`TFX.Extensions.Data.Dapper`
    - 命名空间：`Niacomsoft.TeamFramework.Extensions.Data`
    - 程序集名称：`Niacomsoft.TeamFramework.Extensions.Data.Dapper`
    - 描述信息：This library provides a **Dapper ADO.NET** extensions. 此类库提供了基于 Dapper 的 ADO.NET 扩展。
  - Microsoft SQL Server ADO.NET 数据库访问 (**ADO.NET for SQL Server**)
    - 项目名称：`TFX.Extensions.Data.SqlClient`
    - 命名空间：`Niacomsoft.TeamFramework.Extensions.Data.SqlClient`
    - 程序集名称：`Niacomsoft.TeamFramework.Extensions.Data.SqlServer`
    - 描述信息：This library provides methods for **Microsoft SQL Server**. 此类库提供了 Microsoft SQL Server 数据库访问的 ADO.NET 方法。


## Badges

![GitHub commit activity](https://img.shields.io/github/commit-activity/y/niacomsoft/teamframework-dotnet?style=for-the-badge&logo=github&label=Git%20Commits) ![GitHub top language](https://img.shields.io/github/languages/top/niacomsoft/teamframework-dotnet?style=for-the-badge&label=CSharp) ![GitHub repo size](https://img.shields.io/github/repo-size/niacomsoft/teamframework-dotnet?style=for-the-badge) ![GitHub Release](https://img.shields.io/github/v/release/niacomsoft/teamframework-dotnet?include_prereleases&display_name=tag&style=for-the-badge&logo=github)

----



>   **© 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.**