// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft.TeamFramework
{
    /// <summary> 定义了管理 <typeparamref name="TInstance" /> 类型单例实例的接口。 </summary>
    /// <typeparam name="TInstance"> 一个引用类型。 </typeparam>
    public interface ISingletonInstanceManager<TInstance>
        where TInstance : class
    {
        /// <summary> 创建或获取 <typeparamref name="TInstance" /> 类型的对象实例。 </summary>
        /// <param name="args"> <typeparamref name="TInstance" /> 类型所需的构造方法参数数组。 </param>
        /// <returns> <typeparamref name="TInstance" /> 类型的对象实例。 </returns>
        TInstance CreateOrGet(params object[] args);
    }
}