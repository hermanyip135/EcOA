using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_ProjBaComm_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_ProjBaComm _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ProjBaComm]"
                                                        + "           ([OfficeAutomation_Document_ProjBaComm_ID]"
                                                        + "           ,[OfficeAutomation_Document_ProjBaComm_MainID]"
                                                        + "           ,[OfficeAutomation_Document_ProjBaComm_Apply]"
                                                        + "           ,[OfficeAutomation_Document_ProjBaComm_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_ProjBaComm_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_ProjBaComm_Department]"
                                                        + "           ,[OfficeAutomation_Document_ProjBaComm_ReplyPhone]"
                                                        + "           ,[OfficeAutomation_Document_ProjBaComm_Building]"
                                                        + "           ,[OfficeAutomation_Document_ProjBaComm_Reason]"
                                                        + "           ,[OfficeAutomation_Document_ProjBaComm_MoneyCount]"
                                                        + "           ,[OfficeAutomation_Document_ProjBaComm_TurnBack]"
                                                        + "           ,[OfficeAutomation_Document_ProjBaComm_BDeveloper]"
                                                        + "           ,[OfficeAutomation_Document_ProjBaComm_Measure])"
                                                        + "     VALUES"
                                                        + "           (@guidOfficeAutomation_Document_ProjBaComm_ID"
                                                        + "           ,@guidOfficeAutomation_Document_ProjBaComm_MainID"
                                                        + "           ,@sOfficeAutomation_Document_ProjBaComm_Apply"
                                                        + "           ,@dtOfficeAutomation_Document_ProjBaComm_ApplyDate"
                                                        + "           ,@sOfficeAutomation_Document_ProjBaComm_ApplyID"
                                                        + "           ,@sOfficeAutomation_Document_ProjBaComm_Department"
                                                        + "           ,@sOfficeAutomation_Document_ProjBaComm_ReplyPhone"
                                                        + "           ,@sOfficeAutomation_Document_ProjBaComm_Building"
                                                        + "           ,@sOfficeAutomation_Document_ProjBaComm_Reason"
                                                        + "           ,@dcmOfficeAutomation_Document_ProjBaComm_MoneyCount"
                                                        + "           ,@OfficeAutomation_Document_ProjBaComm_TurnBack"
                                                        + "           ,@OfficeAutomation_Document_ProjBaComm_BDeveloper"
                                                        + "           ,@sOfficeAutomation_Document_ProjBaComm_Measure)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_ProjBaComm)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_ProjBaComm_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjBaComm_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_ProjBaComm_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjBaComm_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ProjBaComm_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjBaComm_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_ProjBaComm_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjBaComm_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ProjBaComm_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjBaComm_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ProjBaComm_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjBaComm_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ProjBaComm_ReplyPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjBaComm_ReplyPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ProjBaComm_Building", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjBaComm_Building));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ProjBaComm_Reason", SqlDbType.NVarChar, System.Int32.MaxValue, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjBaComm_Reason));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcmOfficeAutomation_Document_ProjBaComm_MoneyCount", SqlDbType.Decimal, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjBaComm_MoneyCount));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ProjBaComm_TurnBack", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjBaComm_TurnBack));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ProjBaComm_BDeveloper", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjBaComm_BDeveloper));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ProjBaComm_Measure", SqlDbType.NVarChar, System.Int32.MaxValue, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjBaComm_Measure));

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
            cmdToExecute.CommandText = "dbo.[pr_ProjBaComm_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ProjBaComm]"
                                                        + "     SET  [OfficeAutomation_Document_ProjBaComm_ApplyID]=@sOfficeAutomation_Document_ProjBaComm_ApplyID"
                                                        + "            ,[OfficeAutomation_Document_ProjBaComm_Department]=@sOfficeAutomation_Document_ProjBaComm_Department"
                                                        + "            ,[OfficeAutomation_Document_ProjBaComm_ReplyPhone]=@sOfficeAutomation_Document_ProjBaComm_ReplyPhone"
                                                        + "            ,[OfficeAutomation_Document_ProjBaComm_Building]=@sOfficeAutomation_Document_ProjBaComm_Building"
                                                        + "            ,[OfficeAutomation_Document_ProjBaComm_Reason]=@sOfficeAutomation_Document_ProjBaComm_Reason"
                                                        + "            ,[OfficeAutomation_Document_ProjBaComm_MoneyCount]=@dcmOfficeAutomation_Document_ProjBaComm_MoneyCount"
                                                        + "            ,[OfficeAutomation_Document_ProjBaComm_TurnBack]=@OfficeAutomation_Document_ProjBaComm_TurnBack"
                                                        + "            ,[OfficeAutomation_Document_ProjBaComm_BDeveloper]=@OfficeAutomation_Document_ProjBaComm_BDeveloper"
                                                        + "            ,[OfficeAutomation_Document_ProjBaComm_Measure]=@sOfficeAutomation_Document_ProjBaComm_Measure"
                                                        + " WHERE [OfficeAutomation_Document_ProjBaComm_ID]=@guidOfficeAutomation_Document_ProjBaComm_ID"
                                                        + "     AND [OfficeAutomation_Document_ProjBaComm_MainID] = @guidOfficeAutomation_Document_ProjBaComm_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_ProjBaComm)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ProjBaComm_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjBaComm_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ProjBaComm_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjBaComm_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ProjBaComm_ReplyPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjBaComm_ReplyPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ProjBaComm_Building", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjBaComm_Building));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ProjBaComm_Reason", SqlDbType.NVarChar, System.Int32.MaxValue, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjBaComm_Reason));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcmOfficeAutomation_Document_ProjBaComm_MoneyCount", SqlDbType.Decimal, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjBaComm_MoneyCount));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ProjBaComm_TurnBack", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjBaComm_TurnBack));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ProjBaComm_BDeveloper", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjBaComm_BDeveloper));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ProjBaComm_Measure", SqlDbType.NVarChar, System.Int32.MaxValue, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjBaComm_Measure));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_ProjBaComm_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjBaComm_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_ProjBaComm_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ProjBaComm_MainID));

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
