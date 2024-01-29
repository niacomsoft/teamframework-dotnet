// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft
{
    /// <summary> 定义了服务标识名称的接口。 </summary>
    public interface IKeyOfService
    {
        /// <summary> 服务标识名称。 </summary>
        /// <value> 设置或获取 <see cref="object" /> 类型的对象实例或值，用于表示服务标识名称。 </value>
        object ServiceKey { get; set; }
    }

    /// <summary> 定义了 <typeparamref name="TKey" /> 类型的服务标识名称接口。 </summary>
    /// <typeparam name="TKey"> 服务标识名称类型。 </typeparam>
    /// <seealso cref="IKeyOfService" />
    public interface IKeyOfService<TKey> : IKeyOfService
    {
        /// <summary> 服务标识名称。 </summary>
        /// <value> 设置或获取 <typeparamref name="TKey" /> 类型的对象实例或值，用于表示服务标识名称。 </value>
        /// <seealso cref="IKeyOfService.ServiceKey" />
        new TKey ServiceKey { get; set; }
    }
}