// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;
using System.Collections;

namespace Niacomsoft.Utilities
{
    public static partial class AssertUtilities
    {
        /// <summary>
        /// 当 <paramref name="array" /> 为 <see langword="null" /> 值或 <see cref="Array.LongLength" /> 等于 0 时，返回
        /// <see langword="false" />；否则返回 <see langword="true" />。
        /// </summary>
        /// <param name="array">
        /// 需要验证的数组。
        /// <para> 派生自 <see cref="Array" /> 的类型。 </para>
        /// </param>
        /// <returns>
        /// 当 <paramref name="array" /> 为 <see langword="null" /> 值或 <see cref="Array.LongLength" /> 等于 0 时，返回
        /// <see langword="false" />；否则返回 <see langword="true" />。
        /// </returns>
        /// <seealso cref="Array" />
        public static bool HasItems(Array array)
            => NotNull(array) && GreatThan(array.LongLength);

        /// <summary>
        /// 当集合 <paramref name="collection" /> 为 <see langword="null" /> 值或 <see cref="Array.LongLength" /> 等于 0 时，返回
        /// <see langword="false" />；否则返回 <see langword="true" />。
        /// </summary>
        /// <param name="collection">
        /// 需要验证的集合。
        /// <para> 实现了 <see cref="ICollection" /> 接口的类型。 </para>
        /// </param>
        /// <returns>
        /// 当集合 <paramref name="collection" /> 为 <see langword="null" /> 值或 <see cref="Array.LongLength" /> 等于 0 时，返回
        /// <see langword="false" />；否则返回 <see langword="true" />。
        /// </returns>
        /// <seealso cref="ICollection" />
        public static bool HasItems(ICollection collection)
            => NotNull(collection) && GreatThan(collection.Count);
    }
}