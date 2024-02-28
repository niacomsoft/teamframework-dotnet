// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System.IO;

using Niacomsoft.TeamFramework.Extensions.Logging;

namespace Niacomsoft.TeamFramework.Extensions.IO.FileWatchers
{
    /// <summary> 提供了创建文件监控程序相关的 <see langword="abstract" /> 工厂方法。 </summary>
    /// <seealso cref="IFileWatcherFactory" />
    public abstract class FileWatcherFactory : IFileWatcherFactory
    {
        /// <summary> 初始化 <see cref="FileWatcherFactory" /> 类的新实例。 </summary>
        /// <param name="loggerFactory">
        /// 创建记录运行时日志方法的工厂。
        /// <para> 实现了 <see cref="ILogWriterFactory" /> 类型接口的对象实例。 </para>
        /// </param>
        protected FileWatcherFactory(ILogWriterFactory loggerFactory)
        {
            LoggerFactory = loggerFactory;
        }

        /// <summary> 记录运行时日志的工厂方法。 </summary>
        /// <value> 获取 <see cref="ILogWriterFactory" /> 类型的对象实例，用于表示记录运行时日志的工厂方法。 </value>
        /// <seealso cref="ILogWriterFactory" />
        protected virtual ILogWriterFactory LoggerFactory { get; }

        /// <inheritdoc />
        public virtual IFileWatcher CreateWatcher(FileInfo target)
        {
            return InternalCreateWatcher(target, LoggerFactory.CreateWriter());
        }

        /// <summary> 创建派生自 <see cref="FileWatcher" /> 类型的对象实例。 </summary>
        /// <param name="target">
        /// 需要监控的目标文件信息。
        /// <para> <see cref="FileInfo" /> 类型的对象实例。 </para>
        /// </param>
        /// <param name="logWriter">
        /// 记录运行时日志的方法。
        /// <para> 实现了 <see cref="ILogWriter" /> 类型接口的对象实例。 </para>
        /// </param>
        /// <returns> 派生自 <see cref="FileWatcher" /> 类型的对象实例。 </returns>
        /// <seealso cref="FileInfo" />
        /// <seealso cref="FileWatcher" />
        /// <seealso cref="ILogWriter" />
        protected abstract FileWatcher InternalCreateWatcher(FileInfo target, ILogWriter logWriter);
    }
}