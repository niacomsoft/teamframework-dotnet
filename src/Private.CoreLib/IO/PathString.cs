// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;
using System.IO;

using Niacomsoft.Utilities;

namespace Niacomsoft.IO
{
    /// <summary> 提供了路径字符串相关的方法。 </summary>
    public class PathString
    {
        private static PathString s_currentDir;
        private static readonly object SynchronizationLock = new object();

        /// <summary> 初始化 <see cref="PathString" /> 类的新实例。 </summary>
        /// <param name="initial"> 初始化路径字符串。 </param>
        /// <exception cref="ArgumentException">
        /// 当 <paramref name="initial" /> 等于 <see langword="null" />、 <see cref="string.Empty" /> 或全为空白符时，将引发此类型的异常。
        /// </exception>
        public PathString(string initial)
        {
            if (AssertUtilities.IsEmpty(initial, EmptyComparisonOptions.NullOrWhitespace))
            {
#pragma warning disable Ex0100 // Member may throw undocumented exception
                throw new ArgumentException(SR.Format("ArgumentException_with_parameter_name", nameof(initial)), nameof(initial));
#pragma warning restore Ex0100 // Member may throw undocumented exception
            }
            InitialPath = initial;
        }

        /// <summary> 最终的路径字符串。 </summary>
        /// <value> 获取一个字符串，用于表示最终的路径字符串。 </value>
        public virtual string Path { get; protected set; }

        /// <summary> 初始化路径字符串。 </summary>
        /// <value> 获取一个字符串，用于表示初始化路径字符串。 </value>
        protected virtual string InitialPath { get; }

        /// <summary> 组合 <paramref name="partials" /> 为完成的路径字符串。 </summary>
        /// <param name="partials"> 组成路径的部分。 </param>
        /// <returns> 当前的路径字符串 <see langword="this" />。 </returns>
        /// <seealso cref="System.IO.Path.Combine(string, string)" />
        public virtual PathString Combine(params string[] partials)
        {
#if NET45_OR_GREATER || NETSTANDARD || NETCOREAPP || NET
            Path = System.IO.Path.Combine(partials);
#else
            if (!AssertUtilities.IsNull(partials))
            {
                foreach (var item in partials)
                {
                    Path = System.IO.Path.Combine(Path, item);
                }
            }
#endif
            return this;
        }

        /// <summary> 重置路径字符串 <see cref="Path" /> 为初始路径字符串 <see cref="InitialPath" />。 </summary>
        /// <returns> 当前的路径字符串 <see langword="this" />。 </returns>
        /// <seealso cref="InitialPath" />
        /// <seealso cref="Path" />
        public virtual PathString Reset()
        {
            Path = InitialPath;
            return this;
        }

        /// <summary> 将路径字符串转换成 <see cref="FileInfo" /> 类型的对象实例。 </summary>
        /// <returns>
        /// 文件信息。
        /// <para> <see cref="FileInfo" /> 类型的对象实例。 </para>
        /// </returns>
        /// <seealso cref="FileInfo" />
        /// <exception cref="System.Security.SecurityException"> 当初始化 <see cref="FileInfo" /> 类的新实例时，可能引发此类型的异常。 </exception>
        /// <exception cref="UnauthorizedAccessException"> 当初始化 <see cref="FileInfo" /> 类的新实例时，可能引发此类型的异常。 </exception>
        /// <exception cref="PathTooLongException"> 当初始化 <see cref="FileInfo" /> 类的新实例时，可能引发此类型的异常。 </exception>
        /// <exception cref="NotSupportedException"> 当初始化 <see cref="FileInfo" /> 类的新实例时，可能引发此类型的异常。 </exception>
        public virtual FileInfo ToFile()
        {
            return new FileInfo(Path);
        }

        /// <summary> 将路径字符串转换成 <see cref="DirectoryInfo" /> 类型的对象实例。 </summary>
        /// <returns>
        /// 路径信息。
        /// <para> <see cref="DirectoryInfo" /> 类型的对象实例。 </para>
        /// </returns>
        /// <seealso cref="DirectoryInfo" />
        /// <exception cref="System.Security.SecurityException"> 当初始化 <see cref="DirectoryInfo" /> 类的新实例时，可能引发此类型的异常。 </exception>
        /// <exception cref="PathTooLongException"> 当初始化 <see cref="DirectoryInfo" /> 类的新实例时，可能引发此类型的异常。 </exception>
        public virtual DirectoryInfo ToDirectory()
        {
            return new DirectoryInfo(Path);
        }

        /// <summary> 从路径字符串 <paramref name="path" /> 创建 <see cref="PathString" /> 类型的对象实例。 </summary>
        /// <param name="path"> 路径字符串。 </param>
        /// <returns> <see cref="PathString" /> 类型的对象实例。 </returns>
        /// <exception cref="ArgumentException"> 当初始化 <see cref="PathString" /> 类的新实例时，可能引发此类型的异常。 </exception>
        /// <seealso cref="PathString" />
        public static PathString CreateFromString(string path)
        {
            return new PathString(path);
        }

        /// <summary> 当前应用程序运行路径。 </summary>
        /// <value> 获取 <see cref="PathString" /> 类型的对象实例，用于表示当前应用程序运行路径。 </value>
        /// <seealso cref="AppDomain" />
        /// <seealso cref="AppDomain.BaseDirectory" />
        /// <exception cref="AppDomainUnloadedException" accessor="get"> 当访问 <see cref="AppDomain.CurrentDomain" /> 属性时，可能引发此类型的异常。 </exception>
        public static PathString CurrentDirectory
        {
            get
            {
                if (AssertUtilities.IsNull(s_currentDir))
                {
                    lock (SynchronizationLock)
                    {
                        if (AssertUtilities.IsNull(s_currentDir))
                        {
                            s_currentDir = new PathString(AppDomain.CurrentDomain.BaseDirectory);
                        }
                    }
                }
                return s_currentDir;
            }
        }
    }
}