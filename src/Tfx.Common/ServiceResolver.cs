// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

namespace Niacomsoft.TeamFramework
{
    /// <summary> 提供了解释指定服务相关的 <see langword="abstract" /> 方法。 </summary>
    /// <seealso cref="IServiceResolver" />
    public abstract class ServiceResolver : IServiceResolver
    {
        /// <summary> 初始化 <see cref="ServiceResolver" /> 类的新实例。 </summary>
        protected ServiceResolver()
        {
        }

        /// <inheritdoc />
        public abstract object GetService(Type serviceType);
    }
}