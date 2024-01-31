// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;
using System.IO;

using Niacomsoft.Diagnostics;
using Niacomsoft.Utilities;

namespace Niacomsoft.TeamFramework.IO
{
    /// <summary> 为 <see cref="FileInfo" /> 类型提供的扩展方法。 </summary>
    public static class FileInfoExtensions
    {
        /// <summary>
        /// 当 <paramref name="file" /> 未找到时，将引发一个 <see cref="FileNotFoundException" /> 类型的异常或调用 <paramref name="ifNotExists" /> 方法。
        /// </summary>
        /// <param name="file">
        /// 需要校验的文件信息。
        /// <para> <see cref="FileInfo" /> 类型的对象实例。 </para>
        /// </param>
        /// <param name="ifNotExists">
        /// 无返回值的 <see cref="Action{T}" /> 类型的方法委托。
        /// <para>
        /// 当 <paramref name="ifNotExists" /> 等于 <see langword="null" /> 时，将引发一个 <see cref="FileNotFoundException" /> 类型的异常。
        /// </para>
        /// </param>
        /// <seealso cref="Action{T}" />
        /// <seealso cref="FileInfo" />
        /// <seealso cref="FileSystemInfo.Exists" />
        /// <seealso cref="FileSystemInfo.Refresh()" />
        /// <exception cref="IOException"> 当调用 <see cref="FileSystemInfo.Refresh()" /> 方法时，可能引发此类型的异常。 </exception>
        /// <exception cref="System.Security.SecurityException"> 当访问 <see cref="FileSystemInfo.FullName" /> 属性时，可能引发此类型的异常。 </exception>
        public static void IfNotFound(this FileInfo file, Action<FileInfo> ifNotExists = null)
        {
            file.Refresh();
            if (Debugger.IfWriteLine(!file.Exists, $"File \"{file.FullName}\" does not exist.", null, DebuggingLevel.Warning))
            {
                if (AssertUtilities.NotNull(ifNotExists))
                {
                    ifNotExists(file);
                }
                else
                {
#pragma warning disable Ex0100 // Member may throw undocumented exception
                    throw new FileNotFoundException(SR.Format("FileNotFoundException_with_file_path", file.FullName), file.FullName);
#pragma warning restore Ex0100 // Member may throw undocumented exception
                }
            }
        }
    }
}