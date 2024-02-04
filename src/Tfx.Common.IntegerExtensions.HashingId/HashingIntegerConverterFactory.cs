// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft.TeamFramework.Security.Integer
{
    /// <summary> 提供了创建 <see cref="IHashingIntegerConverter" /> 类型的对象实例相关的基本方法。 </summary>
    /// <seealso cref="IHashingIntegerConverterFactory" />
    public class HashingIntegerConverterFactory : IHashingIntegerConverterFactory
    {
        /// <inheritdoc />
        public virtual IHashingIntegerConverter Create(HashingIntegerOptions options)
        {
            return new HashingIntegerConverter(options);
        }

        /// <inheritdoc />
        public virtual IHashingIntegerConverter Create()
        {
            return Create(HashingIntegerOptions.DefaultOptions);
        }
    }
}