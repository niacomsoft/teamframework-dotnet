// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

namespace Niacomsoft.TeamFramework.Extensions.Logging
{
    /// <summary> 定义了记录运行时日志的接口。 </summary>
    public partial interface ILogWriter
    {
        /// <summary> 记录运行时日志。 </summary>
        /// <param name="entry">
        /// 运行时日志项。
        /// <para> <see cref="LogEntry" /> 类型的对象实例。 </para>
        /// </param>
        /// <seealso cref="LogEntry" />
        void Write(LogEntry entry);

        /// <summary> 记录运行时日志。 </summary>
        /// <typeparam name="TCategory"> 标识运行时日志的类别。 </typeparam>
        /// <param name="entry">
        /// 运行时日志项。
        /// <para> <see cref="LogEntry{TCategory}" /> 类型的对象实例。 </para>
        /// </param>
        /// <seealso cref="LogEntry{TCategory}" />
        void Write<TCategory>(LogEntry<TCategory> entry);

        /// <summary> 记录运行时日志。 </summary>
        /// <param name="message"> 运行时日志描述信息。 </param>
        /// <param name="category"> 运行时日志类别。 </param>
        /// <param name="level">
        /// 运行时日志级别。
        /// <para> <see cref="LogLevel" /> 中的一个值。 </para>
        /// </param>
        /// <seealso cref="LogLevel" />
        void Write(string message, string category = null, LogLevel level = LogLevel.Default);

        /// <summary> 记录运行时日志。 </summary>
        /// <param name="message"> 运行时日志描述信息。 </param>
        /// <param name="category">
        /// 标识运行时日志类别的类型。
        /// <para> <see cref="Type" /> 类型的对象实例。 </para>
        /// </param>
        /// <param name="level">
        /// 运行时日志级别。
        /// <para> <see cref="LogLevel" /> 中的一个值。 </para>
        /// </param>
        /// <seealso cref="LogLevel" />
        /// <seealso cref="Type" />
        void Write(string message, Type category = null, LogLevel level = LogLevel.Default);

        /// <summary> 记录运行时日志。 </summary>
        /// <typeparam name="TCategory"> 标识运行时日志类别的类型。 </typeparam>
        /// <param name="message"> 运行时日志描述信息。 </param>
        /// <param name="level">
        /// 运行时日志级别。
        /// <para> <see cref="LogLevel" /> 中的一个值。 </para>
        /// </param>
        /// <seealso cref="LogLevel" />
        void Write<TCategory>(string message, LogLevel level = LogLevel.Default);

        /// <summary> 记录运行时异常日志。 </summary>
        /// <param name="error">
        /// 运行时异常。
        /// <para> <see cref="Exception" /> 类型的对象实例。 </para>
        /// </param>
        /// <param name="cause"> 引发运行时异常的原因。 </param>
        /// <param name="level">
        /// 运行时异常级别。
        /// <para> <see cref="LogLevel" /> 中的一个值。 </para>
        /// </param>
        /// <seealso cref="Exception" />
        /// <seealso cref="LogLevel" />
        void Write(Exception error, string cause = null, LogLevel level = LogLevel.Fatal);

        /// <summary> 记录运行时异常日志。 </summary>
        /// <typeparam name="TCategory"> 标识运行时日志类别的类型。 </typeparam>
        /// <param name="error">
        /// 运行时异常。
        /// <para> <see cref="Exception" /> 类型的对象实例。 </para>
        /// </param>
        /// <param name="cause"> 引发运行时异常的原因。 </param>
        /// <param name="level">
        /// 运行时异常级别。
        /// <para> <see cref="LogLevel" /> 中的一个值。 </para>
        /// </param>
        /// <seealso cref="Exception" />
        /// <seealso cref="LogLevel" />
        void Write<TCategory>(Exception error, string cause = null, LogLevel level = LogLevel.Fatal);
    }
}