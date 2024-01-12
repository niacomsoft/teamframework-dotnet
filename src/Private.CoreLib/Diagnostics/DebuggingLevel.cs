// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft.Diagnostics
{
    /// <summary> 定义了调试级别枚举类型。 </summary>
    public enum DebuggingLevel
    {
        /// <summary> 调试级的调试信息。 </summary>
        Debug = 65535,

        /// <summary> 信息级的调试信息。 </summary>
        Information = 1,

        /// <summary> 警告级的调试信息。 </summary>
        Warning = 2,

        /// <summary> 错误、异常级的调试信息。 </summary>
        Error = 3,

        /// <summary> 默认的级别。等同于 <see cref="Information" />。 </summary>
        Default = Information
    }
}