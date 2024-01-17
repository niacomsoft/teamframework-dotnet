// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;
using System.Diagnostics.CodeAnalysis;

namespace Niacomsoft.Security.Authentication
{
    /// <summary> 提供了生成密码相关的基本方法。 </summary>
    /// <seealso cref="IPasswordGenerator" />
    public class PasswordGenerator : IPasswordGenerator
    {
        /// <summary> 最小的密码长度。 </summary>
        public const int MinimumLength = 6;

#if NET45_OR_GREATER || NETSTANDARD || NETCOREAPP || NET

        /// <summary> 初始化 <see cref="PasswordGenerator" /> 类的新实例。 </summary>
        /// <seealso cref="SecretKeyAlphabet.Default" />
        /// <exception cref="System.MemberAccessException"> 当访问 <see cref="SecretKeyAlphabet.Default" /> 字段时，可能引发此类型的异常。 </exception>
        public PasswordGenerator() : this(SecretKeyAlphabet.Default.Value)
        {
        }

#else

        /// <summary> 初始化 <see cref="PasswordGenerator" /> 类的新实例。 </summary>
        /// <seealso cref="SecretKeyAlphabet.Default" />
        public PasswordGenerator() : this(SecretKeyAlphabet.Default)
        {
        }

#endif

        /// <summary> 初始化 <see cref="PasswordGenerator" /> 类的新实例。 </summary>
        /// <param name="pwdAlphabet">
        /// 生成密码的字母表。
        /// <para> <see cref="ISecretKeyAlphabet" /> 类型的对象实例。 </para>
        /// </param>
        public PasswordGenerator(ISecretKeyAlphabet pwdAlphabet)
            : this(pwdAlphabet, new RandomAlgorithmsFactory())
        {
        }

        /// <summary> 初始化 <see cref="PasswordGenerator" /> 类的新实例。 </summary>
        /// <param name="pwdAlphabet">
        /// 生成密码的字母表。
        /// <para> <see cref="ISecretKeyAlphabet" /> 类型的对象实例。 </para>
        /// </param>
        /// <param name="randomAlgFactory">
        /// 创建随机数方法的工厂方法。
        /// <para> <see cref="IRandomAlgorithmsFactory" /> 类型的对象实例。 </para>
        /// </param>
        [SuppressMessage("Design", "Ex0100:Member may throw undocumented exception", Justification = "<挂起>")]
        public PasswordGenerator(ISecretKeyAlphabet pwdAlphabet, IRandomAlgorithmsFactory randomAlgFactory)
            : this(pwdAlphabet, randomAlgFactory.Create(pwdAlphabet.Alphabet.Length))
        {
        }

        /// <summary> 初始化 <see cref="PasswordGenerator" /> 类的新实例。 </summary>
        /// <param name="pwdAlphabet">
        /// 生成密码的字母表。
        /// <para> <see cref="ISecretKeyAlphabet" /> 类型的对象实例。 </para>
        /// </param>
        /// <param name="randomAlg">
        /// 随机数算法。
        /// <para> <see cref="IRandomAlgorithms" /> 类型的对象实例。 </para>
        /// </param>
        protected PasswordGenerator(ISecretKeyAlphabet pwdAlphabet, IRandomAlgorithms randomAlg)
        {
            PasswordAlphabet = pwdAlphabet;
            Random = randomAlg;
        }

        /// <inheritdoc />
        public virtual ISecretKeyAlphabet PasswordAlphabet { get; }

        /// <inheritdoc />
        public virtual IRandomAlgorithms Random { get; }

        /// <inheritdoc />
        /// <exception cref="OverflowException"> 当访问 <see cref="Array.Length" /> 属性时，可能引发此类型的异常。 </exception>
        [SuppressMessage("Design", "Ex0200:Member is documented as throwing exception not documented on member in base or interface type", Justification = "<挂起>")]
        public virtual string CreateNew(int length)
        {
            var pwdLength = length < MinimumLength || length > PasswordAlphabet.Alphabet.Length ? MinimumLength : length;
            var pwdIndexes = Random.Shuffle().GetValues(pwdLength);
            var pwdChars = new char[pwdLength];
            for (int i = 0; i < pwdLength; i++)
            {
                pwdChars[i] = PasswordAlphabet.Alphabet[pwdIndexes[i]];
            }
            return new string(pwdChars);
        }
    }
}