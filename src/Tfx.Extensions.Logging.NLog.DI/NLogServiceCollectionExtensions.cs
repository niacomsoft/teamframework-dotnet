// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

using Microsoft.Extensions.DependencyInjection;

using Niacomsoft.TeamFramework.Extensions.Logging;
using Niacomsoft.Utilities;

using NLog;
using NLog.Config;

namespace Niacomsoft.TeamFramework.Extensions.DependencyInjection
{
    /// <summary> 为 <see cref="IServiceCollection" /> 类型提供的扩展方法。 </summary>
    /// <seealso cref="ILogWriter" />
    /// <seealso cref="INLogWriterFactory" />
    /// <seealso cref="LogWriter" />
    /// <seealso cref="NLogWriter" />
    /// <seealso cref="NLogWriterFactory" />
    public static class NLogServiceCollectionExtensions
    {
        /// <summary> 配置 <see cref="NLogWriter" />。 </summary>
        /// <param name="this"> 实现了 <see cref="IServiceCollection" /> 类型接口的对象实例。 </param>
        /// <param name="config">
        /// <see cref="NLogWriter" /> 配置信息。
        /// <para> <see cref="LoggingConfiguration" /> 类型的对象实例。 </para>
        /// </param>
        /// <returns> 当前的 <see cref="IServiceCollection" /> 类型的对象实例 <paramref name="this" />。 </returns>
        /// <seealso cref="LoggingConfiguration" />
        /// <exception cref="ArgumentNullException"> 当 <paramref name="config" /> 等于 <see langword="null" /> 值时，将引发此类型的异常。 </exception>
        public static IServiceCollection ConfigureNLogWriter(this IServiceCollection @this, LoggingConfiguration config)
        {
            if (AssertUtilities.IsNull(config))
            {
#pragma warning disable Ex0100 // Member may throw undocumented exception
                throw new ArgumentNullException(nameof(config), SR.Format("ArgumentNullException_with_method_and_parameter_name", nameof(ConfigureNLogWriter), nameof(config)));
#pragma warning restore Ex0100 // Member may throw undocumented exception
            }

            LogManager.Configuration = config;

            return @this;
        }

        /// <summary> 配置 <see cref="NLogWriter" /> </summary>
        /// <param name="this"> 实现了 <see cref="IServiceCollection" /> 类型接口的对象实例。 </param>
        /// <param name="builder">
        /// 构建 <see cref="NLog" /> 配置信息的方法。
        /// <para> <see cref="Func{TResult}" /> 类型的对象实例。 </para>
        /// <para> <see cref="LoggingConfiguration" /> 类型返回值的 <see cref="Func{TResult}" /> 类型的方法委托。 </para>
        /// </param>
        /// <returns> <see cref="IServiceCollection" /> 类型的对象实例 <paramref name="this" />。 </returns>
        /// <seealso cref="Func{TResult}" />
        /// <seealso cref="LoggingConfiguration" />
        public static IServiceCollection ConfigureNLogWriter(this IServiceCollection @this, Func<LoggingConfiguration> builder)
        {
            return @this.ConfigureNLogWriter(builder?.Invoke());
        }

        /// <summary> 注册 <see cref="NLogWriter" /> 日志服务。 </summary>
        /// <param name="this"> 实现了 <see cref="IServiceCollection" /> 类型接口的对象实例。 </param>
        /// <returns> <see cref="LoggingConfiguration" /> 类型的对象实例 <paramref name="this" />。 </returns>
        /// <seealso cref="ILogWriter" />
        /// <seealso cref="ILogWriterFactory" />
        /// <seealso cref="INLogWriterFactory" />
        /// <seealso cref="NLogWriter" />
        /// <seealso cref="NLogWriterFactory" />
        public static IServiceCollection AddNLogWriter(this IServiceCollection @this)
        {
            @this.AddTransient<ILogWriter, NLogWriter>()
                 .AddSingleton<ILogWriterFactory, NLogWriterFactory>()
                 .AddSingleton<INLogWriterFactory, NLogWriterFactory>();
            return @this;
        }
    }
}