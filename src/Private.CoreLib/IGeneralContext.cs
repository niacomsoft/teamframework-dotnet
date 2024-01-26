// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

namespace Niacomsoft
{
    /// <summary> 定义了通用的上下文的接口。 </summary>
    /// <seealso cref="IDisposable" />
    public interface IGeneralContext : IDisposable
    {
        /// <summary> 上下文数据。 </summary>
        /// <value> 获取 <see cref="IContextualData" /> 类型的对象实例，用于表示上下文数据。 </value>
        /// <seealso cref="IContextualData" />
        IContextualData ContextData { get; }

        /// <summary> 设置标识名称为 <paramref name="key" /> 的上下文数据。 </summary>
        /// <param name="key"> 上下文数据标识名称。 </param>
        /// <param name="value"> 上下文数据。 </param>
        void SetData(string key, object value);

        /// <summary> 获取标识名称为 <paramref name="key" /> 的上下文数据。 </summary>
        /// <param name="key"> 标识名称。 </param>
        /// <returns> 上下文数据。 </returns>
        object GetData(string key);

        /// <summary>
        /// 当上下文中包含标识名称为 <paramref name="key" /> 的上下文数据，且数据不等于 <see langword="null" /> 时，返回 <see langword="true" />；否则返回 <see langword="false" />。
        /// </summary>
        /// <param name="key"> 标识名称。 </param>
        /// <param name="value"> 上下文数据。 </param>
        /// <returns>
        /// 当上下文中包含标识名称为 <paramref name="key" /> 的上下文数据，且数据不等于 <see langword="null" /> 时，返回 <see langword="true" />；否则返回 <see langword="false" />。
        /// </returns>
        bool TryGetData(string key, out object value);

        /// <summary> 上下文数据索引器。 </summary>
        /// <param name="key"> 标识名称。 </param>
        /// <returns> 标识名称为 <paramref name="key" /> 的上下文数据。 </returns>
        object this[string key] { get; set; }
    }
}