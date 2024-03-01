// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using Microsoft.Extensions.Hosting;

namespace Niacomsoft.TeamFramework.Extensions.Configuration.Environment
{
    /// <summary> 提供了基于 <see cref="IHostEnvironment" /> 访问主机环境名称相关的方法。 </summary>
    /// <seealso cref="EnvironmentName" />
    /// <seealso cref="IEnvironmentName" />
    /// <seealso cref="IHostEnvironment" />
    public class HostEnvironmentName : EnvironmentName
    {
        /// <summary> 初始化 <see cref="HostEnvironmentName" /> 类的新实例。 </summary>
        /// <param name="hostEnv">
        /// .NET 应用程序托管主机环境信息。
        /// <para> 实现了 <see cref="IHostEnvironment" /> 类型接口的对象实例。 </para>
        /// </param>
        public HostEnvironmentName(IHostEnvironment hostEnv) : base(hostEnv.EnvironmentName)
        {
            HostEnvironment = hostEnv;
        }

        /// <summary> <c> .NET </c> 应用程序主机环境信息。 </summary>
        /// <value> 获取 <see cref="IHostEnvironment" /> 类型的对象实例，用于表示 <c> .NET </c> 应用程序主机环境信息。 </value>
        /// <seealso cref="IHostEnvironment" />
        public virtual IHostEnvironment HostEnvironment { get; }
    }
}