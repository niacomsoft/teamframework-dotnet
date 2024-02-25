// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;

namespace Niacomsoft.IO
{
    /// <summary> 提供了文件信息令牌相关的方法。 </summary>
    [Serializable]
    public class FileInfoToken
    {
        /// <summary> 初始化 <see cref="FileInfoToken" /> 类的新实例。 </summary>
        public FileInfoToken()
        {
            FullName = string.Empty;
            CreatedAt = DateTime.MinValue;
            LatestModifiedAt = DateTime.MinValue;
            IsExists = false;
            Length = 0;
        }

        /// <summary> 初始化 <see cref="FileInfoToken" /> 类的新实例。 </summary>
        /// <param name="target"> 需要计算文件信息令牌的 <see cref="FileInfo" /> 类型的对象实例。 </param>
        /// <exception cref="PathTooLongException"> 当访问 <see cref="FileSystemInfo.FullName" /> 属性时，可能引发此类型的异常。 </exception>
        /// <exception cref="System.Security.SecurityException"> 当访问 <see cref="FileSystemInfo.FullName" /> 属性时，可能引发此类型的异常。 </exception>
        /// <exception cref="IOException"> 当调用 <see cref="RefreshTargetFileInfo()" /> 方法时，可能引发此类型的异常。 </exception>
        /// <exception cref="PlatformNotSupportedException"> 当调用 <see cref="RefreshTargetFileInfo()" /> 方法时，可能引发此类型的异常。 </exception>
        public FileInfoToken(FileInfo target) : this()
        {
            Target = target;
            FullName = Target.FullName;
            RefreshTargetFileInfo();
        }

        /// <summary> 初始化 <see cref="FileInfoToken" /> 类的新实例。 </summary>
        /// <param name="path">
        /// 路径字符串。
        /// <para> <see cref="PathString" /> 类型的对象实例。 </para>
        /// </param>
        /// <exception cref="PathTooLongException"> 当调用构造方法 <see cref="FileInfoToken(FileInfo)" /> 时，可能引发此类型的异常。 </exception>
        /// <exception cref="System.Security.SecurityException"> 当调用构造方法 <see cref="FileInfoToken(FileInfo)" /> 时，可能引发此类型的异常。 </exception>
        /// <exception cref="IOException"> 当调用构造方法 <see cref="FileInfoToken(FileInfo)" /> 时，可能引发此类型的异常。 </exception>
        /// <exception cref="PlatformNotSupportedException"> 当调用构造方法 <see cref="FileInfoToken(FileInfo)" /> 时，可能引发此类型的异常。 </exception>
        /// <exception cref="UnauthorizedAccessException"> 当调用 <see cref="PathString.ToFile()" /> 方法时，可能引发此类型的异常。 </exception>
        /// <exception cref="NotSupportedException"> 当调用 <see cref="PathString.ToFile()" /> 方法时，可能引发此类型的异常。 </exception>
        public FileInfoToken(PathString path) : this(path.ToFile())
        {
        }

        /// <summary> 初始化 <see cref="FileInfoToken" /> 类的新实例。 </summary>
        /// <param name="path"> 路径字符串。 </param>
        /// <exception cref="PathTooLongException"> 当调用构造方法 <see cref="FileInfoToken(PathString)" /> 时，可能引发此类型的异常。 </exception>
        /// <exception cref="System.Security.SecurityException"> 当调用构造方法 <see cref="FileInfoToken(PathString)" /> 时，可能引发此类型的异常。 </exception>
        /// <exception cref="IOException"> 当调用构造方法 <see cref="FileInfoToken(PathString)" /> 时，可能引发此类型的异常。 </exception>
        /// <exception cref="PlatformNotSupportedException"> 当调用构造方法 <see cref="FileInfoToken(PathString)" /> 时，可能引发此类型的异常。 </exception>
        /// <exception cref="UnauthorizedAccessException"> 当调用构造方法 <see cref="FileInfoToken(PathString)" /> 时，可能引发此类型的异常。 </exception>
        /// <exception cref="NotSupportedException"> 当调用构造方法 <see cref="FileInfoToken(PathString)" /> 时，可能引发此类型的异常。 </exception>
        public FileInfoToken(string path) : this(PathString.CreateFromString(path))
        {
        }

        /// <summary> 指定文件首次创建时间。 </summary>
        /// <value> 设置或获取一个 <see cref="DateTime" /> 类型值，用于表示指定文件首次创建时间。 </value>
        public virtual DateTime CreatedAt { get; set; }

