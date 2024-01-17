// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft.Security.Authentication
{
    /// <summary> 定义了生成密码的接口。 </summary>
    public interface IPasswordGenerator
    {
        /// <summary> 用于生成密码的密钥字母表。 </summary>
        /// <value> 获取 <see cref="ISecretKeyAlphabet" /> 类型的对象实例，用于表示用于生成密码的密钥字母表。 </value>
        /// <seealso cref="ISecretKeyAlphabet" />
        ISecretKeyAlphabet PasswordAlphabet { get; }

        /// <summary> 随机数算法。 </summary>
        /// <value> 获取 <see cref="IRandomAlgorithms" /> 类型的对象实例，用于表示随机数算法。 </value>
        /// <seealso cref="IRandomAlgorithms" />
        IRandomAlgorithms Random { get; }

        /// <summary> 创建一个新的密码。 </summary>
        /// <param name="length"> 密码长度。 </param>
        /// <returns> 新的密码。 </returns>
        string CreateNew(int length);
    }
}