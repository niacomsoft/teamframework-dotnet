// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft.TeamFramework.Extensions.Logging
{
    /// <summary> 提供了管理记录运行时日志方法实例相关的 <see langword="abstract" /> 方法。 </summary>
    public abstract class LogWriterFactory : ILogWriterFactory
    {
        /// <summary> 初始化 <see cref="LogWriterFactory" /> 类的新实例。 </summary>
        protected LogWriterFactory()
        {
        }

        /// <inheritdoc />
        public abstract ILogWriter Create();
    }
}