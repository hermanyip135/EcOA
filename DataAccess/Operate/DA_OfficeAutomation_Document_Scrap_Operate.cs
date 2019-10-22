using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Scrap_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_Scrap _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Scrap]"
                                                        + "           ([OfficeAutomation_Document_Scrap_ID]"
                                                        + "           ,[OfficeAutomation_Document_Scrap_MainID]"
                                                        + "           ,[OfficeAutomation_Document_Scrap_Department]"
                                                        + "           ,[OfficeAutomation_Document_Scrap_Apply]"
                                                        + "           ,[OfficeAutomation_Document_Scrap_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_Scrap_UserName]"
                                                        + "           ,[OfficeAutomation_Document_Scrap_UserTeam]"
                                                        + "           ,[OfficeAutomation_Document_Scrap_ReqReason]"
                                                        + "           ,[OfficeAutomation_Document_Scrap_SurplusValue]"
                                                        + "           ,[OfficeAutomation_Document_Scrap_Suc]"
                                                        + "           ,[OfficeAutomation_Document_Scrap_ApplyID]"
                                                        +")"
                //+ "           ,[OfficeAutomation_Document_Scrap_Deal])"
                                                        + " VALUES"
                                                        + "          (@guidOfficeAutomation_Document_Scrap_ID"
                                                        + "           ,@guidOfficeAutomation_Document_Scrap_MainID"
                                                        + "           ,@sOfficeAutomation_Document_Scrap_Department"
                                                        + "           ,@sOfficeAutomation_Document_Scrap_Apply"
                                                        + "           ,@dtOfficeAutomation_Document_Scrap_ApplyDate"
                                                        + "           ,@sOfficeAutomation_Document_Scrap_UserName"
                                                        + "           ,@sOfficeAutomation_Document_Scrap_UserTeam"
                                                        + "           ,@sOfficeAutomation_Document_Scrap_ReqReason"
                                                        + "           ,@sOfficeAutomation_Document_Scrap_SurplusValue"
                                                        + "           ,@OfficeAutomation_Document_Scrap_Suc"
                                                        + "           ,@OfficeAutomation_Document_Scrap_ApplyID"
                                                        + "           )";
                                                        //+ "           ,@sOfficeAutomation_Document_Scrap_Deal)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_Scrap)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_Scrap_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_Scrap_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Scrap_Department", SqlDbType.NVarChar, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Scrap_Apply", SqlDbType.NVarChar, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_Scrap_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Scrap_UserName", SqlDbType.NVarChar, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_UserName));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Scrap_UserTeam", SqlDbType.NVarChar, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_UserTeam));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Scrap_ReqReason", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_ReqReason));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Scrap_SurplusValue", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_SurplusValue));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Scrap_Suc", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Suc));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Scrap_ApplyID", SqlDbType.NVarChar, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_ApplyID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Scrap_Deal", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Deal));
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
            cmdToExecute.CommandText = "dbo.[pr_Scrap_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Scrap]"
                                + "   SET [OfficeAutomation_Document_Scrap_Department] = @sOfficeAutomation_Document_Scrap_Department"
                                + "         ,[OfficeAutomation_Document_Scrap_Apply] = @sOfficeAutomation_Document_Scrap_Apply"
                                + "         ,[OfficeAutomation_Document_Scrap_ApplyDate] = @dtOfficeAutomation_Document_Scrap_ApplyDate"
                                + "         ,[OfficeAutomation_Document_Scrap_UserName] = @sOfficeAutomation_Document_Scrap_UserName"
                                + "         ,[OfficeAutomation_Document_Scrap_UserTeam] = @sOfficeAutomation_Document_Scrap_UserTeam"
                                + "         ,[OfficeAutomation_Document_Scrap_ReqReason] = @sOfficeAutomation_Document_Scrap_ReqReason"
                                + "         ,[OfficeAutomation_Document_Scrap_SurplusValue] = @sOfficeAutomation_Document_Scrap_SurplusValue"
                                + "         ,[OfficeAutomation_Document_Scrap_Suc] = @OfficeAutomation_Document_Scrap_Suc"
                                + "         ,[OfficeAutomation_Document_Scrap_ApplyID] = @sOfficeAutomation_Document_Scrap_ApplyID"
                                //+ "         ,[OfficeAutomation_Document_Scrap_Deal] = @sOfficeAutomation_Document_Scrap_Deal"
                                + " WHERE [OfficeAutomation_Document_Scrap_ID]=@guidOfficeAutomation_Document_Scrap_ID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_Scrap)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Scrap_Department", SqlDbType.NVarChar, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Scrap_Apply", SqlDbType.NVarChar, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_Scrap_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Scrap_UserName", SqlDbType.NVarChar, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_UserName));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Scrap_UserTeam", SqlDbType.NVarChar, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_UserTeam));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Scrap_ReqReason", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_ReqReason));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Scrap_SurplusValue", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_SurplusValue));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Scrap_Suc", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Suc));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Scrap_ApplyID", SqlDbType.NVarChar, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_ApplyID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Scrap_Deal", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_Deal));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_Scrap_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Scrap_ID));
              
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
