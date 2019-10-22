using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_AssetTransfer_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_AssetTransfer _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_AssetTransfer]"
                                                        + "           ([OfficeAutomation_Document_AssetTransfer_ID]"
                                                        + "           ,[OfficeAutomation_Document_AssetTransfer_MainID]"
                                                        + "           ,[OfficeAutomation_Document_AssetTransfer_Department]"
                                                        + "           ,[OfficeAutomation_Document_AssetTransfer_Apply]"
                                                        + "           ,[OfficeAutomation_Document_AssetTransfer_ExportDepartment]"
                                                        + "           ,[OfficeAutomation_Document_AssetTransfer_ImportDepartment]"
                                                        + "           ,[OfficeAutomation_Document_AssetTransfer_ExportContacts]"
                                                        + "           ,[OfficeAutomation_Document_AssetTransfer_ImportContacts]"
                                                        + "           ,[OfficeAutomation_Document_AssetTransfer_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_AssetTransfer_ExportPlace]"
                                                        + "           ,[OfficeAutomation_Document_AssetTransfer_ImportPlace]"
                                                        + "           ,[OfficeAutomation_Document_AssetTransfer_TransferReason]"
                                                        + "           ,[OfficeAutomation_Document_AssetTransfer_ApplyID]"
                                                        + "           )"
                                                        + " VALUES"
                                                        + "          (@guidOfficeAutomation_Document_AssetTransfer_ID"
                                                        + "           ,@guidOfficeAutomation_Document_AssetTransfer_MainID"
                                                        + "           ,@sOfficeAutomation_Document_AssetTransfer_Department"
                                                        + "           ,@sOfficeAutomation_Document_AssetTransfer_Apply"
                                                        + "           ,@sOfficeAutomation_Document_AssetTransfer_ExportDepartment"
                                                        + "           ,@sOfficeAutomation_Document_AssetTransfer_ImportDepartment"
                                                        + "           ,@sOfficeAutomation_Document_AssetTransfer_ExportContacts"
                                                        + "           ,@sOfficeAutomation_Document_AssetTransfer_ImportContacts"
                                                        + "           ,@dtOfficeAutomation_Document_AssetTransfer_ApplyDate"
                                                        + "           ,@sOfficeAutomation_Document_AssetTransfer_ExportPlace"
                                                        + "           ,@sOfficeAutomation_Document_AssetTransfer_ImportPlace"
                                                        + "           ,@sOfficeAutomation_Document_AssetTransfer_TransferReason"
                                                        + "           ,@sOfficeAutomation_Document_AssetTransfer_ApplyID"
                                                        + "           )";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_AssetTransfer)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_AssetTransfer_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_AssetTransfer_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_AssetTransfer_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_AssetTransfer_Apply", SqlDbType.NVarChar, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_AssetTransfer_ExportDepartment", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_ExportDepartment));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_AssetTransfer_ImportDepartment", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_ImportDepartment));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_AssetTransfer_ExportContacts", SqlDbType.NVarChar, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_ExportContacts));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_AssetTransfer_ImportContacts", SqlDbType.NVarChar, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_ImportContacts));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_AssetTransfer_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_AssetTransfer_ExportPlace", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_ExportPlace));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_AssetTransfer_ImportPlace", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_ImportPlace));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_AssetTransfer_TransferReason", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_TransferReason));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_AssetTransfer_ApplyID", SqlDbType.NVarChar, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_ApplyID));
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
            cmdToExecute.CommandText = "dbo.[pr_AssetTransfer_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_AssetTransfer]"
                                + "   SET [OfficeAutomation_Document_AssetTransfer_Department] = @sOfficeAutomation_Document_AssetTransfer_Department"
                                + "         ,[OfficeAutomation_Document_AssetTransfer_ExportDepartment] = @sOfficeAutomation_Document_AssetTransfer_ExportDepartment"
                                + "         ,[OfficeAutomation_Document_AssetTransfer_ImportDepartment] = @sOfficeAutomation_Document_AssetTransfer_ImportDepartment"
                                + "         ,[OfficeAutomation_Document_AssetTransfer_ExportContacts] = @sOfficeAutomation_Document_AssetTransfer_ExportContacts"
                                + "         ,[OfficeAutomation_Document_AssetTransfer_ImportContacts] = @sOfficeAutomation_Document_AssetTransfer_ImportContacts"
                                + "         ,[OfficeAutomation_Document_AssetTransfer_ApplyDate] = @dtOfficeAutomation_Document_AssetTransfer_ApplyDate"
                                + "         ,[OfficeAutomation_Document_AssetTransfer_ExportPlace] = @sOfficeAutomation_Document_AssetTransfer_ExportPlace"
                                + "         ,[OfficeAutomation_Document_AssetTransfer_ImportPlace] = @sOfficeAutomation_Document_AssetTransfer_ImportPlace"
                                + "         ,[OfficeAutomation_Document_AssetTransfer_TransferReason] = @sOfficeAutomation_Document_AssetTransfer_TransferReason"
                                + " WHERE [OfficeAutomation_Document_AssetTransfer_ID]=@guidOfficeAutomation_Document_AssetTransfer_ID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_AssetTransfer)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_AssetTransfer_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_AssetTransfer_ExportDepartment", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_ExportDepartment));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_AssetTransfer_ImportDepartment", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_ImportDepartment));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_AssetTransfer_ExportContacts", SqlDbType.NVarChar, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_ExportContacts));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_AssetTransfer_ImportContacts", SqlDbType.NVarChar, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_ImportContacts));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_AssetTransfer_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_AssetTransfer_ExportPlace", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_ExportPlace));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_AssetTransfer_ImportPlace", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_ImportPlace));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_AssetTransfer_TransferReason", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_TransferReason));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_AssetTransfer_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_AssetTransfer_ID));

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
