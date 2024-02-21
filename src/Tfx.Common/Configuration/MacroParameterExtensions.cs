// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System.Collections.Generic;
using System.Text.RegularExpressions;

using Niacomsoft.Configuration;
using Niacomsoft.Utilities;

namespace Niacomsoft.TeamFramework.Configuration
{
    /// <summary> 为 <see cref="IMacroParameter" /> 类型提供的扩展方法。 </summary>
    public static class MacroParameterExtensions
    {
        /// <summary> 替换字符串中的宏参数。 </summary>
        /// <param name="this"> 需要替换的字符串。 </param>
        /// <param name="macros">
        /// 宏参数集合。
        /// <para> 实现了 <see cref="IMacroParameter" /> 类型接口的对象实例集合。 </para>
        /// </param>
        /// <param name="options"> <see cref="RegexOptions" /> 中的一个或几个值。 </param>
        /// <returns> 替换后的字符串。 </returns>
        /// <seealso cref="IEnumerable{T}" />
        /// <seealso cref="IMacroParameter" />
        /// <seealso cref="RegexOptions" />
        public static string Replace(this string @this, IEnumerable<IMacroParameter> macros, RegexOptions options = RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase)
        {
            if (AssertUtilities.IsEmpty(@this, EmptyComparisonOptions.NullOrWhitespace) || AssertUtilities.IsNull(macros))
                return @this;
            var replacedStr = @this;
            foreach (var item in macros)
                replacedStr = item.Replace(replacedStr, options);
            return replacedStr;
        }
    }
}