// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft.TeamFramework.Security.Integer
{
    /// <summary> 定义了创建 <see cref="IHashingIntegerConverter" /> 类型的对象实例的工厂方法接口。 </summary>
    public interface IHashingIntegerConverterFactory
    {
        /// <summary> 创建 <see cref="IHashingIntegerConverter" /> 类型的对象实例。 </summary>
        /// <param name="options">
        /// 整型哈希值选项。
        /// <para> <see cref="HashingIntegerOptions" /> 类型的对象实例。 </para>
        /// </param>
        /// <returns> <see cref="IHashingIntegerConverter" /> 类型的对象实例。 </returns>
        /// <seealso cref="HashingIntegerOptions" />
        /// <seealso cref="IHashingIntegerConverter" />
        IHashingIntegerConverter Create(HashingIntegerOptions options);

        /// <summary>
        /// 使用默认的选项 <see cref="HashingIntegerOptions.DefaultOptions" /> 创建 <see cref="IHashingIntegerConverter" /> 类型的对象实例。
        /// </summary>
        /// <returns> <see cref="IHashingIntegerConverter" /> 类型的对象实例。 </returns>
        /// <seealso cref="HashingIntegerOptions" />
        /// <seealso cref="HashingIntegerOptions.DefaultOptions" />
        /// <seealso cref="IHashingIntegerConverter" />
        IHashingIntegerConverter Create();
    }
}