// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

namespace Niacomsoft.TeamFramework.Compatibility
{
    /// <summary> 为 <see cref="DateTime" /> 类型提供的扩展方法。 </summary>
    public static class DateTimeExtensions
    {
        /// <summary> 从 Java <see cref="long" /> 类型时间戳获取 .NET <see cref="DateTime" /> 类型的值。 </summary>
        /// <param name="this"> Java <see cref="long" /> 类型时间戳。 </param>
        /// <returns> <see cref="DateTime" /> 类型的值。 </returns>
        public static DateTime FromJavaTimestampValue(this long @this)
        {
            var javaStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return javaStart.Add(new TimeSpan(@this * 10000));
        }

        /// <summary> 获取兼容 Java 的 <see cref="long" /> 类型的时间戳。 </summary>
        /// <param name="this"> <see cref="DateTime" /> 类型的值。 </param>
        /// <returns> <see cref="long" /> 类型的值。 </returns>
        public static long GetJavaTimestampValue(this DateTime @this)
        {
            var javaStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return (long)(@this - javaStart).TotalMilliseconds;
        }
    }
}