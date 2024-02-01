// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft.Utilities
{
    public static partial class AssertUtilities
    {
        /// <summary> 当 <paramref name="a" /> 等于 <paramref name="b" /> 时，返回 <see langword="true" />；否则返回 <see langword="false" />。 </summary>
        /// <param name="a"> <see cref="int" /> 类型的值。 </param>
        /// <param name="b"> <see cref="int" /> 类型的值。 </param>
        /// <returns> 当 <paramref name="a" /> 等于 <paramref name="b" /> 时，返回 <see langword="true" />；否则返回 <see langword="false" />。 </returns>
        public static bool Equals(int a, int b = 0)
            => a == b;

        /// <summary> 当 <paramref name="a" /> 大于 <paramref name="b" /> 时，返回 <see langword="true" />；否则返回 <see langword="false" />。 </summary>
        /// <param name="a"> <see cref="int" /> 类型的值。 </param>
        /// <param name="b"> <see cref="int" /> 类型的值。 </param>
        /// <returns> 当 <paramref name="a" /> 大于 <paramref name="b" /> 时，返回 <see langword="true" />；否则返回 <see langword="false" />。 </returns>
        public static bool GreatThan(int a, int b = 0)
            => a > b;

        /// <summary> 当 <paramref name="a" /> 大于等于 <paramref name="b" /> 时，返回 <see langword="true" />；否则返回 <see langword="false" />。 </summary>
        /// <param name="a"> <see cref="int" /> 类型的值。 </param>
        /// <param name="b"> <see cref="int" /> 类型的值。 </param>
        /// <returns> 当 <paramref name="a" /> 大于等于 <paramref name="b" /> 时，返回 <see langword="true" />；否则返回 <see langword="false" />。 </returns>
        public static bool GreatThanOrEquals(int a, int b = 0)
            => a >= b;

        /// <summary> 当 <paramref name="a" /> 小于 <paramref name="b" /> 时，返回 <see langword="true" />；否则返回 <see langword="false" />。 </summary>
        /// <param name="a"> <see cref="int" /> 类型的值。 </param>
        /// <param name="b"> <see cref="int" /> 类型的值。 </param>
        /// <returns> 当 <paramref name="a" /> 小于 <paramref name="b" /> 时，返回 <see langword="true" />；否则返回 <see langword="false" />。 </returns>
        public static bool LessThan(int a, int b = 0)
            => a < b;

        /// <summary> 当 <paramref name="a" /> 小于等于 <paramref name="b" /> 时，返回 <see langword="true" />；否则返回 <see langword="false" />。 </summary>
        /// <param name="a"> <see cref="int" /> 类型的值。 </param>
        /// <param name="b"> <see cref="int" /> 类型的值。 </param>
        /// <returns> 当 <paramref name="a" /> 小于等于 <paramref name="b" /> 时，返回 <see langword="true" />；否则返回 <see langword="false" />。 </returns>
        public static bool LessThanOrEquals(int a, int b = 0)
            => a <= b;

        /// <summary>
        /// 当 <paramref name="value" /> 介于 <paramref name="minValue" /> 和 <paramref name="maxValue" /> 之间时，返回
        /// <see langword="true" />；否则返回 <see langword="false" />。
        /// <para> 等同于 <c> minValue &lt; value &lt; maxValue </c>。 </para>
        /// </summary>
        /// <param name="value"> 需要校验的数值。 </param>
        /// <param name="minValue"> 下限值。 </param>
        /// <param name="maxValue"> 上限值。 </param>
        /// <param name="excludesMinValue">
        /// 用于控制下限值对比关系符号。
        /// <para> 当为 <see langword="true" /> 时，使用开放关系符（小于号，即 <c> &lt; </c>）；否则使用闭合的关系符（小于等于号，即 <c> &lt;= </c>）。 </para>
        /// </param>
        /// <param name="excludesMaxValue">
        /// 用于控制上限值对比关系符号。
        /// <para> 当为 <see langword="true" /> 时，使用开放关系符（小于号，即 <c> &lt; </c>）；否则使用闭合的关系符（小于等于号，即 <c> &lt;= </c>）。 </para>
        /// </param>
        /// <returns>
        /// 当 <paramref name="value" /> 介于 <paramref name="minValue" /> 和 <paramref name="maxValue" /> 之间时，返回
        /// <see langword="true" />；否则返回 <see langword="false" />。
        /// </returns>
        public static bool Between(int value, int minValue = 0, int maxValue = int.MaxValue, bool excludesMinValue = true, bool excludesMaxValue = true)
        {
            var greatThan = excludesMinValue ? GreatThan(value, minValue) : GreatThanOrEquals(value, minValue);
            var lessThan = excludesMaxValue ? LessThan(value, maxValue) : LessThanOrEquals(value, maxValue);
            return greatThan && lessThan;
        }
    }
}