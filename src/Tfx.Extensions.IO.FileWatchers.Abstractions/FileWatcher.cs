// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System.IO;

using Niacomsoft.IO;
using Niacomsoft.TeamFramework.Extensions.Logging;
using Niacomsoft.Utilities;

namespace Niacomsoft.TeamFramework.Extensions.IO.FileWatchers
{
    /// <summary> 提供了监控指定文件信息相关的 <see langword="abstract" /> 方法。 </summary>
    /// <seealso cref="IFileWatcher" />
    public abstract class FileWatcher : IFileWatcher
    {
        /// <summary> 初始化 <see cref="FileWatcher" /> 类的新实例。 </summary>
        /// <param name="target">
        /// 需要监控的目标文件。
        /// <para> <see cref="FileInfo" /> 类型的对象实例。 </para>
        /// </param>
        /// <param name="logWriter">
        /// 记录运行时日志的方法。
        /// <para> <see cref="ILogWriter" /> 类型的对象实例。 </para>
        /// </param>
        protected FileWatcher(FileInfo target, ILogWriter logWriter)
        {
            Target = target;
            LogWriter = logWriter;
#pragma warning disable Ex0100 // Member may throw undocumented exception
            TargetToken = new FileInfoToken(target);
#pragma warning restore Ex0100 // Member may throw undocumented exception
        }

        /// <inheritdoc />
        public virtual event GeneralEventHandler<FileChangeEventData> Changed;

        /// <inheritdoc />
        public virtual FileInfo Target { get; }

        /// <summary> 记录运行时日志的方法。 </summary>
        /// <value> 获取 <see cref="ILogWriter" /> 类型的对象实例，用于表示记录运行时日志的方法。 </value>
        /// <seealso cref="ILogWriter" />
        protected virtual ILogWriter LogWriter { get; }

        /// <summary> <see cref="Target" /> 等效的文件令牌信息。 </summary>
        /// <value> 设置或获取 <see cref="FileInfoToken" /> 类型的对象实例，用于表示 <see cref="Target" /> 等效的文件令牌信息。 </value>
        /// <seealso cref="FileInfoToken" />
        protected virtual FileInfoToken TargetToken { get; set; }

        /// <summary> 之前的令牌字符串。 </summary>
        /// <value> 设置或获取一个字符串，用于表示之前的令牌字符串。 </value>
        protected virtual string PreviousToken { get; set; }

        /// <summary> 用于触发 <see cref="Changed" /> 事件。 </summary>
        /// <param name="data">
        /// 文件变更事件数据。
        /// <para> <see cref="FileChangeEventData" /> 类型的对象实例。 </para>
        /// </param>
        protected virtual void OnChanged(FileChangeEventData data)
        {
            Changed?.Invoke(this, new GeneralEventArgs<FileChangeEventData>(data));
        }

        /// <summary> 刷新文件令牌信息。 </summary>
        /// <returns> 文件令牌字符串。 </returns>
        /// <exception cref="IOException"> 当调用 <see cref="FileInfoToken.Refresh()" /> 方法时，可能引发此类型的异常。 </exception>
        /// <exception cref="System.PlatformNotSupportedException"> 当调用 <see cref="FileInfoToken.Refresh()" /> 方法时，可能引发此类型的异常。 </exception>
        /// <exception cref="System.Runtime.Serialization.SerializationException">
        /// 当调用 <see cref="FileInfoToken.Refresh()" /> 方法时，可能引发此类型的异常。
        /// </exception>
        /// <exception cref="System.Security.SecurityException"> 当调用 <see cref="FileInfoToken.Refresh()" /> 方法时，可能引发此类型的异常。 </exception>
        protected virtual string RefreshToken()
        {
            return TargetToken.Refresh().ToString();
        }

        /// <summary> 当文件 <see cref="Target" /> 令牌数据发生变更时返回 <see langword="true" /> 并触发 <see cref="Changed" /> 事件，否则返回 <see langword="false" />。 </summary>
        /// <returns> 当文件 <see cref="Target" /> 令牌数据发生变更时返回 <see langword="true" />，否则返回 <see langword="false" />。 </returns>
        /// <seealso cref="Changed" />
        protected virtual bool HasChanged()
        {
#pragma warning disable Ex0100 // Member may throw undocumented exception
            var tokenStr = RefreshToken();
#pragma warning restore Ex0100 // Member may throw undocumented exception
            if (AssertUtilities.IsEmpty(PreviousToken, EmptyComparisonOptions.NullOrWhitespace))
            {
                PreviousToken = tokenStr;
            }
            else if (!string.Equals(PreviousToken, tokenStr))
            {
                PreviousToken = tokenStr;
                OnChanged(new FileChangeEventData(Target));
                return true;
            }
            return false;
        }
    }
}