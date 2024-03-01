// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using Microsoft.Extensions.DependencyInjection;

using Niacomsoft.TeamFramework.Extensions.IO.FileWatchers;

namespace Niacomsoft.TeamFramework.Extensions.DependencyInjection
{
    /// <summary> 为 <see cref="IServiceCollection" /> 类型提供的扩展方法。 </summary>
    public static class PollingServiceCollectionExtensions
    {
        /// <summary> 注册 <see cref="IPollingFileWatcherFactory" /> 服务。 </summary>
        /// <param name="this"> 实现了 <see cref="IServiceCollection" /> 类型接口的对象实例。 </param>
        /// <returns> 实现了 <see cref="IServiceCollection" /> 类型接口的对象实例 <paramref name="this" />。 </returns>
        /// <seealso cref="IFileWatcherFactory" />
        /// <seealso cref="IPollingFileWatcherFactory" />
        /// <seealso cref="PollingFileWatcherFactory" />
        public static IServiceCollection AddPollingFileWatcher(this IServiceCollection @this)
        {
            return @this.AddSingleton<IFileWatcherFactory, PollingFileWatcherFactory>()
                        .AddSingleton<IPollingFileWatcherFactory, PollingFileWatcherFactory>();
        }
    }
}