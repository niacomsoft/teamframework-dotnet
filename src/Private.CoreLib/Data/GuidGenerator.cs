// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

namespace Niacomsoft.Data
{
    /// <summary> 提供了生成 <see cref="Guid" /> 类型数据标识相关的方法。密闭的，不可以从此类型派生。 </summary>
    /// <seealso cref="Guid" />
    /// <seealso cref="IdGenerator{T}" />
    public sealed class GuidGenerator : IdGenerator<Guid>
    {
        /// <inheritdoc />
        public override Guid CreateNew()
        {
            return Guid.NewGuid();
        }
    }
}