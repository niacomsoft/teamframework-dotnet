// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

namespace Niacomsoft.TeamFramework
{
    /// <summary> 为 <see cref="Nullable{T}" /> 类型提供的扩展方法。 </summary>
    public static class NullableExtensions
    {
        /// <summary> 当 <paramref name="this" /> 为 <see langword="null" /> 值时返回 <paramref name="default" />；否则返回 <paramref name="this" />。 </summary>
        /// <typeparam name="T"> 值类型。 </typeparam>
        /// <param name="this"> 可为空的 <typeparamref name="T" /> 类型的值。 </param>
        /// <param name="default"> 当 <paramref name="this" /> 为 <see langword="null" /> 值时返回的默认值。 </param>
        /// <returns> <typeparamref name="T" /> 类型的值。 </returns>
        public static T IfNull<T>(this T? @this, T @default) where T : struct
        {
            return @this ?? @default;
        }
    }
}