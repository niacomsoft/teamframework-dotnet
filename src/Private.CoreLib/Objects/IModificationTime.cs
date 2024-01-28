// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

namespace Niacomsoft.Objects
{
    /// <summary> 定义了描述最后修改时间的接口。 </summary>
    /// <seealso cref="ICreationTime" />
    public interface IModificationTime : ICreationTime
    {
#if NET45_OR_GREATER || NETSTANDARD || NETCOREAPP || NET
        /// <summary> 最后修改时间。 </summary>
        /// <value> 设置或获取一个 <see cref="DateTime" /> 类型值，用于表示最后修改时间。 </value>
        /// <seealso cref="DateTime" />
        /// <seealso cref="Nullable{T}" />
        DateTime? ModifiedAt { get; set; }
#else
        /// <summary> 最后修改时间。 </summary>
        /// <value> 设置或获取一个 <see cref="DateTime" /> 类型值，用于表示最后修改时间。 </value>
        /// <seealso cref="DateTime" />
        DateTime ModifiedAt { get; set; }
#endif

        /// <summary> 最后更新时间。 </summary>
        /// <value> 获取一个 <see cref="DateTime" /> 类型值，用于表示最后更新时间。 </value>
        /// <seealso cref="DateTime" />
        /// <seealso cref="ICreationTime.CreatedAt" />
        /// <seealso cref="ModifiedAt" />
        DateTime UpdatedAt { get; }
    }
}