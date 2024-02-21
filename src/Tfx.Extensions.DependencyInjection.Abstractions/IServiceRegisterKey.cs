// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft.TeamFramework.Extensions.DependencyInjection
{
    /// <summary> 定义了服务注册标识的接口。 </summary>
    public interface IServiceRegisterKey
    {
        /// <summary> 服务注册标识。 </summary>
        /// <value> 设置或获取 <see cref="object" /> 类型的对象实例或值，用于表示服务注册标识。 </value>
        object Key { get; set; }
    }

    /// <summary> 定义了 <typeparamref name="TKey" /> 类型的服务注册标识的接口。 </summary>
    /// <typeparam name="TKey"> 服务注册标识类型。 </typeparam>
    /// <seealso cref="IServiceRegisterKey" />
    public interface IServiceRegisterKey<TKey> : IServiceRegisterKey
    {
        /// <summary> 服务注册标识。 </summary>
        /// <value> 设置或获取 <typeparamref name="TKey" /> 类型的对象实例或值，用于表示服务注册标识。 </value>
        /// <seealso cref="IServiceRegisterKey.Key" />
        new TKey Key { get; set; }
    }
}