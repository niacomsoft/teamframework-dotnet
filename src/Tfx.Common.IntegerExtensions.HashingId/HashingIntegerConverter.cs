// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using HashidsNet;

using Niacomsoft.Diagnostics;
using Niacomsoft.Utilities;

namespace Niacomsoft.TeamFramework.Security.Integer
{
    /// <summary> 提供了计算整型哈希值相关的方法。 </summary>
    /// <seealso cref="IHashingIntegerConverter" />
    public class HashingIntegerConverter : IHashingIntegerConverter
    {
        /// <summary> 初始化 <see cref="HashingIntegerConverter" /> 类的新实例。 </summary>
        /// <param name="options">
        /// 计算整型哈希值的选项。
        /// <para> 当 <paramref name="options" /> 等于 <see langword="null" /> 时，将使用 <see cref="HashingIntegerOptions.DefaultOptions" />。 </para>
        /// <para> <see cref="HashingIntegerOptions" /> 类型的对象实例。 </para>
        /// </param>
        public HashingIntegerConverter(HashingIntegerOptions options)
        {
            Options = Debugger.IfWriteLine(AssertUtilities.IsNull(options), "Invalid \"Hash Integer\" option, we'll use the default option.", null, DebuggingLevel.Information)
                ? HashingIntegerOptions.DefaultOptions
                : options;
            var minLength = !options.MinLength.HasValue || AssertUtilities.LessThan(options.MinLength.Value) || AssertUtilities.GreatThan(64)
                ? HashingIntegerOptions.DefaultMinLength
                : options.MinLength.Value;
            var alphabet = StringUtilities.IfEmpty(options.Alphabet.RawString, HashingIntegerOptions.DefaultAlphabet.RawString, EmptyComparisonOptions.NullOrWhitespace);
            Provider = new Hashids(minHashLength: minLength, alphabet: alphabet);
        }

        /// <inheritdoc />
        public virtual HashingIntegerOptions Options { get; }

        /// <summary> 计算整型哈希值的服务实例。 </summary>
        /// <value> 获取 <see cref="IHashids" /> 类型的对象实例，用于表示计算整型哈希值的服务实例。 </value>
        /// <seealso cref="IHashids" />
        protected virtual IHashids Provider { get; }

        /// <inheritdoc />
        public virtual string ComputeHash(params long[] values)
        {
            return AssertUtilities.HasItems(values)
                ? Provider.EncodeLong(values)
                : null;
        }

        /// <inheritdoc />
        public virtual long[] FromHashString(string hashStr)
        {
            return AssertUtilities.IsEmpty(hashStr, EmptyComparisonOptions.NullOrWhitespace)
                ? null
                : Provider.DecodeLong(hashStr);
        }
    }
}