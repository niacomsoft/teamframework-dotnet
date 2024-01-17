// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft.Security
{
    /// <summary> 定义了密钥相关字母表的接口。 </summary>
    public interface ISecretKeyAlphabet
    {
        /// <summary> 密钥字母表组成的原始字符串。 </summary>
        /// <value> 获取一个字符串，用于表示密钥字母表组成的原始字符串。 </value>
        string RawString { get; }

        /// <summary> 密钥字母表字符数组。 </summary>
        /// <value> 获取一个 <see cref="char" /> 类型值数组，用于表示密钥字母表字符数组。 </value>
        char[] Alphabet { get; }
    }
}