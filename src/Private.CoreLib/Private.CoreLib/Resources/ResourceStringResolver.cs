// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace Niacomsoft.Resources
{
    /// <summary>
    /// 提供了解析资源字符串相关的方法。
    /// </summary>
    /// <seealso cref="IResourceStringResolver" />
    public class ResourceStringResolver : IResourceStringResolver
    {
        /// <summary>
        /// 初始化 <see cref="ResourceStringResolver" /> 类的新实例。
        /// </summary>
        /// <param name="baseName"> 不包含文件扩展名的资源文件基础名称。 </param>
        /// <param name="target">
        /// 包含资源的程序集。
        /// <para> <see cref="Assembly" /> 类型的对象实例。 </para>
        /// </param>
        /// <seealso cref="Assembly" />
        public ResourceStringResolver(string baseName, Assembly target)
            : this(new ResourceManager(baseName, target))
        {
        }

        /// <summary>
        /// 初始化 <see cref="ResourceStringResolver" /> 类的新实例。
        /// </summary>
        /// <param name="resourceMgr">
        /// 管理特定文化区域资源字符串的方法。
        /// <para> <see cref="ResourceManager" /> 类型的对象实例。 </para>
        /// </param>
        /// <exception cref="ArgumentNullException"> 当 <paramref name="resourceMgr" /> 等于 <see langword="null" /> 时，将引发此类型的异常。 </exception>
        /// <seealso cref="ResourceManager" />
        public ResourceStringResolver(ResourceManager resourceMgr)
            => ResourceManager = resourceMgr ?? throw new ArgumentNullException(Strings.ResourceStringResolver_not_support_resourcemanager);

        /// <inheritdoc />
        public ResourceManager ResourceManager { get; }

        /// <inheritdoc />
        /// <exception cref="ArgumentException"> 当 <paramref name="name" /> 等于 <see langword="null" />、长度等于 0 或全部为空白符时，将引发此类型的异常。 </exception>
        /// <exception cref="MissingManifestResourceException">
        /// 当调用 <see cref="ResourceManager.GetString(string, CultureInfo)" /> 方法时，可能引发此类型的异常。
        /// </exception>
        /// <exception cref="MissingSatelliteAssemblyException">
        /// 当调用 <see cref="ResourceManager.GetString(string, CultureInfo)" /> 方法时，可能引发此类型的异常。
        /// </exception>
        [SuppressMessage("Design", "Ex0200:Member is documented as throwing exception not documented on member in base or interface type", Justification = "<挂起>")]
        public virtual string GetString(string name, CultureInfo culture)
        {
            return string.IsNullOrWhiteSpace(name)
                ? throw new ArgumentException(Strings.ResourceStringResolver_not_support_resource_name)
                : culture is null ? ResourceManager.GetString(name) : ResourceManager.GetString(name, culture);
        }

        /// <inheritdoc />
        /// <seealso cref="M:Niacomsoft.Resources.IResourceStringResolver.GetString(System.String,System.Globalization.CultureInfo)" />
        /// <exception cref="MissingManifestResourceException">
        /// 当调用 <see cref="ResourceManager.GetString(string)" /> 方法时，可能引发此类型的异常。
        /// </exception>
        /// <exception cref="MissingSatelliteAssemblyException">
        /// 当调用 <see cref="ResourceManager.GetString(string)" /> 方法时，可能引发此类型的异常。
        /// </exception>
        [SuppressMessage("Design", "Ex0200:Member is documented as throwing exception not documented on member in base or interface type", Justification = "<挂起>")]
        public string GetString(string name)
            => GetString(name, null);
    }
}