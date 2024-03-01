// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

using Niacomsoft.Utilities;

namespace Niacomsoft.TeamFramework.Extensions.Configuration.Environment
{
    /// <summary> 提供了主机环境名称相关的方法。 </summary>
    /// <seealso cref="IEnvironmentName" />
    public class EnvironmentName : IEnvironmentName
    {
#if DEBUG
        private const string DefaultEnvironmentName = "Development";
#else
        private const string DefaultEnvironmentName = "Production";
#endif

        /// <summary> 开发环境名称。 </summary>
        /// <seealso cref="IEnvironmentName" />
        public static readonly IEnvironmentName DevelopmentEnvironment = new EnvironmentName("Development");

        /// <summary> 生产环境名称。 </summary>
        /// <seealso cref="IEnvironmentName" />
        public static readonly IEnvironmentName ProductionEnvironment = new EnvironmentName("Production");

        /// <summary> 测试环境名称。 </summary>
        /// <seealso cref="IEnvironmentName" />
        public static readonly IEnvironmentName TestingEnvironment = new EnvironmentName("Testing");

        /// <summary> 初始化 <see cref="EnvironmentName" /> 类的新实例。 </summary>
        /// <param name="environmentName"> 主机环境名称。 </param>
        public EnvironmentName(string environmentName)
        {
            Value = StringUtilities.IfEmpty(environmentName, DefaultEnvironmentName, EmptyComparisonOptions.NullOrWhitespace);
        }

        /// <inheritdoc />
        public virtual string Value { get; }

        /// <inheritdoc />
        public virtual bool IsSpecifiedEnvironment(string environmentName, StringComparison options = StringComparison.InvariantCultureIgnoreCase)
        {
            return !AssertUtilities.IsEmpty(environmentName, EmptyComparisonOptions.NullOrWhitespace) && Value.Equals(environmentName, options);
        }
    }
}