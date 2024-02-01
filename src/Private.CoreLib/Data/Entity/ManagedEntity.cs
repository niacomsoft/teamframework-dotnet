// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft.Data.Entity
{
    /// <summary> 提供了可管理的数据实体相关的方法。 </summary>
    /// <typeparam name="TId"> 数据实体唯一标识类型。 </typeparam>
    /// <typeparam name="TEnabledState"> 描述是否启用状态的类型。 </typeparam>
    /// <typeparam name="TRemovedState"> 描述是否逻辑删除状态的类型。 </typeparam>
    /// <seealso cref="IManagedEntity{TId, TEnabledState, TRemovedState}" />
    /// <seealso cref="MonitorEntity{TId}" />
    public abstract class ManagedEntity<TId, TEnabledState, TRemovedState> : MonitorEntity<TId>, IManagedEntity<TId, TEnabledState, TRemovedState>
    {
        /// <summary> 初始化 <see cref="ManagedEntity{TId, TEnabledState, TRemovedState}" /> 类的新实例。 </summary>
        protected ManagedEntity() : this(true, false)
        {
        }

        /// <summary> 初始化 <see cref="ManagedEntity{TId, TEnabledState, TRemovedState}" /> 类的新实例。 </summary>
        /// <param name="enabled"> 是否启用。 </param>
        /// <param name="removed"> 是否被逻辑删除。 </param>
        protected ManagedEntity(bool enabled, bool removed)
        {
            EnableOrDisable(enabled);
            RemoveOrRestore(removed);
        }

        /// <inheritdoc />
        public virtual TEnabledState Enabled { get; set; }

        /// <inheritdoc />
        public virtual TRemovedState HasRemoved { get; set; }

        /// <inheritdoc />
        public virtual IManagedEntity<TId, TEnabledState, TRemovedState> Disable()
        {
            EnableOrDisable(false);
            UpdateModifiedTime();
            return this;
        }

        /// <inheritdoc />
        public virtual IManagedEntity<TId, TEnabledState, TRemovedState> Enable()
        {
            EnableOrDisable(true);
            UpdateModifiedTime();
            return this;
        }

        /// <inheritdoc />
        public virtual IManagedEntity<TId, TEnabledState, TRemovedState> Remove()
        {
            RemoveOrRestore(true);
            UpdateModifiedTime();
            return this;
        }

        /// <inheritdoc />
        public virtual IManagedEntity<TId, TEnabledState, TRemovedState> Restore()
        {
            RemoveOrRestore(false);
            UpdateModifiedTime();
            return this;
        }

        /// <summary> 启用或禁用当前的数据实体 <see langword="this" />。 </summary>
        /// <param name="state"> 当 <paramref name="state" /> 为 <see langword="true" /> 时，代表启用；否则代表禁用。 </param>
        protected abstract void EnableOrDisable(bool state);

        /// <summary> 启用或禁用当前的数据实体 <see langword="this" />。 </summary>
        /// <param name="state"> 当 <paramref name="state" /> 为 <see langword="true" /> 时，代表逻辑删除；否则代表逻辑删除后还原。 </param>
        protected abstract void RemoveOrRestore(bool state);
    }

    /// <summary> 提供了 <see cref="long" /> 类型数据实体唯一标识相关的数据实体 <see langword="abstract" /> 方法。 </summary>
    /// <seealso cref="ManagedEntity{TId, TEnabledState, TRemovedState}" />
    public abstract class ManagedEntity : ManagedEntity<long, int, int>
    {
        /// <summary> 初始化 <see cref="ManagedEntity" /> 类的新实例。 </summary>
        protected ManagedEntity()
        {
        }

        /// <summary> 初始化 <see cref="ManagedEntity" /> 类的新实例。 </summary>
        /// <param name="enabled"> 是否启用。 </param>
        /// <param name="removed"> 是否被逻辑删除。 </param>
        protected ManagedEntity(bool enabled, bool removed) : base(enabled, removed)
        {
        }

        /// <inheritdoc />
        protected override void EnableOrDisable(bool state)
        {
            Enabled = state ? TrueValue.IntValue : FalseValue.IntValue;
        }

        /// <inheritdoc />
        protected override void RemoveOrRestore(bool state)
        {
            HasRemoved = state ? TrueValue.IntValue : FalseValue.IntValue;
        }
    }
}