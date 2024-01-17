// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

using Niacomsoft.Diagnostics;

namespace Niacomsoft.Utilities
{
    /// <summary> 提供了注解相关的工具方法。 </summary>
    public static partial class AttributeUtilities
    {
        /// <summary> 从程序集 <see cref="Assembly" /> 中获取 <paramref name="attributeType" /> 类型的注解。 </summary>
        /// <param name="assembly">
        /// 程序集。
        /// <para> <see cref="Assembly" /> 类型的对象实例。 </para>
        /// </param>
        /// <param name="attributeType"> 派生自 <see cref="Attribute" /> 的类型。 </param>
        /// <param name="inherit"> 是否搜索类型继承链。 </param>
        /// <returns> 派生自 <see cref="Attribute" /> 类型的对象实例。 </returns>
        /// <seealso cref="Assembly" />
        /// <seealso cref="Attribute" />
        /// <seealso cref="Attribute.GetCustomAttribute(Assembly, Type, bool)" />
        /// <seealso cref="Type" />
        /// <exception cref="AmbiguousMatchException">
        /// 当调用 <see cref="Attribute.GetCustomAttribute(Assembly, Type, bool)" /> 方法时，可能引发此类型的异常。
        /// </exception>
        public static Attribute GetCustomAttribute(Assembly assembly, Type attributeType, bool inherit = false)
        {
            Guard.ArgumentNull(assembly, nameof(assembly), nameof(GetCustomAttribute));
            Guard.ArgumentNull(attributeType, nameof(attributeType), nameof(GetCustomAttribute));
            return Attribute.GetCustomAttribute(assembly, attributeType, inherit);
        }

        /// <summary> 从程序集 <see cref="Assembly" /> 中获取 <typeparamref name="TAttribute" /> 类型的注解。 </summary>
        /// <typeparam name="TAttribute"> 派生自 <see cref="Attribute" /> 的类型。 </typeparam>
        /// <param name="assembly">
        /// 程序集。
        /// <para> <see cref="Assembly" /> 类型的对象实例。 </para>
        /// </param>
        /// <param name="inherit"> 是否搜索类型继承链。 </param>
        /// <returns> <typeparamref name="TAttribute" /> 类型的对象实例。 </returns>
        /// <seealso cref="GetCustomAttribute(Assembly, Type, bool)" />
        [SuppressMessage("Design", "Ex0100:Member may throw undocumented exception", Justification = "<挂起>")]
        public static TAttribute GetCustomAttribute<TAttribute>(Assembly assembly, bool inherit = false) where TAttribute : Attribute
            => GetCustomAttribute(assembly, typeof(TAttribute), inherit) as TAttribute;

        /// <summary>
        /// 当从程序集 <paramref name="assembly" /> 中获取 <paramref name="attributeType" /> 类型的注解不等于 <see langword="null" /> 时，返回
        /// <see langword="true" />；否则返回 <see langword="false" />。
        /// </summary>
        /// <param name="assembly">
        /// 程序集。
        /// <para> <see cref="Assembly" /> 类型的对象实例。 </para>
        /// </param>
        /// <param name="attributeType"> 派生自 <see cref="Attribute" /> 的类型。 </param>
        /// <param name="inherit"> 是否搜索类型继承链。 </param>
        /// <param name="attribute">
        /// 指定的注解。
        /// <para> 派生自 <see cref="Attribute" /> 类型的对象实例。 </para>
        /// </param>
        /// <returns>
        /// 当从程序集 <paramref name="assembly" /> 中获取 <paramref name="attributeType" /> 类型的注解不等于 <see langword="null" /> 时，返回
        /// <see langword="true" />；否则返回 <see langword="false" />。
        /// </returns>
        /// <seealso cref="Assembly" />
        /// <seealso cref="Attribute" />
        /// <seealso cref="GetCustomAttribute(Assembly, Type, bool)" />
        /// <seealso cref="Type" />
        public static bool TryGetCustomAttribute(Assembly assembly, Type attributeType, bool inherit, out Attribute attribute)
        {
            try
            {
                attribute = GetCustomAttribute(assembly, attributeType, inherit);
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
        /// 当从程序集 <paramref name="assembly" /> 中获取 <typeparamref name="TAttribute" /> 类型的注解不等于 <see langword="null" /> 时，返回
        /// <see langword="true" />；否则返回 <see langword="false" />。
        /// </summary>
        /// <typeparam name="TAttribute"> 派生自 <see cref="Attribute" /> 的类型。 </typeparam>
        /// <param name="assembly">
        /// 程序集。
        /// <para> <see cref="Assembly" /> 类型的对象实例。 </para>
        /// </param>
        /// <param name="inherit"> 是否搜索类型继承链。 </param>
        /// <param name="attribute">
        /// 指定的注解。
        /// <para> 派生自 <see cref="Attribute" /> 类型的对象实例。 </para>
        /// </param>
        /// <returns>
        /// 当从程序集 <paramref name="assembly" /> 中获取 <typeparamref name="TAttribute" /> 类型的注解不等于 <see langword="null" /> 时，返回
        /// <see langword="true" />；否则返回 <see langword="false" />。
        /// </returns>
        /// <seealso cref="TryGetCustomAttribute(Assembly, Type, bool, out Attribute)" />
        /// <seealso cref="Assembly" />
        /// <seealso cref="Attribute" />
        public static bool TryGetCustomAttribute<TAttribute>(Assembly assembly, bool inherit, out TAttribute attribute) where TAttribute : Attribute
        {
            attribute = default;
            if (TryGetCustomAttribute(assembly, typeof(TAttribute), inherit, out Attribute attr))
            {
                attribute = attr as TAttribute;
                return AssertUtilities.NotNull(attribute);
            }
            return false;
        }
    }
}