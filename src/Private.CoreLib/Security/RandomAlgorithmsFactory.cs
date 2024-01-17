// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft.Security
{
    /// <summary> 提供了创建随机数算法相关的工厂方法。 </summary>
    /// <seealso cref="IRandomAlgorithms" />
    /// <seealso cref="IRandomAlgorithmsFactory" />
    /// <seealso cref="RandomAlgorithms" />
    public class RandomAlgorithmsFactory : IRandomAlgorithmsFactory
    {
        /// <inheritdoc />
        public virtual IRandomAlgorithms Create(int maxValue)
            => new RandomAlgorithms(maxValue);

        /// <inheritdoc />
        public virtual IRandomAlgorithms Create()
            => new RandomAlgorithms();
    }
}