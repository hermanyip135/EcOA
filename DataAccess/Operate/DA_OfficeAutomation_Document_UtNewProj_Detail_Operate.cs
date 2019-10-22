using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_UtNewProj_Detail_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_UtNewProj_Detail _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_UtNewProj_Detail]"
                                                        + "           ([OfficeAutomation_Document_UtNewProj_Detail_ID]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_Detail_MainID]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_Detail_CommType]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_Detail_SetNumberStart]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_Detail_SetNumberEnd]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_Detail_MoneyStart]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_Detail_MoneyEnd]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_Detail_Scale]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_Detail_PublishedScale]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_Detail_OwnerCommFloatKind]"
                                                        + "           ,[OfficeAutomation_Document_UtNewProj_Detail_OrderBy])"
                                                        + "     VALUES"
                                                        + "           (@guidOfficeAutomation_Document_UtNewProj_Detail_ID"
                                                        + "           ,@guidOfficeAutomation_Document_UtNewProj_Detail_MainID"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_Detail_CommType"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_Detail_SetNumberStart"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_Detail_SetNumberEnd"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_Detail_MoneyStart"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_Detail_MoneyEnd"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_Detail_Scale"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_Detail_PublishedScale"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_Detail_OwnerCommFloatKind"
                                                        + "           ,@OfficeAutomation_Document_UtNewProj_Detail_OrderBy)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_UtNewProj_Detail)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_UtNewProj_Detail_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Detail_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_UtNewProj_Detail_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Detail_MainID));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Detail_CommType", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Detail_CommType));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Detail_SetNumberStart", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Detail_SetNumberStart));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Detail_SetNumberEnd", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Detail_SetNumberEnd));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Detail_MoneyStart", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Detail_MoneyStart));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Detail_MoneyEnd", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Detail_MoneyEnd));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Detail_Scale", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Detail_Scale));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Detail_PublishedScale", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Detail_PublishedScale));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Detail_OwnerCommFloatKind", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Detail_OwnerCommFloatKind));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Detail_OrderBy", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Detail_OrderBy));

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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_UtNewProj_Detail]"
                                + "   SET [OfficeAutomation_Document_UtNewProj_Detail_CommType] =@OfficeAutomation_Document_UtNewProj_Detail_CommType"
                                + "         ,[OfficeAutomation_Document_UtNewProj_Detail_SetNumberStart] = @OfficeAutomation_Document_UtNewProj_Detail_SetNumberStart"
                                + "         ,[OfficeAutomation_Document_UtNewProj_Detail_SetNumberEnd] = @OfficeAutomation_Document_UtNewProj_Detail_SetNumberEnd"
                                + "         ,[OfficeAutomation_Document_UtNewProj_Detail_MoneyStart] = @OfficeAutomation_Document_UtNewProj_Detail_MoneyStart"
                                + "         ,[OfficeAutomation_Document_UtNewProj_Detail_MoneyEnd] = @OfficeAutomation_Document_UtNewProj_Detail_MoneyEnd"
                                + "         ,[OfficeAutomation_Document_UtNewProj_Detail_Scale] = @OfficeAutomation_Document_UtNewProj_Detail_Scale"
                                + "         ,[OfficeAutomation_Document_UtNewProj_Detail_PublishedScale] = @OfficeAutomation_Document_UtNewProj_Detail_PublishedScale"
                                + "         ,[OfficeAutomation_Document_UtNewProj_Detail_OwnerCommFloatKind] = @OfficeAutomation_Document_UtNewProj_Detail_OwnerCommFloatKind"
                                + "         ,[OfficeAutomation_Document_UtNewProj_Detail_OrderBy] = @OfficeAutomation_Document_UtNewProj_Detail_OrderBy"
                                + " WHERE [OfficeAutomation_Document_UtNewProj_Detail_ID]=@guidOfficeAutomation_Document_UtNewProj_Detail_ID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_UtNewProj_Detail)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Detail_CommType", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Detail_CommType));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Detail_SetNumberStart", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Detail_SetNumberStart));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Detail_SetNumberEnd", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Detail_SetNumberEnd));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Detail_MoneyStart", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Detail_MoneyStart));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Detail_MoneyEnd", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Detail_MoneyEnd));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Detail_Scale", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Detail_Scale));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Detail_PublishedScale", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Detail_PublishedScale));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Detail_OwnerCommFloatKind", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Detail_OwnerCommFloatKind));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_UtNewProj_Detail_OrderBy", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Detail_OrderBy));

                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_UtNewProj_Detail_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_UtNewProj_Detail_ID));

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

            cmdToExecute.CommandText = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_UtNewProj_Detail]"
                                + " WHERE [OfficeAutomation_Document_UtNewProj_Detail_MainID]=@guidOfficeAutomation_Document_UtNewProj_Detail_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_UtNewProj_Detail_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, new Guid(mainID)));

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
