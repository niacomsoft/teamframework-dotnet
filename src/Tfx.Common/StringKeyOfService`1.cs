// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft.TeamFramework
{
    /// <summary> 提供了 <see cref="string" /> 类型的服务标识相关的方法。 </summary>
    /// <typeparam name="TService"> 服务类型。 </typeparam>
    public class StringKeyOfService<TService> : StringKeyOfService
        where TService : class
    {
        /// <summary> 初始化 <see cref="StringKeyOfService{TService}" /> 类的新实例。 </summary>
        public StringKeyOfService() : base(typeof(TService).FullName.Replace(".", "_"))
        {
        }
    }
}