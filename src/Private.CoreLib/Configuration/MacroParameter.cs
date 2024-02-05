// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System.Text;
using System.Text.RegularExpressions;

using Niacomsoft.Utilities;

namespace Niacomsoft.Configuration
{
    /// <summary> 提供了宏参数配置相关的方法。 </summary>
    /// <seealso cref="IMacroParameter" />
    /// <seealso cref="Regex" />
    public class MacroParameter : IMacroParameter
    {
        /// <summary> 初始化 <see cref="MacroParameter" /> 类的新实例。 </summary>
        /// <param name="name"> 宏参数名称。 </param>
        /// <param name="value"> 宏参数值。 </param>
        public MacroParameter(string name, string value) : this(name, value, null)
        {
        }

        /// <summary> 初始化 <see cref="MacroParameter" /> 类的新实例。 </summary>
        /// <param name="name"> 宏参数名称。 </param>
        /// <param name="value"> 宏参数值。 </param>
        /// <param name="scope"> 宏参数所属范围。 </param>
        public MacroParameter(string name, string value, string scope)
        {
            MacroParameterException.ThrowIfEmpty(name);
            MacroParameterException.ThrowIfNotMatch(name);
            Name = name;
            Value = StringUtilities.IfEmpty(value, string.Empty, EmptyComparisonOptions.OnlyNull);
            Scope = scope;
            Expression = AssertUtilities.IsEmpty(Scope, EmptyComparisonOptions.NullOrWhitespace)
                    ? $"$({Name})"
                    : $"$({Scope.Trim()}:{Name})";

            var patternBuilder = new StringBuilder(@"\$\(");
            if (!AssertUtilities.IsEmpty(Scope, EmptyComparisonOptions.NullOrWhitespace))
            {
                patternBuilder.Append($@"{Scope.Trim()}\:");
            }
            patternBuilder.Append($@"{Name.Trim()}\)");
            DynamicallyGeneratedPattern = patternBuilder.ToString();
        }

        /// <inheritdoc />
        public virtual string Expression { get; }

        /// <inheritdoc />
        public virtual string Name { get; }

        /// <inheritdoc />
        public virtual string Scope { get; }

        /// <inheritdoc />
        public virtual string Value { get; }

        /// <summary> 动态生成的正则表达式。 </summary>
        /// <value> 获取一个字符串，用于表示动态生成的正则表达式。 </value>
        protected virtual string DynamicallyGeneratedPattern { get; }

        /// <inheritdoc />
        public virtual bool IsMatch(string s, RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline)
        {
            return Regex.IsMatch(s, DynamicallyGeneratedPattern, options);
        }

        /// <inheritdoc />
        public virtual string Replace(string s, RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline)
        {
            return Regex.Replace(s, DynamicallyGeneratedPattern, Value, options);
        }

        /// <summary> 获取完整的宏参数名称。 </summary>
        /// <returns> 完整的宏参数名称。 </returns>
        public override string ToString()
        {
            return AssertUtilities.IsEmpty(Scope, EmptyComparisonOptions.NullOrWhitespace)
                ? Name
                : $"{Scope.Trim()}:{Name.Trim()}";
        }
    }
}