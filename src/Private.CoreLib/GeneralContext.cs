// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;
using System.Diagnostics.CodeAnalysis;

using Niacomsoft.Diagnostics;
using Niacomsoft.Utilities;

namespace Niacomsoft
{
    /// <summary> 提供了通用的应用程序上下文相关的基本方法。 </summary>
    /// <seealso cref="IGeneralContext" />
    public partial class GeneralContext : IGeneralContext
    {
        /// <summary> 初始化 <see cref="IContextualData" /> 类的新实例。 </summary>
        /// <param name="data">
        /// 上下文数据。
        /// <para> 实现了 <see cref="IContextualData" /> 类型接口的对象实例。 </para>
        /// </param>
        public GeneralContext(IContextualData data)
        {
            ContextData = data;
        }

        /// <summary> 初始化 <see cref="GeneralContext" /> 类的新实例。 </summary>
        /// <seealso cref="ContextualData" />
        public GeneralContext() : this(new ContextualData())
        {
        }

        /// <inheritdoc />
        public virtual IContextualData ContextData { get; }

        /// <inheritdoc />
        public virtual object this[string key]
        {
            get
            {
                ThrowIfEmptyKey(key);
                return TryGetData(key.Trim(), out object value) ? value : null;
            }
            set
            {
                ThrowIfEmptyKey(key);
                SetData(key.Trim(), value);
            }
        }

        /// <inheritdoc />
        public virtual void Dispose()
        {
            Debugger.WriteLine("The application releases the memory resources occupied by the object instance of the GenericContext type.",
                               null,
                               DebuggingLevel.Information);
        }

        /// <inheritdoc />
        public virtual object GetData(string key)
        {
            ThrowIfEmptyKey(key);
            return TryGetData(key.Trim(), out object value) ? value : null;
        }

        /// <inheritdoc />
        public virtual void SetData(string key, object value)
        {
            ThrowIfEmptyKey(key);
            ContextData.SetValue(key.Trim(), value);
        }

        /// <inheritdoc />
        public virtual bool TryGetData(string key, out object value)
        {
            ThrowIfEmptyKey(key);
            return ContextData.TryGetValue(key.Trim(), out value);
        }

        /// <summary>
        /// 当 <paramref name="key" /> 等于 <see langword="null" />、 <see cref="string.Empty" /> 或全为空白符时，将引发一个
        /// <see cref="ArgumentException" /> 类型的异常。
        /// </summary>
        /// <param name="key"> 需要校验的标识名称。 </param>
        [SuppressMessage("Design", "Ex0100:Member may throw undocumented exception", Justification = "<挂起>")]
        protected virtual void ThrowIfEmptyKey(string key)
        {
            if (Debugger.IfWriteLine(AssertUtilities.IsEmpty(key, EmptyComparisonOptions.NullOrWhitespace), null, "Invalid contextual data key.", level: DebuggingLevel.Warning))
            {
                throw new ArgumentException(SR.Format("ArgumentException_with_parameter_name", nameof(key)), nameof(key));
            }
        }
    }
}