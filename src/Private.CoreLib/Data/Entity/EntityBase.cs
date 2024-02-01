// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

namespace Niacomsoft.Data.Entity
{
    /// <summary> 提供了数据实体相关的 <see langword="abstract" /> 方法。 </summary>
    /// <typeparam name="TId"> 数据实体唯一标识类型。 </typeparam>
    public abstract class EntityBase<TId> : IEntityBase<TId>
    {
        /// <summary> 初始化 <see cref="EntityBase{TId}" /> 类的新实例。 </summary>
        protected EntityBase()
        {
            CreatedAt = DateTime.Now;
        }

        /// <inheritdoc />
        public abstract DateTime CreatedAt { get; set; }

        /// <inheritdoc />
        public abstract TId Id { get; set; }
    }

    /// <summary> 提供了 <see cref="long" /> 类型数据唯一标识的相关数据实体 <see langword="abstract" /> 方法。 </summary>
    /// <seealso cref="EntityBase{TId}" />
    public abstract class EntityBase : EntityBase<long> { }
}