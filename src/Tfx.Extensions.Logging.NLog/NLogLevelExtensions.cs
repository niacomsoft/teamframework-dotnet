// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using NLogLevel = NLog.LogLevel;

namespace Niacomsoft.TeamFramework.Extensions.Logging
{
    /// <summary> 为 <see cref="LogLevel" /> 类型提供的扩展方法。 </summary>
    public static class NLogLevelExtensions
    {
        /// <summary> 将 <see cref="LogLevel" /> 转换成 <see cref="NLogLevel" /> 类型的值。 </summary>
        /// <param name="this"> <see cref="LogLevel" /> 中的一个值。 </param>
        /// <returns> 等效的 <see cref="NLogLevel" /> 中的一个值。 </returns>
        /// <seealso cref="NLogLevel" />
        public static NLogLevel ToNLogLevel(this LogLevel @this)
        {
            switch (@this)
            {
                case LogLevel.Trace: return NLogLevel.Trace;
                case LogLevel.Debug: return NLogLevel.Debug;
                case LogLevel.Information: return NLogLevel.Info;
                case LogLevel.Warning: return NLogLevel.Warn;
                case LogLevel.Error: return NLogLevel.Error;
                case LogLevel.Fatal: return NLogLevel.Fatal;
                default:
#if DEBUG
                    return NLogLevel.Debug;
#else
                    return NLogLevel.Info;
#endif
            }
        }
    }
}