// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System.Collections.Generic;

namespace Niacomsoft.Configuration
{
    /// <summary> <see cref="IMacroParameter" /> 类型的对象实例集合。 </summary>
    /// <seealso cref="IMacroParameter" />
    /// <seealso cref="List{T}" />
    /// <seealso cref="MacroParameter" />
    public sealed class MacroParameterCollection : List<IMacroParameter>
    {
        /// <summary> 初始化 <see cref="MacroParameterCollection" /> 类的新实例。 </summary>
        public MacroParameterCollection()
        {
        }

        /// <summary> 初始化 <see cref="MacroParameterCollection" /> 类的新实例，该实例包含从指定集合复制的元素并且具有足够的容量来容纳所复制的元素。 </summary>
        /// <param name="collection"> 一个集合，其元素被复制到新列表中。 </param>
        public MacroParameterCollection(IEnumerable<IMacroParameter> collection) : base(collection)
        {
        }
    }
}