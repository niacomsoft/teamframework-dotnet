// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;
using System.Collections;

using Niacomsoft.Utilities;

namespace Niacomsoft
{
    /// <summary> 提供了环境变量相关的基本方法。 </summary>
    public partial class EnvironmentVariable
    {
        private static readonly Hashtable CachedEnvironmentVars = new Hashtable();

        /// <summary> 初始化 <see cref="EnvironmentVariable" /> 类的新实例。 </summary>
        /// <param name="name"> 环境变量名称。 </param>
        /// <param name="value"> 环境变量值。 </param>
        /// <param name="targetLocation">
        /// 指定环境变量存在的位置。
        /// <para> <see cref="EnvironmentVariableTarget" /> 中的一个值。 </para>
        /// </param>
        protected EnvironmentVariable(string name, string value, EnvironmentVariableTarget targetLocation)
        {
            Name = name;
            Value = value;
            TargetLocation = targetLocation;
        }

        /// <summary> 环境变量名称。 </summary>
        /// <value> 获取一个字符串，用于表示环境变量名称。 </value>
        public virtual string Name { get; }

        /// <summary>
        /// 指定环境变量存在的位置。
        /// <para> <see cref="EnvironmentVariableTarget" /> 中的一个值。 </para>
        /// </summary>
        /// <value> 获取一个 <see cref="EnvironmentVariableTarget" /> 类型值，用于表示指定环境变量存在的位置。 </value>
        /// <seealso cref="EnvironmentVariableTarget" />
        public virtual EnvironmentVariableTarget TargetLocation { get; }

        /// <summary> 环境变量值。 </summary>
        /// <value> 获取一个字符串，用于表示环境变量值。 </value>
        public virtual string Value { get; }

        /// <summary> 尝试从缓存区中检索指定名称 <paramref name="name" /> 的环境变量。 </summary>
        /// <param name="name"> 环境变量名称。 </param>
        /// <param name="envVar">
        /// 环境变量值。
        /// <para> <see cref="EnvironmentVariable" /> 类型的对象实例。 </para>
        /// </param>
        /// <param name="hasCached"> 缓存区中是否包含了变量名称。 </param>
        /// <returns>
        /// 当缓存区中包含了名称为 <paramref name="name" /> 的环境变量且 <paramref name="envVar" /> 不等于 <see langword="null" /> 时，则返回
        /// <see langword="true" />；否则返回 <see langword="false" />。
        /// </returns>
        private static bool TryGetEnvironmentVarFromCache(string name, out EnvironmentVariable envVar, out bool hasCached)
        {
            envVar = null;
            hasCached = true;
            if (CachedEnvironmentVars.ContainsKey(name))
            {
                envVar = CachedEnvironmentVars[name] as EnvironmentVariable;
                return AssertUtilities.NotNull(envVar);
            }
            hasCached = false;
            return false;
        }

        /// <summary> 从指定位置 <paramref name="target" /> 搜索名称为 <paramref name="name" /> 的环境变量。 </summary>
        /// <param name="name"> 环境变量名称。 </param>
        /// <param name="target">
        /// 指定的环境变量搜索位置。
        /// <para> <see cref="EnvironmentVariableTarget" /> 中的一个值。 </para>
        /// </param>
        /// <returns> 环境变量信息。 </returns>
        /// <seealso cref="EnvironmentVariableTarget" />
        private static EnvironmentVariable InternalGetEnvironmentVar(string name, EnvironmentVariableTarget target)
        {
            var envValue = Environment.GetEnvironmentVariable(name, target);
            if (!AssertUtilities.IsEmpty(envValue, EmptyComparisonOptions.NullOrEmpty))
            {
                var envVar = new EnvironmentVariable(name, envValue, target);
                CachedEnvironmentVars.Add(name, envVar);
                return envVar;
            }
            else if (target != EnvironmentVariableTarget.Machine)
            {
                return InternalGetEnvironmentVar(name, (EnvironmentVariableTarget)((int)target + 1));
            }
            else
            {
                CachedEnvironmentVars.Add(name, string.Empty);
                return InternalGetEnvironmentVar(name, EnvironmentVariableTarget.Machine);
            }
        }

        /// <summary> 尝试搜索名称为 <paramref name="name" /> 的环境变量信息。 </summary>
        /// <param name="name"> 环境变量名称。 </param>
        /// <returns>
        /// 指定的环境变量信息。
        /// <para> <see cref="EnvironmentVariable" /> 类型的对象实例。 </para>
        /// </returns>
        /// <seealso cref="EnvironmentVariable" />
        /// <exception cref="ArgumentException">
        /// 当 <paramref name="name" /> 等于 <see langword="null" /> 或 <see cref="string.Empty" /> 时，将引发此类型的异常。
        /// </exception>
        public static EnvironmentVariable GetEnvironmentVariable(string name)
        {
            if (AssertUtilities.IsEmpty(name, EmptyComparisonOptions.NullOrEmpty))
            {
#pragma warning disable Ex0100 // Member may throw undocumented exception
                throw new ArgumentException(SR.Format("ArgumentException_with_parameter_name", nameof(name)), nameof(name));
#pragma warning restore Ex0100 // Member may throw undocumented exception
            }

            return TryGetEnvironmentVarFromCache(name, out EnvironmentVariable envVar, out bool hasCached)
                ? envVar
                : hasCached ? null : InternalGetEnvironmentVar(name, EnvironmentVariableTarget.Process);
        }
    }
}