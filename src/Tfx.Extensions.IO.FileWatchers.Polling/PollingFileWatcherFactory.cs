// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;
using System.IO;

using Niacomsoft.TeamFramework.Extensions.Logging;

namespace Niacomsoft.TeamFramework.Extensions.IO.FileWatchers
{
    /// <summary> 提供了创建轮询式文件监控程序相关的工厂方法。 </summary>
    /// <seealso cref="FileWatcherFactory" />
    /// <seealso cref="IPollingFileWatcherFactory" />
    /// <seealso cref="PollingFileWatcher" />
    public class PollingFileWatcherFactory : FileWatcherFactory, IPollingFileWatcherFactory
    {
        /// <summary> 初始化 <see cref="PollingFileWatcherFactory" /> 类的新实例。 </summary>
        /// <param name="loggerFactory">
        /// 创建记录运行时日志方法的工厂。
        /// <para> 实现了 <see cref="ILogWriterFactory" /> 类型接口的对象实例。 </para>
        /// </param>
        public PollingFileWatcherFactory(ILogWriterFactory loggerFactory) : base(loggerFactory)
        {
        }

        /// <inheritdoc />
        public virtual IPollingFileWatcher CreateWatcher(FileInfo target, TimeSpan interval)
        {
            return new PollingFileWatcher(target, interval, LoggerFactory.CreateWriter());
        }

        /// <inheritdoc />
        /// <seealso cref="PollingFileWatcher" />
        protected override FileWatcher InternalCreateWatcher(FileInfo target, ILogWriter logWriter)
        {
            return new PollingFileWatcher(target, logWriter);
        }
    }
}