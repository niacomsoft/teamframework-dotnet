// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft
{
    /// <summary> 定义了数据标识的接口。 </summary>
    /// <typeparam name="T"> 数据标识类型。 </typeparam>
    public interface IId<T>
    {
        /// <summary> 数据标识。 </summary>
        /// <value> 设置或获取 <typeparamref name="T" /> 类型的对象实例或值，用于表示数据标识。 </value>
        T Id { get; set; }
    }
}