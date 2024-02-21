// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft.TeamFramework.Extensions.Logging
{
    /// <summary> 定义了管理记录运行时日志方法实例的接口。 </summary>
    /// <seealso cref="ILogWriter" />
    public interface ILogWriterFactory
    {
        /// <summary> 创建记录运行时日志方法实例。 </summary>
        /// <returns>
        /// 记录运行时日志方法实例。
        /// <para> 实现了 <see cref="ILogWriter" /> 类型接口的对象实例。 </para>
        /// </returns>
        /// <seealso cref="ILogWriter" />
        ILogWriter Create();
    }
}