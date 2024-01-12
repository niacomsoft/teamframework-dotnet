// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System.Collections.Generic;

using Niacomsoft.Utilities;

namespace Niacomsoft
{
    /// <summary> 提供了用于事件交互数据相关的方法。 </summary>
    /// <typeparam name="TData"> 交互数据类型。 </typeparam>
    public class EmitData<TData>
    {
        /// <summary> 初始化 <see cref="EmitData{TData}" /> 类的新实例。 </summary>
        public EmitData()
        {
            Optional = new Dictionary<string, object>();
        }

        /// <summary> 初始化 <see cref="EmitData{TData}" /> 类的新实例。 </summary>
        /// <param name="required"> 主要的交互数据。 </param>
        public EmitData(TData required) : this()
        {
            Required = required;
        }

        /// <summary> 初始化 <see cref="EmitData{TData}" /> 类的新实例。 </summary>
        /// <param name="required"> 主要的交互数据。 </param>
        /// <param name="optional">
        /// 可选的附加交互数据。
        /// <para> 实现了 <see cref="IDictionary{TKey, TValue}" /> 类型接口的对象实例。 </para>
        /// </param>
        public EmitData(TData required, IDictionary<string, object> optional) : this(required)
        {
            if (AssertUtilities.NotNull(optional))
            {
                Optional = optional;
            }
        }

        /// <summary> 可选的附加交互数据。 </summary>
        /// <value> 获取 <see cref="IDictionary{TKey, TValue}" /> 类型的对象实例，用于表示可选的附加交互数据。 </value>
        /// <seealso cref="Dictionary{TKey, TValue}" />
        /// <seealso cref="IDictionary{TKey, TValue}" />
        public virtual IDictionary<string, object> Optional { get; }

        /// <summary> 主要的交互数据。 </summary>
        /// <value> 设置或获取 <typeparamref name="TData" /> 类型的对象实例或值，用于表示主要的交互数据。 </value>
        public virtual TData Required { get; set; }
    }
}