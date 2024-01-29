// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

using Niacomsoft.Utilities;

namespace Niacomsoft
{
    /// <summary> 提供了构建 <typeparamref name="T" /> 类型的对象实例相关的 <see langword="abstract" /> 方法。 </summary>
    /// <typeparam name="T"> 引用类型。 </typeparam>
    /// <seealso cref="IBuilder{T}" />
    public abstract class Builder<T> : IBuilder<T>
        where T : class
    {
        private readonly Hashtable m_bufferedProps = new Hashtable();

        /// <summary> 初始化 <see cref="Builder{T}" /> 类的新实例。 </summary>
        protected Builder()
        {
        }

        /// <summary> 设置指定名称 <paramref name="propName" /> 的属性值。 </summary>
        /// <param name="propName"> 属性名称。 </param>
        /// <param name="propValue"> 属性值。 </param>
        [SuppressMessage("Design", "Ex0100:Member may throw undocumented exception", Justification = "<挂起>")]
        protected virtual void SetProperty(string propName, object propValue)
        {
            InvalidPropertyName(propName);
            m_bufferedProps[propName] = propValue;
        }

        /// <summary>
        /// 尝试获取名称为 <paramref name="propName" /> 的属性值。
        /// <para>
        /// 当不存在名称为 <paramref name="propName" /> 的属性，或者 <paramref name="propValue" /> 等于 <see langword="null" /> 值时，返回
        /// <see langword="false" />；否则返回 <see langword="true" />。
        /// </para>
        /// </summary>
        /// <param name="propName"> 属性名。 </param>
        /// <param name="propValue"> 属性值。 </param>
        /// <returns>
        /// 当不存在名称为 <paramref name="propName" /> 的属性，或者 <paramref name="propValue" /> 等于 <see langword="null" /> 值时，返回
        /// <see langword="false" />；否则返回 <see langword="true" />。
        /// </returns>
        protected virtual bool TryGetProperty(string propName, out object propValue)
        {
            propValue = null;
            return m_bufferedProps.ContainsKey(propName) && AssertUtilities.NotNull(propValue = m_bufferedProps[propName]);
        }

        /// <summary>
        /// 当属性名称 <paramref name="propName" /> 等于 <see langword="null" /> 或 <see cref="string.Empty" /> 时，将引发一个
        /// <see cref="ArgumentException" /> 类型的异常。
        /// </summary>
        /// <param name="propName"> 需要校验的属性名称。 </param>
        protected void InvalidPropertyName(string propName)
        {
            if (AssertUtilities.IsEmpty(propName, EmptyComparisonOptions.NullOrEmpty))
            {
#pragma warning disable Ex0100 // Member may throw undocumented exception
                throw new ArgumentException(SR.Format("ArgumentException_with_parameter_name", nameof(propName)), nameof(propName));
#pragma warning restore Ex0100 // Member may throw undocumented exception
            }
        }

        /// <inheritdoc />
        public abstract T Build();
    }
}