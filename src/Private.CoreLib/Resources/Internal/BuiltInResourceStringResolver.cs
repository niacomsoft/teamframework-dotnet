// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

namespace Niacomsoft.Resources.Internal
{
    /// <summary> 提供了解析内置资源字符串相关的方法。密闭的，不可以从此类型派生。 </summary>
    /// <seealso cref="IResourceStringResolver" />
    /// <seealso cref="ResourceStringResolver" />
    /// <remarks> 密闭的，不可以从此类型派生。 </remarks>
    public sealed class BuiltInResourceStringResolver : ResourceStringResolver
    {
#if NET45_OR_GREATER || NETSTANDARD || NETCOREAPP || NET

        /// <summary> 内置的资源字符串解析程序。 </summary>
        /// <seealso cref="IResourceStringResolver" />
        /// <seealso cref="BuiltInResourceStringResolver" />
        /// <seealso cref="Lazy{T}" />
        internal static readonly Lazy<IResourceStringResolver> Default = new Lazy<IResourceStringResolver>(() => new BuiltInResourceStringResolver(), true);

#else

        /// <summary> 内置的资源字符串解析程序。 </summary>
        /// <seealso cref="IResourceStringResolver" />
        /// <seealso cref="BuiltInResourceStringResolver" />
        internal static readonly IResourceStringResolver Default = new BuiltInResourceStringResolver();
#endif

        /// <summary> 初始化 <see cref="BuiltInResourceStringResolver" /> 类的新实例。 </summary>
        private BuiltInResourceStringResolver() : base(Strings.ResourceManager)
        {
        }
    }
}