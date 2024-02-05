// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft.TeamFramework.Extensions.DependencyInjection
{
    /// <summary> 提供了服务注册标识相关的基本方法。 </summary>
    /// <seealso cref="IServiceRegisterKey" />
    public class ServiceRegisterKey : IServiceRegisterKey
    {
        /// <summary> 初始化 <see cref="ServiceRegisterKey" /> 类的新实例。 </summary>
        public ServiceRegisterKey()
        {
        }

        /// <summary> 初始化 <see cref="ServiceRegisterKey" /> 类的新实例。 </summary>
        /// <param name="key"> 服务注册标识。 </param>
        public ServiceRegisterKey(object key)
        {
            Key = key;
        }

        /// <inheritdoc />
        public virtual object Key { get; set; }
    }

    /// <summary> 提供了 <typeparamref name="TKey" /> 类型服务注册标识相关的基本方法。 </summary>
    /// <typeparam name="TKey"> 服务注册标识类型。 </typeparam>
    /// <seealso cref="IServiceRegisterKey" />
    /// <seealso cref="IServiceRegisterKey{TKey}" />
    /// <seealso cref="ServiceRegisterKey" />
    public class ServiceRegisterKey<TKey> : ServiceRegisterKey, IServiceRegisterKey<TKey>
    {
        /// <summary> 初始化 <see cref="ServiceRegisterKey{TKey}" /> 类的新实例。 </summary>
        public ServiceRegisterKey()
        {
        }

        /// <summary> 初始化 <see cref="ServiceRegisterKey{TKey}" /> 类的新实例。 </summary>
        /// <param name="key"> 服务注册标识。 </param>
        public ServiceRegisterKey(TKey key) : base(key)
        {
            Key = key;
        }

        /// <inheritdoc />
        public virtual new TKey Key
        {
            get
            {
                return (TKey)base.Key;
            }
            set
            {
                base.Key = value;
            }
        }
    }
}