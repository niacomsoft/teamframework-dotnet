// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft.Objects
{
    /// <summary> 定义了描述是否启用状态的接口。 </summary>
    /// <typeparam name="T"> 描述是否启用状态的类型。 </typeparam>
    public interface IEnabledState<T>
    {
        /// <summary> 是否启用。 </summary>
        /// <value> 设置或获取 <typeparamref name="T" /> 类型的对象实例或值，用于表示是否启用。 </value>
        T Enabled { get; set; }
    }
}