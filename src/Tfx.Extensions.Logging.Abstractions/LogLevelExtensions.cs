// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft.TeamFramework.Extensions.Logging
{
    /// <summary> 为 <see cref="LogLevel" /> 类型提供的扩展方法。 </summary>
    public static class LogLevelExtensions
    {
        /// <summary> 获取 <see cref="LogLevel" /> 中的一个值的描述文本内容。 </summary>
        /// <param name="this"> <see cref="LogLevel" /> 中的一个值。 </param>
        /// <returns> 等效的描述内容。 </returns>
        public static string GetDescription(this LogLevel @this)
        {
            return SR.GetString($"{nameof(LogLevel)}_{@this}");
        }
    }
}