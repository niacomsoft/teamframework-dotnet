// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;
using System.Diagnostics.CodeAnalysis;

using Niacomsoft.Utilities;

using NLog;

namespace Niacomsoft.TeamFramework.Extensions.Logging
{
    /// <summary> 提供了基于 <see cref="Logger" /> 记录运行时日志相关的方法。 </summary>
    /// <seealso cref="Logger" />
    public class NLogWriter : LogWriter
    {
        /// <summary> 初始化 <see cref="NLogWriter" /> 类的新实例。 </summary>
        /// <seealso cref="LogManager" />
        /// <seealso cref="LogManager.GetCurrentClassLogger()" />
        public NLogWriter() : this(LogManager.GetCurrentClassLogger())
        {
        }

        /// <summary> 初始化 <see cref="NLogWriter" /> 类的新实例。 </summary>
        /// <param name="logger">
        /// 记录运行时日志的方法实现。
        /// <para> <see cref="Logger" /> 类型的对象实例。 </para>
        /// </param>
        /// <exception cref="ArgumentNullException"> 当 <paramref name="logger" /> 为 <see langword="null" /> 值时，将引发此类型的异常。 </exception>
        public NLogWriter(Logger logger)
        {
            if (AssertUtilities.IsNull(logger))
            {
#pragma warning disable Ex0100 // Member may throw undocumented exception
                throw new ArgumentNullException(nameof(logger), SR.Format("ArgumentNullException_with_method_and_parameter_name", nameof(NLogWriter), nameof(logger)));
#pragma warning restore Ex0100 // Member may throw undocumented exception
            }
            InternalLogger = logger;
        }

        /// <summary> 记录运行时日志的方法实现。 </summary>
        /// <value> 获取 ? 类型的对象实例，用于表示记录运行时日志的方法实现。 </value>
        /// <seealso cref="Logger" />
        protected virtual Logger InternalLogger { get; }

        /// <inheritdoc />
        public override void Write(LogEntry entry)
        {
            if (!AssertUtilities.IsEmpty(entry?.Message, EmptyComparisonOptions.NullOrWhitespace))
            {
                InternalLogger.Log(CreateLogEvent(entry));
            }
        }

        /// <summary> 创建 <see cref="LogEventInfo" /> 类型的对象实例。 </summary>
        /// <param name="entry"> <see cref="LogEntry" /> 类型的对象实例。 </param>
        /// <returns> <see cref="LogEventInfo" /> 类型的对象实例。 </returns>
        /// <seealso cref="LogEntry" />
        /// <seealso cref="LogEventInfo" />
        [SuppressMessage("Design", "Ex0100:Member may throw undocumented exception", Justification = "<挂起>")]
        protected virtual LogEventInfo CreateLogEvent(LogEntry entry)
        {
            var eventInfo = new LogEventInfo()
            {
                Level = entry.Level.ToNLogLevel(),
                Message = entry.Message,
                Exception = entry.RuntimeException
            };
            eventInfo.Properties.Add(nameof(entry.ThrownExceptions), entry.ThrownExceptions);
            if (AssertUtilities.NotNull(entry.ExtensibleProperties))
            {
                foreach (var item in entry.ExtensibleProperties)
                {
                    eventInfo.Properties.Add(item.Key, item.Value);
                }
            }
            return eventInfo;
        }
    }
}