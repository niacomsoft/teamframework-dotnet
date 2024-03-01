// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft.TeamFramework.Extensions.Configuration.Environment
{
    /// <summary> 定义了访问主机环境信息的接口。 </summary>
    public interface IEnvironmentInformation
    {
        /// <summary> 获取当前的主机环境名称。 </summary>
        /// <returns> 实现了 <see cref="IEnvironmentName" /> 类型接口的对象实例。 </returns>
        /// <seealso cref="IEnvironmentName" />
        IEnvironmentName GetEnvironmentName();
    }
}