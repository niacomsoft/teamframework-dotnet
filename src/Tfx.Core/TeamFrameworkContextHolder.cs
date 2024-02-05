// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft.TeamFramework
{
    /// <summary> 提供了管理默认 <see cref="ITeamFrameworkContext" /> 类型的对象实例相关的方法。 </summary>
    internal static class TeamFrameworkContextHolder
    {
        /// <summary> 单例的 <see cref="ITeamFrameworkContext" /> 类型的对象实例管理器。 </summary>
        /// <seealso cref="ISingletonInstanceManager{TInstance}" />
        /// <seealso cref="ITeamFrameworkContext" />
        /// <seealso cref="ParameterizedFunc{TReturn}" />
        /// <seealso cref="SingletonInstanceManager{TInstance}" />
        /// <seealso cref="TeamFrameworkContextBuilder" />
        internal static readonly ISingletonInstanceManager<ITeamFrameworkContext> InstanceManager
            = new SingletonInstanceManager<ITeamFrameworkContext>((_) => InternalContext ?? new TeamFrameworkContextBuilder().Build());

        /// <summary> 内部的团队开发框架上下文。 </summary>
        /// <value> 设置或获取 <see cref="ITeamFrameworkContext" /> 类型的对象实例，用于表示内部的团队开发框架上下文。 </value>
        /// <seealso cref="ITeamFrameworkContext" />
        internal static ITeamFrameworkContext InternalContext { get; set; }
    }
}