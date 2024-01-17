// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft.Security
{
    /// <summary> 定义了创建随机数算法的工厂方法接口。 </summary>
    /// <seealso cref="IRandomAlgorithms" />
    public interface IRandomAlgorithmsFactory
    {
        /// <summary> 创建随机数算法。 </summary>
        /// <param name="maxValue"> 最大的种子值。 </param>
        /// <returns>
        /// 随机数算法。
        /// <para> 实现了 <see cref="IRandomAlgorithms" /> 类型接口的对象实例。 </para>
        /// </returns>
        /// <seealso cref="IRandomAlgorithms" />
        IRandomAlgorithms Create(int maxValue);

        /// <summary> 创建随机数算法。 </summary>
        /// <returns>
        /// 随机数算法。
        /// <para> 实现了 <see cref="IRandomAlgorithms" /> 类型接口的对象实例。 </para>
        /// </returns>
        /// <seealso cref="IRandomAlgorithms" />
        IRandomAlgorithms Create();
    }
}