// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

namespace Niacomsoft.TeamFramework.Data.Entity
{
    /// <summary> 提供了数据实体相关的 <see langword="abstract" /> 方法。 </summary>
    /// <typeparam name="TId"> </typeparam>
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
}