// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

using Niacomsoft.Diagnostics;
using Niacomsoft.Utilities;

namespace Niacomsoft
{
    /// <summary> 提供了日期时间 ( <see cref="DateTime" />) 格式化字符串相关的方法。密闭的，不可以从此类型派生。 </summary>
    /// <remarks> 密闭的，不可以从此类型派生。 </remarks>
    public sealed class DateTimeFormatter
    {
#if NET45_OR_GREATER || NETSTANDARD || NETCOREAPP || NET
        /// <summary>
        /// 标准的日期时间格式化方法。
        /// <para> 仅包含日期（参见 <c> yyyy-MM-dd </c>）。 </para>
        /// </summary>
        public static readonly Lazy<DateTimeFormatter> DateOnly = new Lazy<DateTimeFormatter>(() => new DateTimeFormatter("yyyy-MM-dd"), true);

        /// <summary>
        /// 标准的日期时间格式化方法。
        /// <para> 仅包含时、分、秒（参见 <c> HH:mm:ss </c>）。 </para>
        /// </summary>
        public static readonly Lazy<DateTimeFormatter> TimeOnly = new Lazy<DateTimeFormatter>(() => new DateTimeFormatter("HH:mm:ss"), true);

        /// <summary>
        /// 标准的日期时间格式化方法。
        /// <para> 默认的格式化方法（参见 <c> yyyy-MM-dd HH:mm:ss </c>）。 </para>
        /// </summary>
        public static readonly Lazy<DateTimeFormatter> Default = new Lazy<DateTimeFormatter>(() => new DateTimeFormatter("yyyy-MM-dd HH:mm:ss"), true);
#else

        /// <summary>
        /// 标准的日期时间格式化方法。
        /// <para> 仅包含日期（参见 <c> yyyy-MM-dd </c>）。 </para>
        /// </summary>
        public static readonly DateTimeFormatter DateOnly = new DateTimeFormatter("yyyy-MM-dd");

        /// <summary>
        /// 标准的日期时间格式化方法。
        /// <para> 仅包含时、分、秒（参见 <c> HH:mm:ss </c>）。 </para>
        /// </summary>
        public static readonly DateTimeFormatter TimeOnly = new DateTimeFormatter("HH:mm:ss");

        /// <summary>
        /// 标准的日期时间格式化方法。
        /// <para> 默认的格式化方法（参见 <c> yyyy-MM-dd HH:mm:ss </c>）。 </para>
        /// </summary>
        public static readonly DateTimeFormatter Default = new DateTimeFormatter("yyyy-MM-dd HH:mm:ss");

#endif

        /// <summary> 初始化 <see cref="DateTimeFormatter" /> 类的新实例。 </summary>
        /// <param name="template"> 日期时间格式化模板字符串。 </param>
        /// <exception cref="ArgumentException">
        /// 当 <paramref name="template" /> 等于 <see langword="null" />、 <see cref="string.Empty" /> 或空白符时，将引发此类型的异常。
        /// </exception>
        public DateTimeFormatter(string template)
        {
            if (Debugger.IfWriteLine(AssertUtilities.IsEmpty(template, EmptyComparisonOptions.NullOrWhitespace), "Incorrect datetime format template string parameter \"template\".", null, DebuggingLevel.Warning))
            {
#pragma warning disable Ex0100 // Member may throw undocumented exception
                throw new ArgumentException(SR.Format("ArgumentException_with_parameter_name", nameof(template)), nameof(template));
#pragma warning restore Ex0100 // Member may throw undocumented exception
            }
            Template = template;
        }

        /// <summary> 日期时间格式化模板字符串。 </summary>
        /// <value> 获取一个字符串，用于表示日期时间格式化模板字符串。 </value>
        public string Template { get; }

        /// <summary> 格式化日期时间值 <paramref name="value" /> 为字符串。 </summary>
        /// <param name="value"> <see cref="DateTime" /> 类型的值。 </param>
        /// <returns> 日期时间格式化字符串。 </returns>
        /// <seealso cref="DateTime" />
        /// <seealso cref="DateTime.ToString()" />
        /// <exception cref="FormatException"> 当调用 <see cref="DateTime.ToString()" /> 方法时，可能引发此类型的异常。 </exception>
        public string Format(DateTime value)
        {
            return value.ToString(Template);
        }
    }
}