// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft
{
    /// <summary> 定义了构建 <typeparamref name="T" /> 类型的对象实例的接口。 </summary>
    /// <typeparam name="T"> 引用类型。 </typeparam>
    public interface IBuilder<T>
        where T : class
    {
        /// <summary> 构建 <typeparamref name="T" /> 类型的对象实例。 </summary>
        /// <returns> <typeparamref name="T" /> 类型的对象实例。 </returns>
        T Build();
    }
}