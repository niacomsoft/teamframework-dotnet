// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System.Collections.Generic;

namespace Niacomsoft.Web.OData
{
    /// <summary> 提供了基于字典集合的开放数据类型相关的方法。 </summary>
    /// <seealso cref="Dictionary{TKey, TValue}" />
    public class ComplexType : Dictionary<string, object>
    {
        /// <summary> 初始化 <see cref="ComplexType" /> 类的新实例。 </summary>
        public ComplexType()
        {
        }
    }
}