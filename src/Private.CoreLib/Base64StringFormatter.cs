// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;
using System.Diagnostics.CodeAnalysis;

using Niacomsoft.IO;
using Niacomsoft.Utilities;

namespace Niacomsoft
{
    /// <summary> 提供了 BASE-64 字符串格式化相关的方法。密闭的，不可以从此类型派生。 </summary>
    /// <seealso cref="IBase64StringDecoder" />
    /// <seealso cref="IBase64StringEncoder" />
    /// <remarks> 密闭的，不可以从此类型派生。 </remarks>
    public sealed class Base64StringFormatter : IBase64StringDecoder, IBase64StringEncoder
    {
#if NET45_OR_GREATER || NETSTANDARD || NETCOREAPP || NET
#pragma warning disable IDE1006 // 命名样式
        private static readonly Lazy<Base64StringFormatter> s_instance = new Lazy<Base64StringFormatter>(() => new Base64StringFormatter(), true);
#pragma warning restore IDE1006 // 命名样式
#else
        private static readonly Base64StringFormatter s_instance = new Base64StringFormatter();
#endif

        /// <summary> 初始化 <see cref="Base64StringFormatter" /> 类的新实例。 </summary>
        public Base64StringFormatter()
        {
        }

        /// <inheritdoc />
        public byte[] GetBytes(string base64Str)
            => AssertUtilities.IsNull(base64Str)
                ? null
                : Convert.FromBase64String(base64Str);

        /// <inheritdoc />
        [SuppressMessage("Design", "Ex0100:Member may throw undocumented exception", Justification = "<挂起>")]
        public string GetString(byte[] input, ByteArrayOptions encodeOptions = null, Base64FormattingOptions formatOptions = Base64FormattingOptions.None)
        {
            if (AssertUtilities.IsNull(input))
            {
                return null;
            }
            if (AssertUtilities.IsNull(encodeOptions))
            {
                encodeOptions = ByteArrayOptions.FromByteArray(input);
            }
            return Convert.ToBase64String(input, encodeOptions.Index, encodeOptions.Count, formatOptions);
        }

        /// <summary> 获取 BASE-64 字符串编码程序。 </summary>
        /// <returns> 实现了 <see cref="IBase64StringEncoder" /> 类型接口的对象实例。 </returns>
        /// <seealso cref="IBase64StringEncoder" />
        public static IBase64StringEncoder CreateEncoder()
        {
#if NET45_OR_GREATER || NETSTANDARD || NETCOREAPP || NET
#pragma warning disable Ex0100 // Member may throw undocumented exception
            return s_instance.Value;
#pragma warning restore Ex0100 // Member may throw undocumented exception
#else
            return s_instance;
#endif
        }

        /// <summary> 获取 BASE-64 字符串解码码程序。 </summary>
        /// <returns> 实现了 <see cref="IBase64StringDecoder" /> 类型接口的对象实例。 </returns>
        /// <seealso cref="IBase64StringDecoder" />
        public static IBase64StringDecoder CreateDecoder()
        {
#if NET45_OR_GREATER || NETSTANDARD || NETCOREAPP || NET
#pragma warning disable Ex0100 // Member may throw undocumented exception
            return s_instance.Value;
#pragma warning restore Ex0100 // Member may throw undocumented exception
#else
            return s_instance;
#endif
        }
    }
}