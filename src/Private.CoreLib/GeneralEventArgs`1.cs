// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft
{
    /// <summary> 提供了包含 <typeparamref name="TData" /> 类型交互数据的事件参数方法。 </summary>
    /// <typeparam name="TData"> 事件交换数据类型。 </typeparam>
    /// <seealso cref="EmitData{TData}" />
    /// <seealso cref="GeneralEventArgs" />
    public class GeneralEventArgs<TData> : GeneralEventArgs
    {
        /// <summary> 初始化 <see cref="GeneralEventArgs{TData}" /> 类的新实例。 </summary>
        /// <param name="required"> 事件交互所需的 <typeparamref name="TData" /> 类型的值。 </param>
        public GeneralEventArgs(TData required) : this(new EmitData<TData>(required))
        {
        }

        /// <summary> 初始化 <see cref="GeneralEventArgs{TData}" /> 类的新实例。 </summary>
        /// <param name="data">
        /// 事件交互数据。
        /// <para> <see cref="EmitData{TData}" /> 类型的对象实例。 </para>
        /// </param>
        public GeneralEventArgs(EmitData<TData> data)
        {
            Data = data;
        }

        /// <summary> 事件交互数据。 </summary>
        /// <value> 获取 <see cref="EmitData{TData}" /> 类型的对象实例，用于表示事件交互数据。 </value>
        /// <seealso cref="EmitData{TData}" />
        public virtual EmitData<TData> Data { get; }
    }
}