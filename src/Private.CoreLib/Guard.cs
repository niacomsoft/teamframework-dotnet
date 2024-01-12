// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

using Niacomsoft.Utilities;

namespace Niacomsoft
{
    /// <summary> 提供了运行时异常相关的方法。 </summary>
    public static class Guard
    {
        /// <summary>
        /// 当 <paramref name="argValue" /> 等于 <see langword="null" /> 时，将引发一个 <see cref="ArgumentNullException" /> 类型的异常。
        /// </summary>
        /// <param name="argValue"> 需要校验的参数值。 </param>
        /// <param name="argName"> 参数名称。 </param>
        /// <param name="methodName"> 方法名称。 </param>
        /// <exception cref="ArgumentNullException"> </exception>
        public static void ArgumentNull(object argValue, string argName = null, string methodName = null)
        {
            if (AssertUtilities.IsNull(argValue))
            {
                if (AssertUtilities.IsEmpty(argName, EmptyComparisonOptions.NullOrWhitespace))
                {
                    throw new ArgumentNullException(nameof(argValue), SR.GetString("ArgumentNullException_default_message"));
                }
                else if (AssertUtilities.IsEmpty(methodName, EmptyComparisonOptions.NullOrWhitespace))
                {
#pragma warning disable Ex0100 // Member may throw undocumented exception
                    throw new ArgumentNullException(nameof(argValue), SR.Format("ArgumentNullException_with_method_and_parameter_name", methodName, argName));
#pragma warning restore Ex0100 // Member may throw undocumented exception
                }
                else
                {
#pragma warning disable Ex0100 // Member may throw undocumented exception
                    throw new ArgumentNullException(nameof(argValue), SR.Format("ArgumentNullException_with_parameter_name", argName));
#pragma warning restore Ex0100 // Member may throw undocumented exception
                }
            }
        }
    }
}