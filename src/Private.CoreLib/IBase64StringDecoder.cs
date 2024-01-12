// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

namespace Niacomsoft
{
    /// <summary> 定义了 BASE-64 字符串解码的接口。 </summary>
    public interface IBase64StringDecoder
    {
        /// <summary>
        /// 从 BASE-64 字符串 <paramref name="base64Str" /> 解码获取字节数组。
        /// <para> 当 <paramref name="base64Str" /> 为 <see langword="null" /> 值时，返回 <see langword="null" /> 值。 </para>
        /// </summary>
        /// <param name="base64Str"> BASE-64 编码字符串。 </param>
        /// <returns> <see cref="byte" /> 类型数组。 </returns>
        /// <exception cref="FormatException"> 当调用 <see cref="Convert.FromBase64String(string)" /> 方法时，可能引发此类型的异常。 </exception>
        /// <seealso cref="Convert" />
        /// <seealso cref="Convert.FromBase64String(string)" />
        byte[] GetBytes(string base64Str);
    }
}