// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using Microsoft.Extensions.Hosting;

namespace Niacomsoft.TeamFramework.Extensions.Configuration.Environment
{
    /// <summary> 提供了访问 .NET 应用程序托管主机环境信息相关的方法。 </summary>
    /// <seealso cref="EnvironmentInformation" />
    /// <seealso cref="IEnvironmentInformation" />
    /// <seealso cref="IHostEnvironment" />
    public class HostEnvironmentInformation : EnvironmentInformation
    {
        private readonly HostEnvironmentName m_hostEnvName;

        /// <summary> 初始化 <see cref="HostEnvironmentInformation" /> 类的新实例。 </summary>
        /// <param name="hostEnv">
        /// .NET 应用程序托管主机环境信息服务。
        /// <para> 实现了 <see cref="IHostEnvironment" /> 类型接口的对象实例。 </para>
        /// </param>
        public HostEnvironmentInformation(IHostEnvironment hostEnv)
        {
            HostEnvironment = hostEnv;
            m_hostEnvName = new HostEnvironmentName(hostEnv);
        }

        /// <summary> .NET 应用程序托管主机环境信息服务。 </summary>
        /// <value> 获取 <see cref="IHostEnvironment" /> 类型的对象实例，用于表示 .NET 应用程序托管主机环境信息服务。 </value>
        /// <seealso cref="IHostEnvironment" />
        protected virtual IHostEnvironment HostEnvironment { get; }

        /// <inheritdoc />
        public override IEnvironmentName GetEnvironmentName()
        {
            return m_hostEnvName;
        }
    }
}