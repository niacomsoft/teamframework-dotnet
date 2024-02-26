// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft
{
    /// <summary> 提供了包含 <typeparamref name="TData" /> 类型交互数据的事件参数方法。 </summary>
    /// <typeparam name="TData"> 事件交换数据类型。 </typeparam>
    /// <seealso cref="GeneralEventArgs" />
    public class GeneralEventArgs<TData> : GeneralEventArgs
    {
        /// <summary> 初始化 <see cref="GeneralEventArgs{TData}" /> 类的新实例。 </summary>
        /// <param name="data"> 事件交互数据。 </param>
        public GeneralEventArgs(TData data)
        {
            Data = data;
        }

        /// <summary> 事件交互数据。 </summary>
        /// <value> 获取 <typeparamref name="TData" /> 类型的对象实例或值，用于表示事件交互数据。 </value>
        public virtual TData Data { get; }
    }
}