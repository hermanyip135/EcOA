using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_PullafewRd_LeaseTerm_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_PullafewRd_LeaseTerm _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_PullafewRd_LeaseTerm]"
                                                        + "           ([OfficeAutomation_Document_PullafewRd_LeaseTerm_ID]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_LeaseTerm_MainID]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_LeaseTerm_1a]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_LeaseTerm_1b]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_LeaseTerm_1c]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_LeaseTerm_1d]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_LeaseTerm_1e]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_LeaseTerm_1f]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_LeaseTerm_1g]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_LeaseTerm_1h]"
                                                        + "           ,[OfficeAutomation_Document_PullafewRd_LeaseTerm_1i]"
                                                        + "          )"
                                                        + "     VALUES"
                                                        + "           (@guidOfficeAutomation_Document_PullafewRd_LeaseTerm_ID"
                                                        + "           ,@guidOfficeAutomation_Document_PullafewRd_LeaseTerm_MainID"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_LeaseTerm_1a"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_LeaseTerm_1b"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_LeaseTerm_1c"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_LeaseTerm_1d"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_LeaseTerm_1e"
                                                        + "           ,@OfficeAutomation_Document_PullafewRd_LeaseTerm_1f"
                                                        +"            ,@OfficeAutomation_Document_PullafewRd_LeaseTerm_1g"
                                                        + "            ,@OfficeAutomation_Document_PullafewRd_LeaseTerm_1h"
                                                        + "            ,@OfficeAutomation_Document_PullafewRd_LeaseTerm_1i"
                                                        +"            )";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_PullafewRd_LeaseTerm)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_PullafewRd_LeaseTerm_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_LeaseTerm_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_PullafewRd_LeaseTerm_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_LeaseTerm_MainID));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_LeaseTerm_1a", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_LeaseTerm_1a));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_LeaseTerm_1b", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_LeaseTerm_1b));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_LeaseTerm_1c", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_LeaseTerm_1c));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_LeaseTerm_1d", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_LeaseTerm_1d));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_LeaseTerm_1e", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_LeaseTerm_1e));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_LeaseTerm_1f", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_LeaseTerm_1f));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_LeaseTerm_1g", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_LeaseTerm_1g));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_LeaseTerm_1h", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_LeaseTerm_1h));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_LeaseTerm_1i", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_LeaseTerm_1i));
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_PullafewRd_LeaseTerm]"
                                + "   SET [OfficeAutomation_Document_PullafewRd_LeaseTerm_1a] =@OfficeAutomation_Document_PullafewRd_LeaseTerm_1a"
                                + "         ,[OfficeAutomation_Document_PullafewRd_LeaseTerm_1b] = @sOfficeAutomation_Document_PullafewRd_LeaseTerm_1b"
                                + "         ,[OfficeAutomation_Document_PullafewRd_LeaseTerm_1c] = @sOfficeAutomation_Document_PullafewRd_LeaseTerm_1c"
                                + "         ,[OfficeAutomation_Document_PullafewRd_LeaseTerm_1d] = @sOfficeAutomation_Document_PullafewRd_LeaseTerm_1d"
                                + "         ,[OfficeAutomation_Document_PullafewRd_LeaseTerm_1e] = @sOfficeAutomation_Document_PullafewRd_LeaseTerm_1e"
                                + "         ,[OfficeAutomation_Document_PullafewRd_LeaseTerm_1f] = @sOfficeAutomation_Document_PullafewRd_LeaseTerm_1f"
                                 + "         ,[OfficeAutomation_Document_PullafewRd_LeaseTerm_1h] = @sOfficeAutomation_Document_PullafewRd_LeaseTerm_1h"
                                  + "         ,[OfficeAutomation_Document_PullafewRd_LeaseTerm_1i] = @sOfficeAutomation_Document_PullafewRd_LeaseTerm_1i"

                                + " WHERE [OfficeAutomation_Document_PullafewRd_LeaseTerm_ID]=@guidOfficeAutomation_Document_PullafewRd_LeaseTerm_ID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_PullafewRd_LeaseTerm)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewRd_LeaseTerm_1a", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_LeaseTerm_1a));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_PullafewRd_LeaseTerm_1b", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_LeaseTerm_1b));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_PullafewRd_LeaseTerm_1c", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_LeaseTerm_1c));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_PullafewRd_LeaseTerm_1d", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_LeaseTerm_1d));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_PullafewRd_LeaseTerm_1e", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_LeaseTerm_1e));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_PullafewRd_LeaseTerm_1f", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_LeaseTerm_1f));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_PullafewRd_LeaseTerm_1h", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_LeaseTerm_1h));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_PullafewRd_LeaseTerm_1i", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_LeaseTerm_1i));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_PullafewRd_LeaseTerm_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewRd_LeaseTerm_ID));

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

            cmdToExecute.CommandText = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_PullafewRd_LeaseTerm]"
                                + " WHERE [OfficeAutomation_Document_PullafewRd_LeaseTerm_MainID]=@guidOfficeAutomation_Document_PullafewRd_LeaseTerm_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_PullafewRd_LeaseTerm_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, new Guid(mainID)));

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
