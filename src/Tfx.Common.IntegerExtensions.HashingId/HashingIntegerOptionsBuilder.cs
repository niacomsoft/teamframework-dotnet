// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;
using System.Diagnostics.CodeAnalysis;

using Niacomsoft.Diagnostics;
using Niacomsoft.Security;
using Niacomsoft.Utilities;

namespace Niacomsoft.TeamFramework.Security.Integer
{
    /// <summary> 提供了构建 <see cref="HashingIntegerOptions" /> 类型的对象实例相关的方法。 </summary>
    /// <seealso cref="Builder{T}" />
    /// <seealso cref="IHashingIntegerOptionsBuilder" />
    public class HashingIntegerOptionsBuilder : Builder<HashingIntegerOptions>, IHashingIntegerOptionsBuilder
    {
        /// <summary> 初始化 <see cref="HashingIntegerOptionsBuilder" /> 类的新实例。 </summary>
        public HashingIntegerOptionsBuilder()
        {
            Alphabet = HashingIntegerOptions.DefaultAlphabet;
            MinLength = HashingIntegerOptions.DefaultMinLength;
        }

        /// <summary> 构建整型哈希值的字母表。 </summary>
        /// <value> 设置或获取 <see cref="ISecretKeyAlphabet" /> 类型的对象实例，用于表示构建整型哈希值的字母表。 </value>
        /// <seealso cref="ISecretKeyAlphabet" />
        protected virtual ISecretKeyAlphabet Alphabet { get; set; }

        /// <summary> 构建整型哈希值的最小长度。 </summary>
        /// <value> 设置或获取一个 <see cref="int" /> 类型值，用于表示构建整型哈希值的最小长度。 </value>
        protected virtual int MinLength { get; set; }

        /// <inheritdoc />
        public override HashingIntegerOptions Build()
        {
            return new HashingIntegerOptions(Alphabet, MinLength);
        }

        /// <inheritdoc />
        public virtual IHashingIntegerOptionsBuilder WithAlphabet(ISecretKeyAlphabet alphabet)
        {
            Alphabet = Debugger.IfWriteLine(AssertUtilities.IsNull(alphabet), "Invalid \"alphabet\" argument, the default \"HashingIntegerOptions.DefaultAlphabet\" will be used.", null, DebuggingLevel.Debug)
                ? HashingIntegerOptions.DefaultAlphabet
                : alphabet;
            return this;
        }

        /// <inheritdoc />
        public virtual IHashingIntegerOptionsBuilder WithAlphabet(string alphabet)
        {
            return WithAlphabet(AssertUtilities.IsEmpty(alphabet, EmptyComparisonOptions.NullOrWhitespace) ? null : new SecretKeyAlphabet(alphabet));
        }

        /// <inheritdoc />
        /// <exception cref="OverflowException"> 当调用 <see cref="Math.Abs(int)" /> 方法时，可能引发此类型的异常。 </exception>
        [SuppressMessage("Design", "Ex0200:Member is documented as throwing exception not documented on member in base or interface type", Justification = "<挂起>")]
        public virtual IHashingIntegerOptionsBuilder WithMinLength(int minLength = HashingIntegerOptions.DefaultMinLength)
        {
            MinLength = Math.Abs(minLength);
            return this;
        }
    }
}