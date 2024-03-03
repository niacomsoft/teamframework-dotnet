// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using Microsoft.Extensions.DependencyInjection;

namespace Niacomsoft.TeamFramework.Extensions.Hosting
{
    /// <summary> 为 <see cref="DotNetManagedHostEnvironment" /> 类型提供的扩展方法。 </summary>
    public static class DotNetManagedHostEnvironmentExtensions
    {
        /// <summary> 注册访问 <c> .NET </c> 应用程序托管主机环境信息的方法。 </summary>
        /// <param name="this"> 实现了 <see cref="IServiceCollection" /> 类型接口的对象实例。 </param>
        /// <returns> 实现了 <see cref="IServiceCollection" /> 类型接口的对象实例 <paramref name="this" />。 </returns>
        /// <seealso cref="DotNetManagedHostEnvironment" />
        /// <seealso cref="IManagedHostEnvironment" />
        /// <seealso cref="ManagedHostEnvironment" />
        public static IServiceCollection AddManagedHostEnvironment(this IServiceCollection @this)
        {
            return @this.AddSingleton<IManagedHostEnvironment, DotNetManagedHostEnvironment>();
        }
    }
}