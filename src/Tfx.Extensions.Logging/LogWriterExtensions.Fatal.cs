// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

namespace Niacomsoft.TeamFramework.Extensions.Logging
{
    public static partial class LogWriterExtensions
    {
        /// <summary> 当条件表达式 <paramref name="where" /> 等于 <see langword="true" /> 时记录运行时致命级别异常日志。 </summary>
        /// <param name="this"> 实现了 <see cref="ILogWriter" /> 类型接口的对象实例。 </param>
        /// <param name="where"> 条件表达式。 </param>
        /// <param name="message"> 运行时日志描述信息。 </param>
        /// <param name="category"> 运行时日志类别。 </param>
        /// <returns> 参数 <paramref name="where" /> 值。 </returns>
        /// <seealso cref="LogLevel" />
        /// <seealso cref="LogLevel.Fatal" />
        public static bool LogFatalIf(this ILogWriter @this, bool where, string message, string category = null)
        {
            if (where)
            {
                @this.LogFatal(message, category);
            }

            return where;
        }

        /// <summary> 当条件表达式 <paramref name="where" /> 等于 <see langword="true" /> 时记录运行时致命级别异常日志。 </summary>
        /// <param name="this"> 实现了 <see cref="ILogWriter" /> 类型接口的对象实例。 </param>
        /// <param name="where"> 条件表达式。 </param>
        /// <param name="message"> 运行时日志描述信息。 </param>
        /// <param name="category">
        /// 标识运行时日志类别的类型。
        /// <para> <see cref="Type" /> 类型的对象实例。 </para>
        /// </param>
        /// <returns> 参数 <paramref name="where" /> 值。 </returns>
        /// <seealso cref="LogLevel" />
        /// <seealso cref="LogLevel.Fatal" />
        /// <seealso cref="Type" />
        public static bool LogFatalIf(this ILogWriter @this, bool where, string message, Type category)
        {
            if (where)
            {
                @this.LogFatal(message, category);
            }

            return where;
        }

        /// <summary> 当条件表达式 <paramref name="where" /> 等于 <see langword="true" /> 时记录运行时致命级别异常日志。 </summary>
        /// <typeparam name="TCategory"> 标识运行时日志类别的类型。 </typeparam>
        /// <param name="this"> 实现了 <see cref="ILogWriter" /> 类型接口的对象实例。 </param>
        /// <param name="where"> 条件表达式。 </param>
        /// <param name="message"> 运行时日志描述信息。 </param>
        /// <returns> 参数 <paramref name="where" /> 值。 </returns>
        /// <seealso cref="LogLevel" />
        /// <seealso cref="LogLevel.Fatal" />
        public static bool LogFatalIf<TCategory>(this ILogWriter @this, bool where, string message)
        {
            if (where)
            {
                @this.LogFatal<TCategory>(message);
            }

            return where;
        }

        /// <summary> 当条件表达式 <paramref name="where" /> 等于 <see langword="true" /> 时记录运行时致命级别异常日志。 </summary>
        /// <param name="this"> 实现了 <see cref="ILogWriter" /> 类型接口的对象实例。 </param>
        /// <param name="where"> 条件表达式。 </param>
        /// <param name="error">
        /// 运行时异常。
        /// <para> <see cref="Exception" /> 类型的对象实例。 </para>
        /// </param>
        /// <param name="cause"> 引发运行时异常的原因。 </param>
        /// <returns> 参数 <paramref name="where" /> 值。 </returns>
        /// <seealso cref="Exception" />
        /// <seealso cref="LogLevel" />
        /// <seealso cref="LogLevel.Fatal" />
        public static bool LogFatalIf(this ILogWriter @this, bool where, Exception error, string cause = null)
        {
            if (where)
            {
                @this.LogFatal(error, cause);
            }

            return where;
        }

        /// <summary> 当条件表达式 <paramref name="where" /> 等于 <see langword="true" /> 时记录运行时致命级别异常日志。 </summary>
        /// <typeparam name="TCategory"> 标识运行时日志类别的类型。 </typeparam>
        /// <param name="this"> 实现了 <see cref="ILogWriter" /> 类型接口的对象实例。 </param>
        /// <param name="where"> 条件表达式。 </param>
        /// <param name="error">
        /// 运行时异常。
        /// <para> <see cref="Exception" /> 类型的对象实例。 </para>
        /// </param>
        /// <param name="cause"> 引发运行时异常的原因。 </param>
        /// <returns> 参数 <paramref name="where" /> 值。 </returns>
        /// <seealso cref="Exception" />
        /// <seealso cref="LogLevel" />
        /// <seealso cref="LogLevel.Fatal" />
        public static bool LogFatalIf<TCategory>(this ILogWriter @this, bool where, Exception error, string cause = null)
        {
            if (where)
            {
                @this.LogFatal<TCategory>(error, cause);
            }

            return where;
        }
    }
}