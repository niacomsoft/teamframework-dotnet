// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

using Microsoft.Extensions.DependencyInjection;

namespace Niacomsoft.TeamFramework.Extensions.DependencyInjection
{
    /// <summary> 提供了基于 <see cref="IServiceProvider" /> 的解析服务相关的方法。 </summary>
    /// <seealso cref="ServiceResolver" />
    /// <seealso cref="IServiceResolverExtensions" />
    /// <seealso cref="IServiceProvider" />
    public class SystemServiceResolver : ServiceResolver, IServiceResolverExtensions
    {
        /// <summary> 初始化 <see cref="SystemServiceResolver" /> 类的新实例。 </summary>
        /// <param name="serviceProvider">
        /// .NET 默认的服务解析程序。
        /// <para> 实现了 <see cref="IServiceProvider" /> 类型接口的对象实例。 </para>
        /// </param>
        public SystemServiceResolver(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        /// <summary> .NET 默认的服务解析程序。 </summary>
        /// <value> 获取 <see cref="IServiceProvider" /> 类型的对象实例，用于表示 .NET 默认的服务解析程序。 </value>
        protected virtual IServiceProvider ServiceProvider { get; }

        /// <inheritdoc />
        public virtual object GetService(Type serviceType, IServiceRegisterKey serviceKey)
        {
            return ServiceProvider.GetKeyedServices(serviceType, serviceKey.Key);
        }

        /// <inheritdoc />
        public virtual TService GetService<TService>() where TService : class
        {
            return ServiceProvider.GetService<TService>();
        }

        /// <inheritdoc />
        public virtual TService GetService<TService>(IServiceRegisterKey serviceKey) where TService : class
        {
            return ServiceProvider.GetKeyedService<TService>(serviceKey.Key);
        }

        /// <inheritdoc />
        public override object GetService(Type serviceType)
        {
            return ServiceProvider.GetService(serviceType);
        }
    }
}