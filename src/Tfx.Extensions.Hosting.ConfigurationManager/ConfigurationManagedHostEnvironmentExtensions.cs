// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using Unity;
using Unity.Lifetime;

namespace Niacomsoft.TeamFramework.Extensions.Hosting
{
    /// <summary> 为 <see cref="ConfigurationManagedHostEnvironment" /> 相关类型提供的扩展方法。 </summary>
    public static class ConfigurationManagedHostEnvironmentExtensions
    {
        /// <summary> 注册 <see cref="ConfigurationManagedHostEnvironment" /> 相关的托管主机环境信息服务。 </summary>
        /// <param name="this"> 实现了 <see cref="IUnityContainer" /> 类型接口的对象实例。 </param>
        /// <returns> 实现了 <see cref="IUnityContainer" /> 类型接口的对象实例 <paramref name="this" />。 </returns>
        /// <seealso cref="ConfigurationManagedHostEnvironment" />
        /// <seealso cref="IManagedHostEnvironment" />
        /// <seealso cref="ManagedHostEnvironment" />
        /// <seealso cref="OperationSystemManagedHostEnvironment" />
        public static IUnityContainer AddManagedHostEnvironment(this IUnityContainer @this)
        {
            return @this.RegisterInstance<IManagedHostEnvironment>(ConfigurationManagedHostEnvironment.CreateFromConfiguration(), new SingletonLifetimeManager());
        }
    }
}