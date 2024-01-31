// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

using Niacomsoft.Diagnostics;
using Niacomsoft.Utilities;

namespace Niacomsoft.TeamFramework.IO
{
    /// <summary> 为 <see cref="DirectoryInfo" /> 类型提供的扩展方法。 </summary>
    public static class DirectoryInfoExtensions
    {
        /// <summary>
        /// 当 <paramref name="this" /> 未找到时，将引发一个 <see cref="DirectoryNotFoundException" /> 类型的异常或调用
        /// <paramref name="ifNotExists" /> 方法。
        /// </summary>
        /// <param name="this">
        /// 需要校验的路径信息。
        /// <para> <see cref="DirectoryInfo" /> 类型的对象实例。 </para>
        /// </param>
        /// <param name="ifNotExists">
        /// 无返回值的 <see cref="Action{T}" /> 类型的方法委托。
        /// <para>
        /// 当 <paramref name="ifNotExists" /> 等于 <see langword="null" /> 时，将引发一个 <see cref="DirectoryNotFoundException" /> 类型的异常。
        /// </para>
        /// </param>
        /// <seealso cref="Action{T}" />
        /// <seealso cref="DirectoryInfo" />
        /// <seealso cref="FileSystemInfo.Exists" />
        /// <seealso cref="FileSystemInfo.Refresh()" />
        /// <exception cref="IOException"> 当调用 <see cref="FileSystemInfo.Refresh()" /> 方法时，可能引发此类型的异常。 </exception>
        /// <exception cref="System.Security.SecurityException"> 当访问 <see cref="FileSystemInfo.FullName" /> 属性时，可能引发此类型的异常。 </exception>
        public static void IfNotFound(this DirectoryInfo @this, Action<DirectoryInfo> ifNotExists = null)
        {
            @this.Refresh();
            if (Debugger.IfWriteLine(!@this.Exists, $"The directory \"{@this.FullName}\" does not exist.", null, DebuggingLevel.Warning))
            {
                if (AssertUtilities.NotNull(ifNotExists))
                {
                    ifNotExists(@this);
                }
                else
                {
#pragma warning disable Ex0100 // Member may throw undocumented exception
                    throw new DirectoryNotFoundException(SR.Format("DirectoryNotFoundException_with_file_path", @this.FullName));
#pragma warning restore Ex0100 // Member may throw undocumented exception
                }
            }
        }

        /// <summary> 当路径 <paramref name="this" /> 不存在时，自动创建，以确保路径存在。 </summary>
        /// <param name="this">
        /// 需要校验的路径信息。
        /// <para> <see cref="DirectoryInfo" /> 类型的对象实例。 </para>
        /// </param>
        /// <returns> 当前的 <see cref="DirectoryInfo" /> 类型的对象实例 <paramref name="this" />。 </returns>
        /// <seealso cref="DirectoryInfo" />
        /// <seealso cref="IfNotFound(DirectoryInfo, Action{DirectoryInfo})" />
        [SuppressMessage("Design", "Ex0100:Member may throw undocumented exception", Justification = "<挂起>")]
        public static DirectoryInfo EnsureDirectoryExists(this DirectoryInfo @this)
        {
            @this.IfNotFound((dir) => dir.Create());
            @this.Refresh();
            return @this;
        }
    }
}