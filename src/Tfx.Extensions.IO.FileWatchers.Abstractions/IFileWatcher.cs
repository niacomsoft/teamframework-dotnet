// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System.IO;

namespace Niacomsoft.TeamFramework.Extensions.IO.FileWatchers
{
    /// <summary> 定义了文件信息监控的接口。 </summary>
    public interface IFileWatcher
    {
        /// <summary> 目标文件 <see cref="Target" /> 变更事件。 </summary>
        /// <seealso cref="FileWatcherEventArgs" />
        /// <seealso cref="GeneralEventArgs{TData}" />
        /// <seealso cref="Target" />
        event GeneralEventHandler<FileWatcherEventArgs> TargetChanged;

        /// <summary> 需要监控的目标文件。 </summary>
        /// <value> 获取 <see cref="FileInfo" /> 类型的对象实例，用于表示需要监控的目标文件。 </value>
        /// <seealso cref="FileInfo" />
        FileInfo Target { get; }
    }
}