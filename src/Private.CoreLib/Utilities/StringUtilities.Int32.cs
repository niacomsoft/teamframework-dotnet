// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft.Utilities
{
    public static partial class StringUtilities
    {
        /// <summary> 尝试将字符串 <paramref name="s" /> 转换成等效的 <see cref="int" /> 类型的值。 </summary>
        /// <param name="s"> 等效 <see cref="int" /> 类型值的字符串。 </param>
        /// <returns> <see cref="int" /> 类型的值。 </returns>
        /// <exception cref="System.FormatException"> 当调用 <see cref="int.Parse(string)" /> 方法时，可能引发此类型的异常。 </exception>
        /// <exception cref="System.OverflowException"> 当调用 <see cref="int.Parse(string)" /> 方法时，可能引发此类型的异常。 </exception>
        /// <seealso cref="int.Parse(string)" />
        public static int ToInt32(string s)
            => int.Parse(s);

        /// <summary> 当字符串 <paramref name="s" /> 转换成等效的 <see cref="int" /> 类型的值成功时，返回 <see langword="true" />；否则返回 <see langword="false" />。 </summary>
        /// <param name="s"> 等效 <see cref="int" /> 类型值的字符串。 </param>
        /// <param name="value"> <see cref="int" /> 类型的值。 </param>
        /// <returns> 当字符串 <paramref name="s" /> 转换成等效的 <see cref="int" /> 类型的值成功时，返回 <see langword="true" />；否则返回 <see langword="false" />。 </returns>
        /// <seealso cref="int.TryParse(string, out int)" />
        public static bool TryToInt32(string s, out int value)
            => int.TryParse(s, out value);
    }
}