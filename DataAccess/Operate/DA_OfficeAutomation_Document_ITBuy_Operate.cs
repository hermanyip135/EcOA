using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_ITBuy_Operate:SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_ITBuy _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ITBuy]"
                                                        + "           ([OfficeAutomation_Document_ITBuy_ID]"
                                                        + "           ,[OfficeAutomation_Document_ITBuy_MainID]"
                                                        + "           ,[OfficeAutomation_Document_ITBuy_Department]"
                                                        + "           ,[OfficeAutomation_Document_ITBuy_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_ITBuy_Apply]"
                                                        + "           ,[OfficeAutomation_Document_ITBuy_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_ITBuy_ReplyPhone]"
                                                        + "           ,[OfficeAutomation_Document_ITBuy_Buy1]"
                                                        + "           ,[OfficeAutomation_Document_ITBuy_Unit1]"
                                                        + "           ,[OfficeAutomation_Document_ITBuy_Buy2]"
                                                        + "           ,[OfficeAutomation_Document_ITBuy_Unit2]"
                                                        + "           ,[OfficeAutomation_Document_ITBuy_Buy3]"
                                                        + "           ,[OfficeAutomation_Document_ITBuy_Unit3]"
                                                        + "           ,[OfficeAutomation_Document_ITBuy_ReasonTypeID]"
                                                        + "           ,[OfficeAutomation_Document_ITBuy_Reason]"
                                                        + "           ,[OfficeAutomation_Document_ITBuy_ScrapURL])"
                                                        + "     VALUES"
                                                        + "           (@guidOfficeAutomation_Document_ITBuy_ID"
                                                        + "           ,@guidOfficeAutomation_Document_ITBuy_MainID"
                                                        + "           ,@sOfficeAutomation_Document_ITBuy_Department"
                                                        + "           ,@sOfficeAutomation_Document_ITBuy_ApplyID"
                                                        + "           ,@sOfficeAutomation_Document_ITBuy_Apply"
                                                        + "           ,@dtOfficeAutomation_Document_ITBuy_ApplyDate"
                                                        + "           ,@sOfficeAutomation_Document_ITBuy_ReplyPhone"
                                                        + "           ,@sOfficeAutomation_Document_ITBuy_Buy1"
                                                        + "           ,@sOfficeAutomation_Document_ITBuy_Unit1"
                                                        + "           ,@sOfficeAutomation_Document_ITBuy_Buy2"
                                                        + "           ,@sOfficeAutomation_Document_ITBuy_Unit2"
                                                        + "           ,@sOfficeAutomation_Document_ITBuy_Buy3"
                                                        + "           ,@sOfficeAutomation_Document_ITBuy_Unit3"
                                                        + "           ,@iOfficeAutomation_Document_ITBuy_ReasonTypeID"
                                                        + "           ,@sOfficeAutomation_Document_ITBuy_Reason"
                                                        + "           ,@sOfficeAutomation_Document_ITBuy_ScrapURL)";  

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_ITBuy)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_ITBuy_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITBuy_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_ITBuy_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITBuy_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITBuy_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITBuy_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITBuy_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITBuy_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITBuy_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITBuy_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_ITBuy_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITBuy_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITBuy_ReplyPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITBuy_ReplyPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITBuy_Buy1", SqlDbType.NVarChar, 240, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITBuy_Buy1));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITBuy_Unit1", SqlDbType.NVarChar, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITBuy_Unit1));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITBuy_Buy2", SqlDbType.NVarChar, 240, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITBuy_Buy2));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITBuy_Unit2", SqlDbType.NVarChar, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITBuy_Unit2));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITBuy_Buy3", SqlDbType.NVarChar, 240, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITBuy_Buy3));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITBuy_Unit3", SqlDbType.NVarChar, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITBuy_Unit3));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Document_ITBuy_ReasonTypeID", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITBuy_ReasonTypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITBuy_Reason", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITBuy_Reason));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITBuy_ScrapURL", SqlDbType.NVarChar, 160, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITBuy_ScrapURL));
     
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
            cmdToExecute.CommandText = "dbo.[pr_ITBuy_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ITBuy]"
                                                        + "   SET   [OfficeAutomation_Document_ITBuy_Department]=@sOfficeAutomation_Document_ITBuy_Department"
                                                        + "           ,[OfficeAutomation_Document_ITBuy_ApplyID]=@sOfficeAutomation_Document_ITBuy_ApplyID"
                                                        + "           ,[OfficeAutomation_Document_ITBuy_ReplyPhone]=@sOfficeAutomation_Document_ITBuy_ReplyPhone"
                                                        + "           ,[OfficeAutomation_Document_ITBuy_Buy1]=@sOfficeAutomation_Document_ITBuy_Buy1"
                                                        + "           ,[OfficeAutomation_Document_ITBuy_Unit1]=@sOfficeAutomation_Document_ITBuy_Unit1"
                                                        + "           ,[OfficeAutomation_Document_ITBuy_Buy2]=@sOfficeAutomation_Document_ITBuy_Buy2"
                                                        + "           ,[OfficeAutomation_Document_ITBuy_Unit2]=@sOfficeAutomation_Document_ITBuy_Unit2"
                                                        + "           ,[OfficeAutomation_Document_ITBuy_Buy3]=@sOfficeAutomation_Document_ITBuy_Buy3"
                                                        + "           ,[OfficeAutomation_Document_ITBuy_Unit3]=@sOfficeAutomation_Document_ITBuy_Unit3"
                                                        + "           ,[OfficeAutomation_Document_ITBuy_ReasonTypeID]=@iOfficeAutomation_Document_ITBuy_ReasonTypeID"
                                                        + "           ,[OfficeAutomation_Document_ITBuy_Reason]=@sOfficeAutomation_Document_ITBuy_Reason"
                                                        + "           ,[OfficeAutomation_Document_ITBuy_ScrapURL]=@sOfficeAutomation_Document_ITBuy_ScrapURL"
                                + " WHERE [OfficeAutomation_Document_ITBuy_ID]=@guidOfficeAutomation_Document_ITBuy_ID"
                                + "     AND [OfficeAutomation_Document_ITBuy_MainID] = @guidOfficeAutomation_Document_ITBuy_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_ITBuy)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITBuy_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITBuy_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITBuy_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITBuy_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITBuy_ReplyPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITBuy_ReplyPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITBuy_Buy1", SqlDbType.NVarChar, 240, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITBuy_Buy1));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITBuy_Unit1", SqlDbType.NVarChar, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITBuy_Unit1));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITBuy_Buy2", SqlDbType.NVarChar, 240, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITBuy_Buy2));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITBuy_Unit2", SqlDbType.NVarChar, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITBuy_Unit2));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITBuy_Buy3", SqlDbType.NVarChar, 240, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITBuy_Buy3));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITBuy_Unit3", SqlDbType.NVarChar, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITBuy_Unit3));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Document_ITBuy_ReasonTypeID", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITBuy_ReasonTypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITBuy_Reason", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITBuy_Reason));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITBuy_ScrapURL", SqlDbType.NVarChar, 160, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITBuy_ScrapURL));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_ITBuy_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITBuy_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_ITBuy_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITBuy_MainID));

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

    public class DA_Dic_OfficeAutomation_ITBuyReasonType_Operate : SqlInteractionBase
    {
        public override DataSet SelectAll()
        {
            string sql = "SELECT [OfficeAutomation_ITBuyReasonType_ID]"
                            + "         ,[OfficeAutomation_ITBuyReasonType_Name]"
                            + "  FROM [DB_EcOfficeAutomation].[dbo].[t_Dic_OfficeAutomation_ITBuyReasonType]";

            return RunSQL(sql);
        }
    }
}
