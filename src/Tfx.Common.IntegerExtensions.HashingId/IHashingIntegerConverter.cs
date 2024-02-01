// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft.TeamFramework.Security.Integer
{
    /// <summary> 定义了计算整型哈希值的接口。 </summary>
    public interface IHashingIntegerConverter
    {
        /// <summary> 计算整型哈希值的选项。 </summary>
        /// <value> 获取 <see cref="HashingIntegerOptions" /> 类型的对象实例，用于表示计算整型哈希值的选项。 </value>
        /// <seealso cref="HashingIntegerOptions" />
        HashingIntegerOptions Options { get; }

        /// <summary> 计算 <see cref="long" /> 数组 <paramref name="values" /> 等效的哈希字符串。 </summary>
        /// <param name="values"> <see cref="long" /> 类型的值数组。 </param>
        /// <returns> 哈希字符串。 </returns>
        string ComputeHash(params long[] values);

        /// <summary> 从哈希字符串 <paramref name="hashStr" /> 反向解析为 <see cref="long" /> 类型的值数组。 </summary>
        /// <param name="hashStr"> 哈希字符串。 </param>
        /// <returns> <see cref="long" /> 类型的值数组。 </returns>
        long[] FromHashString(string hashStr);
    }
}