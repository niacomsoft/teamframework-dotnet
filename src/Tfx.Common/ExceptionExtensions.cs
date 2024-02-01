// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

using Niacomsoft.Utilities;

namespace Niacomsoft.TeamFramework
{
    /// <summary> 为 <see cref="Exception" /> 类型提供的扩展方法。 </summary>
    public static class ExceptionExtensions
    {
        /// <summary>
        /// 获取运行时异常的摘要描述信息。
        /// <para> 此摘要信息可以用于打印到日志系统中。 </para>
        /// </summary>
        /// <param name="this"> <see cref="Exception" /> 类型的对象实例。 </param>
        /// <param name="cause"> 引发此次异常的原因。如果为 <see langword="null" />、 <see cref="string.Empty" /> 或空格符时，将默认使用通用话术作为原因。 </param>
        /// <returns> 异常摘要信息。 </returns>
        /// <seealso cref="Exception" />
        [SuppressMessage("Design", "Ex0100:Member may throw undocumented exception", Justification = "<挂起>")]
        public static string GetSummary(this Exception @this, string cause = null)
        {
            if (AssertUtilities.IsEmpty(cause, EmptyComparisonOptions.NullOrWhitespace))
            {
                var causeBuilder = new StringBuilder();
                if (AssertUtilities.NotNull(@this.TargetSite.DeclaringType))
                {
                    causeBuilder.Append($"{@this.TargetSite.DeclaringType.FullName}::");
                }

                causeBuilder.Append(@this.TargetSite.Name);

                return SR.Format("Exception_get_summary_without_reason", causeBuilder.ToString(), @this.GetType().FullName, @this.Message);
            }
            return SR.Format("Exception_get_summary_with_reason", cause.TrimEnd('。', '.').Trim(), @this.GetType().FullName, @this.Message);
        }
    }
}