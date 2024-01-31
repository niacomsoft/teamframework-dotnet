// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft.Data
{
    /// <summary> 提供了生成 <typeparamref name="T" /> 类型数据标识相关的 <see langword="abstract" /> 方法。 </summary>
    /// <typeparam name="T"> 数据标识类型。 </typeparam>
    public abstract class IdGenerator<T> : IIdGenerator<T>
    {
        /// <summary> 初始化 <see cref="IdGenerator{T}" /> 类的新实例。 </summary>
        protected IdGenerator()
        {
        }

        /// <inheritdoc />
        public abstract T CreateNew();
    }
}