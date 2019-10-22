using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_AfterCommission_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_AfterCommission _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_AfterCommission]"
                                                        + "           ([OfficeAutomation_Document_AfterCommission_ID]"
                                                        + "           ,[OfficeAutomation_Document_AfterCommission_MainID]"
                                                        + "           ,[OfficeAutomation_Document_AfterCommission_Apply]"
                                                        + "           ,[OfficeAutomation_Document_AfterCommission_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_AfterCommission_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_AfterCommission_Department]"
                                                        + "           ,[OfficeAutomation_Document_AfterCommission_Subject]"
                                                        + "           ,[OfficeAutomation_Document_AfterCommission_ReplyPhone]"
                                                        + "           ,[OfficeAutomation_Document_AfterCommission_Name]"
                                                        + "           ,[OfficeAutomation_Document_AfterCommission_HasCommission]"
                                                        + "           ,[OfficeAutomation_Document_AfterCommission_CommissionMoney]"
                                                        + "           ,[OfficeAutomation_Document_AfterCommission_Contact]"
                                                        + "           ,[OfficeAutomation_Document_AfterCommission_Address]"
                                                        + "           ,[OfficeAutomation_Document_AfterCommission_Reason]"
                                                        + "           ,[OfficeAutomation_Document_AfterCommission_Data])"
                                                        + " VALUES"
                                                        + "           (@OfficeAutomation_Document_AfterCommission_ID"
                                                        + "           ,@OfficeAutomation_Document_AfterCommission_MainID"
                                                        + "           ,@OfficeAutomation_Document_AfterCommission_Apply"
                                                        + "           ,@OfficeAutomation_Document_AfterCommission_ApplyDate"
                                                        + "           ,@OfficeAutomation_Document_AfterCommission_ApplyID"
                                                        + "           ,@OfficeAutomation_Document_AfterCommission_Department"
                                                        + "           ,@OfficeAutomation_Document_AfterCommission_Subject"
                                                        + "           ,@OfficeAutomation_Document_AfterCommission_ReplyPhone"
                                                        + "           ,@OfficeAutomation_Document_AfterCommission_Name"
                                                        + "           ,@OfficeAutomation_Document_AfterCommission_HasCommission"
                                                        + "           ,@OfficeAutomation_Document_AfterCommission_CommissionMoney"
                                                        + "           ,@OfficeAutomation_Document_AfterCommission_Contact"
                                                        + "           ,@OfficeAutomation_Document_AfterCommission_Address"
                                                        + "           ,@OfficeAutomation_Document_AfterCommission_Reason"
                                                        + "           ,@OfficeAutomation_Document_AfterCommission_Data)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_AfterCommission)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AfterCommission_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AfterCommission_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AfterCommission_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AfterCommission_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AfterCommission_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AfterCommission_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AfterCommission_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AfterCommission_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AfterCommission_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AfterCommission_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AfterCommission_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AfterCommission_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AfterCommission_Subject", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AfterCommission_Subject));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AfterCommission_ReplyPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AfterCommission_ReplyPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AfterCommission_Name", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AfterCommission_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AfterCommission_HasCommission", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AfterCommission_HasCommission));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AfterCommission_CommissionMoney", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AfterCommission_CommissionMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AfterCommission_Contact", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AfterCommission_Contact));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AfterCommission_Address", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AfterCommission_Address));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AfterCommission_Reason", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AfterCommission_Reason));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AfterCommission_Data", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AfterCommission_Data));

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
            cmdToExecute.CommandText = "dbo.[pr_AfterCommission_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_AfterCommission]"
                                + "         SET [OfficeAutomation_Document_AfterCommission_ApplyID] = @OfficeAutomation_Document_AfterCommission_ApplyID"
                                + "         ,[OfficeAutomation_Document_AfterCommission_Department] = @OfficeAutomation_Document_AfterCommission_Department"
                                + "         ,[OfficeAutomation_Document_AfterCommission_Subject] = @OfficeAutomation_Document_AfterCommission_Subject"
                                + "         ,[OfficeAutomation_Document_AfterCommission_ReplyPhone] = @OfficeAutomation_Document_AfterCommission_ReplyPhone"
                                + "         ,[OfficeAutomation_Document_AfterCommission_Name] = @OfficeAutomation_Document_AfterCommission_Name"
                                + "         ,[OfficeAutomation_Document_AfterCommission_HasCommission] = @OfficeAutomation_Document_AfterCommission_HasCommission"
                                + "         ,[OfficeAutomation_Document_AfterCommission_CommissionMoney] = @OfficeAutomation_Document_AfterCommission_CommissionMoney"
                                + "         ,[OfficeAutomation_Document_AfterCommission_Contact] = @OfficeAutomation_Document_AfterCommission_Contact"
                                + "         ,[OfficeAutomation_Document_AfterCommission_Address] = @OfficeAutomation_Document_AfterCommission_Address"
                                + "         ,[OfficeAutomation_Document_AfterCommission_Reason] = @OfficeAutomation_Document_AfterCommission_Reason"
                                + "         ,[OfficeAutomation_Document_AfterCommission_Data] = @OfficeAutomation_Document_AfterCommission_Data"
                                + "         WHERE [OfficeAutomation_Document_AfterCommission_ID]=@OfficeAutomation_Document_AfterCommission_ID"
                                + "         AND [OfficeAutomation_Document_AfterCommission_MainID]=@OfficeAutomation_Document_AfterCommission_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_AfterCommission)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AfterCommission_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AfterCommission_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AfterCommission_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AfterCommission_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AfterCommission_Subject", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AfterCommission_Subject));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AfterCommission_ReplyPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AfterCommission_ReplyPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AfterCommission_Name", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AfterCommission_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AfterCommission_HasCommission", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AfterCommission_HasCommission));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AfterCommission_CommissionMoney", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AfterCommission_CommissionMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AfterCommission_Contact", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AfterCommission_Contact));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AfterCommission_Address", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AfterCommission_Address));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AfterCommission_Reason", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AfterCommission_Reason));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AfterCommission_Data", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AfterCommission_Data));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AfterCommission_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AfterCommission_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_AfterCommission_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AfterCommission_MainID));

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
