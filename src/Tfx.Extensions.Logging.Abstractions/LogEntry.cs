// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;
using System.Collections.Generic;

using Niacomsoft.Utilities;

namespace Niacomsoft.TeamFramework.Extensions.Logging
{
    /// <summary> 提供了记录运行时日志项信息相关的方法。 </summary>
    public class LogEntry
    {
        /// <summary> 初始化 <see cref="LogEntry" /> 类的新实例。 </summary>
        public LogEntry()
        {
            ExtensibleProperties = new Dictionary<string, object>();
            Level = LogLevel.Default;
        }

        /// <summary> 运行时日志类别名称。 </summary>
        /// <value> 设置或获取一个字符串，用于表示运行时日志类别名称。 </value>
        public virtual string Category { get; set; }

        /// <summary> 运行时日志扩展属性信息。 </summary>
        /// <value> 获取 <see cref="IDictionary{TKey, TValue}" /> 类型的对象实例，用于表示运行时日志扩展属性信息。 </value>
        /// <seealso cref="IDictionary{TKey, TValue}" />
        public virtual IDictionary<string, object> ExtensibleProperties { get; }

        /// <summary> 运行时日志级别。 </summary>
        /// <value> 设置或获取一个 <see cref="LogLevel" /> 类型值，用于表示运行时日志级别。 </value>
        /// <seealso cref="LogLevel" />
        public virtual LogLevel Level { get; set; }

        /// <summary> 运行时日志描述信息。 </summary>
        /// <value> 设置或获取一个字符串，用于表示运行时日志描述信息。 </value>
        public virtual string Message { get; set; }

        /// <summary> 运行时异常。 </summary>
        /// <value> 设置或获取 <see cref="Exception" /> 类型的对象实例，用于表示运行时异常。 </value>
        /// <seealso cref="Exception" />
        public virtual Exception RuntimeException { get; set; }

        /// <summary> 运行时是否抛出了异常。 </summary>
        /// <value> 获取一个 <see cref="bool" /> 类型值，用于表示运行时是否抛出了异常。 </value>
        public virtual bool ThrownExceptions => AssertUtilities.NotNull(RuntimeException);
    }
}