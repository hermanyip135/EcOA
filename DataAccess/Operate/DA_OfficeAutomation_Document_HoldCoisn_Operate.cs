using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_HoldCoisn_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_HoldCoisn _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_HoldCoisn]"
                                                        + "           ([OfficeAutomation_Document_HoldCoisn_ID]"
                                                        + "           ,[OfficeAutomation_Document_HoldCoisn_MainID]"
                                                        + "           ,[OfficeAutomation_Document_HoldCoisn_Apply]"
                                                        + "           ,[OfficeAutomation_Document_HoldCoisn_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_HoldCoisn_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_HoldCoisn_Department]"
                                                        + "           ,[OfficeAutomation_Document_HoldCoisn_Area]"
                                                        + "           ,[OfficeAutomation_Document_HoldCoisn_Clerk]"
                                                        + "           ,[OfficeAutomation_Document_HoldCoisn_DealDate]"
                                                        + "           ,[OfficeAutomation_Document_HoldCoisn_Address]"
                                                        + "           ,[OfficeAutomation_Document_HoldCoisn_Reason]"
                                                        + "           ,[OfficeAutomation_Document_HoldCoisn_TurnDate])"
                                                        + " VALUES"
                                                        + "           (@OfficeAutomation_Document_HoldCoisn_ID"
                                                        + "           ,@OfficeAutomation_Document_HoldCoisn_MainID"
                                                        + "           ,@OfficeAutomation_Document_HoldCoisn_Apply"
                                                        + "           ,@OfficeAutomation_Document_HoldCoisn_ApplyDate"
                                                        + "           ,@OfficeAutomation_Document_HoldCoisn_ApplyID"
                                                        + "           ,@OfficeAutomation_Document_HoldCoisn_Department"
                                                        + "           ,@OfficeAutomation_Document_HoldCoisn_Area"
                                                        + "           ,@OfficeAutomation_Document_HoldCoisn_Clerk"
                                                        + "           ,@OfficeAutomation_Document_HoldCoisn_DealDate"
                                                        + "           ,@OfficeAutomation_Document_HoldCoisn_Address"
                                                        + "           ,@OfficeAutomation_Document_HoldCoisn_Reason"
                                                        + "           ,@OfficeAutomation_Document_HoldCoisn_TurnDate)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_HoldCoisn)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_HoldCoisn_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_HoldCoisn_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_HoldCoisn_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_HoldCoisn_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_HoldCoisn_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_HoldCoisn_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_HoldCoisn_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_HoldCoisn_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_HoldCoisn_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_HoldCoisn_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_HoldCoisn_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_HoldCoisn_Department));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_HoldCoisn_Area", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_HoldCoisn_Area));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_HoldCoisn_Clerk", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_HoldCoisn_Clerk));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_HoldCoisn_DealDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_HoldCoisn_DealDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_HoldCoisn_Address", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_HoldCoisn_Address));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_HoldCoisn_Reason", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_HoldCoisn_Reason));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_HoldCoisn_TurnDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_HoldCoisn_TurnDate));

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
            cmdToExecute.CommandText = "dbo.[pr_HoldCoisn_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_HoldCoisn]"
                                + "         SET [OfficeAutomation_Document_HoldCoisn_ApplyID] = @OfficeAutomation_Document_HoldCoisn_ApplyID"
                                + "         ,[OfficeAutomation_Document_HoldCoisn_Department] = @OfficeAutomation_Document_HoldCoisn_Department"
                                + "         ,[OfficeAutomation_Document_HoldCoisn_Area] = @OfficeAutomation_Document_HoldCoisn_Area"
                                + "         ,[OfficeAutomation_Document_HoldCoisn_Clerk] = @OfficeAutomation_Document_HoldCoisn_Clerk"
                                + "         ,[OfficeAutomation_Document_HoldCoisn_DealDate] = @OfficeAutomation_Document_HoldCoisn_DealDate"
                                + "         ,[OfficeAutomation_Document_HoldCoisn_Address] = @OfficeAutomation_Document_HoldCoisn_Address"
                                + "         ,[OfficeAutomation_Document_HoldCoisn_Reason] = @OfficeAutomation_Document_HoldCoisn_Reason"
                                + "         ,[OfficeAutomation_Document_HoldCoisn_TurnDate] = @OfficeAutomation_Document_HoldCoisn_TurnDate"
                                + "         WHERE [OfficeAutomation_Document_HoldCoisn_ID]=@OfficeAutomation_Document_HoldCoisn_ID"
                                + "         AND [OfficeAutomation_Document_HoldCoisn_MainID]=@OfficeAutomation_Document_HoldCoisn_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_HoldCoisn)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_HoldCoisn_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_HoldCoisn_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_HoldCoisn_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_HoldCoisn_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_HoldCoisn_Area", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_HoldCoisn_Area));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_HoldCoisn_Clerk", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_HoldCoisn_Clerk));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_HoldCoisn_DealDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_HoldCoisn_DealDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_HoldCoisn_Address", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_HoldCoisn_Address));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_HoldCoisn_Reason", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_HoldCoisn_Reason));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_HoldCoisn_TurnDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_HoldCoisn_TurnDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_HoldCoisn_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_HoldCoisn_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_HoldCoisn_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_HoldCoisn_MainID));

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
