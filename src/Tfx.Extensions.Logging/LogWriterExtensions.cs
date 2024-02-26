// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

namespace Niacomsoft.TeamFramework.Extensions.Logging
{
    /// <summary> 为 <see cref="ILogWriter" /> 类型提供的扩展方法。 </summary>
    public static partial class LogWriterExtensions
    {
        /// <summary> 当条件表达式 <pararef name="where" /> 等于 <see langword="true" /> 时， 记录运行时日志。 </summary>
        /// <param name="this"> 实现了 <see cref="ILogWriter" /> 类型接口的对象实例。 </param>
        /// <param name="where"> 条件表达式。 </param>
        /// <param name="entry">
        /// 运行时日志项。
        /// <para> <see cref="LogEntry" /> 类型的对象实例。 </para>
        /// </param>
        /// <returns> 参数 <paramref name="where" /> 值。 </returns>
        /// <seealso cref="LogEntry" />
        public static bool WriteIf(this ILogWriter @this, bool where, LogEntry entry)
        {
            if (where)
            {
                @this.Write(entry);
            }

            return where;
        }

        /// <summary> 当条件表达式 <pararef name="where" /> 等于 <see langword="true" /> 时， 记录运行时日志。 </summary>
        /// <typeparam name="TCategory"> 标识运行时日志的类别。 </typeparam>
        /// <param name="this"> 实现了 <see cref="ILogWriter" /> 类型接口的对象实例。 </param>
        /// <param name="where"> 条件表达式。 </param>
        /// <param name="entry">
        /// 运行时日志项。
        /// <para> <see cref="LogEntry{TCategory}" /> 类型的对象实例。 </para>
        /// </param>
        /// <returns> 参数 <paramref name="where" /> 值。 </returns>
        /// <seealso cref="LogEntry{TCategory}" />
        public static bool WriteIf<TCategory>(this ILogWriter @this, bool where, LogEntry<TCategory> entry)
        {
            if (where)
            {
                @this.Write(entry);
            }

            return where;
        }

        /// <summary> 当条件表达式 <pararef name="where" /> 等于 <see langword="true" /> 时， 记录运行时日志。 </summary>
        /// <param name="this"> 实现了 <see cref="ILogWriter" /> 类型接口的对象实例。 </param>
        /// <param name="where"> 条件表达式。 </param>
        /// <param name="message"> 运行时日志描述信息。 </param>
        /// <param name="category"> 运行时日志类别。 </param>
        /// <param name="level">
        /// 运行时日志级别。
        /// <para> <see cref="LogLevel" /> 中的一个值。 </para>
        /// </param>
        /// <returns> 参数 <paramref name="where" /> 值。 </returns>
        /// <seealso cref="LogLevel" />
        public static bool WriteIf(this ILogWriter @this, bool where, string message, string category = null, LogLevel level = LogLevel.Default)
        {
            if (where)
            {
                @this.Write(message, category, level);
            }

            return where;
        }

        /// <summary> 当条件表达式 <pararef name="where" /> 等于 <see langword="true" /> 时， 记录运行时日志。 </summary>
        /// <param name="this"> 实现了 <see cref="ILogWriter" /> 类型接口的对象实例。 </param>
        /// <param name="where"> 条件表达式。 </param>
        /// <param name="message"> 运行时日志描述信息。 </param>
        /// <param name="category">
        /// 标识运行时日志类别的类型。
        /// <para> <see cref="Type" /> 类型的对象实例。 </para>
        /// </param>
        /// <param name="level">
        /// 运行时日志级别。
        /// <para> <see cref="LogLevel" /> 中的一个值。 </para>
        /// </param>
        /// <returns> 参数 <paramref name="where" /> 值。 </returns>
        /// <seealso cref="LogLevel" />
        /// <seealso cref="Type" />
        public static bool WriteIf(this ILogWriter @this, bool where, string message, Type category, LogLevel level = LogLevel.Default)
        {
            if (where)
            {
                @this.Write(message, category, level);
            }

            return where;
        }

        /// <summary> 当条件表达式 <pararef name="where" /> 等于 <see langword="true" /> 时， 记录运行时日志。 </summary>
        /// <typeparam name="TCategory"> 标识运行时日志类别的类型。 </typeparam>
        /// <param name="this"> 实现了 <see cref="ILogWriter" /> 类型接口的对象实例。 </param>
        /// <param name="where"> 条件表达式。 </param>
        /// <param name="message"> 运行时日志描述信息。 </param>
        /// <param name="level">
        /// 运行时日志级别。
        /// <para> <see cref="LogLevel" /> 中的一个值。 </para>
        /// </param>
        /// <returns> 参数 <paramref name="where" /> 值。 </returns>
        /// <seealso cref="LogLevel" />
        public static bool WriteIf<TCategory>(this ILogWriter @this, bool where, string message, LogLevel level = LogLevel.Default)
        {
            if (where)
            {
                @this.Write<TCategory>(message, level);
            }

            return where;
        }

        /// <summary> 当条件表达式 <pararef name="where" /> 等于 <see langword="true" /> 时， 记录运行时异常日志。 </summary>
        /// <param name="this"> 实现了 <see cref="ILogWriter" /> 类型接口的对象实例。 </param>
        /// <param name="where"> 条件表达式。 </param>
        /// <param name="error">
        /// 运行时异常。
        /// <para> <see cref="Exception" /> 类型的对象实例。 </para>
        /// </param>
        /// <param name="cause"> 引发运行时异常的原因。 </param>
        /// <param name="level">
        /// 运行时异常级别。
        /// <para> <see cref="LogLevel" /> 中的一个值。 </para>
        /// </param>
        /// <returns> 参数 <paramref name="where" /> 值。 </returns>
        /// <seealso cref="Exception" />
        /// <seealso cref="LogLevel" />
        public static bool WriteIf(this ILogWriter @this, bool where, Exception error, string cause = null, LogLevel level = LogLevel.Fatal)
        {
            if (where)
            {
                @this.Write(error, cause, level);
            }

            return where;
        }

        /// <summary> 当条件表达式 <pararef name="where" /> 等于 <see langword="true" /> 时， 记录运行时异常日志。 </summary>
        /// <typeparam name="TCategory"> 标识运行时日志类别的类型。 </typeparam>
        /// <param name="this"> 实现了 <see cref="ILogWriter" /> 类型接口的对象实例。 </param>
        /// <param name="where"> 条件表达式。 </param>
        /// <param name="error">
        /// 运行时异常。
        /// <para> <see cref="Exception" /> 类型的对象实例。 </para>
        /// </param>
        /// <param name="cause"> 引发运行时异常的原因。 </param>
        /// <param name="level">
        /// 运行时异常级别。
        /// <para> <see cref="LogLevel" /> 中的一个值。 </para>
        /// </param>
        /// <returns> 参数 <paramref name="where" /> 值。 </returns>
        /// <seealso cref="Exception" />
        /// <seealso cref="LogLevel" />
        public static bool WriteIf<TCategory>(this ILogWriter @this, bool where, Exception error, string cause = null, LogLevel level = LogLevel.Fatal)
        {
            if (where)
            {
                @this.Write<TCategory>(error, cause, level);
            }

            return where;
        }
    }
}