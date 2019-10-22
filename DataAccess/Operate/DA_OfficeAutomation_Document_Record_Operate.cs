using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Record_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_Record _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Record]"
                                                        + "           ([OfficeAutomation_Document_Record_ID]"
                                                        + "           ,[OfficeAutomation_Document_Record_MainID]"
                                                        + "           ,[OfficeAutomation_Document_Record_Apply]"
                                                        + "           ,[OfficeAutomation_Document_Record_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_Record_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_Record_Department]"
                                                        + "           ,[OfficeAutomation_Document_Record_Address]"
                                                        + "           ,[OfficeAutomation_Document_Record_AName]"
                                                        + "           ,[OfficeAutomation_Document_Record_APhone]"
                                                        + "           ,[OfficeAutomation_Document_Record_Bname]"
                                                        + "           ,[OfficeAutomation_Document_Record_Bphone]"
                                                        + "           ,[OfficeAutomation_Document_Record_Clerk]"
                                                        + "           ,[OfficeAutomation_Document_Record_Master]"
                                                        + "           ,[OfficeAutomation_Document_Record_TurnDate]"
                                                        + "           ,[OfficeAutomation_Document_Record_Reason]"
                                                        + "           ,[OfficeAutomation_Document_Record_Business]"
                                                        + "           ,[OfficeAutomation_Document_Record_Tname])"
                                                        + " VALUES"
                                                        + "           (@OfficeAutomation_Document_Record_ID"
                                                        + "           ,@OfficeAutomation_Document_Record_MainID"
                                                        + "           ,@OfficeAutomation_Document_Record_Apply"
                                                        + "           ,@OfficeAutomation_Document_Record_ApplyDate"
                                                        + "           ,@OfficeAutomation_Document_Record_ApplyID"
                                                        + "           ,@OfficeAutomation_Document_Record_Department"
                                                        + "           ,@OfficeAutomation_Document_Record_Address"
                                                        + "           ,@OfficeAutomation_Document_Record_AName"
                                                        + "           ,@OfficeAutomation_Document_Record_APhone"
                                                        + "           ,@OfficeAutomation_Document_Record_Bname"
                                                        + "           ,@OfficeAutomation_Document_Record_Bphone"
                                                        + "           ,@OfficeAutomation_Document_Record_Clerk"
                                                        + "           ,@OfficeAutomation_Document_Record_Master"
                                                        + "           ,@OfficeAutomation_Document_Record_TurnDate"
                                                        + "           ,@OfficeAutomation_Document_Record_Reason"
                                                        + "           ,@OfficeAutomation_Document_Record_Business"
                                                        + "           ,@OfficeAutomation_Document_Record_Tname)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_Record)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Record_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Record_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Record_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Record_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Record_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Record_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Record_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Record_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Record_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Record_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Record_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Record_Department));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Record_Address", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Record_Address));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Record_AName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Record_AName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Record_APhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Record_APhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Record_Bname", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Record_Bname));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Record_Bphone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Record_Bphone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Record_Clerk", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Record_Clerk));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Record_Master", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Record_Master));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Record_TurnDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Record_TurnDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Record_Reason", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Record_Reason));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Record_Business", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Record_Business));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Record_Tname", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Record_Tname));

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
            cmdToExecute.CommandText = "dbo.[pr_Record_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Record]"
                                + "         SET [OfficeAutomation_Document_Record_ApplyID] = @OfficeAutomation_Document_Record_ApplyID"
                                + "         ,[OfficeAutomation_Document_Record_Department] = @OfficeAutomation_Document_Record_Department"
                                + "         ,[OfficeAutomation_Document_Record_Address] = @OfficeAutomation_Document_Record_Address"
                                + "         ,[OfficeAutomation_Document_Record_AName] = @OfficeAutomation_Document_Record_AName"
                                + "         ,[OfficeAutomation_Document_Record_APhone] = @OfficeAutomation_Document_Record_APhone"
                                + "         ,[OfficeAutomation_Document_Record_Bname] = @OfficeAutomation_Document_Record_Bname"
                                + "         ,[OfficeAutomation_Document_Record_Bphone] = @OfficeAutomation_Document_Record_Bphone"
                                + "         ,[OfficeAutomation_Document_Record_Clerk] = @OfficeAutomation_Document_Record_Clerk"
                                + "         ,[OfficeAutomation_Document_Record_Master] = @OfficeAutomation_Document_Record_Master"
                                + "         ,[OfficeAutomation_Document_Record_TurnDate] = @OfficeAutomation_Document_Record_TurnDate"
                                + "         ,[OfficeAutomation_Document_Record_Reason] = @OfficeAutomation_Document_Record_Reason"
                                + "         ,[OfficeAutomation_Document_Record_Business] = @OfficeAutomation_Document_Record_Business"
                                + "         ,[OfficeAutomation_Document_Record_Tname] = @OfficeAutomation_Document_Record_Tname"
                                + "         WHERE [OfficeAutomation_Document_Record_ID]=@OfficeAutomation_Document_Record_ID"
                                + "         AND [OfficeAutomation_Document_Record_MainID]=@OfficeAutomation_Document_Record_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_Record)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Record_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Record_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Record_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Record_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Record_Address", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Record_Address));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Record_AName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Record_AName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Record_APhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Record_APhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Record_Bname", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Record_Bname));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Record_Bphone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Record_Bphone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Record_Clerk", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Record_Clerk));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Record_Master", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Record_Master));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Record_TurnDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Record_TurnDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Record_Reason", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Record_Reason));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Record_Business", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Record_Business));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Record_Tname", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Record_Tname));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Record_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Record_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Record_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Record_MainID));

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
