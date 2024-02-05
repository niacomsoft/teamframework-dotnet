// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

namespace Niacomsoft.TeamFramework.Extensions.DependencyInjection
{
    /// <summary> 定义了 <see cref="IServiceResolver" /> 的扩展接口。 </summary>
    public interface IServiceResolverExtensions : IServiceResolver
    {
        /// <summary> 获取服务注册标识为 <paramref name="serviceKey" /> 的 <paramref name="serviceType" /> 类型的服务实例。 </summary>
        /// <param name="serviceType"> 服务类型。 </param>
        /// <param name="serviceKey"> 服务注册标识。 </param>
        /// <returns> <paramref name="serviceType" /> 类型的服务实例。 </returns>
        /// <seealso cref="IServiceRegisterKey" />
        /// <seealso cref="Type" />
        object GetService(Type serviceType, IServiceRegisterKey serviceKey);

        /// <summary> 获取 <typeparamref name="TService" /> 类型的服务。 </summary>
        /// <typeparam name="TService"> 服务类型。 </typeparam>
        /// <returns> <typeparamref name="TService" /> 类型的对象实例。 </returns>
        TService GetService<TService>() where TService : class;

        /// <summary> 获取注册标识为 <paramref name="serviceKey" /> 的 <typeparamref name="TService" /> 类型的服务实例。 </summary>
        /// <typeparam name="TService"> 服务类型。 </typeparam>
        /// <param name="serviceKey"> 服务注册标识。 </param>
        /// <returns> <typeparamref name="TService" /> 类型服务实例。 </returns>
        /// <seealso cref="IServiceRegisterKey" />
        TService GetService<TService>(IServiceRegisterKey serviceKey) where TService : class;
    }
}