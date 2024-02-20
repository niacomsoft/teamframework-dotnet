// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

namespace Niacomsoft.TeamFramework.Extensions.Logging
{
    public partial interface ILogWriter
    {
        /// <summary> 记录运行时错误日志。 </summary>
        /// <param name="message"> 运行时日志描述信息。 </param>
        /// <param name="category"> 运行时日志类别。 </param>
        /// <seealso cref="LogLevel" />
        /// <seealso cref="LogLevel.Error" />
        void LogError(string message, string category = null);

        /// <summary> 记录运行时错误日志。 </summary>
        /// <param name="message"> 运行时日志描述信息。 </param>
        /// <param name="category">
        /// 标识运行时日志类别的类型。
        /// <para> <see cref="Type" /> 类型的对象实例。 </para>
        /// </param>
        /// <seealso cref="LogLevel" />
        /// <seealso cref="LogLevel.Error" />
        /// <seealso cref="Type" />
        void LogError(string message, Type category = null);

        /// <summary> 记录运行时错误日志。 </summary>
        /// <typeparam name="TCategory"> 标识运行时日志类别的类型。 </typeparam>
        /// <param name="message"> 运行时日志描述信息。 </param>
        /// <seealso cref="LogLevel" />
        /// <seealso cref="LogLevel.Error" />
        void LogError<TCategory>(string message);

        /// <summary> 记录运行时错误级别异常日志。 </summary>
        /// <param name="error">
        /// 运行时异常。
        /// <para> <see cref="Exception" /> 类型的对象实例。 </para>
        /// </param>
        /// <param name="cause"> 引发运行时异常的原因。 </param>
        /// <seealso cref="Exception" />
        /// <seealso cref="LogLevel" />
        /// <seealso cref="LogLevel.Error" />
        void LogError(Exception error, string cause = null);

        /// <summary> 记录运行时错误级别异常日志。 </summary>
        /// <typeparam name="TCategory"> 标识运行时日志类别的类型。 </typeparam>
        /// <param name="error">
        /// 运行时异常。
        /// <para> <see cref="Exception" /> 类型的对象实例。 </para>
        /// </param>
        /// <param name="cause"> 引发运行时异常的原因。 </param>
        /// <seealso cref="Exception" />
        /// <seealso cref="LogLevel" />
        /// <seealso cref="LogLevel.Error" />
        void LogError<TCategory>(Exception error, string cause = null);
    }
}