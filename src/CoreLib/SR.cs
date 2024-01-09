// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System.Diagnostics.CodeAnalysis;
using System.Globalization;

using Niacomsoft.Resources.Internal;

namespace Niacomsoft
{
    /// <summary>
    /// 提供了获取内置资源字符串相关的方法。
    /// </summary>
    /// <seealso cref="BuiltInResourceStringResolver" />
    public static class SR
    {
        /// <summary>
        /// 获取特定文化区域的资源字符串。
        /// </summary>
        /// <param name="name"> 资源名称。 </param>
        /// <param name="culture">
        /// 特定的文化区域。
        /// <para> <see cref="CultureInfo" /> 类型的对象实例。 </para>
        /// </param>
        /// <returns> 资源字符串。 </returns>
        /// <seealso cref="CultureInfo" />
        [SuppressMessage("Design", "Ex0100:Member may throw undocumented exception", Justification = "<挂起>")]
        public static string GetString(string name, CultureInfo culture)
            => BuiltInResourceStringResolver.Default.Value.GetString(name, culture);

        /// <summary>
        /// 获取特定文化区域的资源字符串。
        /// </summary>
        /// <param name="name"> 资源名称。 </param>
        /// <returns> 资源字符串。 </returns>
        /// <seealso cref="M:Niacomsoft.Resources.IResourceStringResolver.GetString(System.String,System.Globalization.CultureInfo)" />
        [SuppressMessage("Design", "Ex0100:Member may throw undocumented exception", Justification = "<挂起>")]
        public static string GetString(string name)
            => BuiltInResourceStringResolver.Default.Value.GetString(name);
    }
}