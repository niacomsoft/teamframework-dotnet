// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft
{
    /// <summary> 定义了上下文数据的接口。 </summary>
    public interface IContextualData
    {
        /// <summary> 添加或更新名称为 <paramref name="key" /> 的上下文数据。 </summary>
        /// <param name="key"> 上下文数据标识名称。 </param>
        /// <param name="value"> 上下文数据。 </param>
        void SetValue(string key, object value);

        /// <summary> 尝试获取名称为 <paramref name="key" /> 的上下文数据。 </summary>
        /// <param name="key"> 上下文数据标识名称。 </param>
        /// <param name="value"> 上下文数据。 </param>
        /// <returns>
        /// 当上下文数据中不包含名称为 <paramref name="key" /> 的上下文数据或 <paramref name="value" /> 等于 <see langword="null" /> 时，返回
        /// <see langword="false" />；否则返回 <see langword="true" />。
        /// </returns>
        bool TryGetValue(string key, out object value);
    }
}