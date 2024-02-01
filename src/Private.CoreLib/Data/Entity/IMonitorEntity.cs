// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using Niacomsoft.Objects;

namespace Niacomsoft.Data.Entity
{
    /// <summary> 定义了可追踪的数据实体的接口。 </summary>
    /// <typeparam name="TId"> 数据实体唯一标识类型。 </typeparam>
    /// <seealso cref="IEntityBase{TId}" />
    /// <seealso cref="IModificationTime" />
    public interface IMonitorEntity<TId> : IEntityBase<TId>, IModificationTime
    {
        /// <summary> 更新 <see cref="IModificationTime.ModifiedAt" /> 属性。 </summary>
        /// <returns> 当前的 <see cref="IMonitorEntity{TId}" /> 类型的对象实例 <see langword="this" />。 </returns>
        /// <seealso cref="IModificationTime" />
        /// <seealso cref="IModificationTime.ModifiedAt" />
        IMonitorEntity<TId> UpdateModifiedTime();
    }
}