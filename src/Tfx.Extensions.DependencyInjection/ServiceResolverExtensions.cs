// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

namespace Niacomsoft.TeamFramework.Extensions.DependencyInjection
{
    /// <summary> 为 <see cref="IServiceResolver" /> 类型提供的扩展方法。 </summary>
    public static class ServiceResolverExtensions
    {
        /// <summary> 获取服务注册标识为 <paramref name="serviceKey" /> 的 <paramref name="serviceType" /> 类型的服务实例。 </summary>
        /// <param name="this"> 实现了 <see cref="IServiceResolver" /> 类型接口的对象实例。 </param>
        /// <param name="serviceType"> 服务类型。 </param>
        /// <param name="serviceKey"> 服务注册标识。 </param>
        /// <returns> <paramref name="serviceType" /> 类型的服务实例。 </returns>
        /// <seealso cref="IServiceRegisterKey" />
        /// <seealso cref="Type" />
        public static object GetService(this IServiceResolver @this, Type serviceType, IServiceRegisterKey serviceKey)
        {
            return (@this as IServiceResolverExtensions).GetService(serviceType, serviceKey);
        }

        /// <summary> 获取 <typeparamref name="TService" /> 类型的服务。 </summary>
        /// <typeparam name="TService"> 服务类型。 </typeparam>
        /// <param name="this"> 实现了 <see cref="IServiceResolver" /> 类型接口的对象实例。 </param>
        /// <returns> <typeparamref name="TService" /> 类型的对象实例。 </returns>
        public static TService GetService<TService>(this IServiceResolver @this) where TService : class
        {
            return (@this as IServiceResolverExtensions).GetService<TService>();
        }

        /// <summary> 获取注册标识为 <paramref name="serviceKey" /> 的 <typeparamref name="TService" /> 类型的服务实例。 </summary>
        /// <typeparam name="TService"> 服务类型。 </typeparam>
        /// <param name="this"> 实现了 <see cref="IServiceResolver" /> 类型接口的对象实例。 </param>
        /// <param name="serviceKey"> 服务注册标识。 </param>
        /// <returns> <typeparamref name="TService" /> 类型服务实例。 </returns>
        /// <seealso cref="IServiceRegisterKey" />
        public static TService GetService<TService>(this IServiceResolver @this, IServiceRegisterKey serviceKey) where TService : class
        {
            return (@this as IServiceResolverExtensions).GetService<TService>(serviceKey);
        }
    }
}