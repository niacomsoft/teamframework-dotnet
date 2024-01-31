// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

using Niacomsoft.Diagnostics;

namespace Niacomsoft.TeamFramework.Utilities
{
    /// <summary> 为 <see cref="Nullable{T}" /> 类型提供的扩展方法。 </summary>
    public static class NullableUtilities
    {
        /// <summary> 当 <paramref name="nullable" /> 等于 <see langword="null" /> 时，返回 <paramref name="ifNull" />；否则返回去 <paramref name="nullable" />。 </summary>
        /// <typeparam name="T"> 值类型。 </typeparam>
        /// <param name="nullable"> 可为空的 <typeparamref name="T" /> 类型的值。 </param>
        /// <param name="ifNull"> 当 <paramref name="nullable" /> 等于 <see langword="null" /> 时的返回值。 </param>
        /// <returns> <typeparamref name="T" /> 类型的值。 </returns>
        /// <seealso cref="Nullable{T}" />
        public static T IfNull<T>(T? nullable, T ifNull)
            where T : struct
        {
            return Debugger.IfWriteLine(!nullable.HasValue, $"An empty value of type \"{typeof(T).Name}\".", null, DebuggingLevel.Information)
                ? ifNull
                : nullable.Value;
        }
    }
}