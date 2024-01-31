// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using Niacomsoft.Diagnostics;
using Niacomsoft.Utilities;

namespace Niacomsoft.Web.OData
{
    /// <summary> 提供了分页查询相关的基本方法。 </summary>
    public class PaginableQuery
    {
        /// <summary> <see cref="RowsNumberPerPage" /> 最小值。 </summary>
        public const int MinimumRowsNumber = 10;

        private int m_currentPageIndex;
        private int m_rowsNumberPerPage;

        /// <summary> 初始化 <see cref="PaginableQuery" /> 类的新实例。 </summary>
        public PaginableQuery() : this(0)
        {
        }

        /// <summary> 初始化 <see cref="PaginableQuery" /> 类的新实例。 </summary>
        /// <param name="pageIdx"> 当前的页索引。 </param>
        public PaginableQuery(int pageIdx) : this(pageIdx, MinimumRowsNumber)
        {
        }

        /// <summary> 初始化 <see cref="PaginableQuery" /> 类的新实例。 </summary>
        /// <param name="pageIdx"> 当前的页索引。 </param>
        /// <param name="rowsNumPerPage"> 每页返回多少行数据。 </param>
        public PaginableQuery(int pageIdx, int rowsNumPerPage)
        {
            m_currentPageIndex = pageIdx;
            m_rowsNumberPerPage = rowsNumPerPage;
        }

        /// <summary> 当前的页索引。 </summary>
        /// <value> 设置或获取一个 <see cref="int" /> 类型值，用于表示当前的页索引。 </value>
        public virtual int CurrentPageIndex
        {
            get
            {
                return Debugger.IfWriteLine(AssertUtilities.LessThan(m_currentPageIndex), "The value of the \"CurrentPageIndex\" property is less than 0. We'll use \"0\" instead.", null, DebuggingLevel.Warning)
                    ? 0
                    : m_currentPageIndex;
            }
            set { m_currentPageIndex = value; }
        }

        /// <summary> 每页返回多少行数据。 </summary>
        /// <value> 设置或获取一个 <see cref="int" /> 类型值，用于表示每页返回多少行数据。 </value>
        public virtual int RowsNumberPerPage
        {
            get
            {
                return Debugger.IfWriteLine(AssertUtilities.LessThan(m_rowsNumberPerPage, MinimumRowsNumber), "The value of the \"RowsNumberPerPage\" property is less than 10. We'll use \"10\" instead.", null, DebuggingLevel.Warning)
                    ? MinimumRowsNumber
                    : m_rowsNumberPerPage;
            }
            set { m_rowsNumberPerPage = value; }
        }
    }
}