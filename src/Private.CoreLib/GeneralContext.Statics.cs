// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft
{
    public partial class GeneralContext
    {
        /// <summary> 创建一个新的上下文。 </summary>
        /// <param name="data">
        /// 初始化的上下文数据。
        /// <para> 实现了 <see cref="IContextualData" /> 类型接口的对象实例。 </para>
        /// </param>
        /// <returns>
        /// 通用上下文。
        /// <para> 实现了 <see cref="IGeneralContext" /> 类型接口的对象实例。 </para>
        /// </returns>
        /// <seealso cref="GeneralContext" />
        /// <seealso cref="IContextualData" />
        /// <seealso cref="IGeneralContext" />
        public static IGeneralContext CreateContext(IContextualData data)
            => new GeneralContext(data ?? new ContextualData());

        /// <summary> 创建一个新的上下文。 </summary>
        /// <returns>
        /// 通用上下文。
        /// <para> 实现了 <see cref="IGeneralContext" /> 类型接口的对象实例。 </para>
        /// </returns>
        /// <seealso cref="GeneralContext" />
        /// <seealso cref="IContextualData" />
        /// <seealso cref="IGeneralContext" />
        public static IGeneralContext CreateContext()
            => new GeneralContext();
    }
}