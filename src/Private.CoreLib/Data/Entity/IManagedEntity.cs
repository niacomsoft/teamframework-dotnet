// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using Niacomsoft.Objects;

namespace Niacomsoft.Data.Entity
{
    /// <summary> 定义了可管理的数据实体接口。 </summary>
    /// <typeparam name="TId"> 数据实体唯一标识类型。 </typeparam>
    /// <typeparam name="TEnabledState"> 描述是否启用状态的类型。 </typeparam>
    /// <typeparam name="TRemovedState"> 描述是否逻辑删除状态的类型。 </typeparam>
    /// <seealso cref="IEnabledState{T}" />
    /// <seealso cref="IMonitorEntity{TId}" />
    /// <seealso cref="IRemovedState{T}" />
    public interface IManagedEntity<TId, TEnabledState, TRemovedState> : IMonitorEntity<TId>, IEnabledState<TEnabledState>, IRemovedState<TRemovedState>
    {
        /// <summary> 禁用。 </summary>
        /// <returns> 当前的数据实体 <see langword="this" />。 </returns>
        IManagedEntity<TId, TEnabledState, TRemovedState> Disable();

        /// <summary> 启用。 </summary>
        /// <returns> 当前的数据实体 <see langword="this" />。 </returns>
        IManagedEntity<TId, TEnabledState, TRemovedState> Enable();

        /// <summary> 逻辑删除。 </summary>
        /// <returns> 当前的数据实体 <see langword="this" />。 </returns>
        IManagedEntity<TId, TEnabledState, TRemovedState> Remove();

        /// <summary> 逻辑删除后还原。 </summary>
        /// <returns> 当前的数据实体 <see langword="this" />。 </returns>
        IManagedEntity<TId, TEnabledState, TRemovedState> Restore();
    }
}