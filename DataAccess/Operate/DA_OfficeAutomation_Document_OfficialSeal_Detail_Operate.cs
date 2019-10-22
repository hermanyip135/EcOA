using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_OfficialSeal_Detail_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_OfficialSeal_Detail _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_OfficialSeal_Detail]"
                                                        + "           ([OfficeAutomation_Document_OfficialSeal_Detail_ID]"
                                                        + "           ,[OfficeAutomation_Document_OfficialSeal_Detail_MainID]"
                                                        + "           ,[OfficeAutomation_Document_OfficialSeal_Detail_TransFile]"
                                                        + "           ,[OfficeAutomation_Document_OfficialSeal_Detail_FileName]"
                                                        + "           ,[OfficeAutomation_Document_OfficialSeal_Detail_AgentBeginData]"
                                                        + "           ,[OfficeAutomation_Document_OfficialSeal_Detail_AgentEndData]"
                                                        + "           ,[OfficeAutomation_Document_OfficialSeal_Detail_BN]"
                                                        + "           ,[OfficeAutomation_Document_OfficialSeal_Detail_Company]"
                                                        + "           ,[OfficeAutomation_Document_OfficialSeal_Detail_Use])"
                                                        + "     VALUES"
                                                        + "           (@OfficeAutomation_Document_OfficialSeal_Detail_ID"
                                                        + "           ,@OfficeAutomation_Document_OfficialSeal_Detail_MainID"
                                                        + "           ,@OfficeAutomation_Document_OfficialSeal_Detail_TransFile"
                                                        + "           ,@OfficeAutomation_Document_OfficialSeal_Detail_FileName"
                                                        + "           ,@OfficeAutomation_Document_OfficialSeal_Detail_AgentBeginData"
                                                        + "           ,@OfficeAutomation_Document_OfficialSeal_Detail_AgentEndData"
                                                        + "           ,@OfficeAutomation_Document_OfficialSeal_Detail_BN"
                                                        + "           ,@OfficeAutomation_Document_OfficialSeal_Detail_Company"
                                                        + "           ,@OfficeAutomation_Document_OfficialSeal_Detail_Use)";


            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_OfficialSeal_Detail)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_Detail_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_Detail_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_Detail_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_Detail_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_Detail_TransFile", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_Detail_TransFile));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_Detail_FileName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_Detail_FileName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_Detail_AgentBeginData", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_Detail_AgentBeginData));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_Detail_AgentEndData", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_Detail_AgentEndData));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_Detail_BN", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_Detail_BN));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_Detail_Company", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_Detail_Company));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_Detail_Use", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_Detail_Use));

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

            cmdToExecute.CommandText = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_OfficialSeal_Detail]"
                                + " WHERE [OfficeAutomation_Document_OfficialSeal_Detail_MainID]=@OfficeAutomation_Document_OfficialSeal_Detail_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_Detail_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, new Guid(mainID)));

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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_OfficialSeal_Detail]"
                                                        + "     SET [OfficeAutomation_Document_OfficialSeal_Detail_TransFile]=@OfficeAutomation_Document_OfficialSeal_Detail_TransFile"
                                                        + "            ,[OfficeAutomation_Document_OfficialSeal_Detail_FileName]=@OfficeAutomation_Document_OfficialSeal_Detail_FileName"
                                                        + "            ,[OfficeAutomation_Document_OfficialSeal_Detail_AgentBeginData]=@OfficeAutomation_Document_OfficialSeal_Detail_AgentBeginData"
                                                        + "            ,[OfficeAutomation_Document_OfficialSeal_Detail_AgentEndData]=@OfficeAutomation_Document_OfficialSeal_Detail_AgentEndData"
                                                        + "            ,[OfficeAutomation_Document_OfficialSeal_Detail_BN]=@OfficeAutomation_Document_OfficialSeal_Detail_BN"
                                                        + "            ,[OfficeAutomation_Document_OfficialSeal_Detail_Company]=@OfficeAutomation_Document_OfficialSeal_Detail_Company"
                                                        + "            ,[OfficeAutomation_Document_OfficialSeal_Detail_Use]=@OfficeAutomation_Document_OfficialSeal_Detail_Use"
                                                        + " WHERE [OfficeAutomation_Document_OfficialSeal_Detail_ID]=@OfficeAutomation_Document_OfficialSeal_Detail_ID"
                                                        + "     AND [OfficeAutomation_Document_OfficialSeal_Detail_MainID] = @OfficeAutomation_Document_OfficialSeal_Detail_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_OfficialSeal_Detail)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_Detail_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_Detail_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_Detail_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_Detail_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_Detail_TransFile", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_Detail_TransFile));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_Detail_FileName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_Detail_FileName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_Detail_AgentBeginData", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_Detail_AgentBeginData));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_Detail_AgentEndData", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_Detail_AgentEndData));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_Detail_BN", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_Detail_BN));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_Detail_Company", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_Detail_Company));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_Detail_Use", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_Detail_Use));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_Detail_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_Detail_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OfficialSeal_Detail_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OfficialSeal_Detail_MainID));

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
