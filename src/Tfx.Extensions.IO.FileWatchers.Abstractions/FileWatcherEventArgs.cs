// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System.IO;

namespace Niacomsoft.TeamFramework.Extensions.IO.FileWatchers
{
    /// <summary> 提供了文件监控程序事件参数相关的方法。 </summary>
    /// <seealso cref="FileInfo" />
    /// <seealso cref="GeneralEventArgs{TData}" />
    public class FileWatcherEventArgs : GeneralEventArgs<FileInfo>
    {
        /// <summary> 初始化 <see cref="FileWatcherEventArgs" /> 类的新实例。 </summary>
        /// <param name="target">
        /// 需要监控的文件信息。
        /// <para> <see cref="FileInfo" /> 类型的对象实例。 </para>
        /// </param>
        public FileWatcherEventArgs(FileInfo target) : base(target)
        {
        }

        /// <summary> 需要监控的文件信息。 </summary>
        /// <value> 获取 <see cref="FileInfo" /> 类型的对象实例，用于表示需要监控的文件信息。 </value>
        /// <seealso cref="FileInfo" />
        /// <seealso cref="GeneralEventArgs{TData}.Data" />
        public virtual FileInfo Target => base.Data;
    }
}