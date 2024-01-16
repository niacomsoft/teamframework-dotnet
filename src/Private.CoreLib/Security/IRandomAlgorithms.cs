// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft.Security
{
    /// <summary> 定义了随机算法的接口。 </summary>
    public interface IRandomAlgorithms
    {
        /// <summary> 最大的随机数种子值。 </summary>
        /// <value> 获取一个 <see cref="int" /> 类型值，用于表示最大的随机数种子值。 </value>
        int MaxValue { get; }

        /// <summary> 获取下一个随机值。 </summary>
        /// <returns> <see cref="int" /> 类型的值。 </returns>
        int Next();
    }
}