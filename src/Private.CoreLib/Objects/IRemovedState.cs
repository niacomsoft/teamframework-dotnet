// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft.Objects
{
    /// <summary> 定义了描述是否被逻辑删除状态的接口。 </summary>
    /// <typeparam name="T"> 描述是否被逻辑删除状态的类型。 </typeparam>
    public interface IRemovedState<T>
    {
        /// <summary> 是否已经被逻辑删除。 </summary>
        /// <value> 设置或获取 <typeparamref name="T" /> 类型的对象实例或值，用于表示是否已经被逻辑删除。 </value>
        T HasRemoved { get; set; }
    }

    /// <summary> 定义了描述是否被逻辑删除状态的接口。 </summary>
    /// <seealso cref="IRemovedState{T}" />
    public interface IRemovedState : IRemovedState<bool> { }
}