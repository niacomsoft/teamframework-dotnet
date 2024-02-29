// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;
using System.IO;

namespace Niacomsoft.TeamFramework.Extensions.IO.FileWatchers
{
    /// <summary> 定义了创建 <see cref="IPollingFileWatcher" /> 类型的对象实例的工厂方法接口。 </summary>
    /// <seealso cref="IFileWatcherFactory" />
    /// <seealso cref="IPollingFileWatcher" />
    public interface IPollingFileWatcherFactory : IFileWatcherFactory
    {
        /// <summary> 创建轮询式文件监控程序。 </summary>
        /// <param name="target">
        /// 需要监控的目标文件信息。
        /// <para> <see cref="FileInfo" /> 类型的对象实例。 </para>
        /// </param>
        /// <param name="interval">
        /// 轮询一次的时间间隔。
        /// <para> <see cref="TimeSpan" /> 类型的值。 </para>
        /// </param>
        /// <returns> 实现了 <see cref="IPollingFileWatcher" /> 类型接口的对象实例。 </returns>
        /// <seealso cref="FileInfo" />
        /// <seealso cref="IPollingFileWatcher" />
        /// <seealso cref="TimeSpan" />
        IPollingFileWatcher CreateWatcher(FileInfo target, TimeSpan interval);
    }
}