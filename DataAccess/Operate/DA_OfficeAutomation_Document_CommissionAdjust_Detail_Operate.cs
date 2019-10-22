using System;
using System.Collections.Generic;
using System.Text;


using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_CommissionAdjust_Detail_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_CommissionAdjust_Detail _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_CommissionAdjust_Detail]"
                                                        + "           ([OfficeAutomation_Document_CommissionAdjust_Detail_ID]"
                                                        + "           ,[OfficeAutomation_Document_CommissionAdjust_Detail_MainID]"
                                                        + "           ,[OfficeAutomation_Document_CommissionAdjust_Detail_pNo]"
                                                        + "           ,[OfficeAutomation_Document_CommissionAdjust_Detail_Property]"
                                                        + "           ,[OfficeAutomation_Document_CommissionAdjust_Detail_Controler]"
                                                        + "           ,[OfficeAutomation_Document_CommissionAdjust_Detail_PropertyID]"
                                                        + "           ,[OfficeAutomation_Document_CommissionAdjust_Detail_PropertyDate]"
                                                        + "           ,[OfficeAutomation_Document_CommissionAdjust_Detail_OldDeal]"
                                                        + "           ,[OfficeAutomation_Document_CommissionAdjust_Detail_NewDeal]"
                                                        + "           ,[OfficeAutomation_Document_CommissionAdjust_Detail_AjustDeal]"
                                                        + "           ,[OfficeAutomation_Document_CommissionAdjust_Detail_ShouldComm]"
                                                        + "           ,[OfficeAutomation_Document_CommissionAdjust_Detail_ActualComm]"
                                                        + "           ,[OfficeAutomation_Document_CommissionAdjust_Detail_AjustComm]"
                                                        + "           ,[OfficeAutomation_Document_CommissionAdjust_Detail_LeadReason]"
                                                        + "           ,[OfficeAutomation_Document_CommissionAdjust_Detail_Cname]"
                                                        + "           ,[OfficeAutomation_Document_CommissionAdjust_Detail_Commitment]"
                                                        + "           ,[OfficeAutomation_Document_CommissionAdjust_Detail_Reason]"
                                                        + "           ,[OfficeAutomation_Document_CommissionAdjust_Detail_DealType]"
                                                        + "           ,[OfficeAutomation_Document_CommissionAdjust_Detail_ChangeType])"
                                                        + "     VALUES"
                                                        + "           (@sOfficeAutomation_Document_CommissionAdjust_Detail_ID"
                                                        + "           ,@sOfficeAutomation_Document_CommissionAdjust_Detail_MainID"
                                                        + "           ,@OfficeAutomation_Document_CommissionAdjust_Detail_pNo"
                                                        + "           ,@sOfficeAutomation_Document_CommissionAdjust_Detail_Property"
                                                        + "           ,@sOfficeAutomation_Document_CommissionAdjust_Detail_Controler"
                                                        + "           ,@sOfficeAutomation_Document_CommissionAdjust_Detail_PropertyID"
                                                        + "           ,@sOfficeAutomation_Document_CommissionAdjust_Detail_PropertyDate"
                                                        + "           ,@sOfficeAutomation_Document_CommissionAdjust_Detail_OldDeal"
                                                        + "           ,@sOfficeAutomation_Document_CommissionAdjust_Detail_NewDeal"
                                                        + "           ,@sOfficeAutomation_Document_CommissionAdjust_Detail_AjustDeal"
                                                        + "           ,@sOfficeAutomation_Document_CommissionAdjust_Detail_ShouldComm"
                                                        + "           ,@sOfficeAutomation_Document_CommissionAdjust_Detail_ActualComm"
                                                        + "           ,@sOfficeAutomation_Document_CommissionAdjust_Detail_AjustComm"
                                                        + "           ,@sOfficeAutomation_Document_CommissionAdjust_Detail_LeadReason"
                                                        + "           ,@OfficeAutomation_Document_CommissionAdjust_Detail_Cname"
                                                        + "           ,@sOfficeAutomation_Document_CommissionAdjust_Detail_Commitment"
                                                        + "           ,@sOfficeAutomation_Document_CommissionAdjust_Detail_Reason"
                                                        + "           ,@sOfficeAutomation_Document_CommissionAdjust_Detail_DealType"
                                                        + "           ,@sOfficeAutomation_Document_CommissionAdjust_Detail_ChangeType)";



            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_CommissionAdjust_Detail)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Detail_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Detail_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Detail_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Detail_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionAdjust_Detail_pNo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Detail_pNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Detail_Property", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Detail_Property));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Detail_Controler", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Detail_Controler));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Detail_PropertyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Detail_PropertyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Detail_PropertyDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Detail_PropertyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Detail_OldDeal", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Detail_OldDeal));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Detail_NewDeal", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Detail_NewDeal));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Detail_AjustDeal", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Detail_AjustDeal));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Detail_ShouldComm", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Detail_ShouldComm));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Detail_ActualComm", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Detail_ActualComm));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Detail_AjustComm", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Detail_AjustComm));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Detail_LeadReason", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Detail_LeadReason));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionAdjust_Detail_Cname", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Detail_Cname));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Detail_Commitment", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Detail_Commitment));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Detail_Reason", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Detail_Reason));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Detail_DealType", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Detail_DealType));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Detail_ChangeType", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Detail_ChangeType));

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

            cmdToExecute.CommandText = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_CommissionAdjust_Detail]"
                                + " WHERE [OfficeAutomation_Document_CommissionAdjust_Detail_MainID]=@sOfficeAutomation_Document_CommissionAdjust_Detail_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Detail_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, new Guid(mainID)));

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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_CommissionAdjust_Detail]"
                                                        + "     SET [OfficeAutomation_Document_CommissionAdjust_Detail_Property]=@sOfficeAutomation_Document_CommissionAdjust_Detail_Property"
                                                        + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_pNo]=@OfficeAutomation_Document_CommissionAdjust_Detail_pNo"
                                                        + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_Controler]=@sOfficeAutomation_Document_CommissionAdjust_Detail_Controler"
                                                        + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_PropertyID]=@sOfficeAutomation_Document_CommissionAdjust_Detail_PropertyID"
                                                        + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_PropertyDate]=@sOfficeAutomation_Document_CommissionAdjust_Detail_PropertyDate"
                                                        + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_OldDeal]=@sOfficeAutomation_Document_CommissionAdjust_Detail_OldDeal"
                                                        + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_NewDeal]=@sOfficeAutomation_Document_CommissionAdjust_Detail_NewDeal"
                                                        + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_AjustDeal]=@sOfficeAutomation_Document_CommissionAdjust_Detail_AjustDeal"
                                                        + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_ShouldComm]=@sOfficeAutomation_Document_CommissionAdjust_Detail_ShouldComm"
                                                        + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_ActualComm]=@sOfficeAutomation_Document_CommissionAdjust_Detail_ActualComm"
                                                        + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_AjustComm]=@sOfficeAutomation_Document_CommissionAdjust_Detail_AjustComm"
                                                        + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_LeadReason]=@sOfficeAutomation_Document_CommissionAdjust_Detail_LeadReason"
                                                        + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_Cname]=@OfficeAutomation_Document_CommissionAdjust_Detail_Cname"
                                                        + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_Commitment]=@sOfficeAutomation_Document_CommissionAdjust_Detail_Commitment"
                                                        + "            ,[OfficeAutomation_Document_CommissionAdjust_Detail_Reason]=@sOfficeAutomation_Document_CommissionAdjust_Detail_Reason"
                                                        + " WHERE [OfficeAutomation_Document_CommissionAdjust_Detail_ID]=@sOfficeAutomation_Document_CommissionAdjust_Detail_ID"
                                                        + "     AND [OfficeAutomation_Document_CommissionAdjust_Detail_MainID] = @sOfficeAutomation_Document_CommissionAdjust_Detail_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_CommissionAdjust_Detail)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Detail_Property", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Detail_Property));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionAdjust_Detail_pNo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Detail_pNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Detail_Controler", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Detail_Controler));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Detail_PropertyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Detail_PropertyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Detail_PropertyDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Detail_PropertyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Detail_OldDeal", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Detail_OldDeal));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Detail_NewDeal", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Detail_NewDeal));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Detail_AjustDeal", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Detail_AjustDeal));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Detail_ShouldComm", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Detail_ShouldComm));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Detail_ActualComm", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Detail_ActualComm));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Detail_AjustComm", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Detail_AjustComm));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Detail_LeadReason", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Detail_LeadReason));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionAdjust_Detail_Cname", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Detail_Cname));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Detail_Commitment", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Detail_Commitment));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Detail_Reason", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Detail_Reason));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Detail_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Detail_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_CommissionAdjust_Detail_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionAdjust_Detail_MainID));

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
