// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

using Unity;

namespace Niacomsoft.TeamFramework.Extensions.DependencyInjection
{
    /// <summary> 提供了基于 <see cref="IUnityContainer" /> 解析服务依赖相关的方法。 </summary>
    /// <seealso cref="IServiceResolverExtensions" />
    /// <seealso cref="IUnityContainer" />
    /// <seealso cref="ServiceResolver" />
    public class UnityServiceResolver : ServiceResolver, IServiceResolverExtensions
    {
        /// <summary> 初始化 <see cref="UnityServiceResolver" /> 类的新实例。 </summary>
        /// <param name="serviceContainer">
        /// <see cref="Unity" /> 服务容器。
        /// <para> 实现了 <see cref="IUnityContainer" /> 类型接口的对象实例。 </para>
        /// </param>
        public UnityServiceResolver(IUnityContainer serviceContainer)
        {
            ServiceContainer = serviceContainer;
        }

        /// <summary> <see cref="Unity" /> 服务容器。 </summary>
        /// <value> 获取 <see cref="IUnityContainer" /> 类型的对象实例，用于表示 <see cref="Unity" /> 服务容器。 </value>
        protected virtual IUnityContainer ServiceContainer { get; }

        /// <inheritdoc />
        public virtual object GetService(Type serviceType, IServiceRegisterKey serviceKey)
        {
            return ServiceContainer.Resolve(serviceType, serviceKey.Key.ToString());
        }

        /// <inheritdoc />
        public virtual TService GetService<TService>() where TService : class
        {
            return ServiceContainer.Resolve<TService>();
        }

        /// <inheritdoc />
        public virtual TService GetService<TService>(IServiceRegisterKey serviceKey) where TService : class
        {
            return ServiceContainer.Resolve<TService>(serviceKey.Key.ToString());
        }

        /// <inheritdoc />
        public override object GetService(Type serviceType)
        {
            return ServiceContainer.Resolve(serviceType);
        }
    }
}