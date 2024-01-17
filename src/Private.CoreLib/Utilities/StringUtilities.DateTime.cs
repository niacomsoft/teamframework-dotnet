// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

namespace Niacomsoft.Utilities
{
    public static partial class StringUtilities
    {
        /// <summary> 尝试将字符串 <paramref name="s" /> 转换成等效的 <see cref="DateTime" /> 类型的值。 </summary>
        /// <param name="s"> 等效 <see cref="DateTime" /> 类型值的字符串。 </param>
        /// <returns> <see cref="DateTime" /> 类型的值。 </returns>
        /// <exception cref="FormatException"> 当调用 <see cref="DateTime.Parse(string)" /> 方法时，可能引发此类型的异常。 </exception>
        /// <seealso cref="DateTime.Parse(string)" />
        public static DateTime ToDateTime(string s)
            => DateTime.Parse(s);

        /// <summary>
        /// 当字符串 <paramref name="s" /> 转换成等效的 <see cref="DateTime" /> 类型的值成功时，返回 <see langword="true" />；否则返回 <see langword="false" />。
        /// </summary>
        /// <param name="s"> 等效 <see cref="DateTime" /> 类型值的字符串。 </param>
        /// <param name="value"> <see cref="DateTime" /> 类型的值。 </param>
        /// <returns>
        /// 当字符串 <paramref name="s" /> 转换成等效的 <see cref="DateTime" /> 类型的值成功时，返回 <see langword="true" />；否则返回 <see langword="false" />。
        /// </returns>
        /// <seealso cref="DateTime.TryParse(string, out DateTime)" />
        public static bool TryToDateTime(string s, out DateTime value)
            => DateTime.TryParse(s, out value);
    }
}