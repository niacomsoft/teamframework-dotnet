// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft.Diagnostics
{
    /// <summary> 提供了调试器符号相关的方法。 </summary>
    public static class DebuggerSymbols
    {
#if DEBUG

        /// <summary> 是否为调试模式。 </summary>
        public const bool IsDebugMode = true;

#else
        /// <summary> 是否为调试模式。 </summary>
        public const bool IsDebugMode = false;
#endif
    }
}