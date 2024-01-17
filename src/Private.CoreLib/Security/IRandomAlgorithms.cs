// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft.Security
{
    /// <summary> 定义了随机算法的接口。 </summary>
    public interface IRandomAlgorithms
    {
        /// <summary> 最大的随机数种子值。 </summary>
        /// <value> 获取一个 <see cref="int" /> 类型值，用于表示最大的随机数种子值。 </value>
        int MaxValue { get; }

        /// <summary> 打乱一次顺序。 </summary>
        /// <returns> 实现了 <see cref="IRandomAlgorithms" /> 类型接口的对象实例。 </returns>
        IRandomAlgorithms Shuffle();

        /// <summary> 随机获取一个值。 </summary>
        /// <returns> <see cref="int" /> 类型的值。 </returns>
        int GetValue();

        /// <summary> 获取指定个数 <paramref name="count" /> 的随机值数组。 </summary>
        /// <param name="count"> 指定的个数。 </param>
        /// <returns> 长度为 <paramref name="count" /> 的随机值数组。 </returns>
        int[] GetValues(int count = 1);
    }
}