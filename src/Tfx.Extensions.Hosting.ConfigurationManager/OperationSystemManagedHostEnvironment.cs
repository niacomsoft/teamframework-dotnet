// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using Niacomsoft.Utilities;

namespace Niacomsoft.TeamFramework.Extensions.Hosting
{
    /// <summary> 提供了从操作系统环境变量获取 <c> .NET </c> 应用程序托管主机环境信息相关的 <see langword="abstract" /> 方法。 </summary>
    /// <seealso cref="IManagedHostEnvironment" />
    /// <seealso cref="ManagedHostEnvironment" />
    public abstract class OperationSystemManagedHostEnvironment : ManagedHostEnvironment
    {
        /// <summary> 系统环境变量名称。 </summary>
        public const string EnvironmentVariableName = "DOTNET_ENVIRONMENT";

        /// <summary> 备选的环境变量名称。 </summary>
        public const string SecondaryEnvironmentVariableName = "ASPNET_ENVIRONMENT";

        /// <summary> 初始化 <see cref="OperationSystemManagedHostEnvironment" /> 类的新实例。 </summary>
        /// <param name="name"> 托管主机环境名称。 </param>
        protected OperationSystemManagedHostEnvironment(string name) : base(name)
        {
        }

        /// <summary> 尝试从获取环境中获取托管主机环境信息 ( <see cref="EnvironmentVariableName" /> 或者 <see cref="SecondaryEnvironmentVariableName" />)。 </summary>
        /// <param name="envVariableName"> 环境变量名称。 </param>
        /// <param name="value">
        /// 名称为 <see cref="EnvironmentVariableName" /> 或 <see cref="SecondaryEnvironmentVariableName" /> 的环境变量值。
        /// </param>
        /// <returns>
        /// 当 <paramref name="value" /> 等于 <see langword="null" />、 <see cref="string.Empty" /> 或全为空白符时返回
        /// <see langword="false" />；否则返回 <see langword="true" />。
        /// </returns>
        public static bool TryGetEnvironmentVariable(string envVariableName, out string value)
        {
            var envVariable = EnvironmentVariable.GetEnvironmentVariable(envVariableName);
            value = StringUtilities.IfEmpty(envVariable?.Value, null, EmptyComparisonOptions.NullOrWhitespace);
            return !AssertUtilities.IsEmpty(value, EmptyComparisonOptions.NullOrWhitespace);
        }
    }
}