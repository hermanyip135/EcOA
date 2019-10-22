using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_LegalCommission_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_LegalCommission _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_LegalCommission]"
                                                        + "           ([OfficeAutomation_Document_LegalCommission_ID]"
                                                        + "           ,[OfficeAutomation_Document_LegalCommission_MainID]"
                                                        + "           ,[OfficeAutomation_Document_LegalCommission_Apply]"
                                                        + "           ,[OfficeAutomation_Document_LegalCommission_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_LegalCommission_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_LegalCommission_Department]"
                                                        + "           ,[OfficeAutomation_Document_LegalCommission_Subject]"
                                                        + "           ,[OfficeAutomation_Document_LegalCommission_ReplyPhone]"
                                                        + "           ,[OfficeAutomation_Document_LegalCommission_TotalCoast]"
                                                        + "           ,[OfficeAutomation_Document_LegalCommission_ACMoney]"
                                                        + "           ,[OfficeAutomation_Document_LegalCommission_Cooperation]"
                                                        + "           ,[OfficeAutomation_Document_LegalCommission_Reason]"
                                                        + "           ,[OfficeAutomation_Document_LegalCommission_Cname])"
                                                        + "     VALUES"
                                                        + "           (@OfficeAutomation_Document_LegalCommission_ID"
                                                        + "           ,@OfficeAutomation_Document_LegalCommission_MainID"
                                                        + "           ,@OfficeAutomation_Document_LegalCommission_Apply"
                                                        + "           ,@OfficeAutomation_Document_LegalCommission_ApplyDate"
                                                        + "           ,@OfficeAutomation_Document_LegalCommission_ApplyID"
                                                        + "           ,@OfficeAutomation_Document_LegalCommission_Department"
                                                        + "           ,@OfficeAutomation_Document_LegalCommission_Subject"
                                                        + "           ,@OfficeAutomation_Document_LegalCommission_ReplyPhone"
                                                        + "           ,@OfficeAutomation_Document_LegalCommission_TotalCoast"
                                                        + "           ,@OfficeAutomation_Document_LegalCommission_ACMoney"
                                                        + "           ,@OfficeAutomation_Document_LegalCommission_Cooperation"
                                                        + "           ,@OfficeAutomation_Document_LegalCommission_Reason"
                                                        + "           ,@OfficeAutomation_Document_LegalCommission_Cname)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_LegalCommission)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LegalCommission_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LegalCommission_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LegalCommission_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LegalCommission_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LegalCommission_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LegalCommission_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LegalCommission_ApplyDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LegalCommission_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LegalCommission_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LegalCommission_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LegalCommission_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LegalCommission_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LegalCommission_Subject", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LegalCommission_Subject));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LegalCommission_ReplyPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LegalCommission_ReplyPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LegalCommission_TotalCoast", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LegalCommission_TotalCoast));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LegalCommission_ACMoney", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LegalCommission_ACMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LegalCommission_Cooperation", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LegalCommission_Cooperation));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LegalCommission_Reason", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LegalCommission_Reason));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LegalCommission_Cname", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LegalCommission_Cname));

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
            cmdToExecute.CommandText = "dbo.[pr_LegalCommission_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_LegalCommission]"
                                                        + "     SET   [OfficeAutomation_Document_LegalCommission_ApplyID]=@OfficeAutomation_Document_LegalCommission_ApplyID"
                                                        + "            ,[OfficeAutomation_Document_LegalCommission_Department]=@OfficeAutomation_Document_LegalCommission_Department"
                                                        + "            ,[OfficeAutomation_Document_LegalCommission_Subject]=@OfficeAutomation_Document_LegalCommission_Subject"
                                                        + "            ,[OfficeAutomation_Document_LegalCommission_ReplyPhone]=@OfficeAutomation_Document_LegalCommission_ReplyPhone"
                                                        + "            ,[OfficeAutomation_Document_LegalCommission_TotalCoast]=@OfficeAutomation_Document_LegalCommission_TotalCoast"
                                                        + "            ,[OfficeAutomation_Document_LegalCommission_ACMoney]=@OfficeAutomation_Document_LegalCommission_ACMoney"
                                                        + "            ,[OfficeAutomation_Document_LegalCommission_Cooperation]=@OfficeAutomation_Document_LegalCommission_Cooperation"
                                                        + "            ,[OfficeAutomation_Document_LegalCommission_Reason]=@OfficeAutomation_Document_LegalCommission_Reason"
                                                        + "            ,[OfficeAutomation_Document_LegalCommission_Cname]=@OfficeAutomation_Document_LegalCommission_Cname"
                                                        + " WHERE [OfficeAutomation_Document_LegalCommission_ID]=@OfficeAutomation_Document_LegalCommission_ID"
                                                        + "     AND [OfficeAutomation_Document_LegalCommission_MainID] = @OfficeAutomation_Document_LegalCommission_MainID";



            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_LegalCommission)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LegalCommission_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LegalCommission_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LegalCommission_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LegalCommission_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LegalCommission_Subject", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LegalCommission_Subject));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LegalCommission_ReplyPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LegalCommission_ReplyPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LegalCommission_TotalCoast", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LegalCommission_TotalCoast));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LegalCommission_ACMoney", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LegalCommission_ACMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LegalCommission_Cooperation", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LegalCommission_Cooperation));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LegalCommission_Reason", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LegalCommission_Reason));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LegalCommission_Cname", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LegalCommission_Cname));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LegalCommission_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LegalCommission_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_LegalCommission_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_LegalCommission_MainID));
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
