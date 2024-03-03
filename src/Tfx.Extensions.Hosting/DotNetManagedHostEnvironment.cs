// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using Microsoft.Extensions.Hosting;

namespace Niacomsoft.TeamFramework.Extensions.Hosting
{
    /// <summary> 提供了基于 <c> Microsoft .NET </c> 平台 <see cref="IHostEnvironment" /> 访问托管主机环境相关的方法。 </summary>
    /// <seealso cref="IHostEnvironment" />
    /// <seealso cref="IManagedHostEnvironment" />
    /// <seealso cref="ManagedHostEnvironment" />
    public class DotNetManagedHostEnvironment : ManagedHostEnvironment
    {
        /// <summary> 初始化 <see cref="DotNetManagedHostEnvironment" /> 类的新实例。 </summary>
        /// <param name="environment">
        /// 访问 <c> .NET </c> 应用程序托管主机环境的方法。
        /// <para> 实现了 <see cref="IHostEnvironment" /> 类型接口的对象实例。 </para>
        /// </param>
        public DotNetManagedHostEnvironment(IHostEnvironment environment) : this(environment?.EnvironmentName)
        {
            HostEnvironment = environment;
        }

        /// <summary> 初始化 <see cref="DotNetManagedHostEnvironment" /> 类的新实例。 </summary>
        /// <param name="name"> 托管主机环境名称。 </param>
        protected DotNetManagedHostEnvironment(string name) : base(name)
        {
        }

        /// <summary> 访问 <c> .NET </c> 应用程序托管主机环境的方法。 </summary>
        /// <value> 获取 <see cref="IHostEnvironment" /> 类型的对象实例，用于表示访问 <c> .NET </c> 应用程序托管主机环境的方法。 </value>
        /// <seealso cref="IHostEnvironment" />
        protected virtual IHostEnvironment HostEnvironment { get; }
    }
}