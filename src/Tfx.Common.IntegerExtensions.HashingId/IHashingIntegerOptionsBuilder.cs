// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using Niacomsoft.Security;

namespace Niacomsoft.TeamFramework.Security.Integer
{
    /// <summary> 定义了构建 <see cref="HashingIntegerOptions" /> 类型的对象实例的接口。 </summary>
    /// <seealso cref="HashingIntegerOptions" />
    /// <seealso cref="IBuilder{T}" />
    public interface IHashingIntegerOptionsBuilder : IBuilder<HashingIntegerOptions>
    {
        /// <summary> 指定 <see cref="HashingIntegerOptions.Alphabet" /> 属性。 </summary>
        /// <param name="alphabet"> 整型哈希值的字母表。 </param>
        /// <returns> 当前的 <see cref="IHashingIntegerOptionsBuilder" /> 类型的对象实例 <see langword="this" />。 </returns>
        /// <seealso cref="HashingIntegerOptions.Alphabet" />
        /// <seealso cref="ISecretKeyAlphabet" />
        IHashingIntegerOptionsBuilder WithAlphabet(ISecretKeyAlphabet alphabet);

        /// <summary> 指定 <see cref="HashingIntegerOptions.Alphabet" /> 属性。 </summary>
        /// <param name="alphabet"> 用于初始化 <see cref="ISecretKeyAlphabet" /> 字母表的字符串。 </param>
        /// <returns> 当前的 <see cref="IHashingIntegerOptionsBuilder" /> 类型的对象实例 <see langword="this" />。 </returns>
        /// <seealso cref="HashingIntegerOptions.Alphabet" />
        /// <seealso cref="ISecretKeyAlphabet" />
        /// <seealso cref="WithAlphabet(ISecretKeyAlphabet)" />
        IHashingIntegerOptionsBuilder WithAlphabet(string alphabet);

        /// <summary> 指定 <see cref="HashingIntegerOptions.DefaultMinLength" /> 属性。 </summary>
        /// <param name="minLength"> 整型哈希值的最小长度。 </param>
        /// <returns> 当前的 <see cref="IHashingIntegerOptionsBuilder" /> 类型的对象实例 <see langword="this" />。 </returns>
        /// <seealso cref="HashingIntegerOptions.DefaultMinLength" />
        IHashingIntegerOptionsBuilder WithMinLength(int minLength = HashingIntegerOptions.DefaultMinLength);
    }
}