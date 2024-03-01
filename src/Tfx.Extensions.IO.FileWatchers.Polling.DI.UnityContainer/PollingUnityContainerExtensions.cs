// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using Niacomsoft.TeamFramework.Extensions.IO.FileWatchers;

using Unity;

namespace Niacomsoft.TeamFramework.Extensions.DependencyInjection
{
    /// <summary> 为 <see cref="IUnityContainer" /> 类型提供的扩展方法。 </summary>
    public static class PollingUnityContainerExtensions
    {
        /// <summary> 注册 <see cref="IPollingFileWatcherFactory" /> 服务。 </summary>
        /// <param name="this"> 实现了 <see cref="IUnityContainer" /> 类型接口的对象实例。 </param>
        /// <returns> 实现了 <see cref="IUnityContainer" /> 类型接口的对象实例 <paramref name="this" />。 </returns>
        /// <seealso cref="IFileWatcherFactory" />
        /// <seealso cref="IPollingFileWatcherFactory" />
        /// <seealso cref="PollingFileWatcherFactory" />
        public static IUnityContainer AddPollingFileWatcher(this IUnityContainer @this)
        {
            return @this.RegisterSingleton<IFileWatcherFactory, PollingFileWatcherFactory>()
                        .RegisterSingleton<IPollingFileWatcherFactory, PollingFileWatcherFactory>();
        }
    }
}