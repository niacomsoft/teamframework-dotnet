// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System.Diagnostics;

namespace Niacomsoft.Diagnostics
{
    /// <summary>
    /// 提供了输出调试期诊断信息相关的方法。
    /// </summary>
    /// <seealso cref="Trace" />
    public static class Debugger
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

        /// <summary>
        /// 输出调试信息 <paramref name="message" />。
        /// </summary>
        /// <param name="message"> 调试信息。 </param>
        /// <param name="category"> 调试信息类别。 </param>
        /// <param name="level">
        /// 调试信息级别。
        /// <para> <see cref="DebuggingLevel" /> 中的一个值。 </para>
        /// </param>
        /// <seealso cref="DebuggingLevel" />
        private static void InternalWriteLine(string message, string category, DebuggingLevel level = DebuggingLevel.Default)
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                if (level == DebuggingLevel.Debug)
                {
                    if (DebuggerSymbols.IsDebugMode)
                    {
                        Debug.WriteLine(BuildDebuggingMessage(message, category));
                    }
                }
            }
        }

        /// <summary>
        /// 构建调试信息。
        /// </summary>
        /// <param name="message"> 调试信息。 </param>
        /// <param name="category"> 调试信息类别。 </param>
        /// <returns> 完整的调试信息。 </returns>
        private static string BuildDebuggingMessage(string message, string category)
        {
            return $"[{(string.IsNullOrWhiteSpace(category) ? DefaultCategoryName : category.Trim().ToUpper())}]  {message}";
        }
    }
}