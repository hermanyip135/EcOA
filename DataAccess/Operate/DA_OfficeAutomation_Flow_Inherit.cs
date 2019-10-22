using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DAL;
using DataEntity;
using System.Configuration;
using SqlDatabase;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Flow_Inherit : DA_OfficeAutomation_Flow_Operate
    {
        /// <summary>
        /// 根据公文主键获取流程信息
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainID(string mainID)
        {
            string sql = "SELECT [OfficeAutomation_Flow_ID]"
                            + "          ,[OfficeAutomation_Flow_MainID]"
                            + "          ,[OfficeAutomation_Flow_Employee]"
                            + "          ,[OfficeAutomation_Flow_EmployeeID]"
                            + "          ,[OfficeAutomation_Flow_Idx]"
                            + "          ,[OfficeAutomation_Flow_Audit]"
                            + "          ,[OfficeAutomation_Flow_Suggestion]"
                            + "          ,[OfficeAutomation_Flow_AuditDate]"
                            + "          ,[OfficeAutomation_Flow_Auditor]"
                            + "          ,[OfficeAutomation_Flow_AuditorID]"
                            + "          ,[OfficeAutomation_Flow_IsAgree]"
                            + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
                            + " WHERE OfficeAutomation_Flow_MainID='" + mainID + "'"
                            + " ORDER BY OfficeAutomation_Flow_Idx ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据公文主键获取流程信息（倒序）20141204
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainIDDesc(string mainID)
        {
            string sql = "SELECT [OfficeAutomation_Flow_ID]"
                            + "          ,[OfficeAutomation_Flow_MainID]"
                            + "          ,[OfficeAutomation_Flow_Employee]"
                            + "          ,[OfficeAutomation_Flow_EmployeeID]"
                            + "          ,[OfficeAutomation_Flow_Idx]"
                            + "          ,[OfficeAutomation_Flow_Audit]"
                            + "          ,[OfficeAutomation_Flow_Suggestion]"
                            + "          ,[OfficeAutomation_Flow_AuditDate]"
                            + "          ,[OfficeAutomation_Flow_Auditor]"
                            + "          ,[OfficeAutomation_Flow_AuditorID]"
                            + "          ,[OfficeAutomation_Flow_IsAgree]"
                            + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
                            + " WHERE OfficeAutomation_Flow_MainID='" + mainID + "'"
                            + " ORDER BY OfficeAutomation_Flow_Idx DESC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据公文主键及审批人ID获取流程信息20150512
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByEID(string mainID, string td)
        {
            string sql = "SELECT [OfficeAutomation_Flow_ID]"
                            + "          ,[OfficeAutomation_Flow_MainID]"
                            + "          ,[OfficeAutomation_Flow_Employee]"
                            + "          ,[OfficeAutomation_Flow_EmployeeID]"
                            + "          ,[OfficeAutomation_Flow_Idx]"
                            + "          ,[OfficeAutomation_Flow_Audit]"
                            + "          ,[OfficeAutomation_Flow_Suggestion]"
                            + "          ,[OfficeAutomation_Flow_AuditDate]"
                            + "          ,[OfficeAutomation_Flow_Auditor]"
                            + "          ,[OfficeAutomation_Flow_AuditorID]"
                            + "          ,[OfficeAutomation_Flow_IsAgree]"
                            + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
                            + " WHERE OfficeAutomation_Flow_MainID='" + mainID + "'"
                            + "     AND OfficeAutomation_Flow_EmployeeID LIKE '%" + td + "%'";
                            

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据公文主键获取Idx之后的流程信息
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainIDAfterIdx(string mainID, int Idx)
        {
            string sql = "SELECT [OfficeAutomation_Flow_ID]"
                            + "          ,[OfficeAutomation_Flow_MainID]"
                            + "          ,[OfficeAutomation_Flow_Employee]"
                            + "          ,[OfficeAutomation_Flow_EmployeeID]"
                            + "          ,[OfficeAutomation_Flow_Idx]"
                            + "          ,[OfficeAutomation_Flow_Audit]"
                            + "          ,[OfficeAutomation_Flow_Suggestion]"
                            + "          ,[OfficeAutomation_Flow_AuditDate]"
                            + "          ,[OfficeAutomation_Flow_Auditor]"
                            + "          ,[OfficeAutomation_Flow_AuditorID]"
                            + "          ,[OfficeAutomation_Flow_IsAgree]"
                            + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
                            + " WHERE OfficeAutomation_Flow_MainID='" + mainID + "'"
                            + "     AND OfficeAutomation_Flow_Idx > " + Idx
                            + " ORDER BY OfficeAutomation_Flow_Idx ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据公文主键获取Idx及之前的流程信息
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainIDBeforeIdx(string mainID, int Idx)
        {
            string sql = "SELECT [OfficeAutomation_Flow_ID]"
                            + "          ,[OfficeAutomation_Flow_MainID]"
                            + "          ,[OfficeAutomation_Flow_Employee]"
                            + "          ,[OfficeAutomation_Flow_EmployeeID]"
                            + "          ,[OfficeAutomation_Flow_Idx]"
                            + "          ,[OfficeAutomation_Flow_Audit]"
                            + "          ,[OfficeAutomation_Flow_Suggestion]"
                            + "          ,[OfficeAutomation_Flow_AuditDate]"
                            + "          ,[OfficeAutomation_Flow_Auditor]"
                            + "          ,[OfficeAutomation_Flow_AuditorID]"
                            + "          ,[OfficeAutomation_Flow_IsAgree]"
                            + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
                            + " WHERE OfficeAutomation_Flow_MainID='" + mainID + "'"
                            + "     AND OfficeAutomation_Flow_Idx < " + Idx
                            + " ORDER BY OfficeAutomation_Flow_Idx ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据公文主键获取一定值Idx的流程信息，格式1,2,3,4......
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public DataSet SelectByMainIDInIdx(string mainID, string Idx)
        {
            string sql = "SELECT [OfficeAutomation_Flow_ID]"
                            + "          ,[OfficeAutomation_Flow_MainID]"
                            + "          ,[OfficeAutomation_Flow_Employee]"
                            + "          ,[OfficeAutomation_Flow_EmployeeID]"
                            + "          ,[OfficeAutomation_Flow_Idx]"
                            + "          ,[OfficeAutomation_Flow_Audit]"
                            + "          ,[OfficeAutomation_Flow_Suggestion]"
                            + "          ,[OfficeAutomation_Flow_AuditDate]"
                            + "          ,[OfficeAutomation_Flow_Auditor]"
                            + "          ,[OfficeAutomation_Flow_AuditorID]"
                            + "          ,[OfficeAutomation_Flow_IsAgree]"
                            + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
                            + " WHERE OfficeAutomation_Flow_MainID='" + mainID + "'"
                            + "     AND OfficeAutomation_Flow_Idx IN (" + Idx + ")"
                            + " ORDER BY OfficeAutomation_Flow_Idx ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据公文主键及序号获取指定流程信息实体
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public T_OfficeAutomation_Flow SelectByMainIDAndIdx(string mainID, int Idx)
        {
            T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
            string sql = "SELECT [OfficeAutomation_Flow_ID]"
                            + "          ,[OfficeAutomation_Flow_MainID]"
                            + "          ,[OfficeAutomation_Flow_Employee]"
                            + "          ,[OfficeAutomation_Flow_EmployeeID]"
                            + "          ,[OfficeAutomation_Flow_Idx]"
                            + "          ,[OfficeAutomation_Flow_Audit]"
                            + "          ,[OfficeAutomation_Flow_Suggestion]"
                            + "          ,[OfficeAutomation_Flow_AuditDate]"
                            + "          ,[OfficeAutomation_Flow_Auditor]"
                            + "          ,[OfficeAutomation_Flow_AuditorID]"
                            + "          ,[OfficeAutomation_Flow_IsAgree]"
                            + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
                            + " WHERE OfficeAutomation_Flow_MainID='" + mainID + "'"
                            + "     AND OfficeAutomation_Flow_Idx=" + Idx;

            DataSet ds = RunSQL(sql);
            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
            {
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = new Guid(ds.Tables[0].Rows[0]["OfficeAutomation_Flow_ID"].ToString());
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(ds.Tables[0].Rows[0]["OfficeAutomation_Flow_MainID"].ToString());
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = ds.Tables[0].Rows[0]["OfficeAutomation_Flow_Employee"].ToString();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = ds.Tables[0].Rows[0]["OfficeAutomation_Flow_EmployeeID"].ToString();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = int.Parse(ds.Tables[0].Rows[0]["OfficeAutomation_Flow_Idx"].ToString());
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Audit = ds.Tables[0].Rows[0]["OfficeAutomation_Flow_Audit"].ToString() == "True" ? true : false;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = ds.Tables[0].Rows[0]["OfficeAutomation_Flow_Suggestion"].ToString();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_AuditDate = DateTime.Parse(ds.Tables[0].Rows[0]["OfficeAutomation_Flow_AuditDate"].ToString() == "" ? "1900/1/1" : ds.Tables[0].Rows[0]["OfficeAutomation_Flow_AuditDate"].ToString());
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Auditor = ds.Tables[0].Rows[0]["OfficeAutomation_Flow_Auditor"].ToString();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_AuditorID = ds.Tables[0].Rows[0]["OfficeAutomation_Flow_AuditorID"].ToString();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_IsAgree = int.Parse((ds.Tables[0].Rows[0]["OfficeAutomation_Flow_IsAgree"].ToString() == "" ? "0" : ds.Tables[0].Rows[0]["OfficeAutomation_Flow_IsAgree"].ToString()));
            }
            else
                t_OfficeAutomation_Flow = null;

            return t_OfficeAutomation_Flow;
        }

        public void InsertNewFlow(Guid MainID,string EmployeeID, string Employee,int Idx,bool overwrite)
        {
            var t_OfficeAutomation_Flow = new DataEntity.T_OfficeAutomation_Flow();
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = EmployeeID;
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = Employee;
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = Idx;
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = MainID;
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
            //是否覆盖已存在流程
            if (overwrite)
            {
                DeleteByMainIDAndAfterIdx(MainID.ToString(), Idx);
                Insert(t_OfficeAutomation_Flow);
            }
            else
            {
                var flow = SelectByMainIDAfterIdx(MainID.ToString(), Idx);  //当前流程是否已存在
                if (flow == null || flow.Tables[0].Rows.Count == 0)
                { 
                    //不存在才插入新流程
                    Insert(t_OfficeAutomation_Flow);
                }
            }
        }

        /// <summary>
        /// 20170111添加 根据申请部门插入对应的hr审批人
        /// </summary>
        /// <param name="MainID"></param>
        /// <param name="EmployeeID"></param>
        /// <param name="Employee"></param>
        /// <param name="Idx"></param>
        public void InsertHrFlow(Guid MainID, string EmployeeID, string Employee, int Idx)
        {
            var t_OfficeAutomation_Flow = new DataEntity.T_OfficeAutomation_Flow();
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = EmployeeID;
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = Employee;
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = Idx;
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = MainID;
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

            var flow = SelectByMainIDAndIdx(MainID.ToString(), Idx);  //当前流程是否已存在
            if (flow == null)
            {
                //不存在才插入新流程
                Insert(t_OfficeAutomation_Flow);
            }
            else
            {
                DeleteByMainIDAndIdx(MainID.ToString(), Idx);
                Insert(t_OfficeAutomation_Flow);
            }
        }

        /// <summary>
        /// 根据公文主键及待审工号获取指定流程信息实体20150205
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public T_OfficeAutomation_Flow SelectByMainIDAndEID(string mainID, string eid)
        {
            T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
            string sql = "SELECT [OfficeAutomation_Flow_ID]"
                            + "          ,[OfficeAutomation_Flow_MainID]"
                            + "          ,[OfficeAutomation_Flow_Employee]"
                            + "          ,[OfficeAutomation_Flow_EmployeeID]"
                            + "          ,[OfficeAutomation_Flow_Idx]"
                            + "          ,[OfficeAutomation_Flow_Audit]"
                            + "          ,[OfficeAutomation_Flow_Suggestion]"
                            + "          ,[OfficeAutomation_Flow_AuditDate]"
                            + "          ,[OfficeAutomation_Flow_Auditor]"
                            + "          ,[OfficeAutomation_Flow_AuditorID]"
                            + "          ,[OfficeAutomation_Flow_IsAgree]"
                            + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
                            + " WHERE OfficeAutomation_Flow_MainID='" + mainID + "'"
                            + "     AND OfficeAutomation_Flow_EmployeeID='" + eid + "'"
                            + " ORDER BY OfficeAutomation_Flow_Idx ASC";

            DataSet ds = RunSQL(sql);
            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
            {
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = new Guid(ds.Tables[0].Rows[0]["OfficeAutomation_Flow_ID"].ToString());
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(ds.Tables[0].Rows[0]["OfficeAutomation_Flow_MainID"].ToString());
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = ds.Tables[0].Rows[0]["OfficeAutomation_Flow_Employee"].ToString();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = ds.Tables[0].Rows[0]["OfficeAutomation_Flow_EmployeeID"].ToString();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = int.Parse(ds.Tables[0].Rows[0]["OfficeAutomation_Flow_Idx"].ToString());
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Audit = ds.Tables[0].Rows[0]["OfficeAutomation_Flow_Audit"].ToString() == "True" ? true : false;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = ds.Tables[0].Rows[0]["OfficeAutomation_Flow_Suggestion"].ToString();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_AuditDate = DateTime.Parse(ds.Tables[0].Rows[0]["OfficeAutomation_Flow_AuditDate"].ToString() == "" ? "1900/1/1" : ds.Tables[0].Rows[0]["OfficeAutomation_Flow_AuditDate"].ToString());
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Auditor = ds.Tables[0].Rows[0]["OfficeAutomation_Flow_Auditor"].ToString();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_AuditorID = ds.Tables[0].Rows[0]["OfficeAutomation_Flow_AuditorID"].ToString();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_IsAgree = int.Parse((ds.Tables[0].Rows[0]["OfficeAutomation_Flow_IsAgree"].ToString() == "" ? "0" : ds.Tables[0].Rows[0]["OfficeAutomation_Flow_IsAgree"].ToString()));
            }
            else
                t_OfficeAutomation_Flow = null;

            return t_OfficeAutomation_Flow;
        }

        /// <summary>
        /// 根据公文主键及ID获取流程index后的信息实体
        /// </summary>
        /// <param name="mainID"></param>
        /// <returns></returns>
        public T_OfficeAutomation_Flow SelectByMainIDAndID(string mainID, string id, int index)
        {
            T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
            string sql = "SELECT top 1 [OfficeAutomation_Flow_ID]"
                            + "          ,[OfficeAutomation_Flow_MainID]"
                            + "          ,[OfficeAutomation_Flow_Employee]"
                            + "          ,[OfficeAutomation_Flow_EmployeeID]"
                            + "          ,[OfficeAutomation_Flow_Idx]"
                            + "          ,[OfficeAutomation_Flow_Audit]"
                            + "          ,[OfficeAutomation_Flow_Suggestion]"
                            + "          ,[OfficeAutomation_Flow_AuditDate]"
                            + "          ,[OfficeAutomation_Flow_Auditor]"
                            + "          ,[OfficeAutomation_Flow_AuditorID]"
                            + "          ,[OfficeAutomation_Flow_IsAgree]"
                            + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
                            + " WHERE OfficeAutomation_Flow_MainID='" + mainID + "'"
                            + "     AND OfficeAutomation_Flow_EmployeeID='" + id + "'"
                            + "     AND OfficeAutomation_Flow_Idx > " + index
                            + "     AND OfficeAutomation_Flow_Audit=0"
                            + "     order by [OfficeAutomation_Flow_Idx]";

            DataSet ds = RunSQL(sql);
            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
            {
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = new Guid(ds.Tables[0].Rows[0]["OfficeAutomation_Flow_ID"].ToString());
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(ds.Tables[0].Rows[0]["OfficeAutomation_Flow_MainID"].ToString());
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = ds.Tables[0].Rows[0]["OfficeAutomation_Flow_Employee"].ToString();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = ds.Tables[0].Rows[0]["OfficeAutomation_Flow_EmployeeID"].ToString();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = int.Parse(ds.Tables[0].Rows[0]["OfficeAutomation_Flow_Idx"].ToString());
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Audit = ds.Tables[0].Rows[0]["OfficeAutomation_Flow_Audit"].ToString() == "True" ? true : false;
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = ds.Tables[0].Rows[0]["OfficeAutomation_Flow_Suggestion"].ToString();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_AuditDate = DateTime.Parse(ds.Tables[0].Rows[0]["OfficeAutomation_Flow_AuditDate"].ToString() == "" ? "1900/1/1" : ds.Tables[0].Rows[0]["OfficeAutomation_Flow_AuditDate"].ToString());
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Auditor = ds.Tables[0].Rows[0]["OfficeAutomation_Flow_Auditor"].ToString();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_AuditorID = ds.Tables[0].Rows[0]["OfficeAutomation_Flow_AuditorID"].ToString();
                t_OfficeAutomation_Flow.OfficeAutomation_Flow_IsAgree = int.Parse((ds.Tables[0].Rows[0]["OfficeAutomation_Flow_IsAgree"].ToString() == "" ? "0" : ds.Tables[0].Rows[0]["OfficeAutomation_Flow_IsAgree"].ToString()));
            }
            else
                t_OfficeAutomation_Flow = null;

            return t_OfficeAutomation_Flow;
        }

        /// <summary>
        /// 通用申请审批流
        /// </summary>
        /// <param name="sMainID"></param>
        /// <returns></returns>
        public bool AddGeneralApplyFlow(string sMainID)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "pr_AddGroups";

            cmdToExecute.CommandType = CommandType.StoredProcedure;

            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, new Guid(sMainID)));
              
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Open();

                    cmdToExecute.Transaction = _mainConnection.BeginTransaction();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                _rowsAffected = cmdToExecute.ExecuteNonQuery();

                if (_mainConnectionIsCreatedLocal)
                {
                    cmdToExecute.Transaction.Commit();
                }

                return true;
            }
            catch (Exception ex)
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    cmdToExecute.Transaction.Rollback();
                }
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Close();
                }

                cmdToExecute.Dispose();
            }

        }
        #region 用于签名更新

        /// <summary>
        /// 用于签名所需要完成的更新
        /// </summary>
        /// <param name="mainid"></param>
        /// <param name="employeeid"></param>
        /// <param name="employeename"></param>
        /// <returns></returns>
        public bool UpdateForSign(string mainid, string employeeid, string employeename, string suggestion, string flowIDx)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "pr_UpdateForSign";

            cmdToExecute.CommandType = CommandType.StoredProcedure;

            cmdToExecute.Connection = _mainConnection;

            try
            {
                //cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Flow_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, obj.OfficeAutomation_Flow_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Flow_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, new Guid(mainid)));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Flow_EmployeeID", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, employeeid));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Flow_Employee", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, employeename));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Flow_Idx", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, int.Parse(flowIDx)));
                //cmdToExecute.Parameters.Add(new SqlParameter("@bOfficeAutomation_Flow_Audit", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, obj.OfficeAutomation_Flow_Audit));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Flow_Suggestion", suggestion));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Flow_AuditDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DateTime.Now));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Flow_AuditorID", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, employeeid));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Flow_Auditor", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, employeename));

                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Open();

                    cmdToExecute.Transaction = _mainConnection.BeginTransaction();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                _rowsAffected = cmdToExecute.ExecuteNonQuery();

                if (_mainConnectionIsCreatedLocal)
                {
                    cmdToExecute.Transaction.Commit();
                }

                return true;
            }
            catch (Exception ex)
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    cmdToExecute.Transaction.Rollback();
                }
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Close();
                }

                cmdToExecute.Dispose();
            }
        }

        /// <summary>
        /// 用于签名所需要完成的更新，包含IsAgree字段更新
        /// </summary>
        /// <param name="mainid"></param>
        /// <param name="employeeid"></param>
        /// <param name="employeename"></param>
        /// <param name="suggestion"></param>
        /// <param name="flowIDx"></param>
        /// <param name="isAgree">输入1或0或2，1为同意，0为不同意，2为其他意见</param>
        /// <returns></returns>
        public bool UpdateContainIsAgreeForSign(string mainid, string employeeid, string employeename, string suggestion, string flowIDx, string isAgree)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "pr_UpdateContainIsAgreeForSign";

            cmdToExecute.CommandType = CommandType.StoredProcedure;

            cmdToExecute.Connection = _mainConnection;

            try
            {
                //cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Flow_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, obj.OfficeAutomation_Flow_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Flow_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, new Guid(mainid)));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Flow_EmployeeID", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, employeeid));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Flow_Employee", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, employeename));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Flow_Idx", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, int.Parse(flowIDx)));
                //cmdToExecute.Parameters.Add(new SqlParameter("@bOfficeAutomation_Flow_Audit", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, obj.OfficeAutomation_Flow_Audit));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Flow_Suggestion", suggestion));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Flow_AuditDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DateTime.Now));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Flow_AuditorID", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, employeeid));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Flow_Auditor", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, employeename));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Flow_IsAgree", SqlDbType.Int, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, int.Parse(isAgree)));

                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Open();

                    cmdToExecute.Transaction = _mainConnection.BeginTransaction();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                _rowsAffected = cmdToExecute.ExecuteNonQuery();

                if (_mainConnectionIsCreatedLocal)
                {
                    cmdToExecute.Transaction.Commit();
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();

                //推送手机通知下一步需要审批的人员 2014-05-21
                string employid = GetWaitForAuditorIDByMainID(mainid);
                if (!string.IsNullOrEmpty(employid))
                {
                    string[] employids = employid.Split(',');
                    for (int i = 0; i < employids.Length; i++)
                    {
                        try
                        {
                            if (System.Configuration.ConfigurationSettings.AppSettings["IsPush"] == "True")
                                SendDirecePushMessageByEmpCodeAndApplyName(GetDocumentNameByMainID(mainid), employids[i]);
                        }
                        catch { }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    cmdToExecute.Transaction.Rollback();
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();

                throw new Exception(ex.Message.ToString());
            }
        }

        public bool UpdateContainIsAgreeForSignNew(string mainid, string employeeid, string employeename, string suggestion, string flowIDx, string isAgree, string flowid, int flowstate, string empidsum, string empnamesum)
        {
            try
            {
                string sSql = "dbo.[pr_UpdateContainIsAgreeForSignNew]";
                #region parameters
                List<SqlParameter> parameters = new List<SqlParameter>();

                parameters.Add(new SqlParameter("@guidOfficeAutomation_Flow_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, new Guid(mainid)));
                parameters.Add(new SqlParameter("@iOfficeAutomation_Flow_Idx", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, int.Parse(flowIDx)));
                parameters.Add(new SqlParameter("@sOfficeAutomation_Flow_Suggestion", SqlDbType.NVarChar, 1000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, suggestion));
                parameters.Add(new SqlParameter("@dtOfficeAutomation_Flow_AuditDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DateTime.Now));
                parameters.Add(new SqlParameter("@sOfficeAutomation_Flow_AuditorID", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, employeeid));
                parameters.Add(new SqlParameter("@sOfficeAutomation_Flow_Auditor", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, employeename));
                parameters.Add(new SqlParameter("@iOfficeAutomation_Flow_IsAgree", SqlDbType.Int, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, int.Parse(isAgree)));

                parameters.Add(new SqlParameter("@guidOfficeAutomation_Flow_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, new Guid(flowid)));
                parameters.Add(new SqlParameter("@iOfficeAutomation_Main_FlowStateID", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, flowstate));
                parameters.Add(new SqlParameter("@sOfficeAutomation_Main_AuditorIDsSum", SqlDbType.NVarChar, 800, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empidsum));
                parameters.Add(new SqlParameter("@sOfficeAutomation_Main_AuditorNamesSum", SqlDbType.NVarChar, 800, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empnamesum));

                #endregion

                int i = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, sSql, parameters.ToArray());

                return i > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        /// <summary>
        /// 用于可多人同时签名所需要完成的更新
        /// </summary>
        /// <param name="mainid"></param>
        /// <param name="employeeid"></param>
        /// <param name="employeename"></param>
        /// <returns></returns>
        public bool UpdateForSignAndMulti(string mainid, string employeeid, string employeename, string suggestion, string flowIDx)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "pr_UpdateForSignAndMulti";

            cmdToExecute.CommandType = CommandType.StoredProcedure;

            cmdToExecute.Connection = _mainConnection;

            try
            {
                //cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Flow_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, obj.OfficeAutomation_Flow_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Flow_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, new Guid(mainid)));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Flow_EmployeeID", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, employeeid));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Flow_Employee", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, employeename));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Flow_Idx", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, int.Parse(flowIDx)));
                //cmdToExecute.Parameters.Add(new SqlParameter("@bOfficeAutomation_Flow_Audit", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, obj.OfficeAutomation_Flow_Audit));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Flow_Suggestion", suggestion));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Flow_AuditDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DateTime.Now));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Flow_AuditorID", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, employeeid));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Flow_Auditor", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, employeename));

                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Open();

                    cmdToExecute.Transaction = _mainConnection.BeginTransaction();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                _rowsAffected = cmdToExecute.ExecuteNonQuery();

                if (_mainConnectionIsCreatedLocal)
                {
                    cmdToExecute.Transaction.Commit();
                }

                return true;
            }
            catch (Exception ex)
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    cmdToExecute.Transaction.Rollback();
                }
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Close();
                }

                cmdToExecute.Dispose();
            }
        }

        /// <summary>
        /// 用于可多人同时签名所需要完成的更新，包含IsAgree字段更新
        /// </summary>
        /// <param name="mainid"></param>
        /// <param name="employeeid"></param>
        /// <param name="employeename"></param>
        /// <param name="suggestion"></param>
        /// <param name="flowIDx"></param>
        /// <param name="isAgree">输入1或0或2，1为同意，0为不同意，2为其他意见</param>
        /// <returns></returns>
        public bool UpdateContainIsAgreeForSignAndMulti(string mainid, string employeeid, string employeename, string suggestion, string flowIDx, string isAgree)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "pr_UpdateContainIsAgreeForSignAndMulti";

            cmdToExecute.CommandType = CommandType.StoredProcedure;

            cmdToExecute.Connection = _mainConnection;

            try
            {
                //cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Flow_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, obj.OfficeAutomation_Flow_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Flow_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, new Guid(mainid)));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Flow_EmployeeID", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, employeeid));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Flow_Employee", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, employeename));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Flow_Idx", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, int.Parse(flowIDx)));
                //cmdToExecute.Parameters.Add(new SqlParameter("@bOfficeAutomation_Flow_Audit", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, obj.OfficeAutomation_Flow_Audit));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Flow_Suggestion", suggestion));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Flow_AuditDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DateTime.Now));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Flow_AuditorID", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, employeeid));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Flow_Auditor", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, employeename));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Flow_IsAgree", SqlDbType.Int, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, int.Parse(isAgree)));

                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Open();

                    cmdToExecute.Transaction = _mainConnection.BeginTransaction();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                _rowsAffected = cmdToExecute.ExecuteNonQuery();

                if (_mainConnectionIsCreatedLocal)
                {
                    cmdToExecute.Transaction.Commit();
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();

                //推送手机通知下一步需要审批的人员 2014-05-21
                string employid = GetWaitForAuditorIDByMainID(mainid);
                if (!string.IsNullOrEmpty(employid))
                {
                    string[] employids = employid.Split(',');
                    for (int i = 0; i < employids.Length; i++)
                    {
                        try
                        {
                            if (System.Configuration.ConfigurationSettings.AppSettings["IsPush"] == "True")
                                SendDirecePushMessageByEmpCodeAndApplyName(GetDocumentNameByMainID(mainid), employids[i]);
                        }
                        catch { }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    cmdToExecute.Transaction.Rollback();
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
                throw new Exception(ex.Message.ToString());
            }
        }

        public bool UpdateContainIsAgreeForSignAndMultiNew_V2(string mainid, string employeeid, string employeename, string suggestion, string flowIDx, string isAgree, string flowid, int flowstate, string empidsum, string empnamesum, int islastemp)
        {
            try
            {
                string sSql = "dbo.[pr_UpdateContainIsAgreeForSignAndMultiNew_V2]";
                #region parameters
                List<SqlParameter> parameters = new List<SqlParameter>();

                //parameters.Add(new SqlParameter("@guidOfficeAutomation_Flow_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, obj.OfficeAutomation_Flow_ID));
                parameters.Add(new SqlParameter("@guidOfficeAutomation_Flow_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, new Guid(mainid)));
                //parameters.Add(new SqlParameter("@sOfficeAutomation_Flow_EmployeeID", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, employeeid));
                //parameters.Add(new SqlParameter("@sOfficeAutomation_Flow_Employee", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, employeename));
                parameters.Add(new SqlParameter("@iOfficeAutomation_Flow_Idx", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, int.Parse(flowIDx)));
                //parameters.Add(new SqlParameter("@bOfficeAutomation_Flow_Audit", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, obj.OfficeAutomation_Flow_Audit));
                parameters.Add(new SqlParameter("@sOfficeAutomation_Flow_Suggestion", SqlDbType.NVarChar, 1000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, suggestion));
                parameters.Add(new SqlParameter("@dtOfficeAutomation_Flow_AuditDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DateTime.Now));
                parameters.Add(new SqlParameter("@sOfficeAutomation_Flow_AuditorID", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, employeeid));
                parameters.Add(new SqlParameter("@sOfficeAutomation_Flow_Auditor", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, employeename));
                parameters.Add(new SqlParameter("@iOfficeAutomation_Flow_IsAgree", SqlDbType.Int, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, int.Parse(isAgree)));

                parameters.Add(new SqlParameter("@guidOfficeAutomation_Flow_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, new Guid(flowid)));
                parameters.Add(new SqlParameter("@iOfficeAutomation_Main_FlowStateID", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, flowstate));
                parameters.Add(new SqlParameter("@sOfficeAutomation_Main_AuditorIDsSum", SqlDbType.NVarChar, 800, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empidsum));
                parameters.Add(new SqlParameter("@sOfficeAutomation_Main_AuditorNamesSum", SqlDbType.NVarChar, 800, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empnamesum));
                parameters.Add(new SqlParameter("@iOfficeAutomation_Flow_IsLastEmp", SqlDbType.Int, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, islastemp));

                #endregion

                int i = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, sSql, parameters.ToArray());

                return i > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        #endregion

        /// <summary>
        /// 根据工号获得该员工未处理的申请数量
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="employeeName"></param>
        /// <returns></returns>
        public int GetUnhandledApplyCount(string employeeID, string employeeName)
        {
            DA_OfficeAutomation_Agent_Inherit da_OfficeAutomation_Agent_Inherit = new DA_OfficeAutomation_Agent_Inherit();
            string myAgency = da_OfficeAutomation_Agent_Inherit.GetMyAgencyForSQL(employeeName, employeeID);

            string sql = "SELECT COUNT(*)"
                          + " FROM   ("
                          + "           SELECT tidx.OfficeAutomation_Flow_MainID"
                          + "           FROM   (SELECT OfficeAutomation_Flow_MainID,"
                          + "                                   OfficeAutomation_Flow_Idx AS idx"
                          + "                        FROM   [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
                          + "                        WHERE  ((OfficeAutomation_Flow_EmployeeID LIKE '%" + employeeID + "%'"
                          + "                             AND OfficeAutomation_Flow_Employee LIKE '%" + employeeName + "%')"
                           + myAgency
                //+ "                   ) AND OfficeAutomation_Flow_Audit = 0) tidx"
                + "                   ) AND OfficeAutomation_Flow_Audit = 0 AND (OfficeAutomation_Flow_AuditorID not like '%" + employeeID + "%' OR OfficeAutomation_Flow_AuditorID IS NULL)) tidx"  //+20150121：在多人审批中，审完后不再提示
                          + "           LEFT JOIN (SELECT OfficeAutomation_Flow_MainID,"
                          + "                                       Min(toaf.OfficeAutomation_Flow_Idx) AS minidx"
                          + "                            FROM   t_OfficeAutomation_Flow toaf"
                          + "                            WHERE  toaf.OfficeAutomation_Flow_MainID IN (SELECT OfficeAutomation_Flow_MainID"
                          + "                                                                                                   FROM   t_OfficeAutomation_Flow toaf"
                          + "                                                                                                   WHERE  ((OfficeAutomation_Flow_EmployeeID LIKE '%" + employeeID + "%'"
                          + "                                                                                                        AND OfficeAutomation_Flow_Employee LIKE '%" + employeeName + "%')"
                           + myAgency
                //+ "                                                                         ) AND OfficeAutomation_Flow_Audit = 0)"
                + "                                                                         ) AND OfficeAutomation_Flow_Audit = 0 AND (OfficeAutomation_Flow_AuditorID not like '%" + employeeID + "%' OR OfficeAutomation_Flow_AuditorID IS NULL))"  //+20150121：在多人审批中，审完后不再提示
                          + "                            GROUP  BY toaf.OfficeAutomation_Flow_MainID) tminidx"
                          + "            ON tminidx.OfficeAutomation_Flow_MainID = tidx.OfficeAutomation_Flow_MainID"
                          + "            WHERE  tminidx.minidx = tidx.idx "//以上为查出流程中第一人为该人，且未审批的记录
                          + "            AND tidx.OfficeAutomation_Flow_MainID NOT IN (select OfficeAutomation_Main_ID FROM t_OfficeAutomation_Main where OfficeAutomation_Main_WillDelete = 1 or OfficeAutomation_Main_FlowStateID=8 ) and tidx.OfficeAutomation_Flow_MainID!='00000000-0000-0000-0000-000000000000'"
                          + "            AND EXISTS (SELECT OfficeAutomation_Main_ID FROM t_OfficeAutomation_Main WHERE OfficeAutomation_Main_IsDelete =0 and OfficeAutomation_Main_ID =tidx.OfficeAutomation_Flow_MainID)"
                          + "            UNION"
                          + "            SELECT t1.OfficeAutomation_Flow_MainID"
                          + "            FROM   (SELECT toaf.*"
                          + "                         FROM   t_OfficeAutomation_Flow toaf"
                          + "                                     RIGHT JOIN (SELECT OfficeAutomation_Flow_MainID,"
                          + "                                                                    min(OfficeAutomation_Flow_Idx) as Idx"
                          + "                                                         FROM   [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
                          + "                                                         WHERE  ((OfficeAutomation_Flow_EmployeeID LIKE '%" + employeeID + "%'"
                          + "                                                                      AND OfficeAutomation_Flow_Employee LIKE '%" + employeeName + "%')"
                           + myAgency
                          + "                                                                     ) AND OfficeAutomation_Flow_Audit = 0"
                          + "                 AND (OfficeAutomation_Flow_AuditorID not like '%" + employeeID + "%'  OR OfficeAutomation_Flow_AuditorID IS NULL)" //+20150121：在多人审批中，审完后不再提示
                          + "                                                                      AND OfficeAutomation_Flow_Idx <> 1"
                          + "                                                         GROUP BY OfficeAutomation_Flow_MainID) old"
                          + "                                                   ON old.OfficeAutomation_Flow_MainID = toaf.OfficeAutomation_Flow_MainID"
                + "                         WHERE  toaf.OfficeAutomation_Flow_Idx < old.Idx AND toaf.OfficeAutomation_Flow_MainID NOT IN (select OfficeAutomation_Main_ID FROM t_OfficeAutomation_Main where OfficeAutomation_Main_WillDelete = 1 or OfficeAutomation_Main_FlowStateID=8)) t1"
                          //+ "                         WHERE  toaf.OfficeAutomation_Flow_Idx < old.Idx) t1"
                          + "            WHERE  t1.OfficeAutomation_Flow_Idx = (SELECT Max(t2.OfficeAutomation_Flow_Idx)"
                          + "                                                                        FROM   (SELECT toaf.*"
                          + "                                                                                     FROM   t_OfficeAutomation_Flow toaf"
                          + "                                                                                                 RIGHT JOIN (SELECT OfficeAutomation_Flow_MainID,"
                          + "                                                                                                                                min(OfficeAutomation_Flow_Idx) as Idx"
                          + "                                                                                                                     FROM   [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
                          + "                                                                                                                     WHERE  ((OfficeAutomation_Flow_EmployeeID LIKE '%" + employeeID + "%'"
                          + "                                                                                                                                 AND OfficeAutomation_Flow_Employee LIKE '%" + employeeName + "%')"
                           + myAgency
                          + "                                                                                                                                ) AND OfficeAutomation_Flow_Audit = 0"
                          + "                 AND (OfficeAutomation_Flow_AuditorID not like '%" + employeeID + "%'  OR OfficeAutomation_Flow_AuditorID IS NULL)" //+20150121：在多人审批中，审完后不再提示
                          + "                                                                                                                                 AND OfficeAutomation_Flow_Idx <> 1"
                          + "                                                                                                                     GROUP BY OfficeAutomation_Flow_MainID) old"
                          + "                                                                                                             ON old.OfficeAutomation_Flow_MainID = toaf.OfficeAutomation_Flow_MainID"
                          + "                                                                                    WHERE  toaf.OfficeAutomation_Flow_Idx < old.Idx)t2"
                          + "                                                                       WHERE  t2.OfficeAutomation_Flow_MainID = t1.OfficeAutomation_Flow_MainID)"
                          + "                         AND t1.OfficeAutomation_Flow_Audit = 1 AND EXISTS (SELECT OfficeAutomation_Main_ID FROM t_OfficeAutomation_Main WHERE OfficeAutomation_Main_IsDelete =0 and OfficeAutomation_Main_ID =t1.OfficeAutomation_Flow_MainID)) t ";
            //+"                         AND t1.OfficeAutomation_Flow_Audit = 1 AND (t1.OfficeAutomation_Flow_AuditorID not like '%" + employeeID + "%' OR t1.OfficeAutomation_Flow_AuditorID IS NULL)) t ";

            return RunCountSQL(sql);
        }

        public int GetUnhandledApplyCount(string employeeID, string employeeName, List<DataEntity.DTO.AgentDto> agents)
        {
            string agentwaitforstr = "";
            if (agents != null && agents.Count > 0)
            {
                foreach (var i in agents)
                {
                    agentwaitforstr += " OR (A.OfficeAutomation_Flow_Employee LIKE '%" + i.AgentEmpName + "%' AND A.OfficeAutomation_Flow_EmployeeID LIKE '%" + i.AgentEmpID + "%'"
                    + " AND (ISNULL(A.OfficeAutomation_Flow_Auditor,'') NOT LIKE '%" + i.AgentEmpName + "%'  AND ISNULL(A.OfficeAutomation_Flow_AuditorID,'') NOT LIKE '%" + i.AgentEmpID + "%') ) ";
                }
            }

            string sql = 
@"SELECT COUNT(OfficeAutomation_Flow_MainID) FROM t_OfficeAutomation_Flow A WHERE EXISTS (
	SELECT 1 FROM (
		SELECT OfficeAutomation_Flow_MainID,MIN(f.OfficeAutomation_Flow_Idx) AS OfficeAutomation_Flow_Idx
		FROM t_OfficeAutomation_Flow f
		LEFT JOIN t_OfficeAutomation_Main m ON m.OfficeAutomation_Main_ID=f.OfficeAutomation_Flow_MainID
		WHERE f.OfficeAutomation_Flow_Audit=0 AND m.OfficeAutomation_Main_FlowStateID IN (1,2,3) AND m.OfficeAutomation_Main_IsDelete=0 AND m.OfficeAutomation_Main_WillDelete=0
		GROUP BY OfficeAutomation_Flow_MainID
	) AS B
WHERE A.OfficeAutomation_Flow_MainID= B.OfficeAutomation_Flow_MainID AND A.OfficeAutomation_Flow_Idx=B.OfficeAutomation_Flow_Idx 
) AND ((A.OfficeAutomation_Flow_Employee LIKE '%{0}%' AND A.OfficeAutomation_Flow_EmployeeID LIKE '%{1}%' {2}) AND (ISNULL(A.OfficeAutomation_Flow_Auditor,'') NOT LIKE '%{0}%' AND ISNULL(A.OfficeAutomation_Flow_AuditorID,'') NOT LIKE '%{1}%'))";
            sql = string.Format(sql, employeeName, employeeID, agentwaitforstr);
            return RunCountSQL(sql);
        }

        /// <summary>
        /// 根据工号获得该员工需删除的申请数量
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="employeeName"></param>
        /// <returns></returns>
        public int GetDeleteC(string employeeID, string employeeName)
        {
            string sql = "SELECT COUNT(DISTINCT OfficeAutomation_SerialNumber)"
                    + "         FROM t_OfficeAutomation_Main m"
                    + "         LEFT JOIN t_OfficeAutomation_DeletedFlow f"
                    + "         ON m.OfficeAutomation_Main_ID = f.OfficeAutomation_DeletedFlow_MainID"
                    + "         WHERE m.OfficeAutomation_Main_WillDelete = 1"
                    + "         AND (f.OfficeAutomation_DeletedFlow_Auditor LIKE '%" + employeeName + "%' AND f.OfficeAutomation_DeletedFlow_AuditorID LIKE '%" + employeeID + "%') AND m.OfficeAutomation_Main_IsDelete=0";
            return RunCountSQL(sql);
        }

        public int GetDeleteD(string employeeID, string employeeName)
        {
            string sql =
@"
SELECT COUNT(*)
FROM t_OfficeAutomation_Main m 
WHERE EXISTS (SELECT 1 FROM t_OfficeAutomation_DeletedFlow WHERE OfficeAutomation_DeletedFlow_MainID=m.OfficeAutomation_Main_ID   AND OfficeAutomation_DeletedFlow_Auditor  LIKE '%{0}%' AND OfficeAutomation_DeletedFlow_AuditorID  LIKE '%{1}%' ) 
AND m.OfficeAutomation_Main_IsDelete=0 AND m.OfficeAutomation_Main_WillDelete=1
";
            sql = string.Format(sql, employeeName, employeeID);
            return RunCountSQL(sql);
        }

        #region 删除流程

        /// <summary>
        /// 根据MainID删除对应流程
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public bool DeleteByMainID(string mainid)
        {
            string sql = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
                            + "           WHERE  [OfficeAutomation_Flow_MainID] = '" + mainid + "'";

            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 根据MainID及Idx删除对应流程
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public bool DeleteByMainIDAndIdx(string mainid,int idx)
        {
            string sql = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
                            + "           WHERE  [OfficeAutomation_Flow_MainID] = '" + mainid + "'"
                            + "               AND  [OfficeAutomation_Flow_Idx] = " + idx;

            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 根据MainID删除Idx之后所对应的流程
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public bool DeleteByMainIDAndAfterIdx(string mainid, int idx)
        {
            string sql = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
                            + "           WHERE  [OfficeAutomation_Flow_MainID] = '" + mainid + "'"
                            + "               AND  [OfficeAutomation_Flow_Idx] > " + idx;

            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 根据MainID删除Idx和Idx之后所对应的流程20141114
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public bool DeleteByMainIDAndAfterIdxs(string mainid, int idx)
        { 
            string sql = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
                            + "           WHERE  [OfficeAutomation_Flow_MainID] = '" + mainid + "'"
                            + "               AND  [OfficeAutomation_Flow_Idx] >= " + idx;

            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 删除未审批的流程20150128
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public bool DeleteHaventA(string mainid)
        {
            string sql = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
                            + "           WHERE  [OfficeAutomation_Flow_MainID] = '" + mainid + "'"
                            + "               AND  [OfficeAutomation_Flow_AuditorID] IS NULL ";

            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 根据MainID把审批流程都设为已审20150807
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public bool UpdateTrueByMainID(string mainid)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
                            + "set [OfficeAutomation_Flow_Idx] = 1"
                            + "           WHERE  [OfficeAutomation_Flow_MainID] = '" + mainid + "'";

            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 根据MainID增加Idx和Idx之后所对应的流程20141114
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public bool AddByMainIDAndAfterIdxs(string mainid, int idx, int add)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
                            + "set [OfficeAutomation_Flow_Idx] = [OfficeAutomation_Flow_Idx] + " + add
                            + "           WHERE  [OfficeAutomation_Flow_MainID] = '" + mainid + "'"
                            + "               AND  [OfficeAutomation_Flow_Idx] >= " + idx;

            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 根据MainID增加Idx和Idx之后所对应的流程20141114
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public bool AddByMainIDAndIdxs(string mainid, int idx, int add)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
                            + "set [OfficeAutomation_Flow_Idx] = [OfficeAutomation_Flow_Idx] + " + add
                            + "           WHERE  [OfficeAutomation_Flow_MainID] = '" + mainid + "'"
                            + "               AND  [OfficeAutomation_Flow_Idx] = " + idx;

            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 根据MainID清空Idx和Idx之后所对应的签名20141202
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public bool SetNullByMainIDAndAfterIdxs(string mainid, int idx)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
                            + "    SET OfficeAutomation_Flow_Audit = 0,"
                            //+ "    OfficeAutomation_Flow_Suggestion = '',"
                            //+ "    OfficeAutomation_Flow_AuditDate = NULL,"
                            + "    OfficeAutomation_Flow_Auditor = NULL,"
                            + "    OfficeAutomation_Flow_AuditorID = NULL,"
                            + "    OfficeAutomation_Flow_IsAgree = NULL"
                            + "           WHERE  [OfficeAutomation_Flow_MainID] = '" + mainid + "'"
                            + "               AND  [OfficeAutomation_Flow_Idx] >= " + idx;
            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 根据MainID清空Idx之后所对应的签名20141204
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public bool UpdateAfterByMainIDAndIdxs(string mainid, int idx)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
                            + "    SET OfficeAutomation_Flow_Audit = 0,"
                            //+ "    OfficeAutomation_Flow_Suggestion = '',"
                            + "    OfficeAutomation_Flow_AuditDate = NULL,"
                            + "    OfficeAutomation_Flow_Auditor = NULL,"
                            + "    OfficeAutomation_Flow_AuditorID = NULL,"
                            + "    OfficeAutomation_Flow_IsAgree = NULL"
                            + "           WHERE  [OfficeAutomation_Flow_MainID] = '" + mainid + "'"
                            + "               AND  [OfficeAutomation_Flow_Idx] > " + idx;
            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 根据MainID清空Idx所对应的签名20150105
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public bool SetNullByMainIDAndIdxs(string mainid, int idx)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
                            + "    SET OfficeAutomation_Flow_Audit = 0,"
                            //+ "    OfficeAutomation_Flow_Suggestion = '',"
                            + "    OfficeAutomation_Flow_AuditDate = NULL,"
                            + "    OfficeAutomation_Flow_Auditor = NULL,"
                            + "    OfficeAutomation_Flow_AuditorID = NULL,"
                            + "    OfficeAutomation_Flow_IsAgree = NULL"
                            + "           WHERE  [OfficeAutomation_Flow_MainID] = '" + mainid + "'"
                            + "               AND  [OfficeAutomation_Flow_Idx] = " + idx;
            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 根据MainID更新Idx所对应的签名20141204
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public bool UpdateByMainIDAndIdxs(string mainid, int idx, string namea, string ida)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
                            + "    SET OfficeAutomation_Flow_Auditor = '" + namea + "',"
                            + "    OfficeAutomation_Flow_AuditorID = '" + ida + "',"
                            + "    OfficeAutomation_Flow_Audit = 0,"
                            + "    OfficeAutomation_Flow_IsAgree = 1"
                            + "           WHERE  [OfficeAutomation_Flow_MainID] = '" + mainid + "'"
                            + "               AND  [OfficeAutomation_Flow_Idx] = " + idx;
            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 根据MainID更新Idx所对应的审批人20150325
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public bool UpdateEIDByMainIDAndIdxs(string mainid, int idx, string namea, string ida)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
                            + "    SET OfficeAutomation_Flow_Employee = '" + namea + "',"
                            + "    OfficeAutomation_Flow_EmployeeID = '" + ida + "',"
                            + "    OfficeAutomation_Flow_Audit = 0"
                            + "           WHERE  [OfficeAutomation_Flow_MainID] = '" + mainid + "'"
                            + "               AND  [OfficeAutomation_Flow_Idx] = " + idx;
            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 根据MainID更新所对应的审批人20150511
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public bool UpdateEIDByMainIDAndEName(string mainid, string td, string namea, string ida)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
                            + "    SET OfficeAutomation_Flow_Employee = '" + namea + "',"
                            + "    OfficeAutomation_Flow_EmployeeID = '" + ida + "',"
                            + "    OfficeAutomation_Flow_Audit = 0"
                            + "           WHERE  [OfficeAutomation_Flow_MainID] = '" + mainid + "'"
                            + "               AND  [OfficeAutomation_Flow_EmployeeID] LIKE '%" + td + "%'";
            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 根据MainID清空审批人所对应的签名20150512
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public bool SetNullByMainIDAndEName(string mainid, string td)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
                            + "    SET OfficeAutomation_Flow_Audit = 0,"
                //+ "    OfficeAutomation_Flow_Suggestion = '',"
                            + "    OfficeAutomation_Flow_AuditDate = NULL,"
                            + "    OfficeAutomation_Flow_Auditor = NULL,"
                            + "    OfficeAutomation_Flow_AuditorID = NULL,"
                            + "    OfficeAutomation_Flow_IsAgree = NULL"
                            + "           WHERE  [OfficeAutomation_Flow_MainID] = '" + mainid + "'"
                            + "               AND  [OfficeAutomation_Flow_EmployeeID] LIKE '%" + td + "%'";
            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 根据MainID更新Idx所对应的签名，包括时间和建议等
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public bool UpdateByMainIDAndIdxsAndOther(string mainid, int idx, string namea, string ida, string dt, string su, string ad, string isa)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
                            + "    SET OfficeAutomation_Flow_Auditor = '" + namea + "',"
                            + "    OfficeAutomation_Flow_AuditorID = '" + ida + "',"
                            + "    OfficeAutomation_Flow_AuditDate = CAST('" + dt + "' AS datetime),"
                            + "    OfficeAutomation_Flow_Suggestion = '" + su + "',"
                            + "    OfficeAutomation_Flow_Audit = " + ad + ","
                            + "    OfficeAutomation_Flow_IsAgree = " + isa + ""
                            + "           WHERE  [OfficeAutomation_Flow_MainID] = '" + mainid + "'"
                            + "               AND  [OfficeAutomation_Flow_Idx] = " + idx;
            return RunNoneSQL(sql);
        }
        /// <summary>
        /// 根据MainID更新Idx所对应的签名，包括时间和建议等（用于电子上传申请）
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public bool UpdateFaxByMainIDAndIdxsAndOther(string mainid, int idx, string namea, string ida, string dt, string su, string ad, string isa,string kID)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
                            + "    SET OfficeAutomation_Flow_Auditor = '" + namea + "',"
                            + "    OfficeAutomation_Flow_AuditorID = '" + ida + "',"
                            + "    OfficeAutomation_Flow_AuditDate = CAST('" + dt + "' AS datetime),"
                            + "    OfficeAutomation_Flow_Suggestion = '" + su + "',"
                            + "    OfficeAutomation_Flow_Audit = " + ad + ","
                            + "    OfficeAutomation_Flow_ID = '" + kID + "',"
                            + "    OfficeAutomation_Flow_IsAgree = " + isa + ""
                            + "           WHERE  [OfficeAutomation_Flow_MainID] = '" + mainid + "'"
                            + "               AND  [OfficeAutomation_Flow_Idx] = " + idx;
            return RunNoneSQL(sql);
        }
        /// <summary>
        /// 根据MainID更新Idx所对应的建议
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public bool UpdateFlowsSuggestion(string mainid, string idx, string su)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
                            + "    SET OfficeAutomation_Flow_Suggestion = '" + su + "'"
                            + "           WHERE  [OfficeAutomation_Flow_MainID] = '" + mainid + "'"
                            + "               AND  [OfficeAutomation_Flow_Idx] = '" + idx + "'";
            return RunNoneSQL(sql);
        }

        ///// <summary>
        ///// 根据MainID更新Idx所对应的建议和意见 20150820
        ///// </summary>
        ///// <param name="employeeID"></param>
        ///// <returns></returns>
        //public bool UpdateFlowsSuggestionA(string mainid, string idx, string su, string isa)
        //{
        //    string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
        //                    + "    SET OfficeAutomation_Flow_Suggestion = '" + su + "'"
        //                    + "        ,OfficeAutomation_Flow_IsAgree = " + isa
        //                    + "        ,OfficeAutomation_Flow_AuditDate = '" + DateTime.Now + "'"
        //                    + "           WHERE  [OfficeAutomation_Flow_MainID] = '" + mainid + "'"
        //                    + "               AND  [OfficeAutomation_Flow_Idx] = '" + idx + "'";
        //    return RunNoneSQL(sql);
        //}

        ///// <summary>
        ///// 根据MainID更新Idx所对应的建议和意见 20150820
        ///// </summary>
        ///// <param name="employeeID"></param>
        ///// <returns></returns>
        //public bool UpdateFlowsSuggestionA(string mainid, string idx, string su, string isa)
        //{
        //    string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
        //                    + "    SET OfficeAutomation_Flow_Suggestion = OfficeAutomation_Flow_Suggestion + char(13)+char(10)+char(13)+char(10) + '　　　　　　　　　　　　　　　　　　　　　　　　　　'+ OfficeAutomation_Flow_Auditor + char(13)+char(10) +  '　　　　　　　　　　　　　　　　　　　　　　　　日期：'+ CONVERT(VARCHAR(80), OfficeAutomation_Flow_AuditDate,120) + char(13)+char(10)+char(13)+char(10) + '---------------------------------------------------------------------' + char(13)+char(10)+char(13)+char(10) +     '"
        //                    + su + "' + char(13)+char(10)+char(13)+char(10) + '　　　　　　　　　　　　　　　　　　　　　　　　　　'+ OfficeAutomation_Flow_Auditor + char(13)+char(10) +  '　　　　　　　　　　　　　　　　　　　　　　　　日期：" + DateTime.Now + "' + char(13)+char(10)+char(13)+char(10) + '---------------------------------------------------------------------' + char(13)+char(10)+char(13)+char(10)"
        //                    + "        ,OfficeAutomation_Flow_IsAgree = " + isa
        //                    + "        ,OfficeAutomation_Flow_AuditDate = '" + DateTime.Now + "'"
        //                    + "           WHERE  [OfficeAutomation_Flow_MainID] = '" + mainid + "'"
        //                    + "               AND  [OfficeAutomation_Flow_Idx] = '" + idx + "'";
        //    return RunNoneSQL(sql);
        //}

        /// <summary>
        /// 根据MainID更新Idx所对应的建议和意见 20150820
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public bool UpdateFlowsSuggestionA(string mainid, string idx, string su, string isa)
        {
            string sql = "EXEC pr_UpdateForReview"
                + " @mainid='" + mainid + "'"
                + ",@idx=" + idx
                + ",@su='" + su + "'"
                + ",@isa=" + isa;
            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 根据MainID更新删除流程表中Idx所对应的签名20141231
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public bool UpdateDeletFByMainIDAndIdxs(string mainid, int idx, string namea, string ida)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_DeletedFlow]"
                            + "    SET OfficeAutomation_DeletedFlow_Auditor = '" + namea + "',"
                            + "    OfficeAutomation_DeletedFlow_AuditorID = '" + ida + "',"
                            + "    OfficeAutomation_DeletedFlow_Audit = 0,"
                            + "    OfficeAutomation_DeletedFlow_IsAgree = 1"
                            + "           WHERE  [OfficeAutomation_DeletedFlow_MainID] = '" + mainid + "'"
                            + "               AND  [OfficeAutomation_DeletedFlow_Idx] = " + idx;
            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 根据MainID清空Idx所对应的Delete表签名20150104
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public bool UpdateDFAfterByMainIDAndIdxs(string mainid, int idx)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_DeletedFlow]"
                            + "    SET OfficeAutomation_DeletedFlow_Audit = 0,"
                            + "    OfficeAutomation_DeletedFlow_Suggestion = '',"
                            + "    OfficeAutomation_DeletedFlow_AuditDate = NULL,"
                            //+ "    OfficeAutomation_DeletedFlow_Auditor = NULL,"
                            + "    OfficeAutomation_DeletedFlow_AuditorID = NULL,"
                            + "    OfficeAutomation_DeletedFlow_IsAgree = NULL"
                            + "           WHERE  [OfficeAutomation_DeletedFlow_MainID] = '" + mainid + "'"
                            + "               AND  [OfficeAutomation_DeletedFlow_Idx] = " + idx;
            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 插入因删除而要审批的流程20141230
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public bool InsertFlowsByDelete(string mainid)
        {
            string sql = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_DeletedFlow]"
                            + "    SELECT OfficeAutomation_Flow_ID"
                            + "    ,OfficeAutomation_Flow_MainID"
                            + "    ,OfficeAutomation_Flow_Employee"
                            + "    ,OfficeAutomation_Flow_EmployeeID"
                            + "    ,OfficeAutomation_Flow_Idx"
                            + "    ,OfficeAutomation_Flow_Audit"
                            + "    ,OfficeAutomation_Flow_Suggestion"
                            + "    ,OfficeAutomation_Flow_AuditDate"
                            + "    ,OfficeAutomation_Flow_Auditor"
                            + "    ,OfficeAutomation_Flow_AuditorID"
                            + "    ,OfficeAutomation_Flow_IsAgree"
                            + "    FROM t_OfficeAutomation_Flow"
                            + "    WHERE OfficeAutomation_Flow_Idx IN "
                            + "    (SELECT MIN(OfficeAutomation_Flow_Idx) FROM t_OfficeAutomation_Flow "
                            + "    WHERE OfficeAutomation_Flow_MainID = '" + mainid + "'"
                            + "    GROUP BY OfficeAutomation_Flow_EmployeeID)"
                            + "    AND OfficeAutomation_Flow_MainID = '" + mainid + "'"
                            + "    AND OfficeAutomation_Flow_AuditorID IS NOT NULL"
                            + "    ORDER BY OfficeAutomation_Flow_Idx";
            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 插入因修改而要保存的流程20150120
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public bool InsertFlowsByAlter(string mainid, int num)
        {
            string sql = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_DeletedFlow]"
                            + "    SELECT OfficeAutomation_Flow_ID"
                            + "    ,OfficeAutomation_Flow_MainID"
                            + "    ,OfficeAutomation_Flow_Employee"
                            + "    ,OfficeAutomation_Flow_EmployeeID"
                            + "    ,OfficeAutomation_Flow_Idx"
                            + "    ,OfficeAutomation_Flow_Audit"
                            + "    ,OfficeAutomation_Flow_Suggestion"
                            + "    ,OfficeAutomation_Flow_AuditDate"
                            + "    ,OfficeAutomation_Flow_Auditor"
                            + "    ,OfficeAutomation_Flow_AuditorID"
                            + "    ,OfficeAutomation_Flow_IsAgree"
                            + "    FROM t_OfficeAutomation_Flow"
                            + "    WHERE OfficeAutomation_Flow_MainID = '" + mainid + "'"
                            + "    AND OfficeAutomation_Flow_AuditorID IS NOT NULL"
                            + "    AND OfficeAutomation_Flow_Idx <=" + num
                            + "    ORDER BY OfficeAutomation_Flow_Idx";
            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 插入未审批的流程20150128
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public bool InsertFlowsHaventReview(string mainid)
        {
            string sql = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_DeletedFlow]"
                            + "    SELECT OfficeAutomation_Flow_ID"
                            + "    ,OfficeAutomation_Flow_MainID"
                            + "    ,OfficeAutomation_Flow_Employee"
                            + "    ,OfficeAutomation_Flow_EmployeeID"
                            + "    ,OfficeAutomation_Flow_Idx"
                            + "    ,OfficeAutomation_Flow_Audit"
                            + "    ,OfficeAutomation_Flow_Suggestion"
                            + "    ,OfficeAutomation_Flow_AuditDate"
                            + "    ,OfficeAutomation_Flow_Auditor"
                            + "    ,OfficeAutomation_Flow_AuditorID"
                            + "    ,OfficeAutomation_Flow_IsAgree"
                            + "    FROM t_OfficeAutomation_Flow"
                            + "    WHERE OfficeAutomation_Flow_MainID = '" + mainid + "'"
                            + "    AND OfficeAutomation_Flow_AuditorID IS NULL"
                            + "    ORDER BY OfficeAutomation_Flow_Idx";
            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 查找因删除而需审批的流程20141230
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public DataSet SelectDeleteFlowsByMID(string mainid)
        {
            string sql = " SELECT OfficeAutomation_DeletedFlow_ID"
                            + "    ,OfficeAutomation_DeletedFlow_MainID"
                            + "    ,OfficeAutomation_DeletedFlow_Employee"
                            + "    ,OfficeAutomation_DeletedFlow_EmployeeID"
                            + "    ,OfficeAutomation_DeletedFlow_Idx"
                            + "    ,OfficeAutomation_DeletedFlow_Audit"
                            + "    ,OfficeAutomation_DeletedFlow_Suggestion"
                            + "    ,OfficeAutomation_DeletedFlow_AuditDate"
                            + "    ,OfficeAutomation_DeletedFlow_Auditor"
                            + "    ,OfficeAutomation_DeletedFlow_AuditorID"
                            + "    ,OfficeAutomation_DeletedFlow_IsAgree"
                            + "    FROM t_OfficeAutomation_DeletedFlow"
                            + "    WHERE OfficeAutomation_DeletedFlow_MainID = '" + mainid + "'"
                            + "    AND OfficeAutomation_DeletedFlow_AuditorID IS NOT NULL"
                            + "    ORDER BY OfficeAutomation_DeletedFlow_Idx ASC";
            return RunSQL(sql);
        }

        /// <summary>
        /// 根据MianID查找因删除而需审批的所以流程2016921-52100
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public DataSet SelectAllDeleteFlowsByMID(string mainid)
        {
            string sql = " SELECT OfficeAutomation_DeletedFlow_ID"
                            + "    ,OfficeAutomation_DeletedFlow_MainID"
                            + "    ,OfficeAutomation_DeletedFlow_Employee"
                            + "    ,OfficeAutomation_DeletedFlow_EmployeeID"
                            + "    ,OfficeAutomation_DeletedFlow_Idx"
                            + "    ,OfficeAutomation_DeletedFlow_Audit"
                            + "    ,OfficeAutomation_DeletedFlow_Suggestion"
                            + "    ,OfficeAutomation_DeletedFlow_AuditDate"
                            + "    ,OfficeAutomation_DeletedFlow_Auditor"
                            + "    ,OfficeAutomation_DeletedFlow_AuditorID"
                            + "    ,OfficeAutomation_DeletedFlow_IsAgree"
                            + "    FROM t_OfficeAutomation_DeletedFlow"
                            + "    WHERE OfficeAutomation_DeletedFlow_MainID = '" + mainid + "'"
                            //+ "    AND OfficeAutomation_DeletedFlow_AuditorID IS NULL"
                            + "    ORDER BY OfficeAutomation_DeletedFlow_Idx ASC";
            return RunSQL(sql);
        }

        /// <summary>
        /// 查找保存的流程20150106
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public DataSet SelectDeleteFlows(string mainid)
        {
            string sql = " SELECT OfficeAutomation_DeletedFlow_ID"
                            + "    ,OfficeAutomation_DeletedFlow_MainID"
                            + "    ,OfficeAutomation_DeletedFlow_Employee"
                            + "    ,OfficeAutomation_DeletedFlow_EmployeeID"
                            + "    ,OfficeAutomation_DeletedFlow_Idx"
                            + "    ,OfficeAutomation_DeletedFlow_Audit"
                            + "    ,OfficeAutomation_DeletedFlow_Suggestion"
                            + "    ,OfficeAutomation_DeletedFlow_AuditDate"
                            + "    ,OfficeAutomation_DeletedFlow_Auditor"
                            + "    ,OfficeAutomation_DeletedFlow_AuditorID"
                            + "    ,OfficeAutomation_DeletedFlow_IsAgree"
                            + "    FROM t_OfficeAutomation_DeletedFlow"
                            + "    WHERE OfficeAutomation_DeletedFlow_MainID = '" + mainid + "'"
                            + "    ORDER BY OfficeAutomation_DeletedFlow_Idx ASC";
            return RunSQL(sql);
        }

        /// <summary>
        /// 根据审批人工号及MID查找因删除而需审批的流程20141231
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public DataSet SelectDeleteFlowsByAM(string mainid, string AID)
        {
            string sql = " SELECT OfficeAutomation_DeletedFlow_ID"
                            + "    ,OfficeAutomation_DeletedFlow_MainID"
                            + "    ,OfficeAutomation_DeletedFlow_Employee"
                            + "    ,OfficeAutomation_DeletedFlow_EmployeeID"
                            + "    ,OfficeAutomation_DeletedFlow_Idx"
                            + "    ,OfficeAutomation_DeletedFlow_Audit"
                            + "    ,OfficeAutomation_DeletedFlow_Suggestion"
                            + "    ,OfficeAutomation_DeletedFlow_AuditDate"
                            + "    ,OfficeAutomation_DeletedFlow_Auditor"
                            + "    ,OfficeAutomation_DeletedFlow_AuditorID"
                            + "    ,OfficeAutomation_DeletedFlow_IsAgree"
                            + "    FROM t_OfficeAutomation_DeletedFlow"
                            + "    WHERE OfficeAutomation_DeletedFlow_MainID = '" + mainid + "'"
                            + "    AND OfficeAutomation_DeletedFlow_AuditorID LIKE '%" + AID + "%'";
            return RunSQL(sql);
        }

        /// <summary>
        /// 插入因不同意而删除的流程20141203
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public bool InsertDeleteFlows(string mainid)
        {
            string sql = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
                            + "    SELECT OfficeAutomation_DeletedFlow_ID"
                            + "    ,OfficeAutomation_DeletedFlow_MainID"
                            + "    ,OfficeAutomation_DeletedFlow_Employee"
                            + "    ,OfficeAutomation_DeletedFlow_EmployeeID"
                            + "    ,OfficeAutomation_DeletedFlow_Idx"
                            + "    ,OfficeAutomation_DeletedFlow_Audit"
                            + "    ,OfficeAutomation_DeletedFlow_Suggestion"
                            + "    ,OfficeAutomation_DeletedFlow_AuditDate"
                            + "    ,OfficeAutomation_DeletedFlow_Auditor"
                            + "    ,OfficeAutomation_DeletedFlow_AuditorID"
                            + "    ,OfficeAutomation_DeletedFlow_IsAgree"
                            + "    FROM t_OfficeAutomation_DeletedFlow"
                            + "    WHERE OfficeAutomation_DeletedFlow_MainID = '" + mainid + "'";
            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 删除保存的流程20141203
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public bool DDeleteFlows(string mainid)
        {
            string sql = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_DeletedFlow]"
                            + "    WHERE OfficeAutomation_DeletedFlow_MainID = '" + mainid + "'";
            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 根据文档编辑删除最新一个名为“请审批”的邮件
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public bool DeleteOtherEmailBySMB(string smb)
        {
            string sql = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Message]"
                            + "    WHERE OfficeAutomation_Message_ID ="
                            + "    (SELECT TOP (1) OfficeAutomation_Message_ID FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Message]"
                            + "    WHERE OfficeAutomation_Message_Title = '请审批'"
                            + "    AND OfficeAutomation_Message_MessBody LIKE '%" + smb + "%'"
                            + "    AND OfficeAutomation_Message_PostFlag = 0"
                            + "    ORDER BY OfficeAutomation_Message_CreateDate DESC)";
            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 根据文档编辑更新最新一个名为“请审批”的邮件的发送状态
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public bool UpdateOtherEmailBySMB(string smb)
        {
            string sql = "update [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Message]"
                            + "    SET OfficeAutomation_Message_PostFlag = 1"
                            + "    WHERE OfficeAutomation_Message_ID ="
                            + "    (SELECT TOP (1) OfficeAutomation_Message_ID FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Message]"
                            + "    WHERE OfficeAutomation_Message_Title = '请审批'"
                            + "    AND OfficeAutomation_Message_MessBody LIKE '%" + smb + "%'"
                            + "    AND OfficeAutomation_Message_PostFlag = 0"
                            + "    ORDER BY OfficeAutomation_Message_CreateDate DESC)";
            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 根据MainID及Idxs删除对应流程
        /// </summary>
        /// <param name="mainid"></param>
        /// <param name="idxs">格式为"1,2,3,4"</param>
        /// <returns></returns>
        public bool DeleteByMainIDAndIdxs(string mainid, string idxs)
        {
            string sql = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
                            + "           WHERE  [OfficeAutomation_Flow_MainID] = '" + mainid + "'"
                            + "               AND  [OfficeAutomation_Flow_Idx] in (" + idxs + ")";

            return RunNoneSQL(sql);
        }

        ///// <summary>
        ///// 根据MainID及Idxs删除流程备份表所对应的流程20141231
        ///// </summary>
        ///// <param name="mainid"></param>
        ///// <param name="idxs">格式为"1,2,3,4"</param>
        ///// <returns></returns>
        //public bool DeleteDFlowsByMainIDAndIdxs(string mainid, string idxs)
        //{
        //    string sql = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_DeletedFlow]"
        //                    + "           WHERE  [OfficeAutomation_DeletedFlow_MainID] = '" + mainid + "'"
        //                    + "               AND  [OfficeAutomation_DeletedFlow_Idx] in (" + idxs + ")";

        //    return RunNoneSQL(sql);
        //}

        /// <summary>
        /// 根据MainID及姓名删除流程备份表所对应的流程20141231
        /// </summary>
        /// <param name="mainid"></param>
        /// <param name="idxs"></param>
        /// <returns></returns>
        public bool DeleteDFlowsByMIDAndName(string mainid, string AName)
        {
            string sql = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_DeletedFlow]"
                            + "           WHERE  [OfficeAutomation_DeletedFlow_MainID] = '" + mainid + "'"
                            + "    AND OfficeAutomation_DeletedFlow_Auditor = '" + AName + "'";

            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 在“跳过”或“结束”按钮中，删除相应的部门审批流程20141211（仅用于通用申请表）
        /// </summary>
        /// <param name="mainid"></param>
        /// <param name="idxs">格式为"1,2,3,4"</param>
        /// <returns></returns>
        public bool DeleteFlowsForJump(string mainid, string dpm)
        {
            string sql = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
                            + "           WHERE  [OfficeAutomation_Flow_MainID] = '" + mainid + "'"
                            + "           AND  [OfficeAutomation_Flow_Idx] in ( "
                            + "           SELECT OfficeAutomation_Document_GeneralApply_Detail_Num FROM t_OfficeAutomation_Document_GeneralApply_Detail"
                            + "           WHERE OfficeAutomation_Document_GeneralApply_Detail_MainID = "
                            + "           (SELECT OfficeAutomation_Document_GeneralApply_ID FROM t_OfficeAutomation_Document_GeneralApply"
                            + "           WHERE t_OfficeAutomation_Document_GeneralApply.OfficeAutomation_Document_GeneralApply_MainID = '" + mainid + "'"
                            + "           ) AND OfficeAutomation_Document_GeneralApply_Detail_Department = '" + dpm + "')";
            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 在“跳过”或“结束”按钮中，删除相应的部门审批流程（用于项目部通用申请表）20170410
        /// </summary>
        /// <param name="mainid"></param>
        /// <param name="idxs">格式为"1,2,3,4"</param>
        /// <returns></returns>
        public bool DeleteFlowsForJumpProj(string mainid, string dpm)
        {
            string sql = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
                            + "           WHERE  [OfficeAutomation_Flow_MainID] = '" + mainid + "'"
                            + "           AND  [OfficeAutomation_Flow_Idx] in ( "
                            + "           SELECT OfficeAutomation_Document_GeneralApply_Detail_Num FROM t_OfficeAutomation_Document_GeneralApply_Detail"
                            + "           WHERE OfficeAutomation_Document_GeneralApply_Detail_MainID = "
                            + "           (SELECT OfficeAutomation_Document_ProjGeneralApply_ID FROM t_OfficeAutomation_Document_ProjGeneralApply"
                            + "           WHERE t_OfficeAutomation_Document_ProjGeneralApply.OfficeAutomation_Document_ProjGeneralApply_MainID = '" + mainid + "'"
                            + "           ) AND OfficeAutomation_Document_GeneralApply_Detail_Department = '" + dpm + "')";
            return RunNoneSQL(sql);
        }



        /// <summary>
        /// 删除指定工号的审批流程20150205
        /// </summary>
        /// <param name="mainid"></param>
        /// <param name="idxs"></param>
        /// <returns></returns>
        public bool DeleteFlowsByME(string mainid, string eid)
        {
            string sql = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
                            + "           WHERE  [OfficeAutomation_Flow_MainID] = '" + mainid + "'"
                            + "           AND OfficeAutomation_Flow_EmployeeID = '" + eid + "'";
            return RunNoneSQL(sql);
        }

        #endregion

        /// <summary>
        /// 根据MainID判断审批流程是否成功结束
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public bool IsFlowComplete(string mainid)
        {
            string sql = "SELECT DISTINCT [OfficeAutomation_Flow_Audit]"
                         + "   FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
                         + " WHERE [OfficeAutomation_Flow_MainID] = '" + mainid + "'";
         
            DataSet ds = RunSQL(sql);

            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count == 1 && ds.Tables[0].Rows[0][0].ToString() == "True")
                return true;
            else
                return false;
        }

        /// <summary>
        /// 根据MainID获得该流程中当前待审批人的姓名
        /// </summary>
        /// <param name="mainid"></param>
        /// <returns></returns>
        public string GetWaitForAuditorByMainID(string mainid)
        {
            string sql = "SELECT TOP 1 [OfficeAutomation_Flow_Employee]"
                        + "             ,[OfficeAutomation_Flow_EmployeeID]"
                        + "    FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
                        + "  WHERE OfficeAutomation_Flow_MainID='" + mainid + "' AND OfficeAutomation_Flow_Audit=0"
                        + "  ORDER BY OfficeAutomation_Flow_Idx asc";

            DataSet ds = RunSQL(sql);

            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                return ds.Tables[0].Rows[0][0].ToString();
            else
                return null;
        }

        /// <summary>
        /// 根据MainID获得该流程中当前待审批人的工号
        /// </summary>
        /// <param name="mainid"></param>
        /// <returns></returns>
        public string GetWaitForAuditorIDByMainID(string mainid)
        {
            string sql = "SELECT TOP 1 [OfficeAutomation_Flow_Employee]"
                        + "             ,[OfficeAutomation_Flow_EmployeeID]"
                        + "    FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
                        + "  WHERE OfficeAutomation_Flow_MainID='" + mainid + "' AND OfficeAutomation_Flow_Audit=0"
                        + "  ORDER BY OfficeAutomation_Flow_Idx asc";

            DataSet ds = RunSQL(sql);

            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                return ds.Tables[0].Rows[0][1].ToString();
            else
                return null;
        }

        /// <summary>
        /// 根据MainID获得该流程中的申请表名称
        /// </summary>
        /// <param name="mainid"></param>
        /// <returns></returns>
        public string GetDocumentNameByMainID(string mainid)
        {
            string sql = "SELECT tdoad.OfficeAutomation_Document_Name"
                          + "  FROM   t_Dic_OfficeAutomation_Document tdoad"
                          + " WHERE  tdoad.OfficeAutomation_Document_ID = (SELECT toam.OfficeAutomation_DocumentID"
                          + "                                                                          FROM   t_OfficeAutomation_Main toam"
                          + "                                                                          WHERE  toam.OfficeAutomation_Main_ID = '" + mainid + "') ";

            DataSet ds = RunSQL(sql);

            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                return ds.Tables[0].Rows[0][0].ToString();
            else
                return null;
        }

        /// <summary>
        /// 根据MainID获得该流程中的申请表名
        /// </summary>
        /// <param name="mainid"></param>
        /// <returns></returns>
        public string GetTableNameByMainID(string mainid)
        {
            string sql = "SELECT tdoad.OfficeAutomation_Document_TableName"
                          + "  FROM   t_Dic_OfficeAutomation_Document tdoad"
                          + " WHERE  tdoad.OfficeAutomation_Document_ID = (SELECT toam.OfficeAutomation_DocumentID"
                          + "                                                                          FROM   t_OfficeAutomation_Main toam"
                          + "                                                                          WHERE  toam.OfficeAutomation_Main_ID = '" + mainid + "') ";

            DataSet ds = RunSQL(sql);

            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                return ds.Tables[0].Rows[0][0].ToString();
            else
                return null;
        }


        /// <summary>
        /// 根据MainID获得该流程中的申请表ID20141231
        /// </summary>
        /// <param name="mainid"></param>
        /// <returns></returns>
        public string GetModuleIDByMainID(string Tname)
        {
            string sql = "SELECT OfficeAutomation_OperateModule_ID"
                          + "  FROM   t_Dic_OfficeAutomation_OperateModule"
                          + " WHERE  OfficeAutomation_OperateModule_Name = '" + Tname + "'";

            DataSet ds = RunSQL(sql);

            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                return ds.Tables[0].Rows[0][0].ToString();
            else
                return null;
        }

        /// <summary>
        /// 根据MainID获得该流程正待第几个环节审核,如果已经执行完成则返回9999
        /// </summary>
        /// <param name="mainid"></param>
        /// <returns></returns>
        public int GetWaitingIDxByMainID(string mainid)
        {
            string sql = "SELECT TOP 1 OfficeAutomation_Flow_Idx"
                          + " FROM   t_OfficeAutomation_Flow toaf"
                          + " WHERE  toaf.OfficeAutomation_Flow_MainID = '" + mainid + "'"
                          + "      AND toaf.OfficeAutomation_Flow_Audit = 0"
                          + " ORDER  BY toaf.OfficeAutomation_Flow_Idx ASC ";

            DataSet ds = RunSQL(sql);

            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                return int.Parse(ds.Tables[0].Rows[0][0].ToString());
            else
                return 9999;
        }

        /// <summary>
        /// 根据MainID获得该流程第一个环节审批人员工号
        /// </summary>
        /// <param name="mainid"></param>
        /// <returns></returns>
        public string GetFirstByMainID(string mainid)
        {
            string sql = "SELECT TOP 1 OfficeAutomation_Flow_EmployeeID"
                          + " FROM   t_OfficeAutomation_Flow toaf"
                          + " WHERE  toaf.OfficeAutomation_Flow_MainID = '" + mainid + "'"
                          + " ORDER  BY toaf.OfficeAutomation_Flow_Idx ASC ";

            DataSet ds = RunSQL(sql);

            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                return ds.Tables[0].Rows[0][0].ToString();
            else
                return "";
        }

        /// <summary>
        /// 根据MainID获得获取最后一步流程编号
        /// </summary>
        /// <param name="mainid"></param>
        /// <returns></returns>
        public int GetLastIDxByMainID(string mainid)
        {
            string sql = "SELECT TOP 1 OfficeAutomation_Flow_Idx"
                          + " FROM   t_OfficeAutomation_Flow toaf"
                          + " WHERE  toaf.OfficeAutomation_Flow_MainID = '" + mainid + "'"
                          + " ORDER  BY toaf.OfficeAutomation_Flow_Idx DESC ";

            DataSet ds = RunSQL(sql);

            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            else
                return 0;
        }

        /// <summary>
        /// 根据MainID获得该流程中已经通过审批的列表
        /// </summary>
        /// <param name="mainid"></param>
        /// <returns></returns>
        public DataSet GetAuditedByMainID(string mainid)
        {
            string sql = "SELECT [OfficeAutomation_Flow_ID]"
                            + "          ,[OfficeAutomation_Flow_MainID]"
                            + "          ,[OfficeAutomation_Flow_Employee]"
                            + "          ,[OfficeAutomation_Flow_EmployeeID]"
                            + "          ,[OfficeAutomation_Flow_Idx]"
                            + "          ,[OfficeAutomation_Flow_Audit]"
                            + "          ,[OfficeAutomation_Flow_Suggestion]"
                            + "          ,[OfficeAutomation_Flow_AuditDate]"
                            + "          ,[OfficeAutomation_Flow_Auditor]"
                            + "          ,[OfficeAutomation_Flow_AuditorID]"
                            + "          ,[OfficeAutomation_Flow_IsAgree]"
                            + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
                            + " WHERE OfficeAutomation_Flow_MainID='" + mainid + "'" 
                            + "     AND OfficeAutomation_Flow_Audit = 1"
                            + " ORDER BY OfficeAutomation_Flow_Idx ASC";

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据MainID获得该流程中已经通过审批的列表
        /// </summary>
        /// <param name="mainid"></param>
        /// <returns></returns>
        public DataSet GetAuditedByMainID(string mainid,string orderby)
        {
            string sql = "SELECT [OfficeAutomation_Flow_ID]"
                            + "          ,[OfficeAutomation_Flow_MainID]"
                            + "          ,[OfficeAutomation_Flow_Employee]"
                            + "          ,[OfficeAutomation_Flow_EmployeeID]"
                            + "          ,[OfficeAutomation_Flow_Idx]"
                            + "          ,[OfficeAutomation_Flow_Audit]"
                            + "          ,[OfficeAutomation_Flow_Suggestion]"
                            + "          ,[OfficeAutomation_Flow_AuditDate]"
                            + "          ,[OfficeAutomation_Flow_Auditor]"
                            + "          ,[OfficeAutomation_Flow_AuditorID]"
                            + "          ,[OfficeAutomation_Flow_IsAgree]"
                            + " FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
                            + " WHERE OfficeAutomation_Flow_MainID='" + mainid + "'"
                            + "     AND OfficeAutomation_Flow_Audit = 1"
                            + " ORDER BY " + orderby;

            return RunSQL(sql);
        }

        /// <summary>
        /// 根据MainID及IDx更新Suggestion
        /// </summary>
        /// <param name="mainid"></param>
        /// <param name="idx"></param>
        /// <param name="suggestion"></param>
        public bool UpdateSuggestionByMainIDAndIdx(string mainid,int idx,string suggestion)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
                     + "            SET [OfficeAutomation_Flow_Suggestion] = '" + suggestion + "'"
                     + "       WHERE [OfficeAutomation_Flow_MainID] = '" + mainid + "'"
                     + "           AND [OfficeAutomation_Flow_Idx] = " + idx;

            return RunNoneSQL(sql);
        }

        /// <summary>
        /// 根据MainID及IDx更新IDx
        /// </summary>
        /// <param name="mainid"></param>
        /// <param name="idx"></param>
        /// <param name="suggestion"></param>
        public bool UpdateIdxByMainIDAndIdx(string mainid, int idx, int NewIdx)
        {
            string sql = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Flow]"
                     + "            SET [OfficeAutomation_Flow_Idx] = '" + NewIdx + "'"
                     + "       WHERE [OfficeAutomation_Flow_MainID] = '" + mainid + "'"
                     + "           AND [OfficeAutomation_Flow_Idx] = " + idx;

            return RunNoneSQL(sql);
        }

        public void Add(DataEntity.T_OfficeAutomation_Flow obj)
        {
            string sql = "INSERT INTO t_OfficeAutomation_Flow (OfficeAutomation_Flow_ID,"
                         + "OfficeAutomation_Flow_MainID,"
                         + "OfficeAutomation_Flow_Employee,"
                         + "OfficeAutomation_Flow_EmployeeID,"
                         + "OfficeAutomation_Flow_Idx,"
                         + "OfficeAutomation_Flow_Audit,"
                         + "OfficeAutomation_Flow_Suggestion,"
                         + "OfficeAutomation_Flow_Auditor,"
                         + "OfficeAutomation_Flow_AuditorID,"
                         + "OfficeAutomation_Flow_IsAgree,OfficeAutomation_Flow_AuditDate) VALUES "
                         + "('" + obj.OfficeAutomation_Flow_ID + "','" + obj.OfficeAutomation_Flow_MainID + "','" + obj.OfficeAutomation_Flow_Employee + "','" + obj.OfficeAutomation_Flow_EmployeeID + "'," + obj.OfficeAutomation_Flow_Idx + ",'" + obj.OfficeAutomation_Flow_Audit + "','" + obj.OfficeAutomation_Flow_Suggestion + "','" + obj.OfficeAutomation_Flow_Auditor + "','" + obj.OfficeAutomation_Flow_AuditorID + "'," + obj.OfficeAutomation_Flow_IsAgree + ",'"+obj.OfficeAutomation_Flow_AuditDate+"')";

            RunNoneSQL(sql);
        }

        /// <summary>
        /// 插入净值知会函流程
        /// </summary>
        /// <param name="mainid"></param>
        /// <param name="idx"></param>
        /// <param name="suggestion"></param>
        public bool InsertSurplusValueFlow(string mainid)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[pr_InsertSurplusValueFlow]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Scrap_MainID", SqlDbType.NVarChar, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, mainid));

                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Open();

                    cmdToExecute.Transaction = _mainConnection.BeginTransaction();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                _rowsAffected = cmdToExecute.ExecuteNonQuery();

                if (_mainConnectionIsCreatedLocal)
                {
                    cmdToExecute.Transaction.Commit();
                }

                return true;
            }
            catch (Exception ex)
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    cmdToExecute.Transaction.Rollback();
                }

                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Close();
                }

                cmdToExecute.Dispose();
            }
        }

        #region 用于找出在规定时间内仍未进行批的人

        /// <summary>
        /// 找出在规定时间内仍未进行批的人
        /// </summary>
        /// <param name="mainid"></param>
        /// <param name="employeeid"></param>
        /// <param name="employeename"></param>
        /// <returns></returns>
        public DataSet SelectUnAudioLongTime(int days)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);
            DataSet ds=new DataSet();

            cmdToExecute.CommandText = "pr_SelectUnAudioLongTime";

            cmdToExecute.CommandType = CommandType.StoredProcedure;

            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iDays", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, days));

                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Open();

                    cmdToExecute.Transaction = _mainConnection.BeginTransaction();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                if (_mainConnectionIsCreatedLocal)
                {
                    cmdToExecute.Transaction.Commit();
                }

                adapter.Fill(ds);
            }
            catch (Exception ex)
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    cmdToExecute.Transaction.Rollback();
                }
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Close();
                }

                cmdToExecute.Dispose();
            }

            return ds;
        }
        #endregion

        #region 移动设备推送通知

        /// <summary>
        /// 以工号消息直推
        /// </summary>
        /// <param name="applyTableName">申请表中文名</param>
        /// <param name="empCode">接收员工号</param>
        /// <returns></returns>
        public string SendDirecePushMessageByEmpCodeAndApplyName(string applyTableName, string empCode)
        {
            string jsonData = "{\"table_name\":\"" + applyTableName + "\"}";
            return SendDirecePushMessageByEmpCode(jsonData, empCode);
        }

        /// <summary>
        /// 以工号消息直推
        /// </summary>
        /// <param name="pushId">mcoa提供的固定推送id</param>
        /// <param name="jsonData">推送参数json结构</param>
        /// <param name="empCode">接收员工号</param>
        /// <returns></returns>
        public string SendDirecePushMessageByEmpCode(string jsonData, string empCode)
        {
            wsMCOAWS.McoaWS ws = new wsMCOAWS.McoaWS();
            if (System.Configuration.ConfigurationSettings.AppSettings["IsTesting"] == "True")
                empCode = System.Configuration.ConfigurationSettings.AppSettings["TesterCode"];
            return ws.SendDirecePushMessageByEmpCode(System.Configuration.ConfigurationSettings.AppSettings["PushID"], jsonData, empCode);
        }

        #endregion

        public DataSet SelectByMainIDBeforeIdx(string MainID, string p)
        {
            throw new NotImplementedException();
        }

        public bool Insert0Idx(string MainID,string EmployeeName,string EmployeeID)
        {
            var ds = SelectByMainID(MainID);
            //该MainID下已经有>1条的流程或者已有Idx=0的流程都不需要再额外添加idx0流程了
            if (ds != null && ds.Tables[0].Rows.Count > 0 && (ds.Tables[0].Rows.Count > 1 || ds.Tables[0].Rows[0]["OfficeAutomation_Flow_Idx"].ToString() == "0"))
            {
                return true;
            }
            var obj = new T_OfficeAutomation_Flow();
            obj.OfficeAutomation_Flow_Employee = EmployeeName;
            obj.OfficeAutomation_Flow_EmployeeID = EmployeeID;
            obj.OfficeAutomation_Flow_ID = Guid.NewGuid();
            obj.OfficeAutomation_Flow_Idx = 0;
            obj.OfficeAutomation_Flow_MainID = new Guid(MainID);
            obj.OfficeAutomation_Flow_Suggestion = "";
            return Insert(obj);
        }

        /// <summary>
        /// 插入固定流程
        /// </summary>
        public void  InsertDefaultFlow(string MainID)
        {
            var t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
            DA_OfficeAutomation_Document_Flow_Inherit da_OfficeAutomation_Document_Flow_Inherit = new DA_OfficeAutomation_Document_Flow_Inherit();
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

            var ds = da_OfficeAutomation_Document_Flow_Inherit.SelectByMainID(MainID);
            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //var t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
                    if (string.IsNullOrEmpty(dr["OfficeAutomation_Document_Flow_Position"].ToString()))
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = dr["OfficeAutomation_Document_Flow_AuditCode"].ToString();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = dr["OfficeAutomation_Document_Flow_AuditName"].ToString();
                    }

                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = int.Parse(dr["OfficeAutomation_Document_Flow_Idx"].ToString());

                    Insert(t_OfficeAutomation_Flow);
                }
            }

           

        }

        public string GetAllSuggestion(string MainID)
        {
            var ds = GetAuditedByMainID(MainID, "OfficeAutomation_Flow_Idx ASC");
            //var SuggestionStr = "";
            if (ds == null || ds.Tables[0] == null || ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            var Employee = "";
            var AgreeStr = "";
            var Suggestion = "";
            var sb = new StringBuilder();
            sb.Append("<p style='font-size:14px;font-weight:700'>审核记录：</p>");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Employee = dr["OfficeAutomation_Flow_Auditor"].ToString();
                if(dr["OfficeAutomation_Flow_IsAgree"] != null)
                {
                    switch(dr["OfficeAutomation_Flow_IsAgree"].ToString())
                    {
                        case "1" :
                            AgreeStr = "同意";
                            break;
                        case "2" :
                            AgreeStr = "其他意见";
                            break;
                        case "0" :
                            AgreeStr = "不同意";
                            break;
                        default :
                            AgreeStr = "其他意见";
                            break;
                    }
                }
                Suggestion = string.IsNullOrEmpty(dr["OfficeAutomation_Flow_Suggestion"].ToString()) ? "-" : dr["OfficeAutomation_Flow_Suggestion"].ToString();
                Suggestion = Suggestion.Replace("\r\n","</br>");
                sb.AppendFormat("<p>{0}：审核结果：{1}</p>", Employee, AgreeStr);
                sb.AppendFormat("<p>意见：{0}</p>", Suggestion);
                sb.AppendFormat("<p style='margin-bottom:15px'>=========================================================================================</p>");

            }
            return sb.ToString();
        }

        public List<DataEntity.T_OfficeAutomation_Flow> GetFlowList(DataSet ds)
        {
            if (ds == null || ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            var list = new List<T_OfficeAutomation_Flow>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                DataEntity.T_OfficeAutomation_Flow m = new DataEntity.T_OfficeAutomation_Flow();
                m.OfficeAutomation_Flow_Audit = dr["OfficeAutomation_Flow_Audit"].ToString() == "True" ? true : false;
                if (dr["OfficeAutomation_Flow_AuditDate"] != DBNull.Value)
                {
                    m.OfficeAutomation_Flow_AuditDate = Convert.ToDateTime(dr["OfficeAutomation_Flow_AuditDate"]);
                }
                m.OfficeAutomation_Flow_Auditor = dr["OfficeAutomation_Flow_Auditor"].ToString();
                m.OfficeAutomation_Flow_AuditorID = dr["OfficeAutomation_Flow_AuditorID"].ToString();
                m.OfficeAutomation_Flow_Employee = dr["OfficeAutomation_Flow_Employee"].ToString();
                m.OfficeAutomation_Flow_EmployeeID = dr["OfficeAutomation_Flow_EmployeeID"].ToString();
                m.OfficeAutomation_Flow_ID = new Guid(dr["OfficeAutomation_Flow_ID"].ToString());
                m.OfficeAutomation_Flow_Idx = Convert.ToInt32(dr["OfficeAutomation_Flow_Idx"]);
                if (dr["OfficeAutomation_Flow_IsAgree"] != DBNull.Value)
                {
                    m.OfficeAutomation_Flow_IsAgree = Convert.ToInt32(dr["OfficeAutomation_Flow_IsAgree"]);
                }
                m.OfficeAutomation_Flow_MainID = new Guid(dr["OfficeAutomation_Flow_MainID"].ToString());
                m.OfficeAutomation_Flow_Suggestion = dr["OfficeAutomation_Flow_Suggestion"].ToString();
                list.Add(m);
            }

            return list;
        }

        /// <summary>
        /// 获取流程列表
        /// </summary>
        /// <param name="MainID">关联主键ID</param>
        /// <param name="Idx">当前流程</param>
        /// <returns></returns>
        public List<DataEntity.Model.FLowShowEntity> GetFlowShowList(DataSet ds)
        {
            if (ds == null || ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            var list = new List<DataEntity.Model.FLowShowEntity>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new DataEntity.Model.FLowShowEntity {
                    Audit = dr["OfficeAutomation_Flow_Audit"].ToString() == "True" ? true : false,
                    Auditor = dr["OfficeAutomation_Flow_Auditor"].ToString(),
                    AuditorID = dr["OfficeAutomation_Flow_AuditorID"].ToString(),
                    Employee = dr["OfficeAutomation_Flow_Employee"].ToString(),
                    EmployeeID = dr["OfficeAutomation_Flow_EmployeeID"].ToString(),
                    Idx = Convert.ToInt32(dr["OfficeAutomation_Flow_Idx"])
                });
            }

            return list;
        }

        /// <summary>
        /// 电子传真获取签名列表实体
        /// </summary>
        /// <param name="ds">流程ds</param>
        /// <param name="EmployeeID">当前登录人工号</param>
        /// <param name="EmployeeName">当前登录人姓名</param>
        /// <param name="Apply">申请人姓名</param>
        /// <returns></returns>
        public List<DataEntity.Model.FlowsSignEntity> GetFaxFlowsSignList(DataSet ds, string EmployeeID, string EmployeeName)
        {
            if (ds == null || ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            var list = new List<DataEntity.Model.FlowsSignEntity>();
            var flag = true;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                var o = new DataEntity.Model.FlowsSignEntity();
                o.AuditDate = "";
                if (!string.IsNullOrEmpty(dr["OfficeAutomation_Flow_AuditDate"].ToString()))
                {
                    o.AuditDate = Convert.ToDateTime(dr["OfficeAutomation_Flow_AuditDate"]).ToString("yyyy-MM-dd HH:mm:ss");
                }

                o.Idx = Convert.ToInt32(dr["OfficeAutomation_Flow_Idx"]);
                o.Suggestion = dr["OfficeAutomation_Flow_Suggestion"].ToString().Replace("\r\n", "</br>");
                o.Audit = Convert.ToBoolean(dr["OfficeAutomation_Flow_Audit"]);
                o.IsAgree = dr["OfficeAutomation_Flow_IsAgree"].ToString();
                o.Employee = dr["OfficeAutomation_Flow_Employee"].ToString();
                o.EmployeeID = dr["OfficeAutomation_Flow_EmployeeID"].ToString();
                //o.Auditors = GetSignEmpList(dr["OfficeAutomation_Flow_AuditorID"].ToString(), dr["OfficeAutomation_Flow_Auditor"].ToString(), EmployeeID, EmployeeName);
                o.Auditors = GetSignEmpList(dr["OfficeAutomation_Flow_EmployeeID"].ToString(), dr["OfficeAutomation_Flow_Employee"].ToString(), EmployeeID, EmployeeName);
                DA_OfficeAutomation_Agent_Inherit da_OfficeAutomation_Agent_Inherit = new DA_OfficeAutomation_Agent_Inherit();
                DataSet ds1 = da_OfficeAutomation_Agent_Inherit.GetMyAgencyForAgent(EmployeeName, EmployeeID);//查代理人
                o.SignbtnShow = false;
                //到审核流程
                if (flag && !o.Audit)
                {
                    //登录人需要签名，但还没签的，显示签名按钮
                    var needsign = (o.Employee + ",").Contains(EmployeeName + ",") && (o.EmployeeID + ",").Contains(EmployeeID + ",");  //是否需要登录人签名
                    var issigned = (dr["OfficeAutomation_Flow_Auditor"] + ",").Contains(EmployeeName + ",") || (dr["OfficeAutomation_Flow_Auditor"] + ",").Contains(EmployeeName + "（复审）,") && (dr["OfficeAutomation_Flow_AuditorID"] + ",").Contains(EmployeeID + ",");    //是否已经签名
                    if (needsign && !issigned)
                    {
                        o.SignbtnShow = true;
                    }
                    string sAgentName = string.Empty;//代理人名称
                    string sAgentID = string.Empty;//代理人工号
                    //代理人
                    if (ds1 != null && ds1.Tables != null && ds1.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr1 in ds1.Tables[0].Rows)
                        {
                            sAgentName = dr1["OfficeAutomation_Agent_Auditor"].ToString();
                            sAgentID = dr1["OfficeAutomation_Agent_AuditorID"].ToString();
                            var needsign1 = (o.Employee + ",").Contains(sAgentName + ",") && (o.EmployeeID + ",").Contains(sAgentID + ",");
                            var issigned1 = (dr["OfficeAutomation_Flow_Auditor"] + ",").Contains(sAgentName + ",") || (dr["OfficeAutomation_Flow_Auditor"] + ",").Contains(sAgentName + "（复审）,") && (dr["OfficeAutomation_Flow_AuditorID"] + ",").Contains(sAgentID + ",");    //是否已经签名
                            if (needsign1 && !issigned1)
                            {
                                o.SignbtnShow = true;
                            }
                        }

                    }
                    flag = false;
                }
                list.Add(o);
            }
            return list;
        }
     
        /// <summary>
        /// 获取签名列表实体
        /// </summary>
        /// <param name="ds">流程ds</param>
        /// <param name="EmployeeID">当前登录人工号</param>
        /// <param name="EmployeeName">当前登录人姓名</param>
        /// <param name="Apply">申请人姓名</param>
        /// <returns></returns>
        public List<DataEntity.Model.FlowsSignEntity> GetFlowsSignList(DataSet ds, string EmployeeID, string EmployeeName)
        {
            if (ds == null || ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            var list = new List<DataEntity.Model.FlowsSignEntity>();
            var flag = true;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                var o = new DataEntity.Model.FlowsSignEntity();
                o.AuditDate = "";
                if (!string.IsNullOrEmpty(dr["OfficeAutomation_Flow_AuditDate"].ToString()))
                {
                    o.AuditDate = Convert.ToDateTime(dr["OfficeAutomation_Flow_AuditDate"]).ToString("yyyy-MM-dd HH:mm:ss");
                }

                o.Idx = Convert.ToInt32(dr["OfficeAutomation_Flow_Idx"]);
                o.Suggestion = dr["OfficeAutomation_Flow_Suggestion"].ToString().Replace("\r\n","</br>");
                o.Audit = Convert.ToBoolean(dr["OfficeAutomation_Flow_Audit"]);
                o.IsAgree = dr["OfficeAutomation_Flow_IsAgree"].ToString();
                o.Employee = dr["OfficeAutomation_Flow_Employee"].ToString();
                o.EmployeeID = dr["OfficeAutomation_Flow_EmployeeID"].ToString();
                o.Auditors = GetSignEmpList(dr["OfficeAutomation_Flow_AuditorID"].ToString(),dr["OfficeAutomation_Flow_Auditor"].ToString(), EmployeeID, EmployeeName);
                DA_OfficeAutomation_Agent_Inherit da_OfficeAutomation_Agent_Inherit = new DA_OfficeAutomation_Agent_Inherit();
                DataSet ds1 = da_OfficeAutomation_Agent_Inherit.GetMyAgencyForAgent(EmployeeName, EmployeeID);//查代理人
                o.SignbtnShow = false;
                //到审核流程
                if (flag && !o.Audit)
                {
                    //登录人需要签名，但还没签的，显示签名按钮
                    var needsign = (o.Employee + ",").Contains(EmployeeName + ",") && (o.EmployeeID + ",").Contains(EmployeeID + ",");  //是否需要登录人签名
                    var issigned = (dr["OfficeAutomation_Flow_Auditor"] + ",").Contains(EmployeeName + ",") || (dr["OfficeAutomation_Flow_Auditor"] + ",").Contains(EmployeeName + "（复审）,") && (dr["OfficeAutomation_Flow_AuditorID"] + ",").Contains(EmployeeID + ",");    //是否已经签名
                    if (needsign && !issigned)
                    {
                        o.SignbtnShow = true;
                    }
                    string sAgentName = string.Empty;//代理人名称
                    string sAgentID = string.Empty;//代理人工号
                    //代理人
                    if (ds1 != null && ds1.Tables != null && ds1.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr1 in ds1.Tables[0].Rows)
                        {
                            sAgentName = dr1["OfficeAutomation_Agent_Auditor"].ToString();
                            sAgentID = dr1["OfficeAutomation_Agent_AuditorID"].ToString();
                            var needsign1 = (o.Employee + ",").Contains(sAgentName + ",") && (o.EmployeeID + ",").Contains(sAgentID + ",");
                            var issigned1 = (dr["OfficeAutomation_Flow_Auditor"] + ",").Contains(sAgentName + ",") || (dr["OfficeAutomation_Flow_Auditor"] + ",").Contains(sAgentName + "（复审）,") && (dr["OfficeAutomation_Flow_AuditorID"] + ",").Contains(sAgentID + ",");    //是否已经签名
                            if (needsign1 && !issigned1)
                            {
                                o.SignbtnShow = true;
                            }
                        }

                    }
                    flag = false;
                }
                list.Add(o);
            }
            return list;
        }

        public List<DataEntity.Model.SignEmp> GetSignEmpList(string ids, string names, string EmployeeID, string EmployeeName)
        {
            if (string.IsNullOrEmpty(ids) || string.IsNullOrEmpty(names))
            {
                return null;
            }
            var arrayids = ids.Split(',');
            var arraynames = names.Split(',');
            var list = new List<DataEntity.Model.SignEmp>();
            if (arrayids.Length != arraynames.Length)
            {
                throw new Exception("Error:DA_OfficeAutomation_Flow_Inherit:GetSignEmpList:工号列表跟姓名列表不相等");
            }
            var signpath = GetAppString("SignImageURL");
            for (int i = 0; i < arrayids.Length && i < arraynames.Length; i++)
            {
                var showbtn = arrayids[i] == EmployeeID && arraynames[i] == EmployeeName;
                list.Add(new DataEntity.Model.SignEmp {
                    Code = arrayids[i],
                    Name = arraynames[i],
                    SignPic = signpath + arrayids[i] + ".gif",
                    CancelSignbtnShow = showbtn
                });
            }

            return list;
        }

        public static string GetAppString(string sKey)
        {
            AppSettingsReader _configReader = new AppSettingsReader();
            return _configReader.GetValue(sKey, typeof(string)).ToString();
        }

        public string CanSayNo(string MainID)
        {
            int lastIDx = GetLastIDxByMainID(MainID);   //最终审核允许不同意
            if (lastIDx == 0)
                return "";
            int[] IDxs = { lastIDx };
            return CanSayNo(IDxs);
            
        }

        public string CanSayNo(int[] IDxs)
        {
            if (IDxs.Length == 0 || IDxs == null)
            {
                return "";
            }
            var js = "";
            foreach (var i in IDxs)
            {
                js += string.Format("$('#rdbNoIDx{0}').attr('allow','sayno');", i.ToString());
            }
            return js;
        }
        /// <summary>
        /// 修改意见
        /// </summary>
        public void Updatespecial(string sMain, string textarea,int idx)
        {
            string sql = @"update t_OfficeAutomation_Flow 
                           set OfficeAutomation_Flow_Suggestion ='" + textarea + @"'
                    where 
                          OfficeAutomation_Flow_MainID ='" + sMain + @"' 
                         and OfficeAutomation_Flow_Idx =" + idx;
             RunSQL(sql);
        }
    }
}
