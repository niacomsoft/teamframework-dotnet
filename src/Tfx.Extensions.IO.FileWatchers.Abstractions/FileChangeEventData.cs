// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System.IO;

namespace Niacomsoft.TeamFramework.Extensions.IO.FileWatchers
{
    /// <summary> 提供了文件变更事件数据相关的方法。 </summary>
    public class FileChangeEventData
    {
        /// <summary> 初始化 <see cref="FileChangeEventData" /> 类的新实例。 </summary>
        /// <param name="changedSource">
        /// 已经变更的文件信息。
        /// <para> <see cref="FileInfo" /> 类型的对象实例。 </para>
        /// </param>
        public FileChangeEventData(FileInfo changedSource)
        {
            ChangedSource = changedSource;
        }

        /// <summary> 已经变更的文件信息。 </summary>
        /// <value> 获取 <see cref="FileInfo" /> 类型的对象实例，用于表示已经变更的文件信息。 </value>
        /// <seealso cref="FileInfo" />
        public virtual FileInfo ChangedSource { get; protected set; }
    }
}