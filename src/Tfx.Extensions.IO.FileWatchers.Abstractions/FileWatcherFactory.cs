// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System.IO;

using Niacomsoft.TeamFramework.Extensions.Logging;

namespace Niacomsoft.TeamFramework.Extensions.IO.FileWatchers
{
    /// <summary> 提供了创建 <see cref="IFileWatcher" /> 类型的对象实例相关的 <see langword="abstract" /> 方法。 </summary>
    /// <seealso cref="IFileWatcherFactory" />
    public abstract class FileWatcherFactory : IFileWatcherFactory
    {
        /// <summary> 初始化 <see cref="FileWatcherFactory" /> 类的新实例。 </summary>
        /// <param name="logFactory">
        /// 记录运行时日志的工厂方法。
        /// <para> 实现了 <see cref="ILogWriterFactory" /> 类型接口的对象实例。 </para>
        /// </param>
        protected FileWatcherFactory(ILogWriterFactory logFactory)
        {
            LogFactory = logFactory;
        }

        /// <summary> 记录运行时日志的工厂方法。 </summary>
        /// <value> 获取 <see cref="ILogWriterFactory" /> 类型的对象实例，用于表示记录运行时日志的工厂方法。 </value>
        /// <seealso cref="ILogWriterFactory" />
        protected virtual ILogWriterFactory LogFactory { get; }

        /// <inheritdoc />
        public abstract IFileWatcher Create(FileInfo target);
    }
}