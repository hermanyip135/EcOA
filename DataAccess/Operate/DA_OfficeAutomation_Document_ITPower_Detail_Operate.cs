using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_ITPower_Detail_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_ITPower_Detail _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ITPower_Detail]"
                                                        + "           ([OfficeAutomation_Document_ITPower_Detail_ID]"
                                                        + "           ,[OfficeAutomation_Document_ITPower_Detail_MainID]"
                                                        + "           ,[OfficeAutomation_Document_ITPower_Detail_EmployeeID]"
                                                        + "           ,[OfficeAutomation_Document_ITPower_Detail_Employee]"
                                                        + "           ,[OfficeAutomation_Document_ITPower_Detail_Position]"
                                                        + "           ,[OfficeAutomation_Document_ITPower_Detail_Department]"
                                                        + "           ,[OfficeAutomation_Document_ITPower_Detail_DepartmentID]"
                                                        + "           ,[OfficeAutomation_Document_ITPower_Detail_BeginDate]"
                                                        + "           ,[OfficeAutomation_Document_ITPower_Detail_ApplyTypeID]"
                                                        + "           ,[OfficeAutomation_Document_ITPower_Detail_Client]"
                                                        + "           ,[OfficeAutomation_Document_ITPower_Detail_House]"
                                                        + "           ,[OfficeAutomation_Document_ITPower_Detail_ImportDepartment]"
                                                        + "           ,[OfficeAutomation_Document_ITPower_Detail_ImportDepartmentID]"
                                                        + "           ,[OfficeAutomation_Document_ITPower_Detail_ExportDepartment]"
                                                        + "           ,[OfficeAutomation_Document_ITPower_Detail_ExportDepartmentID]"
                                                        + "            ,OfficeAutomation_Document_ITPower_Detail_ANumber)"
                                                        + "     VALUES"
                                                        + "           (@guidOfficeAutomation_Document_ITPower_Detail_ID"
                                                        + "           ,@guidOfficeAutomation_Document_ITPower_Detail_MainID"
                                                        + "           ,@sOfficeAutomation_Document_ITPower_Detail_EmployeeID"
                                                        + "           ,@sOfficeAutomation_Document_ITPower_Detail_Employee"
                                                        + "           ,@sOfficeAutomation_Document_ITPower_Detail_Position"
                                                        + "           ,@sOfficeAutomation_Document_ITPower_Detail_Department"
                                                        + "           ,@guidOfficeAutomation_Document_ITPower_Detail_DepartmentID"
                                                        + "           ,@dtOfficeAutomation_Document_ITPower_Detail_BeginDate"
                                                        + "           ,@iOfficeAutomation_Document_ITPower_Detail_ApplyTypeID"
                                                        + "           ,@sOfficeAutomation_Document_ITPower_Detail_Client"
                                                        + "           ,@sOfficeAutomation_Document_ITPower_Detail_House"
                                                        + "           ,@sOfficeAutomation_Document_ITPower_Detail_ImportDepartment"
                                                        + "           ,@guidOfficeAutomation_Document_ITPower_Detail_ImportDepartmentID"
                                                        + "           ,@sOfficeAutomation_Document_ITPower_Detail_ExportDepartment"
                                                        + "           ,@guidOfficeAutomation_Document_ITPower_Detail_ExportDepartmentID"
                                                        +"            ,@sOfficeAutomation_Document_ITPower_Detail_ANumber)";

            cmdToExecute.CommandType = CommandType.Text;
            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_ITPower_Detail)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_ITPower_Detail_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITPower_Detail_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_ITPower_Detail_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITPower_Detail_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITPower_Detail_EmployeeID", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITPower_Detail_EmployeeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITPower_Detail_Employee", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITPower_Detail_Employee));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITPower_Detail_Position", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITPower_Detail_Position));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITPower_Detail_Department", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITPower_Detail_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_ITPower_Detail_DepartmentID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITPower_Detail_DepartmentID));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_ITPower_Detail_BeginDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITPower_Detail_BeginDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Document_ITPower_Detail_ApplyTypeID", SqlDbType.Int, 16, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITPower_Detail_ApplyTypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITPower_Detail_Client", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITPower_Detail_Client));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITPower_Detail_House", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITPower_Detail_House));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITPower_Detail_ImportDepartment", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITPower_Detail_ImportDepartment));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_ITPower_Detail_ImportDepartmentID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITPower_Detail_ImportDeaprtmentID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITPower_Detail_ExportDepartment", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITPower_Detail_ExportDepartment));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_ITPower_Detail_ExportDepartmentID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITPower_Detail_ExportDepartmentID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITPower_Detail_ANumber", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITPower_Detail_ANumber));

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
        #endregion

        #region 删除记录
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <returns></returns>
        public bool Delete(string mainID)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[pr_ITPower_Detail_Delete]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sMainID", SqlDbType.NVarChar, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, mainID));

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
        #endregion
    }
}
