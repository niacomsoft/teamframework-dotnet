// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

using Niacomsoft.Utilities;

namespace Niacomsoft.TeamFramework.Extensions.Hosting
{
    /// <summary> 提供了访问 .NET 应用程序托管主机环境信息相关的 <see langword="abstract" /> 方法。 </summary>
    /// <seealso cref="IManagedHostEnvironment" />
    public abstract class ManagedHostEnvironment : IManagedHostEnvironment
    {
#if DEBUG

        /// <summary>
        /// 默认的托管主机环境名称。
        /// <para> 代表开发环境。 </para>
        /// </summary>
        public const string DefaultEnvironmentName = "Development";

#else
        /// <summary>
        /// 默认的托管主机环境名称。
        /// <para> 代表生产环境。 </para>
        /// </summary>
        public const string DefaultEnvironmentName = "Production";
#endif

        /// <summary> 初始化 <see cref="ManagedHostEnvironment" /> 类的新实例。 </summary>
        /// <param name="name"> 托管主机环境名称。 </param>
        protected ManagedHostEnvironment(string name)
        {
            EnvironmentName = StringUtilities.IfEmpty(name, DefaultEnvironmentName, EmptyComparisonOptions.NullOrWhitespace);
        }

        /// <inheritdoc />
        public virtual string EnvironmentName { get; }

        /// <inheritdoc />
        public virtual bool IsSpecifiedEnvironment(string name)
        {
            return !AssertUtilities.IsEmpty(name, EmptyComparisonOptions.NullOrWhitespace) && EnvironmentName.Equals(name.Trim(), StringComparison.CurrentCultureIgnoreCase);
        }
    }
}