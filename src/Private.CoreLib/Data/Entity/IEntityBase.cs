// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using Niacomsoft.Objects;

namespace Niacomsoft.Data.Entity
{
    /// <summary> 定义了数据实体的基本信息接口。 </summary>
    /// <typeparam name="TId"> 数据实体唯一标识类型。 </typeparam>
    /// <seealso cref="IId{T}" />
    /// <seealso cref="ICreationTime" />
    public interface IEntityBase<TId> : IId<TId>, ICreationTime
    {
    }
}