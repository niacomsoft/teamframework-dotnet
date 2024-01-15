// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

namespace Niacomsoft
{
    /// <summary> 提供了动态创建对象实例相关的辅助方法。 </summary>
    public static class ActivatorUtilities
    {
        /// <summary> 创建 <typeparamref name="T" /> 类型的对象实例。 </summary>
        /// <typeparam name="T"> 指定的类类型。 </typeparam>
        /// <param name="args"> <typeparamref name="T" /> 类型的构造函数参数。 </param>
        /// <returns> <typeparamref name="T" /> 类型的对象实例。 </returns>
        /// <exception cref="NotSupportedException"> 当调用 <see cref="Activator.CreateInstance(Type, object[])" /> 方法时，可能引发此类型的异常。 </exception>
        /// <exception cref="System.Reflection.TargetInvocationException">
        /// 当调用 <see cref="Activator.CreateInstance(Type, object[])" /> 方法时，可能引发此类型的异常。
        /// </exception>
        /// <exception cref="MethodAccessException"> 当调用 <see cref="Activator.CreateInstance(Type, object[])" /> 方法时，可能引发此类型的异常。 </exception>
        /// <exception cref="MemberAccessException"> 当调用 <see cref="Activator.CreateInstance(Type, object[])" /> 方法时，可能引发此类型的异常。 </exception>
        /// <exception cref="System.Runtime.InteropServices.InvalidComObjectException">
        /// 当调用 <see cref="Activator.CreateInstance(Type, object[])" /> 方法时，可能引发此类型的异常。
        /// </exception>
        /// <exception cref="System.Runtime.InteropServices.COMException">
        /// 当调用 <see cref="Activator.CreateInstance(Type, object[])" /> 方法时，可能引发此类型的异常。
        /// </exception>
        /// <exception cref="TypeLoadException"> </exception>
        /// <seealso cref="Activator" />
        /// <seealso cref="Activator.CreateInstance(Type, object[])" />
        public static T CreateInstance<T>(params object[] args) where T : class
            => Activator.CreateInstance(typeof(T), args) as T;
    }
}