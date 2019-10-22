using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlDatabase;
using System.Data;
using System.Data.SqlClient;
using DataEntity;

namespace DAL
{
    public class DalBase<TEntity> : IDal<TEntity> where TEntity : class
    {
        private string _tablename;
        private string _connectionstring;
        private string _tentityname;
        public DalBase()
        {
            _tablename = typeof(TEntity).Name.Replace("T_", "t_");
            _connectionstring = SqlHelper.ConnectionString;
            _tentityname = typeof(TEntity).Name;
        }

        /// <summary>
        /// 选择全部数据
        /// </summary>
        /// <returns></returns>
        public DataSet SelectAll()
        {
            var sql = string.Format("SELECT * FROM {0} WHERE 1=1 ", _tablename);
            var ds = SqlHelper.ExecuteDataset(_connectionstring, CommandType.Text, sql);
            if (ds == null || ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            return ds;
        }
        /// <summary>
        /// 执行查询sql
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet OperationSQL(string sql)
        {
            return SqlHelper.ExecuteDataset(_connectionstring, CommandType.Text, sql);
        }
        public DataSet Where(string where)
        {
            var sql = string.Format("SELECT * FROM [{0}] WHERE {1} ", _tablename, where);
            return SqlHelper.ExecuteDataset(_connectionstring, CommandType.Text, sql);
        }

        /// <summary>
        /// 实体主键是否已经存在重复（实体以外字段不作重复判断）
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns></returns>
        public bool Exist(TEntity t)
        {
            try
            {
                bool hasKey = false;
                var tablename = _tablename;
                var Where = "";
                var Column = "";
                var ParameterName = "";
                List<SqlParameter> para = new List<SqlParameter>();
                foreach (var item in t.GetType().GetProperties())
                {
                    //获取自定义属性Key
                    object[] objArray = item.GetCustomAttributes(false);
                    if (objArray != null && objArray.Length > 0)
                    {
                        if ((objArray[0] as DataEntity.CProperty).Value == "Key")
                        {
                            Column = "[" + item.Name + "]";
                            ParameterName = "@s" + item.Name;

                            hasKey = true;
                            Where = " " + Column + "=" + ParameterName + " ";
                            var value = item.GetValue(t, null);
                            para.Add(new SqlParameter(ParameterName, value));
                            break;
                        }
                    }
                }

                if (!hasKey || para.Count == 0)
                {
                    //不含Key属性
                    throw new Exception("Entity not contain Customer Attribute 'Key'");
                }

                var sql = string.Format("SELECT TOP 1 FROM [{0}] WHERE {1} ", tablename, Where);

                var ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionString, CommandType.Text, sql, para.ToArray());
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error:DalBase<" + _tentityname + ">:Exist(" + _tentityname + " t):" + ex.Message);
            }
        }

        /// <summary>
        /// 判断数据库中是否已有重复数据
        /// 例：Exist("字段1=1 AND 字段2=2")
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public bool Exist(string where)
        {
            if (string.IsNullOrEmpty(where))
            { return false; }
            try
            {
                var tablename = _tablename;
                var Where = where;

                var sql = string.Format("SELECT TOP 1 * FROM [{0}] WHERE {1} ", tablename, Where);

                var ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionString, CommandType.Text, sql);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error:DalBase<" + _tentityname + ">:Exist(string where):" + ex.Message);
            }
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public TEntity GetModel<TEntity>(string where) where TEntity : new()
        {
            try
            {
                var tablename = _tablename;
                var sql = string.Format("SELECT TOP 1 * FROM [{0}] WHERE {1}", tablename, where);
                var ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionString, CommandType.Text, sql);
                if (ds == null || ds.Tables[0].Rows.Count == 0)
                    return default(TEntity);
                return ECOA.Common.SerializationHelper.GetEntity<TEntity>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw new Exception("Error:DalBase<" + _tentityname + ">:GetModel<" + _tentityname + ">(string where):" + ex.Message);
            }
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="t">实体</param>
        /// 2016/9/7 52100 添加了判断条件以及Feasibility_Photo变量
        /// <returns></returns>
        public TEntity Add(TEntity t)
        {
            try
            {
                var tablename = _tablename;
                string Columns = "";            //所有列","号分隔
                string Parameters = "";
                List<SqlParameter> para = new List<SqlParameter>();
                string ParameterName = "";      //参数名
                string Feasibility_Photo = "OfficeAutomation_Document_Feasibility_Photo";//数据库表t_OfficeAutomation_Document_Feasibility不存在OfficeAutomation_Document_Feasibility_Photo此字段
                foreach (var item in t.GetType().GetProperties())
                {
                    //Columns += "[" + item.Name + "],";

                    //ParameterName = "@s" + item.Name;
                    //Parameters += ParameterName + ",";

                    //var value = item.GetValue(t, null);
                    //para.Add(new SqlParameter(ParameterName, value));

                    //2016/9/7 52100
                    if (item.Name.ToLower() != Feasibility_Photo.ToLower())
                    {
                      Columns += "[" + item.Name + "],";

                      ParameterName = "@s" + item.Name;
                      Parameters += ParameterName + ",";

                      var value = item.GetValue(t, null);
                      para.Add(new SqlParameter(ParameterName, value));
                    }
                }
                if (string.IsNullOrEmpty(Columns))
                {
                    return null;
                }
                Columns = Columns.TrimEnd(',');
                Parameters = Parameters.TrimEnd(',');
                //return null;
                var sql = string.Format("INSERT INTO [{0}] ({1}) VALUES ({2})", tablename, Columns, Parameters);
                int i = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql, para.ToArray());
                return i > 0 ? t : null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error:DalBase<" + _tentityname + ">:Add:" + ex.Message);
            }
        }

