// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

using Niacomsoft.Configuration;
using Niacomsoft.Utilities;

namespace Niacomsoft.TeamFramework
{
    /// <summary> 提供了构建 <see cref="TeamFrameworkContext" /> 类型的对象实例相关的方法。 </summary>
    /// <seealso cref="Builder{T}" />
    /// <seealso cref="ITeamFrameworkContext" />
    /// <seealso cref="ITeamFrameworkContextBuilder" />
    /// <seealso cref="TeamFrameworkContext" />
    public class TeamFrameworkContextBuilder : Builder<ITeamFrameworkContext>, ITeamFrameworkContextBuilder
    {
        private const string EnvironmentMacroScope = "env";

        /// <summary> 初始化 <see cref="TeamFrameworkContextBuilder" /> 类的新实例。 </summary>
        [SuppressMessage("Design", "Ex0100:Member may throw undocumented exception", Justification = "<挂起>")]
        public TeamFrameworkContextBuilder()
        {
            Macros = new MacroParameterCollection();
            InitializeBuiltinMacros();
        }

        /// <summary> 应用程序版本号信息。 </summary>
        /// <value> 设置或获取 <see cref="Version" /> 类型的对象实例，用于表示应用程序版本号信息。 </value>
        /// <seealso cref="Version" />
        protected virtual Version ApplicationVersion { get; set; }

        /// <summary> 宏参数集合。 </summary>
        /// <value> 获取 <see cref="MacroParameterCollection" /> 类型的对象实例，用于表示宏参数集合。 </value>
        /// <seealso cref="MacroParameterCollection" />
        protected virtual MacroParameterCollection Macros { get; }

        /// <inheritdoc />
        /// <exception cref="ArgumentNullException"> 当 <paramref name="macro" /> 等于 <see langword="null" /> 时，将引发此类型的异常。 </exception>
        [SuppressMessage("Design", "Ex0200:Member is documented as throwing exception not documented on member in base or interface type", Justification = "<挂起>")]
        public virtual ITeamFrameworkContextBuilder AddMacroParameter(IMacroParameter macro)
        {
            if (AssertUtilities.IsNull(macro))
            {
#pragma warning disable Ex0100 // Member may throw undocumented exception
                throw new ArgumentNullException(nameof(macro), SR.Format("ArgumentNullException_with_method_and_parameter_name", nameof(AddMacroParameter), nameof(macro)));
#pragma warning restore Ex0100 // Member may throw undocumented exception
            }

            Macros.Add(macro);

            return this;
        }

        /// <inheritdoc />
        public virtual ITeamFrameworkContextBuilder AddMacroParameters(IEnumerable<IMacroParameter> macros)
        {
            if (AssertUtilities.NotNull(macros))
            {
                foreach (var item in macros)
                {
                    AddMacroParameter(item);
                }
            }
            return this;
        }

        /// <inheritdoc />
        public override ITeamFrameworkContext Build()
        {
            var contextData = new ContextualData();
            if (AssertUtilities.NotNull(ApplicationVersion))
                contextData.SetValue(TeamFrameworkContext.KeyOf_ApplicationVersion, ApplicationVersion);
            contextData.SetValue(TeamFrameworkContext.KeyOf_Macros, Macros.Compile());
            return new TeamFrameworkContext(contextData);
        }

        /// <inheritdoc />
        /// <exception cref="ArgumentNullException"> 当 <paramref name="version" /> 等于 <see langword="null" /> 时，将引发此类型的异常。 </exception>
        [SuppressMessage("Design", "Ex0200:Member is documented as throwing exception not documented on member in base or interface type", Justification = "<挂起>")]
        public virtual ITeamFrameworkContextBuilder SetApplicationVersion(Version version)
        {
            if (AssertUtilities.IsNull(version))
            {
#pragma warning disable Ex0100 // Member may throw undocumented exception
                throw new ArgumentNullException(nameof(version), SR.Format("ArgumentNullException_with_method_and_parameter_name", nameof(SetApplicationVersion), nameof(version)));
#pragma warning restore Ex0100 // Member may throw undocumented exception
            }

            ApplicationVersion = version;

            return AddMacroParameter(new MacroParameter("appVersion", version.ToString(4), EnvironmentMacroScope));
        }

        /// <summary> 初始化内置宏参数。 </summary>
        /// <seealso cref="Macros" />
        /// <exception cref="AppDomainUnloadedException">
        /// 当访问 <c> <see cref="AppDomain.CurrentDomain" />.BaseDirectory </c> 属性时，可能引发此类型的异常。
        /// </exception>
        protected virtual void InitializeBuiltinMacros()
        {
            Macros.Add(new MacroParameter("baseDir", AppDomain.CurrentDomain.BaseDirectory, EnvironmentMacroScope));
            Macros.Add(new MacroParameter("clrVersion", Environment.Version.ToString(4), EnvironmentMacroScope));
            Macros.Add(new MacroParameter("os", Environment.OSVersion.ToString(), EnvironmentMacroScope));
            Macros.Add(new MacroParameter("x64", Environment.Is64BitOperatingSystem ? TrueValue.TrueString : FalseValue.FalseString, EnvironmentMacroScope));
#if NETFRAMEWORK
            Macros.Add(new MacroParameter("platform", ".NET Framework", EnvironmentMacroScope));
#elif NETSTANDARD
            Macros.Add(new MacroParameter("platform", ".NET Standard", EnvironmentMacroScope));
#elif NETCOREAPP
            Macros.Add(new MacroParameter("platform", ".NET Core", EnvironmentMacroScope));
#else
            Macros.Add(new MacroParameter("platform", ".NET", EnvironmentMacroScope));
#endif
        }
    }
}