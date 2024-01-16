// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

using Niacomsoft.Diagnostics;

namespace Niacomsoft.Utilities
{
    public static partial class AttributeUtilities
    {
        /// <summary> 从模块 <see cref="Module" /> 中获取 <paramref name="attributeType" /> 类型的注解。 </summary>
        /// <param name="module">
        /// 模块。
        /// <para> <see cref="Module" /> 类型的对象实例。 </para>
        /// </param>
        /// <param name="attributeType"> 派生自 <see cref="Attribute" /> 的类型。 </param>
        /// <param name="inherit"> 是否搜索类型继承链。 </param>
        /// <returns> 派生自 <see cref="Attribute" /> 类型的对象实例。 </returns>
        /// <seealso cref="Module" />
        /// <seealso cref="Attribute" />
        /// <seealso cref="Attribute.GetCustomAttribute(Module, Type, bool)" />
        /// <seealso cref="Type" />
        /// <exception cref="AmbiguousMatchException">
        /// 当调用 <see cref="Attribute.GetCustomAttribute(Module, Type, bool)" /> 方法时，可能引发此类型的异常。
        /// </exception>
        public static Attribute GetCustomAttribute(Module module, Type attributeType, bool inherit = false)
        {
            Guard.ArgumentNull(module, nameof(module), nameof(GetCustomAttribute));
            Guard.ArgumentNull(attributeType, nameof(attributeType), nameof(GetCustomAttribute));
            return Attribute.GetCustomAttribute(module, attributeType, inherit);
        }

        /// <summary> 从模块 <see cref="Module" /> 中获取 <typeparamref name="TAttribute" /> 类型的注解。 </summary>
        /// <typeparam name="TAttribute"> 派生自 <see cref="Attribute" /> 的类型。 </typeparam>
        /// <param name="module">
        /// 模块。
        /// <para> <see cref="Module" /> 类型的对象实例。 </para>
        /// </param>
        /// <param name="inherit"> 是否搜索类型继承链。 </param>
        /// <returns> <typeparamref name="TAttribute" /> 类型的对象实例。 </returns>
        /// <seealso cref="GetCustomAttribute(Module, Type, bool)" />
        [SuppressMessage("Design", "Ex0100:Member may throw undocumented exception", Justification = "<挂起>")]
        public static TAttribute GetCustomAttribute<TAttribute>(Module module, bool inherit = false) where TAttribute : Attribute
            => GetCustomAttribute(module, typeof(TAttribute), inherit) as TAttribute;

        /// <summary>
        /// 当从模块 <paramref name="module" /> 中获取 <paramref name="attributeType" /> 类型的注解不等于 <see langword="null" /> 时，返回
        /// <see langword="true" />；否则返回 <see langword="false" />。
        /// </summary>
        /// <param name="module">
        /// 模块。
        /// <para> <see cref="Module" /> 类型的对象实例。 </para>
        /// </param>
        /// <param name="attributeType"> 派生自 <see cref="Attribute" /> 的类型。 </param>
        /// <param name="inherit"> 是否搜索类型继承链。 </param>
        /// <param name="attribute">
        /// 指定的注解。
        /// <para> 派生自 <see cref="Attribute" /> 类型的对象实例。 </para>
        /// </param>
        /// <returns>
        /// 当从模块 <paramref name="module" /> 中获取 <paramref name="attributeType" /> 类型的注解不等于 <see langword="null" /> 时，返回
        /// <see langword="true" />；否则返回 <see langword="false" />。
        /// </returns>
        /// <seealso cref="Module" />
        /// <seealso cref="Attribute" />
        /// <seealso cref="GetCustomAttribute(Module, Type, bool)" />
        /// <seealso cref="Type" />
        public static bool TryGetCustomAttribute(Module module, Type attributeType, bool inherit, out Attribute attribute)
        {
            try
            {
                attribute = GetCustomAttribute(module, attributeType, inherit);
                return AssertUtilities.NotNull(attribute);
            }
            catch (Exception error)
            {
                attribute = null;
                Debugger.WriteLine($"When trying to get an annotation of type \"{attributeType.FullName}\", an exception of type \"{error.GetType().FullName}\" is thrown: {error.Message}", null, DebuggingLevel.Error);
                return false;
            }
        }

        /// <summary>
        /// 当从模块 <paramref name="module" /> 中获取 <typeparamref name="TAttribute" /> 类型的注解不等于 <see langword="null" /> 时，返回
        /// <see langword="true" />；否则返回 <see langword="false" />。
        /// </summary>
        /// <typeparam name="TAttribute"> 派生自 <see cref="Attribute" /> 的类型。 </typeparam>
        /// <param name="module">
        /// 模块。
        /// <para> <see cref="Module" /> 类型的对象实例。 </para>
        /// </param>
        /// <param name="inherit"> 是否搜索类型继承链。 </param>
        /// <param name="attribute">
        /// 指定的注解。
        /// <para> 派生自 <see cref="Attribute" /> 类型的对象实例。 </para>
        /// </param>
        /// <returns>
        /// 当从模块 <paramref name="module" /> 中获取 <typeparamref name="TAttribute" /> 类型的注解不等于 <see langword="null" /> 时，返回
        /// <see langword="true" />；否则返回 <see langword="false" />。
        /// </returns>
        /// <seealso cref="TryGetCustomAttribute(Module, Type, bool, out Attribute)" />
        /// <seealso cref="Module" />
        /// <seealso cref="Attribute" />
        public static bool TryGetCustomAttribute<TAttribute>(Module module, bool inherit, out TAttribute attribute) where TAttribute : Attribute
        {
            attribute = default;
            if (TryGetCustomAttribute(module, typeof(TAttribute), inherit, out Attribute attr))
            {
                attribute = attr as TAttribute;
                return AssertUtilities.NotNull(attribute);
            }
            return false;
        }
    }
}