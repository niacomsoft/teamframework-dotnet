// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System.Configuration;

using Niacomsoft.Utilities;

namespace Niacomsoft.TeamFramework.Extensions.Hosting
{
    /// <summary> 提供了基于 <see cref="ConfigurationManager" /> 访问 <c> .NET </c> 应用程序托管环境信息相关的方法。 </summary>
    /// <seealso cref="ManagedHostEnvironment" />
    /// <seealso cref="OperationSystemManagedHostEnvironment" />
    public class ConfigurationManagedHostEnvironment : OperationSystemManagedHostEnvironment
    {
        /// <summary>
        /// <c> App.config </c> 配置文件中 &lt;configuration&gt;/&lt;appSettings&gt;/&lt;add&gt;/[@key="env:Environment"] 的配置值。
        /// </summary>
        public const string ConfigurationSectionName = "env:Environment";

        /// <summary> 初始化 <see cref="ConfigurationManagedHostEnvironment" /> 类的新实例。 </summary>
        /// <param name="name"> 托管主机环境名称。 </param>
        public ConfigurationManagedHostEnvironment(string name) : base(name)
        {
        }

        /// <summary> 从 <c> App.config </c> 配置文件中获取 <c> .NET </c> 应用程序托管环境信息。 </summary>
        /// <returns> <see cref="ConfigurationManagedHostEnvironment" /> 类型的对象实例。 </returns>
        /// <seealso cref="ConfigurationManagedHostEnvironment" />
        public static ConfigurationManagedHostEnvironment CreateFromConfiguration()
        {
#pragma warning disable Ex0100 // Member may throw undocumented exception
            var appSettingValue = ConfigurationManager.AppSettings[ConfigurationSectionName];
#pragma warning restore Ex0100 // Member may throw undocumented exception
            if (!AssertUtilities.IsEmpty(appSettingValue))
            {
                return new ConfigurationManagedHostEnvironment(appSettingValue);
            }
            else
            {
                if (TryGetEnvironmentVariable(EnvironmentVariableName, out appSettingValue))
                {
                    return new ConfigurationManagedHostEnvironment(appSettingValue);
                }
                TryGetEnvironmentVariable(SecondaryEnvironmentVariableName, out appSettingValue);
                return new ConfigurationManagedHostEnvironment(appSettingValue);
            }
        }
    }
}