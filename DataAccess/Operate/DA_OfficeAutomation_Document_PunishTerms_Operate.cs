using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_PunishTerms_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_PunishTerms _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_PunishTerms]"
                                                        + "           ([OfficeAutomation_Document_PunishTerms_ID]"
                                                        + "           ,[OfficeAutomation_Document_PunishTerms_MainID]"
                                                        + "           ,[OfficeAutomation_Document_PunishTerms_Apply]"
                                                        + "           ,[OfficeAutomation_Document_PunishTerms_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_PunishTerms_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_PunishTerms_Department]"
                                                        + "           ,[OfficeAutomation_Document_PunishTerms_Contract]"
                                                        + "           ,[OfficeAutomation_Document_PunishTerms_ContractKind]"
                                                        + "           ,[OfficeAutomation_Document_PunishTerms_AgentPeriod])"
                                                        + " VALUES"
                                                        + "           (@OfficeAutomation_Document_PunishTerms_ID"
                                                        + "           ,@OfficeAutomation_Document_PunishTerms_MainID"
                                                        + "           ,@OfficeAutomation_Document_PunishTerms_Apply"
                                                        + "           ,@OfficeAutomation_Document_PunishTerms_ApplyDate"
                                                        + "           ,@OfficeAutomation_Document_PunishTerms_ApplyID"
                                                        + "           ,@OfficeAutomation_Document_PunishTerms_Department"
                                                        + "           ,@OfficeAutomation_Document_PunishTerms_Contract"
                                                        + "           ,@OfficeAutomation_Document_PunishTerms_ContractKind"
                                                        + "           ,@OfficeAutomation_Document_PunishTerms_AgentPeriod)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_PunishTerms)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PunishTerms_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PunishTerms_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PunishTerms_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PunishTerms_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PunishTerms_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PunishTerms_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PunishTerms_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PunishTerms_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PunishTerms_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PunishTerms_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PunishTerms_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PunishTerms_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PunishTerms_Contract", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PunishTerms_Contract));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PunishTerms_ContractKind", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PunishTerms_ContractKind));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PunishTerms_AgentPeriod", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PunishTerms_AgentPeriod));

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
            cmdToExecute.CommandText = "dbo.[pr_PunishTerms_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_PunishTerms]"
                                + "         SET [OfficeAutomation_Document_PunishTerms_ApplyID] = @OfficeAutomation_Document_PunishTerms_ApplyID"
                                + "         ,[OfficeAutomation_Document_PunishTerms_Department] = @OfficeAutomation_Document_PunishTerms_Department"
                                + "         ,[OfficeAutomation_Document_PunishTerms_Contract] = @OfficeAutomation_Document_PunishTerms_Contract"
                                + "         ,[OfficeAutomation_Document_PunishTerms_ContractKind] = @OfficeAutomation_Document_PunishTerms_ContractKind"
                                + "         ,[OfficeAutomation_Document_PunishTerms_AgentPeriod] = @OfficeAutomation_Document_PunishTerms_AgentPeriod"
                                + "         WHERE [OfficeAutomation_Document_PunishTerms_ID]=@OfficeAutomation_Document_PunishTerms_ID"
                                + "         AND [OfficeAutomation_Document_PunishTerms_MainID]=@OfficeAutomation_Document_PunishTerms_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_PunishTerms)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PunishTerms_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PunishTerms_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PunishTerms_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PunishTerms_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PunishTerms_Contract", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PunishTerms_Contract));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PunishTerms_ContractKind", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PunishTerms_ContractKind));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PunishTerms_AgentPeriod", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PunishTerms_AgentPeriod));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PunishTerms_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PunishTerms_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PunishTerms_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PunishTerms_MainID));

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
