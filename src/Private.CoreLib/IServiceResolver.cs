// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

namespace Niacomsoft
{
    /// <summary> 定义了解释服务的接口。 </summary>
    public interface IServiceResolver
    {
        /// <summary> 获取 <paramref name="serviceType" /> 类型的服务实例。 </summary>
        /// <param name="serviceType">
        /// 服务类型。
        /// <para> <see cref="Type" /> 类型的对象实例。 </para>
        /// </param>
        /// <returns> <paramref name="serviceType" /> 类型的服务实例。 </returns>
        /// <seealso cref="Type" />
        object GetService(Type serviceType);
    }
}