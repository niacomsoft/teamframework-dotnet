// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

namespace Niacomsoft
{
    /// <summary> 提供了环境变量相关的基本方法。 </summary>
    public class EnvironmentVariable
    {
        /// <summary>
        /// 指定环境变量存在的位置。
        /// <para> <see cref="EnvironmentVariableTarget" /> 中的一个值。 </para>
        /// </summary>
        /// <value> 获取一个 <see cref="EnvironmentVariableTarget" /> 类型值，用于表示指定环境变量存在的位置。 </value>
        /// <seealso cref="EnvironmentVariableTarget" />
        public virtual EnvironmentVariableTarget TargetLocation { get; }
    }
}