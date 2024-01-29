// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;
using System.Diagnostics.CodeAnalysis;

using Niacomsoft.Utilities;

namespace Niacomsoft.TeamFramework
{
    /// <summary> 为 <see cref="DateTime" /> 类型提供的扩展方法。 </summary>
    public static class DateTimeExtensions
    {
        /// <summary> 当日期时间 <paramref name="this" /> 值转换成等效的描述文本。 </summary>
        /// <param name="this"> <see cref="DateTime" /> 类型的值。 </param>
        /// <returns> 描述文本。 </returns>
        /// <exception cref="FormatException"> 当调用 <see cref="DateTime.ToString(string)" /> 方法时，可能引发此类型的异常。 </exception>
        public static string ToDescription(this DateTime @this)
        {
            var now = DateTime.Now;
            if (AssertUtilities.IsAfter(@this, now))
            {
                return @this.ToString(SR.GetString("DateTime_GetDescription_default"));
            }
            else
            {
                var intervals = now - @this;
                if (AssertUtilities.LessThanOrEquals(intervals.TotalSeconds, 60))
                {
                    return SR.GetString("DateTime_GetDescription_just_now");
                }
                else if (AssertUtilities.LessThanOrEquals(intervals.TotalMinutes, 60))
                {
                    return SR.Format("DateTime_GetDescription_minutes", (int)intervals.TotalMinutes);
                }
                else if (AssertUtilities.LessThanOrEquals(intervals.TotalHours, 24))
                {
                    return SR.Format("DateTime_GetDescription_hours", (int)intervals.TotalHours);
                }
                else if (AssertUtilities.LessThanOrEquals(intervals.TotalDays, 180))
                {
                    return SR.Format("DateTime_GetDescription_days", (int)intervals.TotalDays);
                }
                else if (AssertUtilities.Equals(now.Year, @this.Year))
                {
                    return @this.ToString(SR.GetString("DateTime_GetDescription_same_year"));
                }

                return @this.ToString(SR.GetString("DateTime_GetDescription_default"));
            }
        }

        /// <summary> 当日期时间 <paramref name="this" /> 值转换成等效的描述文本。 </summary>
        /// <param name="this"> <see cref="DateTime" /> 类型的值。 </param>
        /// <param name="ifNull"> 当 <c> this.HasValue </c> 为 <see langword="false" /> 时，需要返回的描述。 </param>
        /// <returns> 描述文本。 </returns>
        [SuppressMessage("Design", "Ex0100:Member may throw undocumented exception", Justification = "<挂起>")]
        public static string ToDescription(this DateTime? @this, string ifNull = "-")
        {
            return @this.HasValue ? @this.Value.ToDescription() : ifNull;
        }
    }
}