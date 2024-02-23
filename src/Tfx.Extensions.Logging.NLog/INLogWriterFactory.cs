// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using NLog;

namespace Niacomsoft.TeamFramework.Extensions.Logging
{
    /// <summary> 定义了创建基于 <see cref="NLog" /> 记录运行时日志的方法接口。 </summary>
    /// <seealso cref="ILogWriterFactory" />
    /// <seealso cref="NLogWriter" />
    public interface INLogWriterFactory : ILogWriterFactory
    {
        /// <summary> 使用 <see cref="Logger" /> 类型的对象实例创建运行时日志记录器实例。 </summary>
        /// <param name="logger"> <see cref="Logger" /> 类型的对象实例。 </param>
        /// <returns> <see cref="NLogWriter" /> 类型的对象实例。 </returns>
        /// <seealso cref="Logger" />
        /// <seealso cref="NLogWriter" />
        NLogWriter Create(Logger logger);
    }
}