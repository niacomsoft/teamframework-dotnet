// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft
{
    /// <summary> 定义了处理事件的委托。 </summary>
    /// <param name="sender"> 触发事件的对象实例。 </param>
    /// <param name="e">
    /// 通用事件参数。
    /// <para> <see cref="GeneralEventArgs" /> 类型的对象实例。 </para>
    /// </param>
    /// <seealso cref="GeneralEventArgs" />
    public delegate void GeneralEventHandler(object sender, GeneralEventArgs e);
}