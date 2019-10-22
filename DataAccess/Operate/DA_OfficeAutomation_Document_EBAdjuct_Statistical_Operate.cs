﻿using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_EBAdjuct_Statistical_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_EBAdjuct_Statistical _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_EBAdjuct_Statistical]"
                                                        + "           ([OfficeAutomation_Document_EBAdjuct_Statistical_ID]"
                                                        + "           ,[OfficeAutomation_Document_EBAdjuct_Statistical_MainID]"
                                                        + "           ,[OfficeAutomation_Document_EBAdjuct_Statistical_Adjuct]"
                                                        + "           ,[OfficeAutomation_Document_EBAdjuct_Statistical_Money]"
                                                        + "           ,[OfficeAutomation_Document_EBAdjuct_Statistical_Reason]"
                                                        + "           ,[OfficeAutomation_Document_EBAdjuct_Statistical_Condition])"
                                                        + "     VALUES"
                                                        + "           (@guidOfficeAutomation_Document_EBAdjuct_Statistical_ID"
                                                        + "           ,@guidOfficeAutomation_Document_EBAdjuct_Statistical_MainID"
                                                        + "           ,@OfficeAutomation_Document_EBAdjuct_Statistical_Adjuct"
                                                        + "           ,@OfficeAutomation_Document_EBAdjuct_Statistical_Money"
                                                        + "           ,@OfficeAutomation_Document_EBAdjuct_Statistical_Reason"
                                                        + "           ,@OfficeAutomation_Document_EBAdjuct_Statistical_Condition)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_EBAdjuct_Statistical)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_EBAdjuct_Statistical_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_Statistical_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_EBAdjuct_Statistical_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_Statistical_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_Statistical_Adjuct", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_Statistical_Adjuct));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_Statistical_Money", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_Statistical_Money));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_Statistical_Reason", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_Statistical_Reason));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_Statistical_Condition", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_Statistical_Condition));

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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_EBAdjuct_Statistical]"
                                + "   SET [OfficeAutomation_Document_EBAdjuct_Statistical_Adjuct] =@OfficeAutomation_Document_EBAdjuct_Statistical_Adjuct"
                                + "         ,[OfficeAutomation_Document_EBAdjuct_Statistical_Money] = @OfficeAutomation_Document_EBAdjuct_Statistical_Money"
                                + "         ,[OfficeAutomation_Document_EBAdjuct_Statistical_Reason] = @OfficeAutomation_Document_EBAdjuct_Statistical_Reason"
                                + "         ,[OfficeAutomation_Document_EBAdjuct_Statistical_Condition] = @OfficeAutomation_Document_EBAdjuct_Statistical_Condition"
                                + " WHERE [OfficeAutomation_Document_EBAdjuct_Statistical_ID]=@guidOfficeAutomation_Document_EBAdjuct_Statistical_ID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_EBAdjuct_Statistical)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_Statistical_Adjuct", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_Statistical_Adjuct));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_Statistical_Money", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_Statistical_Money));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_Statistical_Reason", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_Statistical_Reason));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_Statistical_Condition", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_Statistical_Condition));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_EBAdjuct_Statistical_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_Statistical_ID));

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

            cmdToExecute.CommandText = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_EBAdjuct_Statistical]"
                                + " WHERE [OfficeAutomation_Document_EBAdjuct_Statistical_MainID]=@guidOfficeAutomation_Document_EBAdjuct_Statistical_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_EBAdjuct_Statistical_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, new Guid(mainID)));

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
