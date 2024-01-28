// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using Niacomsoft.Diagnostics;
using Niacomsoft.Utilities;

namespace Niacomsoft.Web.OData
{
    /// <summary> 提供了可供分页的 <typeparamref name="TRow" /> 类型数据表相关的方法。 </summary>
    /// <typeparam name="TRow"> 单行数据类型。 </typeparam>
    public class PaginableTable<TRow>
    {
        private long m_total;

        /// <summary> 初始化 <see cref="PaginableTable{TRow}" /> 类的新实例。 </summary>
        public PaginableTable() : this(null, 0)
        {
        }

        /// <summary> 初始化 <see cref="PaginableTable{TRow}" /> 类的新实例。 </summary>
        /// <param name="rows"> <typeparamref name="TRow" /> 类型数据行。 </param>
        public PaginableTable(TRow[] rows) : this(rows, AssertUtilities.NotNull(rows) ? rows.LongLength : 0)
        {
        }

        /// <summary> 初始化 <see cref="PaginableTable{TRow}" /> 类的新实例。 </summary>
        /// <param name="total"> 数据总量。 </param>
        public PaginableTable(long total) : this(null, total)
        {
        }

        /// <summary> 初始化 <see cref="PaginableTable{TRow}" /> 类的新实例。 </summary>
        /// <param name="rows"> <typeparamref name="TRow" /> 类型数据行。 </param>
        /// <param name="total"> 数据总量。 </param>
        public PaginableTable(TRow[] rows, long total)
        {
            Rows = rows;
            m_total = total;
        }

        /// <summary> 数据行。 </summary>
        /// <value> 设置或获取 <typeparamref name="TRow" /> 类型的对象实例或值，用于表示数据行。 </value>
        public virtual TRow[] Rows { get; set; }

        /// <summary> 数据总量。 </summary>
        /// <value> 设置或获取一个 <see cref="long" /> 类型值，用于表示数据总量。 </value>
        public virtual long Total
        {
            get
            {
                return
                    Debugger.IfWriteLine(AssertUtilities.LessThan(m_total, 0), $"The wrong data total value of \"{m_total}\" is provided and \"0\" will be used as the final return value.", null)
                        ? 0
                        : m_total;
            }
            set { m_total = value; }
        }
    }
}