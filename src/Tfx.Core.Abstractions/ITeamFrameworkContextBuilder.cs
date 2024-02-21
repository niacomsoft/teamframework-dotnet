// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;
using System.Collections.Generic;

using Niacomsoft.Configuration;

namespace Niacomsoft.TeamFramework
{
    /// <summary> 定义了构建团队开发框架上下文信息的接口。 </summary>
    /// <seealso cref="IBuilder{T}" />
    /// <seealso cref="ITeamFrameworkContext" />
    public interface ITeamFrameworkContextBuilder : IBuilder<ITeamFrameworkContext>
    {
        /// <summary> 添加一个新的宏参数。 </summary>
        /// <param name="macro">
        /// 新的宏参数。
        /// <para> 实现了 <see cref="IMacroParameter" /> 类型接口的对象实例。 </para>
        /// </param>
        /// <returns> 当前的 <see cref="ITeamFrameworkContextBuilder" /> 类型的对象实例 <see langword="this" />。 </returns>
        /// <seealso cref="IMacroParameter" />
        ITeamFrameworkContextBuilder AddMacroParameter(IMacroParameter macro);

        /// <summary> 添加多个宏参数。 </summary>
        /// <param name="macros">
        /// 需要添加的宏参数集合。
        /// <para> 实现了 <see cref="IMacroParameter" /> 类型接口的对象实例集合。 </para>
        /// </param>
        /// <returns> 当前的 <see cref="ITeamFrameworkContextBuilder" /> 类型的对象实例 <see langword="this" />。 </returns>
        /// <seealso cref="IEnumerable{T}" />
        /// <seealso cref="IMacroParameter" />
        ITeamFrameworkContextBuilder AddMacroParameters(IEnumerable<IMacroParameter> macros);

        /// <summary> 设置应用程序版本号。 </summary>
        /// <param name="version">
        /// 版本信息。
        /// <para> <see cref="Version" /> 类型的对象实例。 </para>
        /// </param>
        /// <returns> 当前的 <see cref="ITeamFrameworkContextBuilder" /> 类型的对象实例 <see langword="this" />。 </returns>
        /// <seealso cref="Version" />
        ITeamFrameworkContextBuilder SetApplicationVersion(Version version);
    }
}