// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System.Data;

using Niacomsoft.Utilities;

namespace Niacomsoft.Data
{
    /// <summary> 提供了标准 ADO.NET 数据结果规格相关的方法。 </summary>
    public static class DbResultSpecs
    {
        /// <summary> 默认的数据集 <see cref="DataSet" /> 名称。 </summary>
        public const string DefaultDataSetName = "system.data.dataSet";

        /// <summary> 默认的数据表 <see cref="DataTable" /> 名称。 </summary>
        public const string DefaultDataTableName = "system.data.dataTable";

        /// <summary> 创建一个新的数据集。 </summary>
        /// <param name="dataSetName"> 数据集名称。 </param>
        /// <returns>
        /// 数据集。
        /// <para> <see cref="DataSet" /> 类型的对象实例。 </para>
        /// </returns>
        /// <seealso cref="DataSet" />
        /// <seealso cref="DefaultDataSetName" />
        public static DataSet CreateDataSet(string dataSetName = DefaultDataSetName)
        {
            return new DataSet(StringUtilities.IfEmpty(dataSetName, DefaultDataSetName, EmptyComparisonOptions.NullOrWhitespace));
        }

        /// <summary> 创建一个新的数据表。 </summary>
        /// <param name="dataTableName"> 数据表名称。 </param>
        /// <returns>
        /// 数据表。
        /// <para> <see cref="DataTable" /> 类型的对象实例。 </para>
        /// </returns>
        /// <seealso cref="DataTable" />
        /// <seealso cref="DefaultDataTableName" />
        public static DataTable CreateDataTable(string dataTableName = DefaultDataTableName)
        {
            return new DataTable(StringUtilities.IfEmpty(dataTableName, DefaultDataSetName, EmptyComparisonOptions.NullOrWhitespace));
        }

        /// <summary>
        /// 当 <paramref name="table" /> 不等于 <see langword="null" /> 且 <see cref="DataTable.Rows" /> 行数大于 0 时，返回
        /// <see langword="true" />；否则返回 <see langword="false" />。
        /// </summary>
        /// <param name="table"> 需要校验的数据表。 </param>
        /// <returns>
        /// 当 <paramref name="table" /> 不等于 <see langword="null" /> 且 <see cref="DataTable.Rows" /> 行数大于 0 时，返回
        /// <see langword="true" />；否则返回 <see langword="false" />。
        /// </returns>
        /// <seealso cref="DataTable" />
        /// <seealso cref="DataTable.Rows" />
        public static bool HasData(DataTable table)
        {
            return AssertUtilities.NotNull(table) && AssertUtilities.GreatThan(table.Rows.Count);
        }
    }
}