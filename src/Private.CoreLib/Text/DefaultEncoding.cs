// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System.Text;

namespace Niacomsoft.Text
{
    /// <summary> 提供了默认的文本编码程序相关的方法。 </summary>
    public static class DefaultEncoding
    {
        /// <summary> 默认的文本编码。 </summary>
        /// <seealso cref="Encoding" />
        /// <seealso cref="Encoding.UTF8" />
        /// <seealso cref="UTF8Encoding" />
        public static readonly Encoding Value = Encoding.UTF8;
    }
}