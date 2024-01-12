// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using Niacomsoft.Diagnostics;

namespace Niacomsoft.Utilities
{
    /// <summary> 提供了数据类型断言相关的方法。 </summary>
    public static partial class AssertUtilities
    {
        /// <summary> 当 <paramref name="obj" /> 为 <see langword="null" /> 值时，返回 <see langword="true" />；否则返回 <see langword="false" />。 </summary>
        /// <param name="obj"> 需要验证的 <see cref="object" /> 类型的对象实例。 </param>
        /// <returns> 当 <paramref name="obj" /> 为 <see langword="null" /> 值时，返回 <see langword="true" />；否则返回 <see langword="false" />。 </returns>
        public static bool IsNull(object obj)
            => Debugger.IfWriteLine(obj is null,
                                    "The parameter \"obj\" is a null value, please pay attention to it.",
                                    null,
                                    DebuggingLevel.Debug);

        /// <summary> 当 <paramref name="obj" /> 为 <see langword="null" /> 值时，返回 <see langword="false" />；否则返回 <see langword="true" />。 </summary>
        /// <param name="obj"> 需要验证的 <see cref="object" /> 类型的对象实例。 </param>
        /// <returns> 当 <paramref name="obj" /> 为 <see langword="null" /> 值时，返回 <see langword="false" />；否则返回 <see langword="true" />。 </returns>
        /// <seealso cref="IsNull(object)" />
        public static bool NotNull(object obj)
            => !IsNull(obj);

#if NET45_OR_GREATER || NETSTANDARD || NETCOREAPP || NET
        /// <summary>
        /// 当字符串 <paramref name="s" /> 为 <see langword="null" /> 值、 <see cref="string.Empty" /> 或全为空白符时，返回
        /// <see langword="true" />；否则返回 <see langword="false" />。
        /// </summary>
        /// <param name="s"> 需要验证的字符串。 </param>
        /// <param name="options">
        /// 字符串比较选项。
        /// <para> <see cref="EmptyComparisonOptions" /> 中的一个值。 </para>
        /// </param>
        /// <returns>
        /// 当字符串 <paramref name="s" /> 为 <see langword="null" /> 值、 <see cref="string.Empty" /> 或全为空白符时，返回
        /// <see langword="true" />；否则返回 <see langword="false" />。
        /// </returns>
        /// <seealso cref="EmptyComparisonOptions" />
        /// <seealso cref="IsNull(object)" />
        /// <seealso cref="string.IsNullOrEmpty(string)" />
        /// <seealso cref="string.IsNullOrWhiteSpace(string)" />
#else
        /// <summary>
        /// 当字符串 <paramref name="s" /> 为 <see langword="null" /> 值、 <see cref="string.Empty" /> 或全为空白符时，返回
        /// <see langword="true" />；否则返回 <see langword="false" />。
        /// </summary>
        /// <param name="s"> 需要验证的字符串。 </param>
        /// <param name="options">
        /// 字符串比较选项。
        /// <para> <see cref="EmptyComparisonOptions" /> 中的一个值。 </para>
        /// </param>
        /// <returns>
        /// 当字符串 <paramref name="s" /> 为 <see langword="null" /> 值、 <see cref="string.Empty" /> 或全为空白符时，返回
        /// <see langword="true" />；否则返回 <see langword="false" />。
        /// </returns>
        /// <seealso cref="EmptyComparisonOptions" />
        /// <seealso cref="IsNull(object)" />
        /// <seealso cref="string.IsNullOrEmpty(string)" />
#endif
        public static bool IsEmpty(string s, EmptyComparisonOptions options = EmptyComparisonOptions.Default)
        {
            if (options == EmptyComparisonOptions.OnlyNull)
            {
                return IsNull(s);
            }
            else if (options == EmptyComparisonOptions.NullOrEmpty)
            {
                return Debugger.IfWriteLine(string.IsNullOrEmpty(s),
                                            "The string parameter \"s\" may be a null value or a string. Empty value.",
                                            null,
                                            DebuggingLevel.Debug);
            }
            else
            {
#if NET45_OR_GREATER || NETSTANDARD || NETSTANDARD || NET
                return Debugger.IfWriteLine(string.IsNullOrWhiteSpace(s),
                                            "The string parameter \"s\" may be a null value;string. Empty value or all whitespace.",
                                            null,
                                            DebuggingLevel.Debug);
#else
                return Debugger.IfWriteLine(string.IsNullOrEmpty(s?.ToString()),
                                            "The string parameter \"s\" may be a null value;string. Empty value or all whitespace.",
                                            null,
                                            DebuggingLevel.Debug);
#endif
            }
        }
    }
}