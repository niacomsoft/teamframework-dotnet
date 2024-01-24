// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System.Collections.Generic;

using Niacomsoft.Diagnostics;
using Niacomsoft.Utilities;

namespace Niacomsoft
{
    /// <summary> 提供了观测属性值变更相关的方法。 </summary>
    /// <seealso cref="IObservablePropertyValue" />
    public partial class ObservablePropertyValue : IObservablePropertyValue
    {
        /// <summary> 初始化 <see cref="ObservablePropertyValue" /> 类的新实例。 </summary>
        public ObservablePropertyValue()
        {
            BufferedProperties = new Dictionary<string, object>();
            ChangedProperties = new Dictionary<string, object>();
        }

        /// <inheritdoc />
        public virtual event GeneralEventHandler<IDictionary<string, object>> PropertiesChanged;

        /// <inheritdoc />
        public virtual event GeneralEventHandler<KeyValuePair<string, object>> PropertyChanged;

        /// <summary> 缓存的属性字典集合。 </summary>
        /// <value> 获取 <see cref="IDictionary{TKey, TValue}" /> 类型的对象实例，用于表示缓存的属性字典集合。 </value>
        /// <seealso cref="IDictionary{TKey, TValue}" />
        protected virtual IDictionary<string, object> BufferedProperties { get; }

        /// <summary> 当前变更的属性字典集合。 </summary>
        /// <value> 获取 <see cref="IDictionary{TKey, TValue}" /> 类型的对象实例，用于表示当前变更的属性字典集合。 </value>
        /// <seealso cref="IDictionary{TKey, TValue}" />
        protected virtual IDictionary<string, object> ChangedProperties { get; }

        /// <inheritdoc />
        public virtual bool AddOrUpdate(string propName, object propValue)
        {
#pragma warning disable Ex0100 // Member may throw undocumented exception
            if (!AssertUtilities.IsEmpty(propName, EmptyComparisonOptions.NullOrWhitespace))
            {
                if (Debugger.IfWriteLine(!BufferedProperties.ContainsKey(propName), $"The property \"{propName}\" is not included in the cached dictionary collection.", null, DebuggingLevel.Information))
                {
                    BufferedProperties[propName] = propValue;
                }
                else
                {
                    var oldValue = BufferedProperties[propName];
                    if (Debugger.IfWriteLine(oldValue != propValue, $"The value of the property \"{propName}\" has changed.", null, DebuggingLevel.Warning))
                    {
                        ChangedProperties[propName] = propValue;
                        BufferedProperties[propName] = propValue;
                        OnPropertyChanged(new KeyValuePair<string, object>(propName, propValue));
                    }
                }
            }
#pragma warning restore Ex0100 // Member may throw undocumented exception
            return false;
        }

        /// <inheritdoc />
        public virtual void OnPropertiesChanged()
        {
            PropertiesChanged?.Invoke(this, new GeneralEventArgs<IDictionary<string, object>>(ChangedProperties));
#pragma warning disable Ex0100 // Member may throw undocumented exception
            ChangedProperties.Clear();
#pragma warning restore Ex0100 // Member may throw undocumented exception
        }

        /// <summary> 用于触发 <see cref="PropertyChanged" /> 事件。 </summary>
        /// <param name="new">
        /// 发生变更的属性键值对。
        /// <para> <see cref="KeyValuePair{TKey, TValue}" /> 类型的值。 </para>
        /// </param>
        /// <seealso cref="KeyValuePair{TKey, TValue}" />
        /// <seealso cref="PropertyChanged" />
        protected virtual void OnPropertyChanged(KeyValuePair<string, object> @new)
        {
            PropertyChanged?.Invoke(this, new GeneralEventArgs<KeyValuePair<string, object>>(@new));
        }
    }
}