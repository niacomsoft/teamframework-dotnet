// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using Niacomsoft.Utilities;

namespace Niacomsoft.TeamFramework
{
    /// <summary> 提供了管理单例的 <typeparamref name="TInstance" /> 类型的对象实例相关的方法。 </summary>
    /// <typeparam name="TInstance"> 引用类型。 </typeparam>
    /// <seealso cref="ISingletonInstanceManager{TInstance}" />
    public class SingletonInstanceManager<TInstance> : ISingletonInstanceManager<TInstance>
        where TInstance : class
    {
        /// <summary> 初始化 <see cref="SingletonInstanceManager{TInstance}" /> 类的新实例。 </summary>
        /// <seealso cref="ActivatorUtilities" />
        /// <seealso cref="ActivatorUtilities.CreateInstance{T}(object[])" />
        public SingletonInstanceManager() : this((args) => ActivatorUtilities.CreateInstance<TInstance>(args))
        {
        }

        /// <summary> 初始化 <see cref="SingletonInstanceManager{TInstance}" /> 类的新实例。 </summary>
        /// <param name="constructor">
        /// 构造 <typeparamref name="TInstance" /> 类型的对象实例的方法。
        /// <para> <typeparamref name="TInstance" /> 类型返回值的 <see cref="ParameterizedFunc{TReturn}" /> 类型的方法委托。 </para>
        /// </param>
        public SingletonInstanceManager(ParameterizedFunc<TInstance> constructor)
        {
            Constructor = constructor;
            SynchronizationLock = new object();
            SingletonInstance = default;
        }

        /// <summary> 构造 <typeparamref name="TInstance" /> 类型的对象实例的方法。 </summary>
        /// <value> 设置或获取 <see cref="ParameterizedFunc{TReturn}" /> 类型的对象实例，用于表示构造 <typeparamref name="TInstance" /> 类型的对象实例的方法。 </value>
        /// <seealso cref="ParameterizedFunc{TReturn}" />
        protected virtual ParameterizedFunc<TInstance> Constructor { get; set; }

        /// <summary> 单例的 <typeparamref name="TInstance" /> 类型的对象实例。 </summary>
        /// <value> 设置或获取 <typeparamref name="TInstance" /> 类型的对象实例，用于表示单例的 <typeparamref name="TInstance" /> 类型的对象实例。 </value>
        protected virtual TInstance SingletonInstance { get; set; }

        /// <summary> 单例模式同步锁。 </summary>
        /// <value> 设置或获取 <see cref="object" /> 类型的对象实例，用于表示单例模式同步锁。 </value>
        protected virtual object SynchronizationLock { get; set; }

        /// <inheritdoc />
        public virtual TInstance CreateOrGet(params object[] args)
        {
            if (AssertUtilities.IsNull(SingletonInstance))
            {
                lock (SynchronizationLock)
                {
                    if (AssertUtilities.IsNull(SingletonInstance))
                    {
                        SingletonInstance = Constructor(args);
                    }
                }
            }
            return SingletonInstance;
        }
    }
}