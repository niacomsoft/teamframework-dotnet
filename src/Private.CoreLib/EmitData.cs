// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

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

        /// <summary> 添加可选的附加交互数据。 </summary>
        /// <param name="key"> 扩展交互数据标识名称。 </param>
        /// <param name="data"> 可选的附加交互数据。 </param>
        /// <returns> <see cref="EmitData{TData}" /> 类型的对象实例。 </returns>
        /// <seealso cref="Optional" />
        /// <exception cref="ArgumentException">
        /// 当 <paramref name="key" /> 等于 <see langword="null" /> 或 <see cref="string.Empty" /> 时，将引发此类型的异常。
        /// </exception>
        [SuppressMessage("Design", "Ex0100:Member may throw undocumented exception", Justification = "<挂起>")]
        public virtual EmitData<TData> AddOptional(string key, object data)
        {
            return AssertUtilities.IsEmpty(key, EmptyComparisonOptions.NullOrEmpty)
                ? throw new ArgumentException(SR.Format("ArgumentException_with_method_and_parameter_name", nameof(AddOptional), nameof(key)), nameof(key))
                : this;
        }

        /// <summary> 尝试从 <see cref="Optional" /> 中获取标识名称为 <paramref name="key" /> 的可选的附加交互数据。 </summary>
        /// <param name="key"> 可选的附加交互数据标识名称。 </param>
        /// <param name="data"> 可选的附加交互数据。 </param>
        /// <returns>
        /// 当 <see cref="Optional" /> 中包含标识名称为 <paramref name="key" /> 的数据，且目标数据不为 <see langword="null" /> 值时，返回
        /// <see langword="true" />；否则返回 <see langword="false" />。
        /// </returns>
        /// <seealso cref="Dictionary{TKey, TValue}" />
        /// <seealso cref="Dictionary{TKey, TValue}.ContainsKey(TKey)" />
        /// <seealso cref="IDictionary{TKey, TValue}" />
        /// <seealso cref="IDictionary{TKey, TValue}.ContainsKey(TKey)" />
        /// <seealso cref="Optional" />
        /// <exception cref="ArgumentException">
        /// 当 <paramref name="key" /> 等于 <see langword="null" /> 或 <see cref="string.Empty" /> 时，将引发此类型的异常。
        /// </exception>
        [SuppressMessage("Design", "Ex0100:Member may throw undocumented exception", Justification = "<挂起>")]
        public virtual bool TryGetOptional(string key, out object data)
        {
            return AssertUtilities.IsEmpty(key, EmptyComparisonOptions.NullOrEmpty)
                ? throw new ArgumentException(SR.Format("ArgumentException_with_method_and_parameter_name", nameof(TryGetOptional), nameof(key)), nameof(key))
                : Optional.TryGetValue(key, out data) && AssertUtilities.NotNull(data);
        }
    }
}