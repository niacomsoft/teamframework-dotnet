// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft.TeamFramework.Extensions.Serialization
{
    /// <summary> 定义了创建数据契约序列化程序 <see cref="ISerializer" /> 的工厂方法接口。 </summary>
    public interface ISerializerFactory
    {
        /// <summary> 创建数据契约序列化程序。 </summary>
        /// <returns> 实现了 <see cref="ISerializer" /> 类型接口的对象实例。 </returns>
        /// <seealso cref="ISerializer" />
        ISerializer CreateSerializer();
    }
}