// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft
{
    using System.Globalization;
    using System.Resources;

    using Niacomsoft.Resources;

    /// <summary> 提供了内置资源字符串相关的方法。 </summary>
    public static class SR
    {
        private static readonly ResourceManager s_resourceMgr = Strings.ResourceManager;

        /// <summary> 获取名称为 <paramref name="name" /> 的模板资源字符串，并格式化。 </summary>
        /// <param name="name">    资源名称。 </param>
        /// <param name="culture">
        /// 指定的文化区域信息。
        /// <para> <see cref="CultureInfo" /> 类型的对象实例。 </para>
        /// </param>
        /// <param name="args">    格式化参数数组。 </param>
        /// <returns> 格式化后的字符串。 </returns>
        /// <seealso cref="CultureInfo" />
        /// <seealso cref="string.Format(string, object[])" />
        /// <exception cref="MissingManifestResourceException"> 当调用 <see cref="GetString(string, CultureInfo)" /> 方法时，可能引发此类型的异常。 </exception>
        /// <exception cref="MissingSatelliteAssemblyException"> 当调用 <see cref="GetString(string, CultureInfo)" /> 方法时，可能引发此类型的异常。 </exception>
        /// <exception cref="System.FormatException"> 当调用 <see cref="string.Format(string, object[])" /> 方法时，可能引发此类型的异常。 </exception>
        public static string Format(string name, CultureInfo culture, params object[] args)
            => string.Format(GetString(name, culture), args);

        /// <summary> 获取名称为 <paramref name="name" /> 的模板资源字符串，并格式化。 </summary>
        /// <param name="name"> 资源名称。 </param>
        /// <param name="args"> 格式化参数数组。 </param>
        /// <returns> 格式化后的字符串。 </returns>
        /// <seealso cref="string.Format(string, object[])" />
        /// <exception cref="MissingManifestResourceException"> 当调用 <see cref="GetString(string, CultureInfo)" /> 方法时，可能引发此类型的异常。 </exception>
        /// <exception cref="MissingSatelliteAssemblyException"> 当调用 <see cref="GetString(string, CultureInfo)" /> 方法时，可能引发此类型的异常。 </exception>
        /// <exception cref="System.FormatException"> 当调用 <see cref="string.Format(string, object[])" /> 方法时，可能引发此类型的异常。 </exception>
        public static string Format(string name, params object[] args)
            => string.Format(GetString(name), args);

        /// <summary> 获取名称为 <paramref name="name" /> 的资源字符串。 </summary>
        /// <param name="name">    资源名称。 </param>
        /// <param name="culture">
        /// 指定的文化区域信息。
        /// <para> <see cref="CultureInfo" /> 类型的对象实例。 </para>
        /// </param>
        /// <returns> 资源字符串。 </returns>
        /// <seealso cref="CultureInfo" />
        /// <exception cref="MissingManifestResourceException">
        /// 当调用 <see cref="ResourceManager.GetString(string, CultureInfo)" /> 方法时，可能引发此类型的异常。
        /// </exception>
        /// <exception cref="MissingSatelliteAssemblyException">
        /// 当调用 <see cref="ResourceManager.GetString(string, CultureInfo)" /> 方法时，可能引发此类型的异常。
        /// </exception>
        public static string GetString(string name, CultureInfo culture = null)
            => culture is null
                ? s_resourceMgr.GetString(name)
                : s_resourceMgr.GetString(name, culture);
    }
}