// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using Niacomsoft.Security;

namespace Niacomsoft.TeamFramework.Security.Integer
{
    /// <summary> 提供了计算整型哈希值相关的选项。 </summary>
    public class HashingIntegerOptions
    {
        /// <summary> 默认的生成整型哈希值的最小长度。 </summary>
        public const int DefaultMinLength = 16;

        /// <summary> 默认的字母表。 </summary>
        /// <seealso cref="ISecretKeyAlphabet" />
        /// <seealso cref="SecretKeyAlphabet" />
        public static readonly ISecretKeyAlphabet DefaultAlphabet = new SecretKeyAlphabet("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_-");

        /// <summary> 默认的计算整型哈希值选项。 </summary>
        public static readonly HashingIntegerOptions DefaultOptions = new HashingIntegerOptions();

        /// <summary> 初始化 <see cref="HashingIntegerOptions" /> 类的新实例。 </summary>
        public HashingIntegerOptions() : this(DefaultAlphabet, DefaultMinLength)
        {
        }

        /// <summary> 初始化 <see cref="HashingIntegerOptions" /> 类的新实例。 </summary>
        /// <param name="minLength"> 生成整型哈希值的最小长度。 </param>
        /// <seealso cref="DefaultAlphabet" />
        public HashingIntegerOptions(int minLength) : this(DefaultAlphabet, minLength)
        {
        }

        /// <summary> 初始化 <see cref="HashingIntegerOptions" /> 类的新实例。 </summary>
        /// <param name="alphabet"> 生成整型哈希值的字母表。 </param>
        public HashingIntegerOptions(ISecretKeyAlphabet alphabet) : this(alphabet, DefaultMinLength)
        {
        }

        /// <summary> 初始化 <see cref="HashingIntegerOptions" /> 类的新实例。 </summary>
        /// <param name="alphabet"> 生成整型哈希值的字母表。 </param>
        /// <param name="minLength"> 生成整型哈希值的最小长度。 </param>
        public HashingIntegerOptions(ISecretKeyAlphabet alphabet, int minLength)
        {
            Alphabet = alphabet;
            MinLength = minLength;
        }

        /// <summary> 生成整型哈希值的字母表。 </summary>
        /// <value> 设置或获取 <see cref="ISecretKeyAlphabet" /> 类型的对象实例，用于表示生成整型哈希值的字母表。 </value>
        /// <seealso cref="ISecretKeyAlphabet" />
        public virtual ISecretKeyAlphabet Alphabet { get; set; }

        /// <summary> 生成整型哈希值的最小长度。 </summary>
        /// <value> 设置或获取一个 <see cref="int" /> 类型值，用于表示生成整型哈希值的最小长度。 </value>
        public virtual int? MinLength { get; set; }
    }
}