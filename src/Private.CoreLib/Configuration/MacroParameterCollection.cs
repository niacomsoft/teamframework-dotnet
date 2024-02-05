// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System.Collections.Generic;

namespace Niacomsoft.Configuration
{
    /// <summary> <see cref="IMacroParameter" /> 类型的对象实例集合。密闭的，不可以从此类型派生。 </summary>
    /// <seealso cref="IMacroParameter" />
    /// <seealso cref="List{T}" />
    /// <seealso cref="MacroParameter" />
    /// <remarks> 密闭的，不可以从此类型派生。 </remarks>
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

        /// <summary> 编译并合并同名宏参数。 </summary>
        /// <returns> <see cref="IMacroParameter" /> 类型的对象实例字典集合。 </returns>
        /// <seealso cref="Dictionary{TKey, TValue}" />
        /// <seealso cref="IDictionary{TKey, TValue}" />
        /// <seealso cref="IMacroParameter" />
        /// <seealso cref="MacroParameter" />
        public IDictionary<string, IMacroParameter> Compile()
        {
            var macrosDic = new Dictionary<string, IMacroParameter>();
            foreach (var item in this)
            {
                macrosDic[item.ToString()] = item;
            }
            return macrosDic;
        }
    }
}