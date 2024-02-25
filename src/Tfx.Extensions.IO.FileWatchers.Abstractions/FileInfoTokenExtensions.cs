// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System.IO;

namespace Niacomsoft.IO
{
    /// <summary> 为 <see cref="FileInfoToken" /> 类型提供的相关扩展方法。 </summary>
    public static class FileInfoTokenExtensions
    {
        /// <summary> 获取 <see cref="FileInfo" /> 类型的对象实例等效的令牌信息。 </summary>
        /// <param name="this"> <see cref="FileInfo" /> 类型的对象实例。 </param>
        /// <returns>
        /// 文件信息令牌。
        /// <para> <see cref="FileInfoToken" /> 类型的对象实例。 </para>
        /// </returns>
        /// <seealso cref="FileInfo" />
        public static FileInfoToken GetToken(this FileInfo @this)
        {
#pragma warning disable Ex0100 // Member may throw undocumented exception
            return new FileInfoToken(@this);
#pragma warning restore Ex0100 // Member may throw undocumented exception
        }
    }
}