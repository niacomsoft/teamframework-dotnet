// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft.Data
{
    /// <summary> 定义了生成数据标识的接口。 </summary>
    /// <typeparam name="T"> 数据标识类型。 </typeparam>
    public interface IIdGenerator<T>
    {
        /// <summary> 创建一个新的 <typeparamref name="T" /> 类型数据标识。 </summary>
        /// <returns> 新的 <typeparamref name="T" /> 类型数据标识。 </returns>
        T CreateNew();
    }
}