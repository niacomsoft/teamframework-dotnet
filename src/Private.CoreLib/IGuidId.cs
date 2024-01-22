// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

namespace Niacomsoft
{
    /// <summary> 定义了 <see cref="Guid" /> 类型的数据标识接口。 </summary>
    /// <seealso cref="Guid" />
    /// <seealso cref="IId{T}" />
    public interface IGuidId : IId<Guid>
    {
    }
}