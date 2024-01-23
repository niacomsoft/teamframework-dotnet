// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System.Collections.Generic;

namespace Niacomsoft
{
    /// <summary> 定义了观察属性值的接口。 </summary>
    public interface IObservablePropertyValue
    {
        /// <summary> 单个属性值变更事件。 </summary>
        /// <seealso cref="GeneralEventArgs{TData}" />
        /// <seealso cref="GeneralEventHandler{TData}" />
        /// <seealso cref="KeyValuePair{TKey, TValue}" />
        event GeneralEventHandler<KeyValuePair<string, object>> PropertyChanged;

        /// <summary> 所有变更的属性值事件。 </summary>
        /// <seealso cref="GeneralEventArgs{TData}" />
        /// <seealso cref="GeneralEventHandler{TData}" />
        /// <seealso cref="IDictionary{TKey, TValue}" />
        event GeneralEventHandler<IDictionary<string, object>> PropertiesChanged;

        /// <summary> 当指定名称 <paramref name="propName" /> 的属性值变更后，返回 <see langword="true" />；否则返回 <see langword="false" />。 </summary>
        /// <param name="propName"> 需要更新的属性名称。 </param>
        /// <param name="propValue"> 新的属性值。 </param>
        /// <returns> 当指定名称 <paramref name="propName" /> 的属性值变更后，返回 <see langword="true" />；否则返回 <see langword="false" />。 </returns>
        bool AddOrUpdate(string propName, object propValue);

        /// <summary> 统一引发一次 <see cref="PropertiesChanged" /> 事件。 </summary>
        /// <seealso cref="PropertiesChanged" />
        void OnPropertiesChanged();
    }
}