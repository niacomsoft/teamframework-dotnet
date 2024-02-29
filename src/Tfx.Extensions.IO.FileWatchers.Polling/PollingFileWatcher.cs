// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Timers;

using Niacomsoft.TeamFramework.Extensions.Logging;
using Niacomsoft.Utilities;

namespace Niacomsoft.TeamFramework.Extensions.IO.FileWatchers
{
    /// <summary> 提供了时钟轮询式的文件监控相关的方法。 </summary>
    /// <seealso cref="IPollingFileWatcher" />
    /// <seealso cref="TokenBasedFileWatcher" />
    public class PollingFileWatcher : TokenBasedFileWatcher, IPollingFileWatcher
    {
        /// <summary> 默认的扫描时间间隔。 </summary>
        /// <seealso cref="TimeSpan" />
        [SuppressMessage("Design", "Ex0104:Member initializer may throw undocumented exception", Justification = "<挂起>")]
        public static readonly TimeSpan DefaultPollingInterval = TimeSpan.FromSeconds(5);

        /// <summary> 初始化 <see cref="PollingFileWatcher" /> 类的新实例。 </summary>
        /// <param name="target"> 需要监控的目标文件信息。 </param>
        /// <param name="interval">
        /// 扫描一次的时间间隔。
        /// <para> <see cref="TimeSpan" /> 类型的值。 </para>
        /// </param>
        /// <param name="logWriter">
        /// 用于记录运行时文件信息 <see cref="P:Niacomsoft.TeamFramework.Extensions.IO.FileWatchers.FileWatcher.Target" /> 变更的方法。
        /// <para> 实现了 <see cref="ILogWriter" /> 类型接口的对象实例。 </para>
        /// </param>
        public PollingFileWatcher(FileInfo target, TimeSpan interval, ILogWriter logWriter) : base(target, logWriter)
        {
            Interval = interval;
            IsStarted = false;
        }

        /// <summary> 初始化 <see cref="PollingFileWatcher" /> 类的新实例。 </summary>
        /// <param name="target"> 需要监控的目标文件信息。 </param>
        /// <param name="logWriter">
        /// 用于记录运行时文件信息 <see cref="P:Niacomsoft.TeamFramework.Extensions.IO.FileWatchers.FileWatcher.Target" /> 变更的方法。
        /// <para> 实现了 <see cref="ILogWriter" /> 类型接口的对象实例。 </para>
        /// </param>
        public PollingFileWatcher(FileInfo target, ILogWriter logWriter) : this(target, DefaultPollingInterval, logWriter)
        {
        }

        /// <inheritdoc />
        public virtual TimeSpan Interval { get; }

        /// <summary> 轮询时钟是否已经启动。 </summary>
        /// <value> 设置或获取一个 <see cref="bool" /> 类型值，用于表示轮询时钟是否已经启动。 </value>
        protected virtual bool IsStarted { get; set; }

        /// <summary> 执行轮询任务的时钟。 </summary>
        /// <value> 设置或获取 <see cref="Timer" /> 类型的对象实例，用于表示执行轮询任务的时钟。 </value>
        /// <seealso cref="Timer" />
        protected virtual Timer PollingTimer { get; set; }

        /// <inheritdoc />
        public virtual void Dispose()
        {
            Disposing(true);
        }

        /// <inheritdoc />
        public virtual void Start()
        {
            InitializeComponent();
            if (LogWriter.LogDebugIf(!IsStarted, "Start the file monitoring polling clock.", GetType()))
            {
                PollingTimer.Start();
                IsStarted = true;
            }
        }

        /// <inheritdoc />
        public virtual void Stop()
        {
            Disposing(false);
        }

        /// <summary> 尝试方法 <see cref="PollingFileWatcher" /> 类型的对象实例占用的资源。 </summary>
        /// <param name="disposeThis"> 是否强制释放所有资源。 </param>
        protected virtual void Disposing(bool disposeThis)
        {
            if (LogWriter.LogDebugIf(IsStarted, "Stop the file monitoring polling clock.", GetType()))
            {
                PollingTimer?.Stop();
            }
            if (LogWriter.LogWarningIf(disposeThis && AssertUtilities.NotNull(PollingTimer), $"{GetType().Name} will dispose.", GetType()))
            {
                PollingTimer.Elapsed -= OnPollingTimerElapsed;
                PollingTimer.Dispose();
                PollingTimer = null;
            }
        }

        /// <summary> 初始化 <see cref="PollingFileWatcher" /> 相关的时钟组件。 </summary>
        protected virtual void InitializeComponent()
        {
            if (LogWriter.LogDebugIf(AssertUtilities.IsNull(PollingTimer), "Initialize the file monitoring polling clock component.", GetType()))
            {
                PollingTimer = new Timer(Interval.TotalMilliseconds)
                {
                    Enabled = false,
                    AutoReset = true
                };

                PollingTimer.Elapsed += OnPollingTimerElapsed;
            }
        }

        private void OnPollingTimerElapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                if (IsChanged())
                {
                    RaiseTargetChanged(new FileWatcherEventArgs(Target));
                }
            }
            catch (Exception error)
            {
#pragma warning disable Ex0100 // Member may throw undocumented exception
                LogWriter.LogFatal(error, $"refresh [{Target.FullName}] token");
#pragma warning restore Ex0100 // Member may throw undocumented exception
            }
        }
    }
}