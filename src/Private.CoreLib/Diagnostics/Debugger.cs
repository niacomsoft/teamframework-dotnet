// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System.Diagnostics;

namespace Niacomsoft.Diagnostics
{
    /// <summary> 提供了输出调试期诊断信息相关的方法。 </summary>
    /// <seealso cref="Trace" />
    public static partial class Debugger
    {
#if NETFRAMEWORK
        private const string DefaultCategoryName = "NETFX";
#elif NETSTANDARD
        private const string DefaultCategoryName = "NETSTANDARD";
#elif NETCOREAPP
        private const string DefaultCategoryName = "NETCORE";
#else
        private const string DefaultCategoryName = "NET";
#endif

        /// <summary> 输出调试信息 <paramref name="message" />。 </summary>
        /// <param name="message"> 调试信息。 </param>
        /// <param name="category"> 调试信息类别。 </param>
        /// <param name="level">
        /// 调试信息级别。
        /// <para> <see cref="DebuggingLevel" /> 中的一个值。 </para>
        /// </param>
        /// <seealso cref="DebuggingLevel" />
        private static void InternalWriteLine(string message, string category, DebuggingLevel level)
        {
            if (!string.IsNullOrEmpty(message))
            {
                if (level == DebuggingLevel.Debug)
                {
                    if (DebuggerSymbols.IsDebugMode)
                    {
                        Debug.WriteLine(BuildDebuggingMessage(message, category));
                    }
                }
                else if (level == DebuggingLevel.Information)
                {
                    Trace.TraceInformation(BuildDebuggingMessage(message, category));
                }
                else if (level == DebuggingLevel.Warning)
                {
                    Trace.TraceWarning(BuildDebuggingMessage(message, category));
                }
                else
                {
                    Trace.TraceError(BuildDebuggingMessage(message, category));
                }
            }
        }

        /// <summary> 构建调试信息。 </summary>
        /// <param name="message"> 调试信息。 </param>
        /// <param name="category"> 调试信息类别。 </param>
        /// <returns> 完整的调试信息。 </returns>
        private static string BuildDebuggingMessage(string message, string category)
            => $"[{(string.IsNullOrEmpty(category) ? DefaultCategoryName : category.Trim())}]  {message}";

        /// <summary> 输出调试诊断信息。 </summary>
        /// <param name="message"> 调试信息。 </param>
        /// <param name="category"> 调试信息类别。 </param>
        /// <param name="level">
        /// 调试级别。
        /// <para> <see cref="DebuggingLevel" /> 中的一个值。 </para>
        /// </param>
        /// <seealso cref="DebuggingLevel" />
        public static void WriteLine(string message, string category, DebuggingLevel level = DebuggingLevel.Default)
            => InternalWriteLine(message, category, level);

        /// <summary> 输出调试诊断信息。 </summary>
        /// <typeparam name="TCategory"> 标识调试诊断信息的类别类型。 </typeparam>
        /// <param name="message"> 调试信息。 </param>
        /// <param name="level">
        /// 调试级别。
        /// <para> <see cref="DebuggingLevel" /> 中的一个值。 </para>
        /// </param>
        /// <seealso cref="DebuggingLevel" />
        /// <seealso cref="WriteLine(string, string, DebuggingLevel)" />
        public static void WriteLine<TCategory>(string message, DebuggingLevel level = DebuggingLevel.Default)
            => WriteLine(message, typeof(TCategory).Name, level);

        /// <summary> 当条件表达式 <paramref name="where" /> 为 <see langword="true" /> 时，输出调试诊断信息。 </summary>
        /// <param name="where"> 条件表达式。 </param>
        /// <param name="message"> 调试信息。 </param>
        /// <param name="category"> 调试信息类别。 </param>
        /// <param name="level">
        /// 调试级别。
        /// <para> <see cref="DebuggingLevel" /> 中的一个值。 </para>
        /// </param>
        /// <returns> <paramref name="where" /> 值。 </returns>
        /// <seealso cref="DebuggingLevel" />
        /// <seealso cref="WriteLine(string, string, DebuggingLevel)" />
        public static bool IfWriteLine(bool where, string message, string category, DebuggingLevel level = DebuggingLevel.Default)
        {
            if (where)
            {
                WriteLine(message, category, level);
            }
            return where;
        }

        /// <summary> 当条件表达式 <paramref name="where" /> 为 <see langword="true" /> 时，输出调试诊断信息。 </summary>
        /// <typeparam name="TCategory"> 标识调试诊断信息的类别类型。 </typeparam>
        /// <param name="where"> 条件表达式。 </param>
        /// <param name="message"> 调试信息。 </param>
        /// <param name="level">
        /// 调试级别。
        /// <para> <see cref="DebuggingLevel" /> 中的一个值。 </para>
        /// </param>
        /// <returns> <paramref name="where" /> 值。 </returns>
        /// <seealso cref="DebuggingLevel" />
        /// <seealso cref="IfWriteLine(bool, string, string, DebuggingLevel)" />
        public static bool IfWriteLine<TCategory>(bool where, string message, DebuggingLevel level = DebuggingLevel.Default)
            => IfWriteLine(where, message, typeof(TCategory).Name, level);
    }
}