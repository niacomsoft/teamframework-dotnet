// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using Niacomsoft.Utilities;

using NLog;

namespace Niacomsoft.TeamFramework.Extensions.Logging
{
    /// <summary> 提供了创建基于 <see cref="NLog" /> 记录运行时日志相关的工厂方法。 </summary>
    /// <seealso cref="INLogWriterFactory" />
    /// <seealso cref="LogWriterFactory" />
    public class NLogWriterFactory : LogWriterFactory, INLogWriterFactory
    {
        /// <inheritdoc />
        /// <seealso cref="NLogWriter" />
        public override ILogWriter CreateWriter()
        {
            return new NLogWriter();
        }

        /// <inheritdoc />
        public virtual NLogWriter CreateWriter(Logger logger)
        {
            return AssertUtilities.IsNull(logger) ? new NLogWriter() : new NLogWriter(logger);
        }
    }
}