// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft
{
    /// <summary> 提供了服务标识名称相关的基本方法。 </summary>
    /// <seealso cref="IKeyOfService" />
    public class KeyOfService : IKeyOfService
    {
        /// <summary> 初始化 <see cref="KeyOfService" /> 类的新实例。 </summary>
        public KeyOfService()
        {
        }

        /// <summary> 初始化 <see cref="KeyOfService" /> 类的新实例。 </summary>
        /// <param name="serviceKey"> 服务标识名称。 </param>
        public KeyOfService(object serviceKey) : this()
        {
            ServiceKey = serviceKey;
        }

        /// <inheritdoc />
        public virtual object ServiceKey { get; set; }
    }

    /// <summary> 提供了 <typeparamref name="TKey" /> 类型服务标识名称相关的方法。 </summary>
    /// <typeparam name="TKey"> 服务标识名称。 </typeparam>
    /// <seealso cref="IKeyOfService{TKey}" />
    /// <seealso cref="KeyOfService" />
    public class KeyOfService<TKey> : KeyOfService, IKeyOfService<TKey>
    {
        /// <summary> 初始化 <see cref="KeyOfService{TKey}" /> 类的新实例。 </summary>
        public KeyOfService()
        {
        }

        /// <summary> 初始化 <see cref="KeyOfService{TKey}" /> 类的新实例。 </summary>
        /// <param name="serviceKey"> <typeparamref name="TKey" /> 类型的服务标识名称。 </param>
        public KeyOfService(TKey serviceKey) : base(serviceKey)
        {
        }

        /// <inheritdoc />
        public new TKey ServiceKey
        {
            get { return (TKey)base.ServiceKey; }
            set { base.ServiceKey = value; }
        }
    }
}