// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using Microsoft.Extensions.DependencyInjection;

using Niacomsoft.TeamFramework.Extensions.Configuration.Environment;

namespace Niacomsoft.TeamFramework.Extensions.DependencyInjection
{
    /// <summary> 为 <see cref="IServiceCollection" /> 类型提供的扩展方法。 </summary>
    public static class HostEnvironmentInformationServiceCollectionExtensions
    {
        /// <summary> 注册 <see cref="IEnvironmentInformation" /> 服务。 </summary>
        /// <param name="this"> 实现了 <see cref="IServiceCollection" /> 类型接口的对象实例。 </param>
        /// <returns> 实现了 <see cref="IServiceCollection" /> 类型接口的对象实例 <paramref name="this" />。 </returns>
        /// <seealso cref="IEnvironmentInformation" />
        /// <seealso cref="HostEnvironmentInformation" />
        public static IServiceCollection AddEnvironmentInformation(this IServiceCollection @this)
        {
            return @this.AddSingleton<IEnvironmentInformation, HostEnvironmentInformation>();
        }
    }
}