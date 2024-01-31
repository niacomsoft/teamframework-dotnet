// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System.Text.RegularExpressions;

namespace Niacomsoft.Configuration
{
    /// <summary> 定义了宏参数信息的接口。 </summary>
    public interface IMacroParameter
    {
        /// <summary> 宏参数表达式。 </summary>
        /// <value> 获取一个字符串，用于表示宏参数表达式。 </value>
        string Expression { get; }

        /// <summary> 宏参数名称。 </summary>
        /// <value> 获取一个字符串，用于表示宏参数名称。 </value>
        string Name { get; }

        /// <summary> 宏参数所属范围。 </summary>
        /// <value> 获取一个字符串，用于表示宏参数所属范围。 </value>
        string Scope { get; }

        /// <summary> 宏参数值。 </summary>
        /// <value> 获取一个字符串，用于表示宏参数值。 </value>
        string Value { get; }

        /// <summary> 当字符串 <paramref name="s" /> 与当前的宏参数模式匹配时返回 <see langword="true" />；否则返回 <see langword="false" />。 </summary>
        /// <param name="s"> 需要匹配的字符串。 </param>
        /// <param name="options">
        /// 正则匹配选项。
        /// <para> <see cref="RegexOptions" /> 中的一个或几个值。 </para>
        /// </param>
        /// <returns> 当字符串 <paramref name="s" /> 与当前的宏参数模式匹配时返回 <see langword="true" />；否则返回 <see langword="false" />。 </returns>
        /// <seealso cref="Regex" />
        /// <seealso cref="Regex.IsMatch(string, string, RegexOptions)" />
        /// <seealso cref="RegexOptions" />
        bool IsMatch(string s, RegexOptions options = RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase);

        /// <summary> 将字符串 <paramref name="s" /> 中匹配当前宏参数的片段替换为宏参数值 <see cref="Value" />。 </summary>
        /// <param name="s"> 需要匹配替换的字符串。 </param>
        /// <param name="options">
        /// 正则匹配替换选项。
        /// <para> <see cref="RegexOptions" /> 中的一个或几个值。 </para>
        /// </param>
        /// <returns> 替换后的字符串。 </returns>
        /// <seealso cref="Regex" />
        /// <seealso cref="Regex.Replace(string, string, string, RegexOptions)" />
        /// <seealso cref="RegexOptions" />
        string Replace(string s, RegexOptions options = RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase);
    }
}