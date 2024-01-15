// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft.Utilities
{
    public static partial class AssertUtilities
    {
        /// <summary> 当 <paramref name="a" /> 等于 <paramref name="b" /> 时，返回 <see langword="true" />；否则返回 <see langword="false" />。 </summary>
        /// <param name="a"> <see cref="float" /> 类型的值。 </param>
        /// <param name="b"> <see cref="float" /> 类型的值。 </param>
        /// <returns> 当 <paramref name="a" /> 等于 <paramref name="b" /> 时，返回 <see langword="true" />；否则返回 <see langword="false" />。 </returns>
        public static bool Equals(float a, float b = 0.00F)
            => a == b;

        /// <summary> 当 <paramref name="a" /> 大于 <paramref name="b" /> 时，返回 <see langword="true" />；否则返回 <see langword="false" />。 </summary>
        /// <param name="a"> <see cref="float" /> 类型的值。 </param>
        /// <param name="b"> <see cref="float" /> 类型的值。 </param>
        /// <returns> 当 <paramref name="a" /> 大于 <paramref name="b" /> 时，返回 <see langword="true" />；否则返回 <see langword="false" />。 </returns>
        public static bool GreatThan(float a, float b = 0.00F)
            => a > b;

        /// <summary> 当 <paramref name="a" /> 大于等于 <paramref name="b" /> 时，返回 <see langword="true" />；否则返回 <see langword="false" />。 </summary>
        /// <param name="a"> <see cref="float" /> 类型的值。 </param>
        /// <param name="b"> <see cref="float" /> 类型的值。 </param>
        /// <returns> 当 <paramref name="a" /> 大于等于 <paramref name="b" /> 时，返回 <see langword="true" />；否则返回 <see langword="false" />。 </returns>
        public static bool GreatThanOrEquals(float a, float b = 0.00F)
            => a >= b;

        /// <summary> 当 <paramref name="a" /> 小于 <paramref name="b" /> 时，返回 <see langword="true" />；否则返回 <see langword="false" />。 </summary>
        /// <param name="a"> <see cref="float" /> 类型的值。 </param>
        /// <param name="b"> <see cref="float" /> 类型的值。 </param>
        /// <returns> 当 <paramref name="a" /> 小于 <paramref name="b" /> 时，返回 <see langword="true" />；否则返回 <see langword="false" />。 </returns>
        public static bool LessThan(float a, float b = 0.00F)
            => a < b;

        /// <summary> 当 <paramref name="a" /> 小于等于 <paramref name="b" /> 时，返回 <see langword="true" />；否则返回 <see langword="false" />。 </summary>
        /// <param name="a"> <see cref="float" /> 类型的值。 </param>
        /// <param name="b"> <see cref="float" /> 类型的值。 </param>
        /// <returns> 当 <paramref name="a" /> 小于等于 <paramref name="b" /> 时，返回 <see langword="true" />；否则返回 <see langword="false" />。 </returns>
        public static bool LessThanOrEquals(float a, float b = 0.00F)
            => a <= b;
    }
}