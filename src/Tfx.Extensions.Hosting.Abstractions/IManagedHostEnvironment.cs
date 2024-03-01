// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft.TeamFramework.Extensions.Hosting
{
    /// <summary> 定义了 .NET 应用程序托管主机环境信息接口。 </summary>
    public interface IManagedHostEnvironment
    {
        /// <summary> 托管主机环境名称。 </summary>
        /// <value> 获取一个字符串，用于表示托管主机环境名称。 </value>
        string EnvironmentName { get; }

        /// <summary>
        /// 当当前的托管主机环境名称 <see cref="EnvironmentName" /> 与 <paramref name="name" /> 相等时，返回 <see langword="true" />；否则返回 <see langword="false" />。
        /// </summary>
        /// <param name="name"> 指定的环境名称。 </param>
        /// <returns>
        /// 当当前的托管主机环境名称 <see cref="EnvironmentName" /> 与 <paramref name="name" /> 相等时，返回 <see langword="true" />；否则返回 <see langword="false" />。
        /// </returns>
        /// <seealso cref="EnvironmentName" />
        bool IsSpecifiedEnvironment(string name);
    }
}