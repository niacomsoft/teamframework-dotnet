// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

namespace Niacomsoft.TeamFramework.Extensions.Logging
{
    /// <summary> 提供了记录运行时日志相关的 <see langword="abstract" /> 方法。 </summary>
    /// <seealso cref="ILogWriter" />
    public abstract class LogWriter : ILogWriter
    {
        /// <summary> 初始化 <see cref="LogWriter" /> 类的新实例。 </summary>
        protected LogWriter()
        {
        }

        /// <inheritdoc />
        public abstract void LogDebug(string message, string category = null);

        /// <inheritdoc />
        public abstract void LogDebug(string message, Type category = null);

        /// <inheritdoc />
        public abstract void LogDebug<TCategory>(string message);

        /// <inheritdoc />
        public abstract void LogDebug(Exception error, string cause = null);

        /// <inheritdoc />
        public abstract void LogDebug<TCategory>(Exception error, string cause = null);

        /// <inheritdoc />
        public abstract void LogError(string message, string category = null);

        /// <inheritdoc />
        public abstract void LogError(string message, Type category = null);

        /// <inheritdoc />
        public abstract void LogError<TCategory>(string message);

        /// <inheritdoc />
        public abstract void LogError(Exception error, string cause = null);

        /// <inheritdoc />
        public abstract void LogError<TCategory>(Exception error, string cause = null);

        /// <inheritdoc />
        public abstract void LogFatal(string message, string category = null);

        /// <inheritdoc />
        public abstract void LogFatal(string message, Type category = null);

        /// <inheritdoc />
        public abstract void LogFatal<TCategory>(string message);

        /// <inheritdoc />
        public abstract void LogFatal(Exception error, string cause = null);

        /// <inheritdoc />
        public abstract void LogFatal<TCategory>(Exception error, string cause = null);

        /// <inheritdoc />
        public abstract void LogInformation(string message, string category = null);

        /// <inheritdoc />
        public abstract void LogInformation(string message, Type category = null);

        /// <inheritdoc />
        public abstract void LogInformation<TCategory>(string message);

        /// <inheritdoc />
        public abstract void LogInformation(Exception error, string cause = null);

        /// <inheritdoc />
        public abstract void LogInformation<TCategory>(Exception error, string cause = null);

        /// <inheritdoc />
        public abstract void LogTrace(string message, string category = null);

        /// <inheritdoc />
        public abstract void LogTrace(string message, Type category = null);

        /// <inheritdoc />
        public abstract void LogTrace<TCategory>(string message);

        /// <inheritdoc />
        public abstract void LogTrace(Exception error, string cause = null);

        /// <inheritdoc />
        public abstract void LogTrace<TCategory>(Exception error, string cause = null);

        /// <inheritdoc />
        public abstract void LogWarning(string message, string category = null);

        /// <inheritdoc />
        public abstract void LogWarning(string message, Type category = null);

        /// <inheritdoc />
        public abstract void LogWarning<TCategory>(string message);

        /// <inheritdoc />
        public abstract void LogWarning(Exception error, string cause = null);

        /// <inheritdoc />
        public abstract void LogWarning<TCategory>(Exception error, string cause = null);

        /// <inheritdoc />
        public abstract void Write(LogEntry entry);

        /// <inheritdoc />
        public virtual void Write<TCategory>(LogEntry<TCategory> entry)
        {
            Write(entry as LogEntry);
        }

        /// <inheritdoc />
        public virtual void Write(string message, string category = null, LogLevel level = LogLevel.Debug)
        {
            Write(new LogEntry(message, level, category));
        }

        /// <inheritdoc />
        public virtual void Write(string message, Type category = null, LogLevel level = LogLevel.Debug)
        {
            Write(new LogEntry(message, category, level));
        }

        /// <inheritdoc />
        public virtual void Write<TCategory>(string message, LogLevel level = LogLevel.Debug)
        {
            Write(new LogEntry<TCategory>(message, level));
        }

        /// <inheritdoc />
        public virtual void Write(Exception error, string cause = null, LogLevel level = LogLevel.Fatal)
        {
            Write(new LogEntry(error, cause)
            {
                Level = level
            });
        }

        /// <inheritdoc />
        public virtual void Write<TCategory>(Exception error, string cause = null, LogLevel level = LogLevel.Fatal)
        {
            Write(new LogEntry<TCategory>(error, cause)
            {
                Level = level
            });
        }
    }
}