        /// <summary>
        /// 插入并插入主表（支持事务回滚）
        /// </summary>
        /// <param name="t">实体</param>
        /// <param name="Main"></param>
        /// <returns></returns>
        public TEntity AddAndMain(TEntity t, T_OfficeAutomation_Main Main)
        {
            if (Main == null)
                throw new Exception("Error:DalBase<" + _tentityname + ">:AddAndMain:Main IS NULL");
            SqlConnection conn = new SqlConnection(SqlHelper.ConnectionString);
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                var tablename = _tablename;
                string Columns = "";            //所有列","号分隔
                string Parameters = "";
                List<SqlParameter> para = new List<SqlParameter>();
                string ParameterName = "";      //参数名
                string Feasibility_Photo = "OfficeAutomation_Document_Feasibility_Photo";//数据库表t_OfficeAutomation_Document_Feasibility不存在OfficeAutomation_Document_Feasibility_Photo此字段
                foreach (var item in t.GetType().GetProperties())
                {
                    //Columns += "[" + item.Name + "],";

                    //ParameterName = "@s" + item.Name;
                    //Parameters += ParameterName + ",";

                    //var value = item.GetValue(t, null);
                    //para.Add(new SqlParameter(ParameterName, value));

                    //2016/9/7 52100
                    var value = item.GetValue(t, null);
                    var itemLowerName = item.Name.ToLower();
                    if (itemLowerName != Feasibility_Photo.ToLower())
                    {
                        Columns += "[" + item.Name + "],";

                        ParameterName = "@s" + item.Name;
                        Parameters += ParameterName + ",";
                        para.Add(new SqlParameter(ParameterName, value));
                    }
                    //20170702 自动给OfficeAutomation_Main_Apply(冗余字段赋值)
                    var rowname = tablename.Substring(2,tablename.Length - 2);
                    if(itemLowerName == rowname + "_apply")
                    {
                        Main.OfficeAutomation_Main_Apply = (string)value;
                    }
                    //20170702 自动给OfficeAutomation_Main_ApplyDate(冗余字段赋值)
                    if(itemLowerName == rowname + "_applydate")
                    {
                        Main.OfficeAutomation_Main_ApplyDate = (DateTime)value;
                    }
                    //20170702 自动给OfficeAutomation_Main_Department(冗余字段赋值)
                    if(itemLowerName == rowname + "_departmente")
                    {
                        if(tablename == "t_OfficeAutomation_Document_WirelessFixedLine")
                            Main.OfficeAutomation_Main_Department = "项目部";
                        else
                            Main.OfficeAutomation_Main_Department = (string)value;
                    }
                }
                if (string.IsNullOrEmpty(Columns))
                {
                    return null;
                }
                Columns = Columns.TrimEnd(',');
                Parameters = Parameters.TrimEnd(',');

                string insertMainSql = InsertMainSql(Main);
                var sql = string.Format("INSERT INTO [{0}] ({1}) VALUES ({2})", tablename, Columns, Parameters);
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql);
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql, para.ToArray());
                trans.Commit();
                return t;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw new Exception("Error:DalBase<" + _tentityname + ">:AddAndMain:" + ex.Message);
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t">实体</param>
        /// 2016/9/7 52100 添加了判断条件以及Feasibility_Photo变量
        /// <returns></returns>
        public TEntity Edit(TEntity t)
        {
            try
            {
                bool hasKey = false;
                var tablename = _tablename;
                string Column = "";            //列名
                string ParameterName = "";      //参数名
                string SetValueStr = "";        //赋值字符窜

                string Feasibility_Photo = "OfficeAutomation_Document_Feasibility_Photo";//数据库表t_OfficeAutomation_Document_Feasibility不存在OfficeAutomation_Document_Feasibility_Photo此字段
                string Where = "";

                List<SqlParameter> para = new List<SqlParameter>();

                foreach (var item in t.GetType().GetProperties())
                {
                    #region 未改动前代码
                    //Column = "[" + item.Name + "]";
                    //ParameterName = "@s" + item.Name;


                    ////获取自定义属性Key
                    //object[] objArray = item.GetCustomAttributes(false);
                    //if (objArray != null && objArray.Length > 0)
                    //{
                    //    if ((objArray[0] as DataEntity.CProperty).Value == "Key")
                    //    {
                    //        hasKey = true;
                    //        Where = " " + Column + "=" + ParameterName + " ";
                    //    }
                    //}
                    //else
                    //{
                    //    //非Key字段
                    //    SetValueStr += Column + "=" + ParameterName + ",";
                    //}
                    //var value = item.GetValue(t, null);
                    //para.Add(new SqlParameter(ParameterName, value));
                    #endregion
                    
                    //2016/9/7 52100
                    if (item.Name.ToLower() != Feasibility_Photo.ToLower())
                    {
                        Column = "[" + item.Name + "]";
                        ParameterName = "@s" + item.Name;


                        //获取自定义属性Key
                        object[] objArray = item.GetCustomAttributes(false);
                        if (objArray != null && objArray.Length > 0)
                        {
                            if ((objArray[0] as DataEntity.CProperty).Value == "Key")
                            {
                                hasKey = true;
                                Where = " " + Column + "=" + ParameterName + " ";
                            }
                        }
                        else
                        {
                            //非Key字段
                            SetValueStr += Column + "=" + ParameterName + ",";
                        }
                        var value = item.GetValue(t, null);
                        para.Add(new SqlParameter(ParameterName, value));
                    }
                }
                if (!hasKey)
                {
                    //不含Key属性
                    throw new Exception("Error:DalBase<" + typeof(TEntity).Name + ">:Edit:Entity not contain Customer Attribute 'Key'");
                }
                if (string.IsNullOrEmpty(SetValueStr))
                {
                    return null;
                }
                SetValueStr = SetValueStr.TrimEnd(',');

                var sql = string.Format("UPDATE {0} SET {1} WHERE {2}", tablename, SetValueStr, Where);
                int i = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql, para.ToArray());
                return i > 0 ? t : null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error:DalBase<" + _tentityname + ">:Edit:" + ex.Message);
            }
        }

        /// <summary>
        /// 修改并修改主表（支持事务回滚）
        /// </summary>
        /// <param name="t">实体</param>
        /// <param name="Main">Main实体</param>
        /// <returns></returns>
        public TEntity EditAndMain(TEntity t, T_OfficeAutomation_Main Main)
        {
            if (Main == null)
                throw new Exception("Error:DalBase<" + _tentityname + ">:EditAndMain:Main IS NULL");
            SqlConnection conn = new SqlConnection(SqlHelper.ConnectionString);
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                bool hasKey = false;
                var tablename = _tablename;
                string Column = "";            //列名
                string ParameterName = "";      //参数名
                string SetValueStr = "";        //赋值字符窜

                string Feasibility_Photo = "OfficeAutomation_Document_Feasibility_Photo";//数据库表t_OfficeAutomation_Document_Feasibility不存在OfficeAutomation_Document_Feasibility_Photo此字段
                string Where = "";

                List<SqlParameter> para = new List<SqlParameter>();

                foreach (var item in t.GetType().GetProperties())
                {
                    #region 未改动前代码
                    //Column = "[" + item.Name + "]";
                    //ParameterName = "@s" + item.Name;


                    ////获取自定义属性Key
                    //object[] objArray = item.GetCustomAttributes(false);
                    //if (objArray != null && objArray.Length > 0)
                    //{
                    //    if ((objArray[0] as DataEntity.CProperty).Value == "Key")
                    //    {
                    //        hasKey = true;
                    //        Where = " " + Column + "=" + ParameterName + " ";
                    //    }
                    //}
                    //else
                    //{
                    //    //非Key字段
                    //    SetValueStr += Column + "=" + ParameterName + ",";
                    //}
                    //var value = item.GetValue(t, null);
                    //para.Add(new SqlParameter(ParameterName, value));
                    #endregion

                    var value = item.GetValue(t, null);
                    var itemLowerName = item.Name.ToLower();
                    //2016/9/7 52100
                    if (item.Name.ToLower() != Feasibility_Photo.ToLower())
                    {
                        Column = "[" + item.Name + "]";
                        ParameterName = "@s" + item.Name;


                        //获取自定义属性Key
                        object[] objArray = item.GetCustomAttributes(false);
                        if (objArray != null && objArray.Length > 0)
                        {
                            if ((objArray[0] as DataEntity.CProperty).Value == "Key")
                            {
                                hasKey = true;
                                Where = " " + Column + "=" + ParameterName + " ";
                            }
                        }
                        else
                        {
                            //非Key字段
                            SetValueStr += Column + "=" + ParameterName + ",";
                        }
                        para.Add(new SqlParameter(ParameterName, value));

                        //20170702 自动给OfficeAutomation_Main_Apply(冗余字段赋值)
                        var rowname = tablename.Substring(2, tablename.Length - 2);
                        if (itemLowerName == rowname + "_apply")
                        {
                            Main.OfficeAutomation_Main_Apply = (string)value;
                        }
                        //20170702 自动给OfficeAutomation_Main_ApplyDate(冗余字段赋值)
                        if (itemLowerName == rowname + "_applydate")
                        {
                            Main.OfficeAutomation_Main_ApplyDate = (DateTime)value;
                        }
                        //20170702 自动给OfficeAutomation_Main_Department(冗余字段赋值)
                        if (itemLowerName == rowname + "_departmente")
                        {
                            if (tablename == "t_OfficeAutomation_Document_WirelessFixedLine")
                                Main.OfficeAutomation_Main_Department = "项目部";
                            else
                                Main.OfficeAutomation_Main_Department = (string)value;
                        }
                    }
                }
                if (!hasKey)
                {
                    //不含Key属性
                    throw new Exception("Error:DalBase<" + typeof(TEntity).Name + ">:EditAndMain:Entity not contain Customer Attribute 'Key'");
                }
                if (string.IsNullOrEmpty(SetValueStr))
                {
                    return null;
                }
                SetValueStr = SetValueStr.TrimEnd(',');
                string updateMainSql = InsertMainSql(Main);
                var sql = string.Format("UPDATE {0} SET {1} WHERE {2}", tablename, SetValueStr, Where);

                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, updateMainSql);
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql, para.ToArray());
                trans.Commit();
                return t;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw new Exception("Error:DalBase<" + _tentityname + ">:EditAndMain:" + ex.Message);
            }
        }

        public void Del(TEntity t)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除自身MainID的数据
        /// </summary>
        /// <param name="MainID"></param>
        /// <returns></returns>
        public bool DelByMainID(string MainID)
        {
            string sMainID = _tablename.Substring(2, _tablename.Length - 2) + "_MainID";
            string sql = "DELETE FROM " + _tablename + " WHERE " + sMainID + "='" + MainID + "'";
            int i = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql);
            return i > 0;
        }

        /// <summary>
        /// 通过t_OfficeAutomation_Main的ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string MainID)
        {
            try
            {
                string columnflagname = _tablename.Substring(2, _tablename.Length - 2); //去掉头T_
                string sql = "SELECT * "
                               + "           ,toam.OfficeAutomation_SerialNumber"
                               + "           ,tdoad.OfficeAutomation_Document_Name"
                               + "           ,toam.OfficeAutomation_Main_FlowStateID"
                               + " FROM [DB_EcOfficeAutomation].[dbo].[" + _tablename + "] todi"
                               + " LEFT JOIN t_OfficeAutomation_Main toam ON toam.OfficeAutomation_Main_ID= todi." + columnflagname + "_MainID"
                               + " LEFT JOIN t_Dic_OfficeAutomation_Document tdoad ON tdoad.OfficeAutomation_Document_ID = toam.OfficeAutomation_DocumentID"
                               + " WHERE " + columnflagname + "_MainID='" + MainID + "'";
                return SqlHelper.ExecuteDataset(SqlHelper.ConnectionString, CommandType.Text, sql);
            }
            catch (Exception ex)
            {
                throw new Exception("Error:DalBase<" + _tentityname + ">:SelectByMainID:" + ex.Message);
            }
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByID(string ID)
        {
            try
            {
                string columnflagname = _tablename.Substring(2, _tablename.Length - 2); //去掉头T_
                string sql = "SELECT * "
                               + " FROM [DB_EcOfficeAutomation].[dbo].[" + _tablename + "]"
                               + " WHERE " + columnflagname + "_MainID='" + ID + "' order by "+ columnflagname + "_ProjectID asc";
                return SqlHelper.ExecuteDataset(SqlHelper.ConnectionString, CommandType.Text, sql);
            }
            catch (Exception ex)
            {
                throw new Exception("Error:DalBase<" + _tentityname + ">:SelectByMainID:" + ex.Message);
            }
        }

        /// <summary>
        /// 通过t_OfficeAutomation_Main的ID删除相关表对应的所有数据
        /// 需要依赖存储过程
        /// 存储过程命名规则(表名：t_OfficeAutomation_Document_UtContract对应存储过程名：pr_UtContract_Delete)
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public bool Delete(string MainID)
        {
            var prname = _tablename.Replace("t_OfficeAutomation_Document_", "");
            prname = "[pr_" + prname + "_Delete]";
            string sql = prname;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@sMainID", SqlDbType.NVarChar, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, MainID));
            int i = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, sql, parameters.ToArray());

            return i > 0;
        }

        private string InsertMainSql(T_OfficeAutomation_Main Main)
        {
            if (Main == null)
                return "";
            string sql =
@"
INSERT 
     [OfficeAutomation_Main_ID]
      ,[OfficeAutomation_SerialNumber]
      ,[OfficeAutomation_DocumentID]
      ,[OfficeAutomation_Main_FlowStateID]
      ,[OfficeAutomation_Main_Creater]
      ,[OfficeAutomation_Main_CrTime]
      ,[OfficeAutomation_Main_Sremark]
      ,[OfficeAutomation_Main_Department]
      ,[OfficeAutomation_Main_Apply]
      ,[OfficeAutomation_Main_ApplyDate]
INTO t_OfficeAutomation_Main VALUES (
    '{0}','{1}',{2},'{3}','{4}','{5}','{6}','{7}','{8}','{9}'
)
";
            sql = string.Format(sql,
                        Main.OfficeAutomation_Main_ID,
                        Main.OfficeAutomation_SerialNumber,
                        Main.OfficeAutomation_DocumentID,
                        Main.OfficeAutomation_Main_Creater,
                        DateTime.Now,
                        Main.OfficeAutomation_Main_Sremark,
                        Main.OfficeAutomation_Main_Department,
                        Main.OfficeAutomation_Main_Apply,
                        Main.OfficeAutomation_Main_ApplyDate
                    );
            return sql;
        }

        private string UpdateMainSql(T_OfficeAutomation_Main Main)
        {
            if (Main == null)
                return "";
            string sql =
@"
    UPDATE [t_OfficeAutomation_Main]
    SET OfficeAutomation_Main_FlowStateID={0},
        OfficeAutomation_Main_Department='{1}',
        OfficeAutomation_Main_Apply = '{2}',
        OfficeAutomation_Main_ApplyDate='{3}'
";
            sql = string.Format(sql,
                    Main.OfficeAutomation_Main_FlowStateID,
                    Main.OfficeAutomation_Main_Department,
                    Main.OfficeAutomation_Main_Apply,
                    Main.OfficeAutomation_Main_ApplyDate
                );
            return sql;
        }

    }
}
