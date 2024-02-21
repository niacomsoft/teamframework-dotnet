// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;
using System.Collections.Generic;

using Niacomsoft.Configuration;
using Niacomsoft.IO;

namespace Niacomsoft.TeamFramework
{
    /// <summary> 定义了团队开发框架上下文信息的接口。 </summary>
    /// <seealso cref="IGeneralContext" />
    public interface ITeamFrameworkContext : IGeneralContext
    {
        /// <summary> 应用程序版本号。 </summary>
        /// <value> 获取 <see cref="Version" /> 类型的对象实例，用于表示应用程序版本号。 </value>
        /// <seealso cref="Version" />
        Version ApplicationVersion { get; }

        /// <summary> 应用程序当前的运行目录路径。 </summary>
        /// <value>
        /// 获取 <see cref="PathString" /> 类型的对象实例，用于表示应用程序当前的运行目录路径。
        /// <para> 请参见 <see cref="AppDomain.CurrentDomain" /> 中的 <c> BaseDirectory </c> 属性。 </para>
        /// </value>
        /// <seealso cref="AppDomain" />
        /// <seealso cref="AppDomain.BaseDirectory" />
        /// <seealso cref="AppDomain.CurrentDomain" />
        /// <seealso cref="PathString" />
        PathString CurrentDirectory { get; }

        /// <summary> 宏参数字典集合。 </summary>
        /// <value> 获取 <see cref="IMacroParameter" /> 类型的对象实例，用于表示宏参数字典集合。 </value>
        /// <seealso cref="IDictionary{TKey, TValue}" />
        /// <seealso cref="IMacroParameter" />
        IDictionary<string, IMacroParameter> Macros { get; }

        /// <summary> 团队开发框架版本号。 </summary>
        /// <value> 获取 <see cref="Version" /> 类型的对象实例，用于表示团队开发框架版本号。 </value>
        /// <seealso cref="Version" />
        Version SdkVersion { get; }
    }
}