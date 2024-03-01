// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

namespace Niacomsoft.TeamFramework.Extensions.Configuration.Environment
{
    /// <summary> 定义了访问环境名称的接口。 </summary>
    public interface IEnvironmentName
    {
        /// <summary> 当前的主机环境名称。 </summary>
        /// <value> 获取一个字符串，用于表示当前的主机环境名称。 </value>
        string Value { get; }

        /// <summary>
        /// 当 <see cref="Value" /> 与 <paramref name="environmentName" /> 相等时，返回 <see langword="true" />；否则返回 <see langword="false" />。
        /// </summary>
        /// <param name="environmentName"> 需要校验的环境名称。 </param>
        /// <param name="options"> 环境名称字符串比较选项。 </param>
        /// <returns>
        /// 当 <see cref="Value" /> 与 <paramref name="environmentName" /> 相等时，返回 <see langword="true" />；否则返回 <see langword="false" />。
        /// </returns>
        /// <seealso cref="StringComparison" />
        /// <seealso cref="StringComparison.InvariantCultureIgnoreCase" />
        bool IsSpecifiedEnvironment(string environmentName, StringComparison options = StringComparison.InvariantCultureIgnoreCase);
    }
}