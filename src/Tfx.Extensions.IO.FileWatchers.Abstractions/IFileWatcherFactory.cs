// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System.IO;

namespace Niacomsoft.TeamFramework.Extensions.IO.FileWatchers
{
    /// <summary> 定义了创建 <see cref="IFileWatcher" /> 类型的对象实例的接口。 </summary>
    public interface IFileWatcherFactory
    {
        /// <summary> 创建文件监控程序。 </summary>
        /// <param name="target">
        /// 需要监控的文件。
        /// <para> <see cref="FileInfo" /> 类型的对象实例。 </para>
        /// </param>
        /// <returns> 实现了 <see cref="IFileWatcher" /> 类型接口的对象实例。 </returns>
        /// <seealso cref="FileInfo" />
        /// <seealso cref="IFileWatcher" />
        IFileWatcher Create(FileInfo target);
    }
}