// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft.TeamFramework.Extensions.Logging
{
    /// <summary> 定义了日志级别枚举类型。 </summary>
    public enum LogLevel
    {
        /// <summary> 追踪级日志。 </summary>
        Trace = 1,

        /// <summary> 调试级日志。 </summary>
        Debug = 2,

        /// <summary> 信息级日志。 </summary>
        Information = 3,

        /// <summary> 警告级日志。 </summary>
        Warning = 4,

        /// <summary> 错误级日志。 </summary>
        Error = 5,

        /// <summary> 崩溃、致命级日志。 </summary>
        Fatal = 6,

#if DEBUG

        /// <summary>
        /// 默认的日志级别。
        /// <para> 等效于 <see cref="Debug" />。 </para>
        /// </summary>
        /// <seealso cref="Debug" />
        Default = Debug

#else
        /// <summary>
        /// 默认的日志级别。
        /// <para> 等效于 <see cref="Information" />。 </para>
        /// </summary>
        /// <seealso cref="Information" />
        Default = Information
#endif
    }
}