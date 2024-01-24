// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;
using System.Reflection;

using Niacomsoft.Utilities;

namespace Niacomsoft
{
    public partial class ObservablePropertyValue
    {
#if NET45_OR_GREATER || NETSTANDARD || NETCOREAPP || NET

        /// <summary> 创建属性观察程序。 </summary>
        /// <param name="instance"> 需要观察的 <see cref="object" /> 类型的对象实例。 </param>
        /// <returns> 实现了 <see cref="IObservablePropertyValue" /> 类型接口的对象实例。 </returns>
        /// <exception cref="ArgumentNullException"> 当 <paramref name="instance" /> 等于 <see langword="null" /> 时，将引发此类型的异常。 </exception>
        public static IObservablePropertyValue CreatePropertiesObserver(object instance)
        {
            Guard.ArgumentNull(instance, nameof(instance), nameof(CreatePropertiesObserver));
            var properties = instance.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            var propertiesObserver = new ObservablePropertyValue();
            foreach (var prop in properties)
            {
                if (prop.CanWrite && prop.CanRead && AttributeUtilities.TryGetCustomAttribute<ObservablePropertyAttribute>(prop, false, out ObservablePropertyAttribute attr) && attr.Enabled)
                {
                    propertiesObserver.AddOrUpdate(prop.Name, prop.GetValue(instance));
                }
            }
            return propertiesObserver;
        }

#endif
    }
}