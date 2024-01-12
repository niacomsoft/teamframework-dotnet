// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System.Globalization;
using System.Resources;

namespace Niacomsoft.Resources
{
    /// <summary> 定义了解析资源字符串的接口。 </summary>
    public interface IResourceStringResolver
    {
        /// <summary>
        /// 管理特定文化区域资源字符串的方法。
        /// <para> <see cref="ResourceManager" /> 类型的对象实例。 </para>
        /// </summary>
        /// <value> 获取 <see cref="ResourceManager" /> 类型的对象实例，用于表示管理特定文化区域资源字符串的方法。 </value>
        /// <seealso cref="ResourceManager" />
        ResourceManager ResourceManager { get; }

        /// <summary> 获取特定文化区域的资源字符串。 </summary>
        /// <param name="name"> 资源名称。 </param>
        /// <param name="culture">
        /// 特定的文化区域。
        /// <para> <see cref="CultureInfo" /> 类型的对象实例。 </para>
        /// </param>
        /// <returns> 资源字符串。 </returns>
        /// <seealso cref="CultureInfo" />
        string GetString(string name, CultureInfo culture);

        /// <summary> 获取特定文化区域的资源字符串。 </summary>
        /// <param name="name"> 资源名称。 </param>
        /// <returns> 资源字符串。 </returns>
        /// <seealso cref="GetString(string, CultureInfo)" />
        string GetString(string name);
    }
}