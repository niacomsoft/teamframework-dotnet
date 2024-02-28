// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

namespace Niacomsoft.TeamFramework.Extensions.IO.FileWatchers
{
    /// <summary> 定义了基于时钟的轮询式文件监控的接口。 </summary>
    /// <seealso cref="IDisposable" />
    /// <seealso cref="IFileWatcher" />
    public interface IPollingFileWatcher : IFileWatcher, IDisposable
    {
        /// <summary> 扫描一次的时间间隔。 </summary>
        /// <value> 设置或获取一个 <see cref="TimeSpan" /> 类型值，用于表示扫描一次的时间间隔。 </value>
        /// <seealso cref="TimeSpan" />
        TimeSpan Interval { get; }

        /// <summary> 启动自动扫描时钟。 </summary>
        void Start();

        /// <summary> 终止自动扫描时钟。 </summary>
        void Stop();
    }
}