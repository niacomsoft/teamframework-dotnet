// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

using Unity;
using Unity.Lifetime;

namespace Niacomsoft.TeamFramework.Extensions.DependencyInjection
{
    /// <summary> 为 <see cref="ITeamFrameworkContext" /> 类型提供的扩展方法。 </summary>
    public static class TeamFrameworkContextExtensions
    {
        /// <summary> 配置团队开发框架服务。 </summary>
        /// <param name="this">
        /// 团队开发框架上下文信息。
        /// <para> 实现了 <see cref="ITeamFrameworkContext" /> 类型接口的对象实例。 </para>
        /// </param>
        /// <param name="container">
        /// 服务依赖注入容器。
        /// <para> 实现了 <see cref="IUnityContainer" /> 类型接口的对象实例。 </para>
        /// </param>
        /// <param name="configure">
        /// 配置服务的方法。
        /// <para> 无返回值的 <see cref="Action{T}" /> 类型的方法委托。 </para>
        /// </param>
        /// <returns> 实现了 <see cref="IUnityContainer" /> 类型接口的对象实例。 </returns>
        /// <seealso cref="ITeamFrameworkContext" />
        /// <seealso cref="IUnityContainer" />
        /// <seealso cref="Action{T}" />
        public static IUnityContainer ConfigureTeamFrameworkServices(this ITeamFrameworkContext @this,
                                                                     IUnityContainer container,
                                                                     Action<IUnityContainer> configure)
        {
            configure(container.RegisterInstance<ITeamFrameworkContext>(@this)
                               .RegisterType<IServiceResolver, UnityServiceResolver>(new PerResolveLifetimeManager())
                               .RegisterType<IServiceResolverExtensions, UnityServiceResolver>(new PerResolveLifetimeManager()));
            return container;
        }
    }
}