// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

namespace Niacomsoft.Data.Entity
{
    /// <summary> 提供了可监控数据提示相关的 <see langword="abstract" /> 方法。 </summary>
    /// <typeparam name="TId"> 数据实体唯一标识类型。 </typeparam>
    /// <seealso cref="EntityBase{TId}" />
    /// <seealso cref="IMonitorEntity{TId}" />
    public abstract class MonitorEntity<TId> : EntityBase<TId>, IMonitorEntity<TId>
    {
        /// <summary> 初始化 <see cref="MonitorEntity{TId}" /> 类的新实例。 </summary>
        protected MonitorEntity()
        {
#if NET45_OR_GREATER || NETSTANDARD || NETCOREAPP || NET
            ModifiedAt = null;
#else
            ModifiedAt = DateTime.MinValue;
#endif
        }

#if NET45_OR_GREATER || NETSTANDARD || NETCOREAPP || NET

        /// <inheritdoc />
        public virtual DateTime? ModifiedAt { get; set; }

#else
        /// <inheritdoc />
        public virtual DateTime ModifiedAt { get; set; }
#endif

        /// <inheritdoc />
        public virtual DateTime UpdatedAt
        {
            get
            {
#if NET45_OR_GREATER || NETSTANDARD || NETCOREAPP || NET
                return ModifiedAt ?? CreatedAt;
#else
                return Niacomsoft.Utilities.AssertUtilities.IsBefore(ModifiedAt, CreatedAt) ? CreatedAt : ModifiedAt;
#endif
            }
        }

        /// <inheritdoc />
        public virtual IMonitorEntity<TId> UpdateModifiedTime()
        {
            ModifiedAt = DateTime.Now;
            return this;
        }
    }

    /// <summary> 提供了 <see cref="long" /> 类型数据实体唯一标识的相关数据实体 <see langword="abstract" /> 方法。 </summary>
    /// <seealso cref="MonitorEntity{TId}" />
    public abstract class MonitorEntity : MonitorEntity<long> { }
}