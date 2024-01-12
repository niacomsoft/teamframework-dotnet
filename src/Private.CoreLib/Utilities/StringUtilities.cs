// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System.Diagnostics.CodeAnalysis;
using System.Text;

using Niacomsoft.IO;
using Niacomsoft.Text;

namespace Niacomsoft.Utilities
{
    /// <summary> 提供了 <see cref="string" /> 相关的方法。 </summary>
    public static class StringUtilities
    {
        /// <summary>
        /// 使用默认的编码程序 <see cref="DefaultEncoding.Value" /> 获取字符串 <paramref name="s" /> 的字节数组。
        /// <para> 当 <paramref name="s" /> 为 <see langword="null" /> 值时，返回 <see langword="null" />。 </para>
        /// </summary>
        /// <param name="s"> 字符串。 </param>
        /// <returns> <see cref="byte" /> 类型的数组。 </returns>
        /// <seealso cref="DefaultEncoding" />
        /// <seealso cref="DefaultEncoding.Value" />
        /// <seealso cref="Encoding" />
        /// <seealso cref="Encoding.UTF8" />
        /// <seealso cref="UTF8Encoding" />
        public static byte[] GetBytes(string s)
            => AssertUtilities.IsEmpty(s, EmptyComparisonOptions.OnlyNull)
                ? null
                : DefaultEncoding.Value.GetBytes(s);

        /// <summary>
        /// 使用特定的编码程序 <paramref name="encoding" /> 获取字符串 <paramref name="s" /> 的字节数组。
        /// <para> 当 <paramref name="s" /> 为 <see langword="null" /> 值时，返回 <see langword="null" />。 </para>
        /// </summary>
        /// <param name="s"> 字符串。 </param>
        /// <param name="encoding">
        /// 特定的编码程序。
        /// <para> 当 <paramref name="encoding" /> 等于 <see langword="null" /> 值时，使用 <see cref="DefaultEncoding.Value" /> 编码程序。 </para>
        /// </param>
        /// <returns> <see cref="byte" /> 类型的数组。 </returns>
        /// <seealso cref="DefaultEncoding" />
        /// <seealso cref="DefaultEncoding.Value" />
        /// <seealso cref="Encoding" />
        /// <seealso cref="Encoding.UTF8" />
        /// <seealso cref="UTF8Encoding" />
        public static byte[] GetBytes(string s, Encoding encoding)
            => AssertUtilities.IsNull(encoding)
                ? GetBytes(s)
                : AssertUtilities.IsEmpty(s, EmptyComparisonOptions.OnlyNull)
                    ? null
                    : encoding.GetBytes(s);

        /// <summary>
        /// 使用默认的解码程序 <see cref="DefaultEncoding.Value" /> 获取字节数组对应的字符串。
        /// <para>
        /// 当 <paramref name="input" /> 等于 <see langword="null" /> 或 <c> input.Length </c> 属性等于 0 时，将返回 <see langword="null" /> 值。
        /// </para>
        /// </summary>
        /// <param name="input"> 字节数组。 </param>
        /// <param name="decodeOptions">
        /// 用于解码 <paramref name="input" /> 的配置选项。
        /// <para> <see cref="ByteArrayOptions" /> 类型的对象实例。 </para>
        /// </param>
        /// <returns> 字符串。 </returns>
        /// <seealso cref="ByteArrayOptions" />
        /// <seealso cref="DefaultEncoding" />
        /// <seealso cref="DefaultEncoding.Value" />
        /// <seealso cref="Encoding" />
        /// <seealso cref="Encoding.UTF8" />
        /// <seealso cref="UTF8Encoding" />
        [SuppressMessage("Design", "Ex0100:Member may throw undocumented exception", Justification = "<挂起>")]
        public static string GetString(byte[] input, ByteArrayOptions decodeOptions = null)
        {
            if (AssertUtilities.IsNull(input) || AssertUtilities.Equals(input.LongLength))
            {
                return null;
            }
            if (AssertUtilities.IsNull(decodeOptions))
            {
                decodeOptions = ByteArrayOptions.FromByteArray(input);
            }

            return DefaultEncoding.Value.GetString(input, decodeOptions.Index, decodeOptions.Count);
        }

        /// <summary>
        /// 使用特定的编码程序 <paramref name="encoding" /> 获取字节数组对应的字符串。
        /// <para>
        /// 当 <paramref name="input" /> 等于 <see langword="null" /> 或 <c> input.Length </c> 属性等于 0 时，将返回 <see langword="null" /> 值。
        /// </para>
        /// </summary>
        /// <param name="input"> 字节数组。 </param>
        /// <param name="encoding">
        /// 特定的解码程序。
        /// <para> 当 <paramref name="encoding" /> 等于 <see langword="null" /> 值时，使用 <see cref="DefaultEncoding.Value" /> 解码程序。 </para>
        /// </param>
        /// <param name="decodeOptions">
        /// 用于解码 <paramref name="input" /> 的配置选项。
        /// <para> <see cref="ByteArrayOptions" /> 类型的对象实例。 </para>
        /// </param>
        /// <returns> 字符串。 </returns>
        /// <seealso cref="ByteArrayOptions" />
        /// <seealso cref="DefaultEncoding" />
        /// <seealso cref="DefaultEncoding.Value" />
        /// <seealso cref="Encoding" />
        /// <seealso cref="Encoding.UTF8" />
        /// <seealso cref="UTF8Encoding" />
        [SuppressMessage("Design", "Ex0100:Member may throw undocumented exception", Justification = "<挂起>")]
        public static string GetString(byte[] input, Encoding encoding, ByteArrayOptions decodeOptions = null)
        {
            if (AssertUtilities.IsNull(encoding))
            {
                return GetString(input, decodeOptions);
            }
            if (AssertUtilities.IsNull(input) || AssertUtilities.Equals(input.LongLength))
            {
                return null;
            }
            if (AssertUtilities.IsNull(decodeOptions))
            {
                decodeOptions = ByteArrayOptions.FromByteArray(input);
            }

            return encoding.GetString(input, decodeOptions.Index, decodeOptions.Count);
        }
    }
}