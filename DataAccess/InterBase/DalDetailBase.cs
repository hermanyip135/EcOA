using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlDatabase;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DalDetailBase<TEntity> : DalBase<TEntity> where TEntity : class
    {
        private string _pTableName = "";
        private string _tablename;
        private string _connectionstring;
        private string _tentityname;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ParentTableName"></param>
        public DalDetailBase(string ParentTableName)
        {
            _tablename = typeof(TEntity).Name.Replace("T_", "t_");  //表名
            _connectionstring = SqlHelper.ConnectionString;         //连接字符窜
            _tentityname = typeof(TEntity).Name;                    //实体名称
            _pTableName = ParentTableName;                          //夫table名
        }

        /// <summary>
        /// 根据主键获取其下对应的详情
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public new DataSet SelectByMainID(string mainID)
        {
            try
            {
                string columnflagname = _tablename.Substring(2, _tablename.Length - 2); //去掉头T_
                string pcolumnflagname = _pTableName.Substring(2, _pTableName.Length - 2); //去掉头T_
                string sql = "SELECT * "
                        + " FROM [" + _tablename + "]"
                        + " WHERE [" + columnflagname + "_MainID]= (SELECT toads." + pcolumnflagname + "_ID"
                        + " FROM " + _pTableName + " toads"
                        + " WHERE  toads." + pcolumnflagname + "_MainID = '" + mainID + "')";

                return SqlHelper.ExecuteDataset(SqlHelper.ConnectionString, CommandType.Text, sql);
            }
            catch (Exception ex)
            {
                throw new Exception("Error:DalDetailBase<" + _tentityname + ">:SelectByMainID:" + ex.Message);
            }
        }

        public new bool DelByMainID(string MainID)
        {
            string columnflagname = _tablename.Substring(2, _tablename.Length - 2); //去掉头T_
            string pcolumnflagname = _pTableName.Substring(2, _pTableName.Length - 2); //去掉头T_
            string sMainID = _tablename.Substring(2, _tablename.Length - 2) + "_MainID";
            string sql = "Delete "
                               + " FROM [" + _tablename + "]"
                               + " WHERE [" + columnflagname + "_MainID]= (SELECT toads." + pcolumnflagname + "_ID"
                               + " FROM " + _pTableName + " toads"
                               + " WHERE  toads." + pcolumnflagname + "_MainID = '" + MainID + "')";
            int i = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql);
            return i > 0;
        }
    }
}
