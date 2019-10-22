using System;
using System.Collections.Generic;
using System.Text;

namespace AppCommon.Model
{
    #region DbTable
    /// <summary>
    /// 字段和值对应模型
    /// </summary>
    public class DbTable
    {
        /// <summary>
        /// 字段和值对应模型
        /// </summary>
        /// <param name="_columnName">字段名</param>
        /// <param name="_columnValue">字段值</param>
        public DbTable(string _columnName, string _columnValue)
        {
            this._columnName = _columnName;
            this._columnValue = _columnValue;
        }

        private string _columnName, _columnValue;

        /// <summary>
        /// 字段名
        /// </summary>
        public string ColumnName
        {
            get { return _columnName; }
            set { _columnName = value; }
        }

        /// <summary>
        /// 字段值
        /// </summary>
        public string ColumnValue
        {
            get { return _columnValue; }
            set { _columnValue = value; }
        }
    }
    #endregion
}
