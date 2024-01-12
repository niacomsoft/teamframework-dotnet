// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

using Niacomsoft.Resources.Internal;

namespace Niacomsoft
{
    /// <summary> 提供了获取内置资源字符串相关的方法。 </summary>
    /// <seealso cref="BuiltInResourceStringResolver" />
    public static class SR
    {
        /// <summary> 使用特定文化区域的资源字符串格式化。 </summary>
        /// <param name="name"> 资源名称。 </param>
        /// <param name="culture">
        /// 特定的文化区域。
        /// <para> <see cref="CultureInfo" /> 类型的对象实例。 </para>
        /// </param>
        /// <param name="args"> 格式化字符串。 </param>
        /// <returns> 格式化后的资源字符串。 </returns>
        /// <seealso cref="CultureInfo" />
        /// <seealso cref="string.Format(string, object[])" />
        /// <exception cref="FormatException"> 当调用 <see cref="string.Format(string, object[])" /> 方法时，可能引发此类型的异常。 </exception>
        public static string Format(string name, CultureInfo culture, params object[] args)
            => string.Format(GetString(name, culture), args);

        /// <summary> 使用特定文化区域的资源字符串格式化。 </summary>
        /// <param name="name"> 资源名称。 </param>
        /// <param name="args"> 格式化字符串。 </param>
        /// <returns> 格式化后的资源字符串。 </returns>
        /// <seealso cref="string.Format(string, object[])" />
        /// <exception cref="FormatException"> 当调用 <see cref="string.Format(string, object[])" /> 方法时，可能引发此类型的异常。 </exception>
        public static string Format(string name, params object[] args)
            => string.Format(GetString(name), args);

        /// <summary> 获取特定文化区域的资源字符串。 </summary>
        /// <param name="name"> 资源名称。 </param>
        /// <param name="culture">
        /// 特定的文化区域。
        /// <para> <see cref="CultureInfo" /> 类型的对象实例。 </para>
        /// </param>
        /// <returns> 资源字符串。 </returns>
        /// <seealso cref="CultureInfo" />
        [SuppressMessage("Design", "Ex0100:Member may throw undocumented exception", Justification = "<挂起>")]
        public static string GetString(string name, CultureInfo culture)
        {
#if NET45_OR_GREATER || NETSTANDARD || NETCOREAPP || NET
            return BuiltInResourceStringResolver.Default.Value.GetString(name, culture);
#else
            return BuiltInResourceStringResolver.Default.GetString(name, culture);
#endif
        }

        /// <summary> 获取特定文化区域的资源字符串。 </summary>
        /// <param name="name"> 资源名称。 </param>
        /// <returns> 资源字符串。 </returns>
        /// <seealso cref="M:Niacomsoft.Resources.IResourceStringResolver.GetString(System.String,System.Globalization.CultureInfo)" />
        [SuppressMessage("Design", "Ex0100:Member may throw undocumented exception", Justification = "<挂起>")]
        public static string GetString(string name)
        {
#if NET45_OR_GREATER || NETSTANDARD || NETCOREAPP || NET
            return BuiltInResourceStringResolver.Default.Value.GetString(name);
#else
            return BuiltInResourceStringResolver.Default.GetString(name);
#endif
        }
    }
}