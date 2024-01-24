// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

namespace Niacomsoft
{
    /// <summary> 提供了可供 <see cref="IObservablePropertyValue" /> 观察的属性相关的注解方法。密闭的，不可以从此类型派生。 </summary>
    /// <seealso cref="Attribute" />
    /// <seealso cref="AttributeTargets" />
    /// <seealso cref="AttributeUsageAttribute" />
    /// <remarks> 密闭的，不可以从此类型派生。 </remarks>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public sealed class ObservablePropertyAttribute : Attribute
    {
        /// <summary> 初始化 <see cref="ObservablePropertyAttribute" /> 类的新实例。 </summary>
        public ObservablePropertyAttribute() : this(true)
        {
        }

        /// <summary> 初始化 <see cref="ObservablePropertyAttribute" /> 类的新实例。 </summary>
        /// <param name="enabled"> 是否启用属性值观测。 </param>
        public ObservablePropertyAttribute(bool enabled)
        {
            Enabled = enabled;
        }

        /// <summary> 是否启用属性值观测。 </summary>
        /// <value> 设置或获取一个 <see langword="bool" /> 类型值，用于表示是否启用属性值观测。 </value>
        public bool Enabled { get; set; }
    }
}