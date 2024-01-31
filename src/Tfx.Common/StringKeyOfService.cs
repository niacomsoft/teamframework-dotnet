// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft.TeamFramework
{
    /// <summary> 提供了 <see cref="string" /> 类型的服务标识相关的方法。 </summary>
    /// <seealso cref="IKeyOfService{TKey}" />
    /// <seealso cref="KeyOfService{TKey}" />
    public class StringKeyOfService : KeyOfService<string>
    {
        /// <summary> 初始化 <see cref="StringKeyOfService" /> 类的新实例。 </summary>
        public StringKeyOfService()
        {
        }

        /// <summary> 初始化 <see cref="StringKeyOfService" /> 类的新实例。 </summary>
        /// <param name="serviceKey"> 服务标识名称。 </param>
        public StringKeyOfService(string serviceKey) : base(serviceKey)
        {
        }
    }
}