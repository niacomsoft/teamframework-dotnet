// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

namespace Niacomsoft.Utilities
{
    public static partial class AssertUtilities
    {
        /// <summary> 当 <paramref name="time1" /> 在 <paramref name="time2" /> 之前，返回 <see langword="true" />；否则返回 <see langword="false" />。 </summary>
        /// <param name="time1"> <see cref="DateTime" /> 类型的值。 </param>
        /// <param name="time2"> <see cref="DateTime" /> 类型的值。 </param>
        /// <returns> 当 <paramref name="time1" /> 在 <paramref name="time2" /> 之前，返回 <see langword="true" />；否则返回 <see langword="false" />。 </returns>
        /// <seealso cref="LessThanOrEquals(double, double)" />
        public static bool IsBefore(DateTime time1, DateTime time2)
            => LessThanOrEquals((time1 - time2).TotalMilliseconds);

        /// <summary> 当 <paramref name="time1" /> 在 <paramref name="time2" /> 之后，返回 <see langword="true" />；否则返回 <see langword="false" />。 </summary>
        /// <param name="time1"> <see cref="DateTime" /> 类型的值。 </param>
        /// <param name="time2"> <see cref="DateTime" /> 类型的值。 </param>
        /// <returns> 当 <paramref name="time1" /> 在 <paramref name="time2" /> 之后，返回 <see langword="true" />；否则返回 <see langword="false" />。 </returns>
        /// <seealso cref="GreatThanOrEquals(double, double)" />
        public static bool IsAfter(DateTime time1, DateTime time2)
            => GreatThanOrEquals((time1 - time2).TotalMilliseconds);
    }
}