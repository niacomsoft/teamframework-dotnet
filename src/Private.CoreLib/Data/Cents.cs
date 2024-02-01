// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;
using System.Diagnostics.CodeAnalysis;

using Niacomsoft.Utilities;

namespace Niacomsoft.Data
{
    /// <summary> 提供了货币单位 “分” 相关的方法。 </summary>
    public readonly struct Cents
    {
        /// <summary> 初始化 <see cref="Cents" /> 的新实例。 </summary>
        /// <param name="value"> 以 “分” 为计数单位的货币值。 </param>
        public Cents(long value)
        {
            Value = value;
        }

        /// <summary> 初始化 <see cref="Cents" /> 的新实例。 </summary>
        /// <param name="yuan"> 以 “元” 为计数单位的货币值。 </param>
        public Cents(int yuan) : this((long)(yuan * 100))
        {
        }

        /// <summary> 初始化 <see cref="Cents" /> 的新实例。 </summary>
        /// <param name="amount"> 货币金额。 </param>
        public Cents(double amount) : this((long)(amount * 100))
        {
        }

        /// <summary> 以 “分” 为计数单位的货币值。 </summary>
        /// <value> 获取一个 <see cref="long" /> 类型值，用于表示以 “分” 为计数单位的货币值。 </value>
        public long Value { get; }

        /// <summary> 将 “分” 转换成以 “元” 为计数单位的货币值。 </summary>
        /// <returns> <see cref="double" /> 类型的值。 </returns>
        public double ToAmount()
        {
            return (double)(Value / 100.00D);
        }

        /// <summary> 获取以 “元” 为计数单位的货币字符串。并保留 2 位小数。 </summary>
        /// <returns> 以 “元” 为计数单位的货币字符串。 </returns>
        /// <exception cref="System.FormatException"> 当调用 <see cref="double.ToString(string)" /> 方法时，可能引发此类型的异常。 </exception>
        [SuppressMessage("Design", "Ex0200:Member is documented as throwing exception not documented on member in base or interface type", Justification = "<挂起>")]
        public override string ToString()
        {
            return ToAmount().ToString("F2");
        }

        /// <summary> 获取指定折扣比例 <paramref name="rate" /> 的折扣货币值。 </summary>
        /// <param name="rate"> 折扣率。必须为 <c> 0 ~ 100 </c> 之间的值。 </param>
        /// <returns> 折扣后的货币值。 </returns>
        /// <exception cref="ArgumentException"> 当 <paramref name="rate" /> 小于 0 或大于 100 时，将引发此类型的异常。 </exception>
        public Cents Discount(int rate)
        {
            if (!AssertUtilities.Between(rate, 0, 100, false, false))
            {
#pragma warning disable Ex0100 // Member may throw undocumented exception
                throw new ArgumentException(SR.Format("ArgumentException_with_method_and_parameter_name", nameof(Discount), nameof(rate)), nameof(rate));
#pragma warning restore Ex0100 // Member may throw undocumented exception
            }

            return new Cents(Value * rate / 100);
        }
    }
}