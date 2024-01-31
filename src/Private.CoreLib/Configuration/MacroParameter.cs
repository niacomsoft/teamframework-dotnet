// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

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
#pragma warning disable Ex0100 // Member may throw undocumented exception
            MacroParameterException.ThrowIfNotMatch(name);
#pragma warning restore Ex0100 // Member may throw undocumented exception
            Name = name;
            Value = StringUtilities.IfEmpty(value, string.Empty, EmptyComparisonOptions.OnlyNull);
            Scope = scope;
            Expression = AssertUtilities.IsEmpty(Scope, EmptyComparisonOptions.NullOrWhitespace)
                    ? $"$({Name})"
                    : $"$({Scope.Trim()}:{Name})";
        }

        /// <inheritdoc />
        public virtual string Expression { get; }

        /// <inheritdoc />
        public virtual string Name { get; }

        /// <inheritdoc />
        public virtual string Scope { get; }

        /// <inheritdoc />
        public virtual string Value { get; }

        /// <inheritdoc />
        public virtual bool IsMatch(string s, RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline)
        {
        }

        /// <inheritdoc />
        public virtual string Replace(string s, RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline)
        {
        }
    }
}