using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_PullafewTwo_Statistical_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_PullafewTwo_Statistical _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_PullafewTwo_Statistical]"
                                                        + "           ([OfficeAutomation_Document_PullafewTwo_Statistical_ID]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_Statistical_MainID]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_Statistical_1a]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_Statistical_1b]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_Statistical_1c]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_Statistical_1d]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_Statistical_1e]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_Statistical_1f]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_Statistical_1g]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_Statistical_1h]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_Statistical_1i]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_Statistical_1j]"
                                                        //+ "           ,[OfficeAutomation_Document_PullafewTwo_Statistical_1jk]"
                                                        + "           ,[OfficeAutomation_Document_PullafewTwo_Statistical_1k])"
                                                        + "     VALUES"
                                                        + "           (@guidOfficeAutomation_Document_PullafewTwo_Statistical_ID"
                                                        + "           ,@guidOfficeAutomation_Document_PullafewTwo_Statistical_MainID"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_Statistical_1a"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_Statistical_1b"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_Statistical_1c"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_Statistical_1d"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_Statistical_1e"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_Statistical_1f"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_Statistical_1g"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_Statistical_1h"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_Statistical_1i"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_Statistical_1j"
                                                        //+ "           ,@OfficeAutomation_Document_PullafewTwo_Statistical_1jk"
                                                        + "           ,@OfficeAutomation_Document_PullafewTwo_Statistical_1k)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_PullafewTwo_Statistical)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_PullafewTwo_Statistical_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_Statistical_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_PullafewTwo_Statistical_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_Statistical_MainID));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_Statistical_1a", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_Statistical_1a));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_Statistical_1b", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_Statistical_1b));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_Statistical_1c", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_Statistical_1c));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_Statistical_1d", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_Statistical_1d));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_Statistical_1e", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_Statistical_1e));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_Statistical_1f", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_Statistical_1f));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_Statistical_1g", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_Statistical_1g));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_Statistical_1h", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_Statistical_1h));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_Statistical_1i", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_Statistical_1i));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_Statistical_1j", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_Statistical_1j));
                //cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_Statistical_1jk", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_Statistical_1jk));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_Statistical_1k", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_Statistical_1k));

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

            cmdToExecute.CommandText = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_PullafewTwo_Statistical]"
                                + " WHERE [OfficeAutomation_Document_PullafewTwo_Statistical_MainID]=@guidOfficeAutomation_Document_PullafewTwo_Statistical_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_PullafewTwo_Statistical_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, new Guid(mainID)));

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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_PullafewTwo_Statistical]"
                                                        + "     SET  [OfficeAutomation_Document_PullafewTwo_Statistical_1a]=@OfficeAutomation_Document_PullafewTwo_Statistical_1a"
                                                        + "         ,[OfficeAutomation_Document_PullafewTwo_Statistical_1b] = @OfficeAutomation_Document_PullafewTwo_Statistical_1b"
                                                        + "         ,[OfficeAutomation_Document_PullafewTwo_Statistical_1c] = @OfficeAutomation_Document_PullafewTwo_Statistical_1c"
                                                        + "         ,[OfficeAutomation_Document_PullafewTwo_Statistical_1d] = @OfficeAutomation_Document_PullafewTwo_Statistical_1d"
                                                        + "         ,[OfficeAutomation_Document_PullafewTwo_Statistical_1e] = @OfficeAutomation_Document_PullafewTwo_Statistical_1e"
                                                        + "         ,[OfficeAutomation_Document_PullafewTwo_Statistical_1f] = @OfficeAutomation_Document_PullafewTwo_Statistical_1f"
                                                        + "         ,[OfficeAutomation_Document_PullafewTwo_Statistical_1g] = @OfficeAutomation_Document_PullafewTwo_Statistical_1g"
                                                        + "         ,[OfficeAutomation_Document_PullafewTwo_Statistical_1h] = @OfficeAutomation_Document_PullafewTwo_Statistical_1h"
                                                        + "         ,[OfficeAutomation_Document_PullafewTwo_Statistical_1i] = @OfficeAutomation_Document_PullafewTwo_Statistical_1i"
                                                        + "         ,[OfficeAutomation_Document_PullafewTwo_Statistical_1j] = @OfficeAutomation_Document_PullafewTwo_Statistical_1j"
                                                        + "         ,[OfficeAutomation_Document_PullafewTwo_Statistical_1j] = @OfficeAutomation_Document_PullafewTwo_Statistical_1j"

                                                        + " WHERE [OfficeAutomation_Document_PullafewTwo_Statistical_ID]=@guidOfficeAutomation_Document_PullafewTwo_Statistical_ID"
                                                        + "     AND [OfficeAutomation_Document_PullafewTwo_Statistical_MainID] = @guidOfficeAutomation_Document_PullafewTwo_Statistical_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_PullafewTwo_Statistical)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_Statistical_1a", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_Statistical_1a));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_Statistical_1b", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_Statistical_1b));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_Statistical_1c", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_Statistical_1c));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_Statistical_1d", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_Statistical_1d));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_Statistical_1e", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_Statistical_1e));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_Statistical_1f", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_Statistical_1f));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_Statistical_1g", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_Statistical_1g));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_Statistical_1h", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_Statistical_1h));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_Statistical_1i", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_Statistical_1i));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_Statistical_1j", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_Statistical_1j));
                //cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_Statistical_1jk", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_Statistical_1jk));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PullafewTwo_Statistical_1k", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_Statistical_1k));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_PullafewTwo_Statistical_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_Statistical_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_PullafewTwo_Statistical_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PullafewTwo_Statistical_MainID));

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
