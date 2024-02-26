// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System.IO;

using Niacomsoft.TeamFramework.Extensions.Logging;

namespace Niacomsoft.TeamFramework.Extensions.IO.FileWatchers
{
    /// <summary> 提供了监控文件信息相关的 <see langword="abstract" /> 方法。 </summary>
    /// <seealso cref="IFileWatcher" />
    public abstract class FileWatcher : IFileWatcher
    {
        /// <summary> 初始化 <see cref="FileWatcher" /> 类的新实例。 </summary>
        /// <param name="target"> 需要监控的目标文件信息。 </param>
        /// <param name="logWriter">
        /// 用于记录运行时文件信息 <see cref="Target" /> 变更的方法。
        /// <para> 实现了 <see cref="ILogWriter" /> 类型接口的对象实例。 </para>
        /// </param>
        protected FileWatcher(FileInfo target, ILogWriter logWriter)
        {
            Target = target;
            LogWriter = logWriter;
        }

        /// <inheritdoc />
        public virtual event GeneralEventHandler<FileWatcherEventArgs> TargetChanged;

        /// <inheritdoc />
        public virtual FileInfo Target { get; }

        /// <summary> 记录运行时文件信息 <see cref="Target" /> 变更的方法。 </summary>
        /// <value> 获取 <see cref="ILogWriter" /> 类型的对象实例，用于表示记录运行时文件信息 <see cref="Target" /> 变更的方法。 </value>
        /// <seealso cref="ILogWriter" />
        protected virtual ILogWriter LogWriter { get; }

        /// <summary> 当文件 <see cref="Target" /> 变更时返回 <see langword="true" />；否则返回 <see langword="false" />。 </summary>
        /// <returns> 当文件 <see cref="Target" /> 变更时返回 <see langword="true" />；否则返回 <see langword="false" />。 </returns>
        protected abstract bool IsChanged();

        /// <summary> 用于触发 <see cref="TargetChanged" /> 事件。 </summary>
        /// <param name="e">
        /// 事件参数。
        /// <para> <see cref="FileWatcherEventArgs" /> 类型的对象实例。 </para>
        /// </param>
        protected virtual void RaiseTargetChanged(FileWatcherEventArgs e)
        {
            TargetChanged?.Invoke(this, e);
        }
    }
}