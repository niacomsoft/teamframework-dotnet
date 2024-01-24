// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

using Niacomsoft.Utilities;

namespace Niacomsoft
{
    /// <summary> 提供了上下文数据相关的方法。 </summary>
    /// <seealso cref="IContextualData" />
    public class ContextualData : IContextualData
    {
        /// <summary> 初始化 <see cref="ContextualData" /> 类的新实例。 </summary>
        public ContextualData()
        {
            Buffer = new Hashtable();
        }

        /// <summary> 初始化 <see cref="ContextualData" /> 类的新实例。 </summary>
        /// <param name="initialValues"> 初始化数据。 </param>
        public ContextualData(IDictionary<string, object> initialValues) : this()
        {
            if (AssertUtilities.NotNull(initialValues))
            {
                foreach (var item in initialValues)
                {
#pragma warning disable Ex0100 // Member may throw undocumented exception
                    Buffer[item.Key] = item.Value;
#pragma warning restore Ex0100 // Member may throw undocumented exception
                }
            }
        }

        /// <summary> 上下文数据缓冲区。 </summary>
        /// <value> 获取 <see cref="Hashtable" /> 类型的对象实例，用于表示上下文数据缓冲区。 </value>
        /// <seealso cref="Hashtable" />
        protected virtual Hashtable Buffer { get; }

        /// <inheritdoc />
        public void SetValue(string key, object value)
        {
            InvalidKey(key);
#pragma warning disable Ex0100 // Member may throw undocumented exception
            Buffer[key] = value;
#pragma warning restore Ex0100 // Member may throw undocumented exception
        }

        /// <inheritdoc />
        public bool TryGetValue(string key, out object value)
        {
            value = null;
            return Buffer.ContainsKey(key) && AssertUtilities.NotNull(value = Buffer[key]);
        }

        /// <summary>
        /// 当上下文数据名称 <paramref name="key" /> 等于 <see langword="null" />、 <see cref="string.Empty" /> 或空白符时，将引发一个
        /// <see cref="ArgumentException" /> 类型的异常。
        /// </summary>
        /// <param name="key"> 需要校验的上下文数据名称。 </param>
        [SuppressMessage("Design", "Ex0100:Member may throw undocumented exception", Justification = "<挂起>")]
        protected virtual void InvalidKey(string key)
        {
            if (AssertUtilities.IsEmpty(key, EmptyComparisonOptions.NullOrWhitespace))
            {
                throw new ArgumentException(SR.Format("ArgumentException_with_parameter_name", nameof(key)), nameof(key));
            }
        }
    }
}