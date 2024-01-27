// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

namespace Niacomsoft.Objects
{
    /// <summary> 定义了描述创建时间的接口。 </summary>
    public interface ICreationTime
    {
        /// <summary> 创建时间。 </summary>
        /// <value> 设置或获取一个 <see cref="DateTime" /> 类型值，用于表示创建时间。 </value>
        /// <seealso cref="DateTime" />
        DateTime CreatedAt { get; set; }
    }
}