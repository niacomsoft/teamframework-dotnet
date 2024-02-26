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
        public virtual void LogDebug(string message, string category = null)
        {
            Write(message, category, LogLevel.Debug);
        }

        /// <inheritdoc />
        public virtual void LogDebug(string message, Type category)
        {
            Write(message, category, LogLevel.Debug);
        }

        /// <inheritdoc />
        public virtual void LogDebug<TCategory>(string message)
        {
            Write<TCategory>(message, LogLevel.Debug);
        }

        /// <inheritdoc />
        public virtual void LogDebug(Exception error, string cause = null)
        {
            Write(error, cause, LogLevel.Debug);
        }

        /// <inheritdoc />
        public virtual void LogDebug<TCategory>(Exception error, string cause = null)
        {
            Write<TCategory>(error, cause, LogLevel.Debug);
        }

        /// <inheritdoc />
        public virtual void LogError(string message, string category = null)
        {
            Write(message, category, LogLevel.Error);
        }

        /// <inheritdoc />
        public virtual void LogError(string message, Type category)
        {
            Write(message, category, LogLevel.Error);
        }

        /// <inheritdoc />
        public virtual void LogError<TCategory>(string message)
        {
            Write<TCategory>(message, LogLevel.Error);
        }

        /// <inheritdoc />
        public virtual void LogError(Exception error, string cause = null)
        {
            Write(error, cause, LogLevel.Error);
        }

        /// <inheritdoc />
        public virtual void LogError<TCategory>(Exception error, string cause = null)
        {
            Write<TCategory>(error, cause, LogLevel.Error);
        }

        /// <inheritdoc />
        public virtual void LogFatal(string message, string category = null)
        {
            Write(message, category, LogLevel.Fatal);
        }

        /// <inheritdoc />
        public virtual void LogFatal(string message, Type category)
        {
            Write(message, category, LogLevel.Fatal);
        }

        /// <inheritdoc />
        public virtual void LogFatal<TCategory>(string message)
        {
            Write<TCategory>(message, LogLevel.Fatal);
        }

        /// <inheritdoc />
        public virtual void LogFatal(Exception error, string cause = null)
        {
            Write(error, cause, LogLevel.Fatal);
        }

        /// <inheritdoc />
        public virtual void LogFatal<TCategory>(Exception error, string cause = null)
        {
            Write<TCategory>(error, cause, LogLevel.Fatal);
        }

        /// <inheritdoc />
        public virtual void LogInformation(string message, string category = null)
        {
            Write(message, category, LogLevel.Information);
        }

        /// <inheritdoc />
        public virtual void LogInformation(string message, Type category)
        {
            Write(message, category, LogLevel.Information);
        }

        /// <inheritdoc />
        public virtual void LogInformation<TCategory>(string message)
        {
            Write<TCategory>(message, LogLevel.Information);
        }

        /// <inheritdoc />
        public virtual void LogInformation(Exception error, string cause = null)
        {
            Write(error, cause, LogLevel.Information);
        }

        /// <inheritdoc />
        public virtual void LogInformation<TCategory>(Exception error, string cause = null)
        {
            Write<TCategory>(error, cause, LogLevel.Information);
        }

        /// <inheritdoc />
        public virtual void LogTrace(string message, string category = null)
        {
            Write(message, category, LogLevel.Trace);
        }

        /// <inheritdoc />
        public virtual void LogTrace(string message, Type category)
        {
            Write(message, category, LogLevel.Trace);
        }

        /// <inheritdoc />
        public virtual void LogTrace<TCategory>(string message)
        {
            Write<TCategory>(message, LogLevel.Trace);
        }

        /// <inheritdoc />
        public virtual void LogTrace(Exception error, string cause = null)
        {
            Write(error, cause, LogLevel.Trace);
        }

        /// <inheritdoc />
        public virtual void LogTrace<TCategory>(Exception error, string cause = null)
        {
            Write<TCategory>(error, cause, LogLevel.Trace);
        }

        /// <inheritdoc />
        public virtual void LogWarning(string message, string category = null)
        {
            Write(message, category, LogLevel.Warning);
        }

        /// <inheritdoc />
        public virtual void LogWarning(string message, Type category)
        {
            Write(message, category, LogLevel.Warning);
        }

        /// <inheritdoc />
        public virtual void LogWarning<TCategory>(string message)
        {
            Write<TCategory>(message, LogLevel.Warning);
        }

        /// <inheritdoc />
        public virtual void LogWarning(Exception error, string cause = null)
        {
            Write(error, cause, LogLevel.Warning);
        }

        /// <inheritdoc />
        public virtual void LogWarning<TCategory>(Exception error, string cause = null)
        {
            Write<TCategory>(error, cause, LogLevel.Warning);
        }

        /// <inheritdoc />
        public abstract void Write(LogEntry entry);

        /// <inheritdoc />
        public virtual void Write<TCategory>(LogEntry<TCategory> entry)
        {
            Write(entry as LogEntry);
        }

        /// <inheritdoc />
        public virtual void Write(string message, string category = null, LogLevel level = LogLevel.Default)
        {
            Write(new LogEntry(message, level, category));
        }

        /// <inheritdoc />
        public virtual void Write(string message, Type category, LogLevel level = LogLevel.Default)
        {
            Write(new LogEntry(message, category, level));
        }

        /// <inheritdoc />
        public virtual void Write<TCategory>(string message, LogLevel level = LogLevel.Default)
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