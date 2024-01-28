// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft.Objects
{
    /// <summary> 定义了描述名称的接口。 </summary>
    /// <typeparam name="T"> 描述名称的类型。 </typeparam>
    public interface IName<T>
    {
        /// <summary> 名称。 </summary>
        /// <value> 设置或获取 <typeparamref name="T" /> 类型的对象实例或值，用于表示名称。 </value>
        T Name { get; set; }
    }

    /// <summary> 定义了描述名称的接口。 </summary>
    /// <seealso cref="IName{T}" />
    public interface IName : IName<string>
    {
    }
}