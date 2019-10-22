using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Marketing_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_Marketing _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Marketing]"
                                                        + "           ([OfficeAutomation_Document_Marketing_ID]"
                                                        + "           ,[OfficeAutomation_Document_Marketing_MainID]"
                                                        + "           ,[OfficeAutomation_Document_Marketing_Apply]"
                                                        + "           ,[OfficeAutomation_Document_Marketing_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_Marketing_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_Marketing_Department]"
                                                        + "           ,[OfficeAutomation_Document_Marketing_ReceiveDP]"
                                                        + "           ,[OfficeAutomation_Document_Marketing_Telephone]"
                                                        + "           ,[OfficeAutomation_Document_Marketing_Fax]"
                                                        + "           ,[OfficeAutomation_Document_Marketing_Subject]"
                                                        + "           ,[OfficeAutomation_Document_Marketing_Describe])"
                                                        + " VALUES"
                                                        + "           (@OfficeAutomation_Document_Marketing_ID"
                                                        + "           ,@OfficeAutomation_Document_Marketing_MainID"
                                                        + "           ,@OfficeAutomation_Document_Marketing_Apply"
                                                        + "           ,@OfficeAutomation_Document_Marketing_ApplyDate"
                                                        + "           ,@OfficeAutomation_Document_Marketing_ApplyID"
                                                        + "           ,@OfficeAutomation_Document_Marketing_Department"
                                                        + "           ,@OfficeAutomation_Document_Marketing_ReceiveDP"
                                                        + "           ,@OfficeAutomation_Document_Marketing_Telephone"
                                                        + "           ,@OfficeAutomation_Document_Marketing_Fax"
                                                        + "           ,@OfficeAutomation_Document_Marketing_Subject"
                                                        + "           ,@OfficeAutomation_Document_Marketing_Describe)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_Marketing)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Marketing_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Marketing_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Marketing_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Marketing_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Marketing_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Marketing_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Marketing_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Marketing_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Marketing_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Marketing_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Marketing_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Marketing_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Marketing_ReceiveDP", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Marketing_ReceiveDP));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Marketing_Telephone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Marketing_Telephone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Marketing_Fax", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Marketing_Fax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Marketing_Subject", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Marketing_Subject));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Marketing_Describe", SqlDbType.Text, 999999, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Marketing_Describe));

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
            cmdToExecute.CommandText = "dbo.[pr_Marketing_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Marketing]"
                                + "         SET [OfficeAutomation_Document_Marketing_ApplyID] = @OfficeAutomation_Document_Marketing_ApplyID"
                                + "         ,[OfficeAutomation_Document_Marketing_Department] = @OfficeAutomation_Document_Marketing_Department"
                                + "         ,[OfficeAutomation_Document_Marketing_ReceiveDP] = @OfficeAutomation_Document_Marketing_ReceiveDP"
                                + "         ,[OfficeAutomation_Document_Marketing_Telephone] = @OfficeAutomation_Document_Marketing_Telephone"
                                + "         ,[OfficeAutomation_Document_Marketing_Fax] = @OfficeAutomation_Document_Marketing_Fax"
                                + "         ,[OfficeAutomation_Document_Marketing_Subject] = @OfficeAutomation_Document_Marketing_Subject"
                                + "         ,[OfficeAutomation_Document_Marketing_Describe] = @OfficeAutomation_Document_Marketing_Describe"
                                + "         WHERE [OfficeAutomation_Document_Marketing_ID]=@OfficeAutomation_Document_Marketing_ID"
                                + "         AND [OfficeAutomation_Document_Marketing_MainID]=@OfficeAutomation_Document_Marketing_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_Marketing)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Marketing_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Marketing_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Marketing_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Marketing_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Marketing_ReceiveDP", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Marketing_ReceiveDP));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Marketing_Telephone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Marketing_Telephone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Marketing_Fax", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Marketing_Fax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Marketing_Subject", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Marketing_Subject));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Marketing_Describe", SqlDbType.Text, 999999, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Marketing_Describe));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Marketing_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Marketing_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Marketing_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Marketing_MainID));

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
