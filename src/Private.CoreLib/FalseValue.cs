// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft
{
    /// <summary> 提供了 <see langword="false" /> 值相关的常量。 </summary>
    public static class FalseValue
    {
        /// <summary> <see langword="false" /> 值。 </summary>
        public const bool Value = false;

        /// <summary> <see langword="false" /> 等效的 <see cref="int" /> 类型的值。 </summary>
        public const int IntValue = 0;

        /// <summary> <see langword="false" /> 等效的 <see cref="byte" /> 类型的值。 </summary>
        public const byte ByteValue = 0;

        /// <summary> <see langword="false" /> 等效的 <see cref="char" /> 类型的值（ <c> N </c>）。 </summary>
        public const char N = 'N';

        /// <summary> <see langword="false" /> 等效的 <see cref="char" /> 类型的值（ <c> F </c>）。 </summary>
        public const char F = 'F';

        /// <summary> <see langword="false" /> 等效的字符串。 </summary>
        public const string FalseString = "False";
    }
}