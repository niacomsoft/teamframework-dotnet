// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

namespace Niacomsoft.Diagnostics
{
    public static partial class Debugger
    {
#if NET45_OR_GREATER || NETSTANDARD || NETCOREAPP || NET
        /// <summary> 当条件表达式 <paramref name="where" /> 返回 <see langword="true" /> 时，输出调试诊断信息。 </summary>
        /// <param name="where">
        /// 条件表达式。
        /// <para> <see cref="bool" /> 类型返回值的 <see cref="Func{TResult}" /> 类型的方法委托。 </para>
        /// </param>
        /// <param name="message"> 调试信息。 </param>
        /// <param name="category"> 调试信息类别。 </param>
        /// <param name="level">
        /// 调试级别。
        /// <para> <see cref="DebuggingLevel" /> 中的一个值。 </para>
        /// </param>
        /// <returns> <paramref name="where" /> 值。 </returns>
        /// <seealso cref="DebuggingLevel" />
        /// <seealso cref="Func{TResult}" />
        /// <seealso cref="IfWriteLine(bool, string, string, DebuggingLevel)" />
        public static bool IfWriteLine(Func<bool> where, string message, string category, DebuggingLevel level = DebuggingLevel.Default)
            => IfWriteLine(!(where is null) && where(), message, category, level);

        /// <summary> 当条件表达式 <paramref name="where" /> 返回 <see langword="true" /> 时，输出调试诊断信息。 </summary>
        /// <typeparam name="TCategory"> 标识调试诊断信息的类别类型。 </typeparam>
        /// <param name="where">
        /// 条件表达式。
        /// <para> <see cref="bool" /> 类型返回值的 <see cref="Func{TResult}" /> 类型的方法委托。 </para>
        /// </param>
        /// <param name="message"> 调试信息。 </param>
        /// <param name="level">
        /// 调试级别。
        /// <para> <see cref="DebuggingLevel" /> 中的一个值。 </para>
        /// </param>
        /// <returns> <paramref name="where" /> 值。 </returns>
        /// <seealso cref="DebuggingLevel" />
        /// <seealso cref="Func{TResult}" />
        /// <seealso cref="IfWriteLine(Func{bool}, string, string, DebuggingLevel)" />
        public static bool IfWriteLine<TCategory>(Func<bool> where, string message, DebuggingLevel level = DebuggingLevel.Default)
            => IfWriteLine(where, message, typeof(TCategory).Name, level);
#endif
    }
}