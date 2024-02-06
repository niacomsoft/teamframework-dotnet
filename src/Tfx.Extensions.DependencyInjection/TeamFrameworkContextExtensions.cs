// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

using Microsoft.Extensions.DependencyInjection;

namespace Niacomsoft.TeamFramework.Extensions.DependencyInjection
{
    /// <summary> 为 <see cref="ITeamFrameworkContext" /> 类型提供的扩展方法。 </summary>
    public static class TeamFrameworkContextExtensions
    {
        /// <summary> 配置 <see cref="TeamFramework" /> 团队开发框架服务。 </summary>
        /// <param name="this">
        /// 团队开发框架上下文。
        /// <para> 实现了 <see cref="ITeamFrameworkContext" /> 类型接口的对象实例。 </para>
        /// </param>
        /// <param name="services">
        /// Microsoft .NET 依赖注入容器。
        /// <para> 实现了 <see cref="IServiceCollection" /> 类型接口的对象实例。 </para>
        /// </param>
        /// <param name="configure"> 配置方法。 </param>
        /// <returns> 实现了 <see cref="IServiceCollection" /> 类型接口的对象实例。即： <paramref name="services" />。 </returns>
        public static IServiceCollection ConfigureTeamFrameworkServices(this ITeamFrameworkContext @this,
                                                                        IServiceCollection services,
                                                                        Action<IServiceCollection> configure)
        {
            configure(services.AddSingleton<ITeamFrameworkContext>(@this)
                              .AddTransient<IServiceResolver, SystemServiceResolver>()
                              .AddTransient<IServiceResolverExtensions, SystemServiceResolver>());
            return services;
        }
    }
}