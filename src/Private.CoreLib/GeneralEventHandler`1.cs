// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft
{
    /// <summary> 定义了处理事件的委托。 </summary>
    /// <typeparam name="TEventArgs"> 派生自 <see cref="GeneralEventArgs" /> 的类型。 </typeparam>
    /// <param name="sender"> 触发事件的对象实例。 </param>
    /// <param name="e">
    /// 通用事件参数。
    /// <para> <typeparamref name="TEventArgs" /> 类型的对象实例。 </para>
    /// </param>
    /// <seealso cref="GeneralEventArgs" />
    /// <seealso cref="GeneralEventArgs{TData}" />
    public delegate void GeneralEventHandler<TEventArgs>(object sender, TEventArgs e) where TEventArgs : GeneralEventArgs;
}