        /// <summary> 包含了路径的文件完整名称。 </summary>
        /// <value> 设置或获取一个字符串，用于表示包含了路径的文件完整名称。 </value>
        public virtual string FullName { get; set; }

        /// <summary> 指定的文件是否存在。 </summary>
        /// <value> 设置或获取一个 <see cref="bool" /> 类型值，用于表示指定的文件是否存在。 </value>
        public virtual bool IsExists { get; set; }

        /// <summary> 指定文件最后一次修改时间。 </summary>
        /// <value> 设置或获取一个 <see cref="DateTime" /> 类型值，用于表示指定文件最后一次修改时间。 </value>
        public virtual DateTime LatestModifiedAt { get; set; }

        /// <summary> 指定文件的长度值。 </summary>
        /// <value> 设置或获取一个 <see cref="long" /> 类型值，用于表示指定文件的长度值。 </value>
        public virtual long Length { get; set; }

        /// <summary> 目标文件信息。 </summary>
        /// <value> 获取 <see cref="FileInfo" /> 类型的对象实例，用于表示目标文件信息。 </value>
        /// <seealso cref="FileInfo" />
        protected FileInfo Target { get; }

        /// <summary> 使用 <see cref="SHA1" /> 算法计算 <see cref="FileInfoToken" /> 类型的对象实例 <see langword="this" /> 的字节数据。 </summary>
        /// <returns> 字节数组。 </returns>
        /// <exception cref="System.Runtime.Serialization.SerializationException">
        /// 当调用 <see cref="BinaryFormatter.Serialize(Stream, object)" /> 方法时，可能引发此类型的异常。
        /// </exception>
        /// <exception cref="System.Security.SecurityException">
        /// 当调用 <see cref="BinaryFormatter.Serialize(Stream, object)" /> 方法时，可能引发此类型的异常。
        /// </exception>
        /// <seealso cref="BinaryFormatter" />
        /// <seealso cref="SHA1" />
        public virtual byte[] ComputeHash()
        {
            using (var serializationStream = new MemoryStream())
            {
                var binarySerializer = new BinaryFormatter();
                binarySerializer.Serialize(serializationStream, this);
                return SHA1.Create().ComputeHash(serializationStream.ToArray());
            }
        }

        /// <summary> 刷新一次 <see cref="FileInfoToken" /> 类型的对象实例 <see langword="this" />。 </summary>
        /// <returns> 当前的 <see cref="FileInfoToken" /> 类型的对象实例 <see langword="this" />。 </returns>
        /// <exception cref="IOException"> 当调用 <see cref="RefreshTargetFileInfo()" /> 方法时，可能引发此类型的异常。 </exception>
        /// <exception cref="PlatformNotSupportedException"> 当调用 <see cref="RefreshTargetFileInfo()" /> 方法时，可能引发此类型的异常。 </exception>
        public virtual FileInfoToken Refresh()
        {
            RefreshTargetFileInfo();
            return this;
        }

        /// <summary> 返回十六进制令牌字符串。 </summary>
        /// <returns> 十六进制令牌字符串。 </returns>
        /// <seealso cref="BitConverter" />
        /// <seealso cref="BitConverter.ToString(byte[])" />
        /// <seealso cref="ComputeHash()" />
        /// <exception cref="System.Runtime.Serialization.SerializationException"> 当调用 <see cref="ComputeHash()" /> 方法时，可能引发此类型的异常。 </exception>
        /// <exception cref="System.Security.SecurityException"> 当调用 <see cref="ComputeHash()" /> 方法时，可能引发此类型的异常。 </exception>
        [SuppressMessage("Design", "Ex0200:Member is documented as throwing exception not documented on member in base or interface type", Justification = "<挂起>")]
        public override string ToString()
        {
            return BitConverter.ToString(ComputeHash()).Replace("-", string.Empty).ToLower();
        }

        /// <summary> 刷新文件 <see cref="Target" /> 属性。 </summary>
        /// <exception cref="IOException"> 当访问 <see cref="FileSystemInfo.CreationTime" /> 等属性时，可能引发此类型的异常。 </exception>
        /// <exception cref="PlatformNotSupportedException"> 当访问 <see cref="FileSystemInfo.CreationTime" /> 等属性时，可能引发此类型的异常。 </exception>
        protected virtual void RefreshTargetFileInfo()
        {
            if (IsExists = Target.Exists)
            {
                CreatedAt = Target.CreationTime;
                Length = Target.Length;
                LatestModifiedAt = Target.LastWriteTime;
            }
        }
    }
}