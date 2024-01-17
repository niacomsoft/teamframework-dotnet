// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;
using System.Diagnostics.CodeAnalysis;

using Niacomsoft.Utilities;

namespace Niacomsoft.Security
{
    /// <summary> 提供了密钥相关的字母表。 </summary>
    /// <seealso cref="ISecretKeyAlphabet" />
    public class SecretKeyAlphabet : ISecretKeyAlphabet
    {
#if NET45_OR_GREATER || NETSTANDARD || NETCOREAPP || NET

        /// <summary> 默认的密钥字母表。 </summary>
        /// <seealso cref="ISecretKeyAlphabet" />
        /// <seealso cref="Lazy{T}" />
        /// <seealso cref="SecretKeyAlphabet" />
        public static readonly Lazy<ISecretKeyAlphabet> Default = new Lazy<ISecretKeyAlphabet>(() => new SecretKeyAlphabet("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_~!@#$%^&*+=<>?"), true);

#else

        /// <summary> 默认的密钥字母表。 </summary>
        /// <seealso cref="ISecretKeyAlphabet" />
        /// <seealso cref="SecretKeyAlphabet" />
        public static readonly ISecretKeyAlphabet Default = new SecretKeyAlphabet("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_~!@#$%^&*+=<>?");

#endif

        /// <summary> 初始化 <see cref="SecretKeyAlphabet" /> 类的新实例。 </summary>
        /// <param name="rawString"> 密钥字符串组成的字符串。 </param>
        /// <exception cref="ArgumentException">
        /// 当 <paramref name="rawString" /> 等于 <see langword="null" />、 <see cref="string.Empty" /> 或全为空白符时，将引发此类型的异常。
        /// </exception>
        [SuppressMessage("Design", "Ex0100:Member may throw undocumented exception", Justification = "<挂起>")]
        public SecretKeyAlphabet(string rawString)
        {
            if (AssertUtilities.IsEmpty(rawString, EmptyComparisonOptions.NullOrWhitespace))
            {
                throw new ArgumentException(SR.Format("ArgumentException_with_parameter_name", nameof(rawString)), nameof(rawString));
            }
            Alphabet = (RawString = rawString).ToCharArray();
        }

        /// <inheritdoc />
        public virtual char[] Alphabet { get; }

        /// <inheritdoc />
        public virtual string RawString { get; }
    }
}