using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_ChangeData_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_ChangeData _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ChangeData]"
                                                        + "           ([OfficeAutomation_Document_ChangeData_ID]"
                                                        + "           ,[OfficeAutomation_Document_ChangeData_MainID]"
                                                        + "           ,[OfficeAutomation_Document_ChangeData_Apply]"
                                                        + "           ,[OfficeAutomation_Document_ChangeData_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_ChangeData_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_ChangeData_Department]"
                                                        + "           ,[OfficeAutomation_Document_ChangeData_ReplyPhone]"
                                                        + "           ,[OfficeAutomation_Document_ChangeData_Building]"
                                                        + "           ,[OfficeAutomation_Document_ChangeData_Reason]"
                                                        + "           ,[OfficeAutomation_Document_ChangeData_ReasonDay]"
                                                        + "           ,[OfficeAutomation_Document_ChangeData_ReportNo]"
                                                        + "           ,[OfficeAutomation_Document_ChangeData_DataAddress]"
                                                        + "           ,[OfficeAutomation_Document_ChangeData_NewDataAddress]"
                                                        + "           ,[OfficeAutomation_Document_ChangeData_OldCustomerName]"
                                                        + "           ,[OfficeAutomation_Document_ChangeData_NewCustomerName]"
                                                        + "           ,[OfficeAutomation_Document_ChangeData_OldBranch]"
                                                        + "           ,[OfficeAutomation_Document_ChangeData_NewBranch]"
                                                        + "           ,[OfficeAutomation_Document_ChangeData_Others])"
                                                        + "     VALUES"
                                                        + "           (@sOfficeAutomation_Document_ChangeData_ID"
                                                        + "           ,@sOfficeAutomation_Document_ChangeData_MainID"
                                                        + "           ,@sOfficeAutomation_Document_ChangeData_Apply"
                                                        + "           ,@sOfficeAutomation_Document_ChangeData_ApplyDate"
                                                        + "           ,@sOfficeAutomation_Document_ChangeData_ApplyID"
                                                        + "           ,@sOfficeAutomation_Document_ChangeData_Department"
                                                        + "           ,@sOfficeAutomation_Document_ChangeData_ReplyPhone"
                                                        + "           ,@sOfficeAutomation_Document_ChangeData_Building"
                                                        + "           ,@sOfficeAutomation_Document_ChangeData_Reason"
                                                        + "           ,@sOfficeAutomation_Document_ChangeData_ReasonDay"
                                                        + "           ,@sOfficeAutomation_Document_ChangeData_ReportNo"
                                                        + "           ,@sOfficeAutomation_Document_ChangeData_DataAddress"
                                                        + "           ,@sOfficeAutomation_Document_ChangeData_NewDataAddress"
                                                        + "           ,@sOfficeAutomation_Document_ChangeData_OldCustomerName"
                                                        + "           ,@sOfficeAutomation_Document_ChangeData_NewCustomerName"
                                                        + "           ,@sOfficeAutomation_Document_ChangeData_OldBranch"
                                                        + "           ,@sOfficeAutomation_Document_ChangeData_NewBranch"
                                                        + "           ,@sOfficeAutomation_Document_ChangeData_Others)";



            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_ChangeData)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_ReplyPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_ReplyPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_Building", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_Building));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_Reason", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_Reason));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_ReasonDay", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_ReasonDay));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_ReportNo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_ReportNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_DataAddress", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_DataAddress));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_NewDataAddress", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_NewDataAddress));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_OldCustomerName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_OldCustomerName));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_NewCustomerName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_NewCustomerName));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_OldBranch", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_OldBranch));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_NewBranch", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_NewBranch));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_Others", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_Others));

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
            cmdToExecute.CommandText = "dbo.[pr_ChangeData_Delete]";
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

        #region 更新记录
        public override bool Update(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ChangeData]"
                                                        + "     SET  [OfficeAutomation_Document_ChangeData_ApplyID]=@sOfficeAutomation_Document_ChangeData_ApplyID"
                                                        + "            ,[OfficeAutomation_Document_ChangeData_Department]=@sOfficeAutomation_Document_ChangeData_Department"
                                                        + "            ,[OfficeAutomation_Document_ChangeData_ReplyPhone]=@sOfficeAutomation_Document_ChangeData_ReplyPhone"
                                                        + "            ,[OfficeAutomation_Document_ChangeData_Building]=@sOfficeAutomation_Document_ChangeData_Building"
                                                        + "            ,[OfficeAutomation_Document_ChangeData_Reason]=@sOfficeAutomation_Document_ChangeData_Reason"
                                                        + "            ,[OfficeAutomation_Document_ChangeData_ReasonDay]=@sOfficeAutomation_Document_ChangeData_ReasonDay"
                                                        + "            ,[OfficeAutomation_Document_ChangeData_ReportNo]=@sOfficeAutomation_Document_ChangeData_ReportNo"
                                                        + "            ,[OfficeAutomation_Document_ChangeData_DataAddress]=@sOfficeAutomation_Document_ChangeData_DataAddress"
                                                        + "            ,[OfficeAutomation_Document_ChangeData_NewDataAddress]=@sOfficeAutomation_Document_ChangeData_NewDataAddress"
                                                        + "            ,[OfficeAutomation_Document_ChangeData_OldCustomerName]=@sOfficeAutomation_Document_ChangeData_OldCustomerName"
                                                        + "            ,[OfficeAutomation_Document_ChangeData_NewCustomerName]=@sOfficeAutomation_Document_ChangeData_NewCustomerName"
                                                        + "            ,[OfficeAutomation_Document_ChangeData_OldBranch]=@sOfficeAutomation_Document_ChangeData_OldBranch"
                                                        + "            ,[OfficeAutomation_Document_ChangeData_NewBranch]=@sOfficeAutomation_Document_ChangeData_NewBranch"
                                                        + "            ,[OfficeAutomation_Document_ChangeData_Others]=@sOfficeAutomation_Document_ChangeData_Others"
                                                        + " WHERE [OfficeAutomation_Document_ChangeData_ID]=@sOfficeAutomation_Document_ChangeData_ID"
                                                        + "     AND [OfficeAutomation_Document_ChangeData_MainID] = @sOfficeAutomation_Document_ChangeData_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_ChangeData)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_ReplyPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_ReplyPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_Building", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_Building));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_Reason", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_Reason));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_ReasonDay", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_ReasonDay));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_ReportNo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_ReportNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_DataAddress", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_DataAddress));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_NewDataAddress", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_NewDataAddress));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_OldCustomerName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_OldCustomerName));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_NewCustomerName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_NewCustomerName));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_OldBranch", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_OldBranch));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_NewBranch", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_NewBranch));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_Others", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_Others));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ChangeData_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeData_MainID));

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
