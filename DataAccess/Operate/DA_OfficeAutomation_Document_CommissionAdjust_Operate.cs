using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_CommissionAdjust_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_CommissionAdjust _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_CommissionAdjust]"
                                                        + "           ([OfficeAutomation_Document_CommissionAdjust_ID]"
                                                        + "           ,[OfficeAutomation_Document_CommissionAdjust_MainID]"
                                                        + "           ,[OfficeAutomation_Document_CommissionAdjust_Apply]"
                                                        + "           ,[OfficeAutomation_Document_CommissionAdjust_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_CommissionAdjust_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_CommissionAdjust_Department]"
                                                        + "           ,[OfficeAutomation_Document_CommissionAdjust_ReplyPhone]"
                                                        + "           ,[OfficeAutomation_Document_CommissionAdjust_IsLawE]"
                                                        + "           ,[OfficeAutomation_Document_CommissionAdjust_Building]"
                                                        + "           ,[OfficeAutomation_Document_CommissionAdjust_BadCommDate]"
                                                        + "           ,[OfficeAutomation_Document_CommissionAdjust_Property]"
                                                        + "           ,[OfficeAutomation_Document_CommissionAdjust_Controler]"
                                                        + "           ,[OfficeAutomation_Document_CommissionAdjust_PropertyID]"
                                                        + "           ,[OfficeAutomation_Document_CommissionAdjust_PropertyDate]"
                                                        + "           ,[OfficeAutomation_Document_CommissionAdjust_OldDeal]"
                                                        + "           ,[OfficeAutomation_Document_CommissionAdjust_NewDeal]"
                                                        + "           ,[OfficeAutomation_Document_CommissionAdjust_AjustDeal]"
                                                        + "           ,[OfficeAutomation_Document_CommissionAdjust_ShouldComm]"
                                                        + "           ,[OfficeAutomation_Document_CommissionAdjust_ActualComm]"
                                                        + "           ,[OfficeAutomation_Document_CommissionAdjust_AjustComm]"
                                                        + "           ,[OfficeAutomation_Document_CommissionAdjust_LeadReason]"
                                                        + "           ,[OfficeAutomation_Document_CommissionAdjust_Commitment]"
                                                        + "           ,[OfficeAutomation_Document_CommissionAdjust_SumShouldComm]"
                                                        + "           ,[OfficeAutomation_Document_CommissionAdjust_SumAjustComm]"

                                                        + "           ,[OfficeAutomation_Document_CommissionAdjust_SumOldDeal]"
                                                       + "           ,[OfficeAutomation_Document_CommissionAdjust_SumNewDeal]"
                                                       + "           ,[OfficeAutomation_Document_CommissionAdjust_SumAjustDeal]"
                                                       + "           ,[OfficeAutomation_Document_CommissionAdjust_SumActualComm]"
                                                          + "           ,[OfficeAutomation_Document_CommissionAdjust_Sign]"
                                                        + "           ,[OfficeAutomation_Document_CommissionAdjust_Reason])"
                                                        + "     VALUES"
                                                        + "           (@sOfficeAutomation_Document_CommissionAdjust_ID"
                                                        + "           ,@sOfficeAutomation_Document_CommissionAdjust_MainID"
                                                        + "           ,@sOfficeAutomation_Document_CommissionAdjust_Apply"
                                                        + "           ,@sOfficeAutomation_Document_CommissionAdjust_ApplyDate"
                                                        + "           ,@sOfficeAutomation_Document_CommissionAdjust_ApplyID"
                                                        + "           ,@sOfficeAutomation_Document_CommissionAdjust_Department"
                                                        + "           ,@sOfficeAutomation_Document_CommissionAdjust_ReplyPhone"
                                                        + "           ,@sOfficeAutomation_Document_CommissionAdjust_IsLawE"
                                                        + "           ,@sOfficeAutomation_Document_CommissionAdjust_Building"
                                                        + "           ,@sOfficeAutomation_Document_CommissionAdjust_BadCommDate"
                                                        + "           ,@sOfficeAutomation_Document_CommissionAdjust_Property"
                                                        + "           ,@sOfficeAutomation_Document_CommissionAdjust_Controler"
                                                        + "           ,@sOfficeAutomation_Document_CommissionAdjust_PropertyID"
                                                        + "           ,@sOfficeAutomation_Document_CommissionAdjust_PropertyDate"
                                                        + "           ,@sOfficeAutomation_Document_CommissionAdjust_OldDeal"
                                                        + "           ,@sOfficeAutomation_Document_CommissionAdjust_NewDeal"
                                                        + "           ,@sOfficeAutomation_Document_CommissionAdjust_AjustDeal"
                                                        + "           ,@sOfficeAutomation_Document_CommissionAdjust_ShouldComm"
                                                        + "           ,@sOfficeAutomation_Document_CommissionAdjust_ActualComm"
                                                        + "           ,@sOfficeAutomation_Document_CommissionAdjust_AjustComm"
                                                        + "           ,@sOfficeAutomation_Document_CommissionAdjust_LeadReason"
                                                        + "           ,@sOfficeAutomation_Document_CommissionAdjust_Commitment"
                                                        + "           ,@sOfficeAutomation_Document_CommissionAdjust_SumShouldComm"
                                                        + "           ,@sOfficeAutomation_Document_CommissionAdjust_SumAjustComm"

                                                        + "           ,@OfficeAutomation_Document_CommissionAdjust_SumOldDeal"
                                                        + "           ,@OfficeAutomation_Document_CommissionAdjust_SumNewDeal"
                                                        + "           ,@OfficeAutomation_Document_CommissionAdjust_SumAjustDeal"
                                                        + "           ,@OfficeAutomation_Document_CommissionAdjust_SumActualComm"
                                                        + "           ,@sOfficeAutomation_Document_CommissionAdjust_Sign"
                                                        + "           ,@sOfficeAutomation_Document_CommissionAdjust_Reason)";



            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_CommissionAdjust)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_ReplyPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_ReplyPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_IsLawE", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_IsLawE));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Building", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Building));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_BadCommDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_BadCommDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Property", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Property));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Controler", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Controler));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_PropertyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_PropertyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_PropertyDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_PropertyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_OldDeal", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_OldDeal));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_NewDeal", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_NewDeal));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_AjustDeal", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_AjustDeal));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_ShouldComm", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_ShouldComm));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_ActualComm", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_ActualComm));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_AjustComm", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_AjustComm));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_LeadReason", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_LeadReason));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Commitment", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Commitment));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_SumShouldComm", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_SumShouldComm));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_SumAjustComm", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_SumAjustComm));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionAdjust_SumOldDeal", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_SumOldDeal));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionAdjust_SumNewDeal", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_SumNewDeal));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionAdjust_SumAjustDeal", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_SumAjustDeal));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionAdjust_SumActualComm", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_SumActualComm));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Sign", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Sign));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Reason", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Reason));

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
            cmdToExecute.CommandText = "dbo.[pr_CommissionAdjust_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_CommissionAdjust]"
                                                        + "     SET   [OfficeAutomation_Document_CommissionAdjust_ApplyID]=@sOfficeAutomation_Document_CommissionAdjust_ApplyID"
                                                        + "            ,[OfficeAutomation_Document_CommissionAdjust_Department]=@sOfficeAutomation_Document_CommissionAdjust_Department"
                                                        + "            ,[OfficeAutomation_Document_CommissionAdjust_ReplyPhone]=@sOfficeAutomation_Document_CommissionAdjust_ReplyPhone"
                                                        + "            ,[OfficeAutomation_Document_CommissionAdjust_IsLawE]=@sOfficeAutomation_Document_CommissionAdjust_IsLawE"
                                                        + "            ,[OfficeAutomation_Document_CommissionAdjust_Building]=@sOfficeAutomation_Document_CommissionAdjust_Building"
                                                        + "            ,[OfficeAutomation_Document_CommissionAdjust_BadCommDate]=@sOfficeAutomation_Document_CommissionAdjust_BadCommDate"
                                                        + "            ,[OfficeAutomation_Document_CommissionAdjust_Property]=@sOfficeAutomation_Document_CommissionAdjust_Property"
                                                        + "            ,[OfficeAutomation_Document_CommissionAdjust_Controler]=@sOfficeAutomation_Document_CommissionAdjust_Controler"
                                                        + "            ,[OfficeAutomation_Document_CommissionAdjust_PropertyID]=@sOfficeAutomation_Document_CommissionAdjust_PropertyID"
                                                        + "            ,[OfficeAutomation_Document_CommissionAdjust_PropertyDate]=@sOfficeAutomation_Document_CommissionAdjust_PropertyDate"
                                                        + "            ,[OfficeAutomation_Document_CommissionAdjust_OldDeal]=@sOfficeAutomation_Document_CommissionAdjust_OldDeal"
                                                        + "            ,[OfficeAutomation_Document_CommissionAdjust_NewDeal]=@sOfficeAutomation_Document_CommissionAdjust_NewDeal"
                                                        + "            ,[OfficeAutomation_Document_CommissionAdjust_AjustDeal]=@sOfficeAutomation_Document_CommissionAdjust_AjustDeal"
                                                        + "            ,[OfficeAutomation_Document_CommissionAdjust_ShouldComm]=@sOfficeAutomation_Document_CommissionAdjust_ShouldComm"
                                                        + "            ,[OfficeAutomation_Document_CommissionAdjust_ActualComm]=@sOfficeAutomation_Document_CommissionAdjust_ActualComm"
                                                        + "            ,[OfficeAutomation_Document_CommissionAdjust_AjustComm]=@sOfficeAutomation_Document_CommissionAdjust_AjustComm"
                                                        + "            ,[OfficeAutomation_Document_CommissionAdjust_LeadReason]=@sOfficeAutomation_Document_CommissionAdjust_LeadReason"
                                                        + "            ,[OfficeAutomation_Document_CommissionAdjust_Commitment]=@sOfficeAutomation_Document_CommissionAdjust_Commitment"
                                                        + "            ,[OfficeAutomation_Document_CommissionAdjust_SumShouldComm]=@sOfficeAutomation_Document_CommissionAdjust_SumShouldComm"
                                                        + "            ,[OfficeAutomation_Document_CommissionAdjust_SumAjustComm]=@sOfficeAutomation_Document_CommissionAdjust_SumAjustComm"

                                                        + "            ,[OfficeAutomation_Document_CommissionAdjust_SumOldDeal]=@OfficeAutomation_Document_CommissionAdjust_SumOldDeal"
                                                        + "            ,[OfficeAutomation_Document_CommissionAdjust_SumNewDeal]=@OfficeAutomation_Document_CommissionAdjust_SumNewDeal"
                                                        + "            ,[OfficeAutomation_Document_CommissionAdjust_SumAjustDeal]=@OfficeAutomation_Document_CommissionAdjust_SumAjustDeal"
                                                        + "            ,[OfficeAutomation_Document_CommissionAdjust_SumActualComm]=@OfficeAutomation_Document_CommissionAdjust_SumActualComm"
                                                        + "            ,[OfficeAutomation_Document_CommissionAdjust_Sign]=@sOfficeAutomation_Document_CommissionAdjust_Sign"
                                                        + "            ,[OfficeAutomation_Document_CommissionAdjust_Reason]=@sOfficeAutomation_Document_CommissionAdjust_Reason"
                                                        + " WHERE [OfficeAutomation_Document_CommissionAdjust_ID]=@sOfficeAutomation_Document_CommissionAdjust_ID"
                                                        + "     AND [OfficeAutomation_Document_CommissionAdjust_MainID] = @sOfficeAutomation_Document_CommissionAdjust_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_CommissionAdjust)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_ReplyPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_ReplyPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_IsLawE", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_IsLawE));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Building", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Building));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_BadCommDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_BadCommDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Property", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Property));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Controler", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Controler));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_PropertyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_PropertyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_PropertyDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_PropertyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_OldDeal", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_OldDeal));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_NewDeal", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_NewDeal));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_AjustDeal", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_AjustDeal));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_ShouldComm", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_ShouldComm));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_ActualComm", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_ActualComm));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_AjustComm", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_AjustComm));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_LeadReason", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_LeadReason));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Commitment", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Commitment));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_SumShouldComm", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_SumShouldComm));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_SumAjustComm", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_SumAjustComm));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionAdjust_SumOldDeal", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_SumOldDeal));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionAdjust_SumNewDeal", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_SumNewDeal));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionAdjust_SumAjustDeal", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_SumAjustDeal));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionAdjust_SumActualComm", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_SumActualComm));

                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Sign", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Sign));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Reason", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Reason));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_MainID));

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
