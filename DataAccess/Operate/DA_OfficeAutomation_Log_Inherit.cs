using System;
using System.Data;
using System.Collections;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Log_Inherit : DA_OfficeAutomation_Log_Operate
    {
        #region 查询日志
        /// <summary>
        /// 查询日志
        /// </summary>
        /// <returns></returns>
        public DataSet FindLibrary(string sReportID)
        {

            string sSql = "select OfficeAutomation_Log_EmployeeID,OfficeAutomation_Log_EmployeeName,OfficeAutomation_Log_OperateTime,(select OfficeAutomation_Operate_Name from t_Dic_OfficeAutomation_Operate where OfficeAutomation_Operate_ID=OfficeAutomation_Log_OperateID) as OfficeAutomation_Operate_Name," +
                        "(select OfficeAutomation_OperateModule_Name from t_Dic_OfficeAutomation_OperateModule where OfficeAutomation_OperateModule_ID=OfficeAutomation_Log_OperateModuleID) as OperateModule_Name" +
                        " from t_OfficeAutomation_Log where OfficeAutomation_Log_OperateModuleMainID=@sReportID order by OfficeAutomation_Log_OperateTime desc";
            SqlCommand cmdToExecute = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);
            DataSet ds = new DataSet();

            cmdToExecute.CommandText = sSql;
            cmdToExecute.CommandType = CommandType.Text;

            try
            {
                cmdToExecute.Connection = _mainConnection;

                cmdToExecute.Parameters.Add(new SqlParameter("@sReportID", sReportID));

                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Open();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                adapter.Fill(ds);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Close();
                }

                cmdToExecute.Dispose();

                adapter.Dispose();
            }

            return ds;
        }
        #endregion

        #region 取操作人
        /// <summary>
        /// 取操作人
        /// </summary>
        /// <returns></returns>
        public string getOperate(string sReportID,int iOperate,int iOperateModule)
        {

            string sSql = "select top 1 OfficeAutomation_Log_EmployeeName from t_OfficeAutomation_Log where OfficeAutomation_Log_OperateModuleMainID='" + sReportID +
                        "' and OfficeAutomation_Log_OperateModuleID=" + iOperateModule + " and OfficeAutomation_Log_OperateID=" + iOperate + " order by OfficeAutomation_Log_OperateTime desc";
            SqlCommand cmdToExecute = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);
            DataSet ds = new DataSet();

            cmdToExecute.CommandText = sSql;
            cmdToExecute.CommandType = CommandType.Text;
            cmdToExecute.CommandTimeout = 0;

            try
            {
                cmdToExecute.Connection = _mainConnection;

                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Open();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                adapter.Fill(ds);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Close();
                }

                cmdToExecute.Dispose();

                adapter.Dispose();
            }

            if (ds.Tables[0].Rows.Count > 0)
            { return ds.Tables[0].Rows[0]["OfficeAutomation_Log_EmployeeName"].ToString(); }
            else
            { return ""; }
        }

        /// <summary>
        /// 取增加集团操作人
        /// </summary>
        /// <returns></returns>
        public string getGroupOperate(string sReportID)
        {

            string sSql = "select top 1 OfficeAutomation_Log_EmployeeName from t_OfficeAutomation_Log where OfficeAutomation_Log_OperateModuleMainID='" + sReportID +
                        "' and OfficeAutomation_Log_OperateModuleID=87 and OfficeAutomation_Log_OperateID in (1,101) order by OfficeAutomation_Log_OperateTime desc";
            SqlCommand cmdToExecute = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);
            DataSet ds = new DataSet();

            cmdToExecute.CommandText = sSql;
            cmdToExecute.CommandType = CommandType.Text;
            cmdToExecute.CommandTimeout = 0;

            try
            {
                cmdToExecute.Connection = _mainConnection;

                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Open();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                adapter.Fill(ds);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Close();
                }

                cmdToExecute.Dispose();

                adapter.Dispose();
            }

            if (ds.Tables[0].Rows.Count > 0)
            { return ds.Tables[0].Rows[0]["OfficeAutomation_Log_EmployeeName"].ToString(); }
            else
            { return ""; }
        }
        #endregion

        #region  取一条记录
        /// <summary>
        /// 取一条记录
        /// </summary>
        /// <returns></returns>
        public DataSet getOneLog(string sReportID, int iOperate, int iOperateModule)
        {

            string sSql = "select top 1 * from t_OfficeAutomation_Log where OfficeAutomation_Log_OperateModuleMainID='" + sReportID +
                        "' and OfficeAutomation_Log_OperateModuleID=" + iOperateModule + " and OfficeAutomation_Log_OperateID=" + iOperate + " order by OfficeAutomation_Log_OperateTime desc";
            SqlCommand cmdToExecute = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);
            DataSet ds = new DataSet();

            cmdToExecute.CommandText = sSql;
            cmdToExecute.CommandType = CommandType.Text;
            cmdToExecute.CommandTimeout = 0;

            try
            {
                cmdToExecute.Connection = _mainConnection;

                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Open();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                adapter.Fill(ds);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Close();
                }

                cmdToExecute.Dispose();

                adapter.Dispose();
            }

            return ds;
        }
        #endregion
        #region 取操作时间
        /// <summary>
        /// 取操作时间
        /// </summary>
        /// <returns></returns>
        public string getOperateTime(string sReportID, int iOperate, int iOperateModule)
        {

            string sSql = "select top 1 OfficeAutomation_Log_OperateTime from t_OfficeAutomation_Log where OfficeAutomation_Log_OperateModuleMainID='" + sReportID +
                        "' and OfficeAutomation_Log_OperateModuleID=" + iOperateModule + " and OfficeAutomation_Log_OperateID=" + iOperate + " order by OfficeAutomation_Log_OperateTime desc";
            SqlCommand cmdToExecute = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);
            DataSet ds = new DataSet();

            cmdToExecute.CommandText = sSql;
            cmdToExecute.CommandType = CommandType.Text;

            try
            {
                cmdToExecute.Connection = _mainConnection;

                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Open();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                adapter.Fill(ds);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Close();
                }

                cmdToExecute.Dispose();

                adapter.Dispose();
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["OfficeAutomation_Log_OperateTime"].ToString() == "1900-1-1 0:00:00")
                { return ""; }
                else
                { return ds.Tables[0].Rows[0]["OfficeAutomation_Log_OperateTime"].ToString(); }
            }
            else
            { return ""; }
        }
        #endregion
    }
}
