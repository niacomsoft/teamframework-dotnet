// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft
{
    /// <summary> 定义了空白字符串比较选项枚举类型。 </summary>
    public enum EmptyComparisonOptions
    {
        /// <summary> 仅比较字符串是否为 <see langword="null" /> 值。 </summary>
        OnlyNull = 1,

        /// <summary> 比较字符串是否为 <see langword="null" /> 值或 <see cref="string.Empty" />。 </summary>
        NullOrEmpty = 2,

        /// <summary> 比较字符串是否为 <see langword="null" /> 值； <see cref="string.Empty" /> 或全为空白符。 </summary>
        NullOrWhitespace = 3,

        /// <summary> 默认的。等同于 <see cref="NullOrEmpty" />。 </summary>
        Default = NullOrEmpty
    }
}