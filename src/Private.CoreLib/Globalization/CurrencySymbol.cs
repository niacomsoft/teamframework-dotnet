// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using Niacomsoft.Utilities;

namespace Niacomsoft.Globalization
{
    /// <summary> 提供了货币符号相关的方法。 </summary>
    public class CurrencySymbol
    {
        /// <summary> 人民币。 </summary>
        public static readonly CurrencySymbol CNY = new CurrencySymbol("CNY", "RMB ¥");

        /// <summary> 欧元。 </summary>
        public static readonly CurrencySymbol EUR = new CurrencySymbol("EUR", "EUR €");

        /// <summary> 英镑。 </summary>
        public static readonly CurrencySymbol GBP = new CurrencySymbol("GBP", "£");

        /// <summary> 港币。 </summary>
        public static readonly CurrencySymbol HKD = new CurrencySymbol("HKD", "HK $");

        /// <summary> 日元。 </summary>
        public static readonly CurrencySymbol JPY = new CurrencySymbol("JPY", "J. ￥");

        /// <summary> 俄罗斯卢布。 </summary>
        public static readonly CurrencySymbol SUR = new CurrencySymbol("SUR", "RBL.");

        /// <summary> 美元。 </summary>
        public static readonly CurrencySymbol USD = new CurrencySymbol("USD", "U.S. $");

        /// <summary> 初始化 <see cref="CurrencySymbol" /> 类的新实例。 </summary>
        /// <param name="current"> 当前使用的货币符号。 </param>
        public CurrencySymbol(string current) : this(current, null)
        {
        }

        /// <summary> 初始化 <see cref="CurrencySymbol" /> 类的新实例。 </summary>
        /// <param name="current"> 当前使用的货币符号。 </param>
        /// <param name="originallyUsed"> 原有的货币符号。 </param>
        public CurrencySymbol(string current, string originallyUsed)
        {
            Current = current;
            OriginallyUsed = originallyUsed;
        }

        /// <summary> 当前使用的货币符号。 </summary>
        /// <value> 获取一个字符串，用于表示当前使用的货币符号。 </value>
        public virtual string Current { get; }

        /// <summary> 原有的货币符号。 </summary>
        /// <value> 获取一个字符串，用于表示原有的货币符号。 </value>
        public virtual string OriginallyUsed { get; }

        /// <summary> 将 <paramref name="amount" /> 转换成带有货币符号的金额字符串（保留两位小数）。 </summary>
        /// <param name="amount"> 金额。 </param>
        /// <param name="useOriginal"> 使用之前货币符号。 </param>
        /// <returns> 带有货币符号的金额字符串（保留两位小数）。 </returns>
        /// <exception cref="System.FormatException"> 当调用 <see cref="long.ToString(string)" /> 时，可能引发此类型的异常。 </exception>
        public string ToString(long amount, bool useOriginal = false)
        {
            var symbols = useOriginal && !AssertUtilities.IsEmpty(OriginallyUsed, EmptyComparisonOptions.NullOrWhitespace) ? OriginallyUsed : Current;
            return $"{symbols} {amount:F2}";
        }

        /// <summary> 将 <paramref name="amount" /> 转换成带有货币符号的金额字符串（保留两位小数）。 </summary>
        /// <param name="amount"> 金额。 </param>
        /// <param name="useOriginal"> 使用之前货币符号。 </param>
        /// <returns> 带有货币符号的金额字符串（保留两位小数）。 </returns>
        /// <exception cref="System.FormatException"> 当调用 <see cref="int.ToString(string)" /> 时，可能引发此类型的异常。 </exception>
        public string ToString(int amount, bool useOriginal = false)
        {
            var symbols = useOriginal && !AssertUtilities.IsEmpty(OriginallyUsed, EmptyComparisonOptions.NullOrWhitespace) ? OriginallyUsed : Current;
            return $"{symbols} {amount:F2}";
        }

        /// <summary> 将 <paramref name="amount" /> 转换成带有货币符号的金额字符串（保留两位小数）。 </summary>
        /// <param name="amount"> 金额。 </param>
        /// <param name="useOriginal"> 使用之前货币符号。 </param>
        /// <returns> 带有货币符号的金额字符串（保留两位小数）。 </returns>
        /// <exception cref="System.FormatException"> 当调用 <see cref="short.ToString(string)" /> 时，可能引发此类型的异常。 </exception>
        public string ToString(short amount, bool useOriginal = false)
        {
            var symbols = useOriginal && !AssertUtilities.IsEmpty(OriginallyUsed, EmptyComparisonOptions.NullOrWhitespace) ? OriginallyUsed : Current;
            return $"{symbols} {amount:F2}";
        }

        /// <summary> 将 <paramref name="amount" /> 转换成带有货币符号的金额字符串（保留两位小数）。 </summary>
        /// <param name="amount"> 金额。 </param>
        /// <param name="useOriginal"> 使用之前货币符号。 </param>
        /// <returns> 带有货币符号的金额字符串（保留两位小数）。 </returns>
        /// <exception cref="System.FormatException"> 当调用 <see cref="double.ToString(string)" /> 时，可能引发此类型的异常。 </exception>
        public string ToString(double amount, bool useOriginal = false)
        {
            var symbols = useOriginal && !AssertUtilities.IsEmpty(OriginallyUsed, EmptyComparisonOptions.NullOrWhitespace) ? OriginallyUsed : Current;
            return $"{symbols} {amount:F2}";
        }

        /// <summary> 将 <paramref name="amount" /> 转换成带有货币符号的金额字符串（保留两位小数）。 </summary>
        /// <param name="amount"> 金额。 </param>
        /// <param name="useOriginal"> 使用之前货币符号。 </param>
        /// <returns> 带有货币符号的金额字符串（保留两位小数）。 </returns>
        /// <exception cref="System.FormatException"> 当调用 <see cref="float.ToString(string)" /> 时，可能引发此类型的异常。 </exception>
        public string ToString(float amount, bool useOriginal = false)
        {
            var symbols = useOriginal && !AssertUtilities.IsEmpty(OriginallyUsed, EmptyComparisonOptions.NullOrWhitespace) ? OriginallyUsed : Current;
            return $"{symbols} {amount:F2}";
        }

        /// <summary> 将 <paramref name="amount" /> 转换成带有货币符号的金额字符串（保留两位小数）。 </summary>
        /// <param name="amount"> 金额。 </param>
        /// <param name="useOriginal"> 使用之前货币符号。 </param>
        /// <returns> 带有货币符号的金额字符串（保留两位小数）。 </returns>
        /// <exception cref="System.FormatException"> 当调用 <see cref="decimal.ToString(string)" /> 时，可能引发此类型的异常。 </exception>
        public string ToString(decimal amount, bool useOriginal = false)
        {
            var symbols = useOriginal && !AssertUtilities.IsEmpty(OriginallyUsed, EmptyComparisonOptions.NullOrWhitespace) ? OriginallyUsed : Current;
            return $"{symbols} {amount:F2}";
        }
    }
}