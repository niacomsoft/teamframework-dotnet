// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using Unity;

namespace Niacomsoft.TeamFramework.Extensions.DependencyInjection
{
    /// <summary> 提供了管理默认 <see cref="IUnityContainer" /> 服务容器相关的方法。 </summary>
    public static class DefaultUnityContainer
    {
        private static readonly ISingletonInstanceManager<IUnityContainer> SingletonUnityContainer = new SingletonInstanceManager<IUnityContainer>((_) => new UnityContainer());

        /// <summary> 获取默认的 <see cref="IUnityContainer" /> 依赖注入服务容器。 </summary>
        /// <returns> 实现了 <see cref="IUnityContainer" /> 类型接口的对象实例。 </returns>
        /// <seealso cref="ISingletonInstanceManager{TInstance}" />
        /// <seealso cref="IUnityContainer" />
        public static IUnityContainer GetDefaultContainer()
        {
            return SingletonUnityContainer.CreateOrGet();
        }
    }
}