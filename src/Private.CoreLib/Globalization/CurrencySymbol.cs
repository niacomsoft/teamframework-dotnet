// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

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
    }
}