// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

using Niacomsoft.Utilities;

namespace Niacomsoft.Net
{
    /// <summary> 当提供了一个无效的网络通信端口号数值时，将引发此类型的异常。 </summary>
    /// <seealso cref="Exception" />
    [Serializable]
    public class InvalidPortException : Exception
    {
        /// <summary> 初始化 <see cref="InvalidPortException" /> 类的新实例。 </summary>
        public InvalidPortException() : base(SR.GetString("InvalidPortException_default_message"))
        {
        }

        /// <summary> 用指定的错误消息初始化 <see cref="InvalidPortException" /> 类的新实例。 </summary>
        /// <param name="message"> 描述错误的消息。 </param>
        public InvalidPortException(string message) : base(StringUtilities.IfEmpty(message, SR.GetString("InvalidPortException_default_message"), EmptyComparisonOptions.NullOrWhitespace))
        {
        }

        /// <summary> 使用指定的错误消息和对作为此异常原因的内部异常的引用来初始化 <see cref="InvalidPortException" /> 类的新实例。 </summary>
        /// <param name="message"> 解释异常原因的错误消息。 </param>
        /// <param name="innerException"> 导致当前异常的异常；如果未指定内部异常，则是一个 null 引用（在 Visual Basic 中为 <see langword="Nothing" />）。 </param>
        public InvalidPortException(string message, Exception innerException) : base(StringUtilities.IfEmpty(message, SR.GetString("InvalidPortException_default_message"), EmptyComparisonOptions.NullOrWhitespace), innerException)
        {
        }

        /// <summary> 使用指定的错误消息和对作为此异常原因的内部异常的引用来初始化 <see cref="InvalidPortException" /> 类的新实例。 </summary>
        /// <param name="port"> 错误的网络端口号值。 </param>
        /// <param name="message"> 解释异常原因的错误消息。 </param>
        /// <param name="innerException"> 导致当前异常的异常；如果未指定内部异常，则是一个 null 引用（在 Visual Basic 中为 <see langword="Nothing" />）。 </param>
        [SuppressMessage("Design", "Ex0100:Member may throw undocumented exception", Justification = "<挂起>")]
        public InvalidPortException(int port, string message, Exception innerException) : base(StringUtilities.IfEmpty(message, SR.Format("InvalidPortException_with_port", port), EmptyComparisonOptions.NullOrWhitespace), innerException)
        {
            Port = port;
        }

        /// <summary> 用指定的错误消息初始化 <see cref="InvalidPortException" /> 类的新实例。 </summary>
        /// <param name="port"> 错误的网络端口号值。 </param>
        /// <param name="message"> 描述错误的消息。 </param>
        [SuppressMessage("Design", "Ex0100:Member may throw undocumented exception", Justification = "<挂起>")]
        public InvalidPortException(int port, string message) : base(StringUtilities.IfEmpty(message, SR.Format("InvalidPortException_with_port", port), EmptyComparisonOptions.NullOrWhitespace))
        {
            Port = port;
        }

        /// <summary> 初始化 <see cref="InvalidPortException" /> 类的新实例。 </summary>
        /// <param name="port"> 错误的网络端口号值。 </param>
        [SuppressMessage("Design", "Ex0100:Member may throw undocumented exception", Justification = "<挂起>")]
        public InvalidPortException(int port) : base(SR.Format("InvalidPortException_with_port", port))
        {
            Port = port;
        }

        /// <summary> 用序列化数据初始化 <see cref="InvalidPortException" /> 类的新实例。 </summary>
        /// <param name="info"> 包含有关所引发异常的序列化对象数据的 <see cref="SerializationInfo" />。 </param>
        /// <param name="context"> <see cref="StreamingContext" />，它包含关于源或目标的上下文信息。 </param>
        /// <exception cref="ArgumentNullException"> <paramref name="info" /> 为 <see langword="null" />。 </exception>
        /// <exception cref="SerializationException">
        /// 类名为 <see langword="null" /> 或者 <see cref="P:System.Exception.HResult" /> 为零 (0)。
        /// </exception>
        protected InvalidPortException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            info.AddValue(nameof(Port), Port, typeof(int));
        }

        /// <summary> 无效的网络通信端口号。 </summary>
        /// <value> 获取一个 <see cref="int" /> 类型值，用于表示无效的网络通信端口号。 </value>
        public int Port { get; protected set; }

        /// <summary> 当 <paramref name="port" /> 不是一个有效的网络通信端口号时，将引发一个 <see cref="InvalidPortException" /> 类型的异常。 </summary>
        /// <param name="port"> 需要校验的端口号。 </param>
        /// <exception cref="InvalidPortException"> </exception>
        public static void IfInvalid(int port)
        {
            if (!Net.Port.IsValid(port))
            {
                throw new InvalidPortException(port);
            }
        }

        /// <summary> 当在派生类中重写时，用关于异常的信息设置 <see cref="SerializationInfo" />。 </summary>
        /// <param name="info"> 包含有关所引发异常的序列化对象数据的 <see cref="SerializationInfo" />。 </param>
        /// <param name="context"> <see cref="StreamingContext" />，它包含关于源或目标的上下文信息。 </param>
        /// <exception cref="ArgumentNullException"> <paramref name="info" /> 参数为 null 引用（在 Visual Basic 中为 <see langword="Nothing" />）。 </exception>
        [SuppressMessage("Design", "Ex0100:Member may throw undocumented exception", Justification = "<挂起>")]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            Port = info.GetInt32(nameof(Port));
        }
    }
}