// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

using Niacomsoft.IO;

namespace Niacomsoft
{
    /// <summary> 定义了 BASE-64 字符串编码的接口。 </summary>
    public interface IBase64StringEncoder
    {
        /// <summary>
        /// 获取 BASE-64 编码字符串。
        /// <para> 当 <paramref name="input" /> 为 <see langword="null" /> 值时，返回 <see langword=" null" />。 </para>
        /// </summary>
        /// <param name="input"> 需要编码的 <see cref="byte" /> 数组。 </param>
        /// <param name="encodeOptions">
        /// <paramref name="input" /> 编码配置选项。
        /// <para> <see cref="ByteArrayOptions" /> 类型的对象实例。 </para>
        /// </param>
        /// <param name="formatOptions">
        /// BASE-64 字符串格式化配置选项。
        /// <para> <see cref="Base64FormattingOptions " /> 中的一个值。 </para>
        /// </param>
        /// <returns> BASE-64 编码字符串。 </returns>
        /// <seealso cref="Base64FormattingOptions" />
        /// <seealso cref="ByteArrayOptions" />
        /// <seealso cref="Convert" />
        /// <seealso cref="Convert.ToBase64String(byte[], int, int, Base64FormattingOptions)" />
        string GetString(byte[] input, ByteArrayOptions encodeOptions = null, Base64FormattingOptions formatOptions = Base64FormattingOptions.None);
    }
}