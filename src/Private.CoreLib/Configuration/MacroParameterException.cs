// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;
using System.Text.RegularExpressions;

using Niacomsoft.Utilities;

namespace Niacomsoft.Configuration
{
    /// <summary> 提供了宏参数相关的异常。密闭的，不可以从此类型派生。 </summary>
    /// <seealso cref="Exception" />
    /// <remarks> 密闭的，不可以从此类型派生。 </remarks>
    public sealed class MacroParameterException : Exception
    {
        private static readonly Regex NamePattern = new Regex(@"^[a-zA-Z\d\-_]+$", RegexOptions.Singleline);

        /// <summary> 初始化 <see cref="MacroParameterException" /> 类的新实例。 </summary>
        public MacroParameterException() : base()
        {
        }

        /// <summary> 用指定的错误消息初始化 <see cref="MacroParameterException" /> 类的新实例。 </summary>
        /// <param name="message"> 描述错误的消息。 </param>
        public MacroParameterException(string message) : base(message)
        {
        }

        /// <summary> 使用指定的错误消息和对作为此异常原因的内部异常的引用来初始化 <see cref="MacroParameterException" /> 类的新实例。 </summary>
        /// <param name="message"> 解释异常原因的错误消息。 </param>
        /// <param name="innerException"> 导致当前异常的异常；如果未指定内部异常，则是一个 null 引用（在 Visual Basic 中为 <see langword="Nothing" />）。 </param>
        public MacroParameterException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// 当指定的宏参数名称 <paramref name="name" /> 等于 <see langword="null" />、 <see cref="string.Empty" /> 或空白符时，将引发一个
        /// <see cref="MacroParameterException" /> 类型的异常。
        /// </summary>
        /// <param name="name"> 需要校验的宏参数名称。 </param>
        public static void ThrowIfEmpty(string name)
        {
            if (AssertUtilities.IsEmpty(name, EmptyComparisonOptions.NullOrWhitespace))
            {
#pragma warning disable Ex0100 // Member may throw undocumented exception
                throw new MacroParameterException(SR.GetString("MacroParameterException_invalid_name_empty_name"),
                    new ArgumentException(SR.Format("ArgumentException_with_parameter_name", nameof(name)), nameof(name)));
#pragma warning restore Ex0100 // Member may throw undocumented exception
            }
        }

        /// <summary>
        /// 当指定的宏命令参数名称 <paramref name="name" /> 包含了字母、数字、英文减号和英文下划线之外的特殊字符时，将引发一个 <see cref="MacroParameterException" /> 类型的异常。
        /// </summary>
        /// <param name="name"> 需要校验的宏参数名称。 </param>
        public static void ThrowIfNotMatch(string name)
        {
#pragma warning disable Ex0100 // Member may throw undocumented exception
            if (!NamePattern.IsMatch(name))
            {
                throw new MacroParameterException(SR.GetString("MacroParameterException_invalid_name_not_match"));
#pragma warning restore Ex0100 // Member may throw undocumented exception
            }
        }
    }
}