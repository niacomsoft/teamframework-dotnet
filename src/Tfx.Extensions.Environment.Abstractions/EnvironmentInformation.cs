// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using Niacomsoft.Utilities;

namespace Niacomsoft.TeamFramework.Extensions.Configuration.Environment
{
    /// <summary> 提供了访问主机环境信息相关的 <see langword="abstract" /> 方法。 </summary>
    /// <seealso cref="IEnvironmentInformation" />
    public abstract class EnvironmentInformation : IEnvironmentInformation
    {
        /// <summary> 用于存储主机环境名称的系统环境变量名称。 </summary>
        public const string EnvironmentVariableName = "DOTNET_ENVIRONMENT";

        /// <inheritdoc />
        public abstract IEnvironmentName GetEnvironmentName();

        /// <summary> 从系统环境变量中获取环境名称。 </summary>
        /// <returns> 实现了 <see cref="IEnvironmentName" /> 类型接口的对象实例。 </returns>
        /// <seealso cref="EnvironmentName" />
        /// <seealso cref="EnvironmentVariable" />
        /// <seealso cref="IEnvironmentName" />
        protected virtual IEnvironmentName GetEnvironmentNameFromEnvironmentVariablesStorage()
        {
            var environment = EnvironmentVariable.GetEnvironmentVariable(EnvironmentVariableName);
            return AssertUtilities.IsEmpty(environment?.Value, EmptyComparisonOptions.NullOrWhitespace)
                ? EnvironmentName.ProductionEnvironment
                : new EnvironmentName(environment.Value);
        }
    }
}