// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;
using System.Collections.Generic;

using Niacomsoft.Configuration;
using Niacomsoft.IO;

namespace Niacomsoft.TeamFramework
{
    /// <summary> 提供了团队开发框架上下文相关的方法。密闭的，不可以从此类型派生。 </summary>
    /// <seealso cref="GeneralContext" />
    /// <seealso cref="ITeamFrameworkContext" />
    /// <remarks> 密闭的，不可以从此类型派生。 </remarks>
    public sealed class TeamFrameworkContext : GeneralContext, ITeamFrameworkContext
    {
        internal const string KeyOf_ApplicationVersion = "TFXCTX::APPVER";
        internal const string KeyOf_Macros = "TFXCTX::MACROS";

        /// <summary> 初始化 <see cref="TeamFrameworkContext" /> 类的新实例。 </summary>
        /// <param name="data">
        /// 上下文数据。
        /// <para> 实现了 <see cref="IContextualData" /> 类型接口的对象实例。 </para>
        /// </param>
        internal TeamFrameworkContext(IContextualData data) : base(data)
        {
            SdkVersion = GetType().Assembly.GetName().Version;
        }

        /// <summary> 当前的上下文。 </summary>
        /// <value> 获取 <see cref="ITeamFrameworkContext" /> 类型的对象实例，用于表示当前的上下文。 </value>
        /// <seealso cref="ITeamFrameworkContext" />
        /// <seealso cref="TeamFrameworkContext" />
        public static ITeamFrameworkContext CurrentContext => TeamFrameworkContextHolder.InstanceManager.CreateOrGet();

        /// <inheritdoc />
        public Version ApplicationVersion
        {
            get
            {
                return TryGetData(KeyOf_ApplicationVersion, out object appVer) ? appVer as Version : SdkVersion;
            }
        }

        /// <inheritdoc />
        public PathString CurrentDirectory { get; }

        /// <inheritdoc />
        public IDictionary<string, IMacroParameter> Macros
        {
            get
            {
                return TryGetData(KeyOf_Macros, out object macros) ? macros as IDictionary<string, IMacroParameter> : null;
            }
        }

        /// <inheritdoc />
        public Version SdkVersion { get; }
    }
}