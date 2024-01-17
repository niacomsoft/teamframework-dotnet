// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;
using System.Diagnostics.CodeAnalysis;

using Niacomsoft.Utilities;

namespace Niacomsoft.Security
{
    /// <summary> 提供了随机数算法相关的方法。 </summary>
    /// <seealso cref="IRandomAlgorithms" />
    public class RandomAlgorithms : IRandomAlgorithms
    {
        /// <summary> 默认的最小种子值。 </summary>
        private const int MinValue = 0x20;

        /// <summary> 初始化 <see cref="RandomAlgorithms" /> 类的新实例。 </summary>
        /// <param name="maxValue"> 最大种子值。 </param>
        public RandomAlgorithms(int maxValue)
        {
            Random = new Random(MaxValue = AssertUtilities.LessThan(maxValue, MinValue) ? MinValue : maxValue);
            Seeds = new int[MaxValue];
            InitializeSeedArray();
        }

        /// <summary> 初始化 <see cref="RandomAlgorithms" /> 类的新实例。 </summary>
        public RandomAlgorithms() : this(MinValue)
        {
        }

        /// <summary> 内部的随机算法实现。 </summary>
        /// <value> 获取 <see cref="System.Random" /> 类型的对象实例，用于表示内部的随机算法实现。 </value>
        /// <seealso cref="System.Random" />
        protected virtual Random Random { get; }

        /// <summary> 随机算法种子值数组。 </summary>
        /// <value> 获取一个 <see cref="int" /> 类型值数组，用于表示随机算法种子值。 </value>
        protected virtual int[] Seeds { get; }

        /// <inheritdoc />
        public virtual int MaxValue { get; }

        /// <inheritdoc />
        public virtual int GetValue()
        {
            return Seeds[Random.Next(MaxValue)];
        }

        /// <inheritdoc />
        /// <exception cref="ArgumentException"> 当 <paramref name="count" /> 小于等于 0 时，将引发此类型的异常。 </exception>
        [SuppressMessage("Design", "Ex0200:Member is documented as throwing exception not documented on member in base or interface type", Justification = "<挂起>")]
        public virtual int[] GetValues(int count = 1)
        {
            if (AssertUtilities.LessThan(count, 1))
            {
#pragma warning disable Ex0100 // Member may throw undocumented exception
                throw new ArgumentException(SR.Format("ArgumentException_with_method_and_parameter_name", nameof(GetValues), nameof(count)), nameof(count));
#pragma warning restore Ex0100 // Member may throw undocumented exception
            }
            var values = new int[count];
            for (var i = 0; i < count; i++)
            {
                values[i] = GetValue();
            }
            return values;
        }

        /// <inheritdoc />
        public virtual IRandomAlgorithms Shuffle()
        {
            ShuffleOnce();
            return this;
        }

        /// <summary> 初始化随机算法种子数组。 </summary>
        protected virtual void InitializeSeedArray()
        {
            for (var i = 0; i < MaxValue; i++)
            {
                Seeds[i] = i;
            }
            ShuffleOnce();
        }

        /// <summary> 打乱一次顺序。 </summary>
        [SuppressMessage("Style", "IDE0180:使用元组交换值", Justification = "<挂起>")]
        protected virtual void ShuffleOnce()
        {
            for (var i = 0; i < MaxValue; i++)
            {
                var randomIdx = Random.Next(MaxValue);
                var bufferedValue = Seeds[randomIdx];
                Seeds[randomIdx] = Seeds[i];
                Seeds[i] = bufferedValue;
            }
        }
    }
}