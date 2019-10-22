using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_SignedG_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_SignedG _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SignedG]"
                                                        + "           ([OfficeAutomation_Document_SignedG_ID]"
                                                        + "           ,[OfficeAutomation_Document_SignedG_MainID]"
                                                        + "           ,[OfficeAutomation_Document_SignedG_Apply]"
                                                        + "           ,[OfficeAutomation_Document_SignedG_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_SignedG_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_SignedG_Department]"
                                                        + "           ,[OfficeAutomation_Document_SignedG_ReceiveDP]"
                                                        + "           ,[OfficeAutomation_Document_SignedG_CCDepartment]"
                                                        + "           ,[OfficeAutomation_Document_SignedG_Telephone]"
                                                        + "           ,[OfficeAutomation_Document_SignedG_Fax]"
                                                        + "           ,[OfficeAutomation_Document_SignedG_Subject]"
                                                        + "           ,[OfficeAutomation_Document_SignedG_CaseNo]"
                                                        + "           ,[OfficeAutomation_Document_SignedG_Dealer]"
                                                        + "           ,[OfficeAutomation_Document_SignedG_Address]"
                                                        + "           ,[OfficeAutomation_Document_SignedG_Owner]"
                                                        + "           ,[OfficeAutomation_Document_SignedG_Buyer]"
                                                        + "           ,[OfficeAutomation_Document_SignedG_LoanBank]"
                                                        + "           ,[OfficeAutomation_Document_SignedG_Lmoney]"
                                                        + "           ,[OfficeAutomation_Document_SignedG_Dmoney]"
                                                        + "           ,[OfficeAutomation_Document_SignedG_Cmoney]"
                                                        + "           ,[OfficeAutomation_Document_SignedG_Reason])"
                                                        + " VALUES"
                                                        + "           (@OfficeAutomation_Document_SignedG_ID"
                                                        + "           ,@OfficeAutomation_Document_SignedG_MainID"
                                                        + "           ,@OfficeAutomation_Document_SignedG_Apply"
                                                        + "           ,@OfficeAutomation_Document_SignedG_ApplyDate"
                                                        + "           ,@OfficeAutomation_Document_SignedG_ApplyID"
                                                        + "           ,@OfficeAutomation_Document_SignedG_Department"
                                                        + "           ,@OfficeAutomation_Document_SignedG_ReceiveDP"
                                                        + "           ,@OfficeAutomation_Document_SignedG_CCDepartment"
                                                        + "           ,@OfficeAutomation_Document_SignedG_Telephone"
                                                        + "           ,@OfficeAutomation_Document_SignedG_Fax"
                                                        + "           ,@OfficeAutomation_Document_SignedG_Subject"
                                                        + "           ,@OfficeAutomation_Document_SignedG_CaseNo"
                                                        + "           ,@OfficeAutomation_Document_SignedG_Dealer"
                                                        + "           ,@OfficeAutomation_Document_SignedG_Address"
                                                        + "           ,@OfficeAutomation_Document_SignedG_Owner"
                                                        + "           ,@OfficeAutomation_Document_SignedG_Buyer"
                                                        + "           ,@OfficeAutomation_Document_SignedG_LoanBank"
                                                        + "           ,@OfficeAutomation_Document_SignedG_Lmoney"
                                                        + "           ,@OfficeAutomation_Document_SignedG_Dmoney"
                                                        + "           ,@OfficeAutomation_Document_SignedG_Cmoney"
                                                        + "           ,@OfficeAutomation_Document_SignedG_Reason)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_SignedG)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SignedG_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SignedG_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SignedG_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SignedG_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SignedG_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SignedG_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SignedG_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SignedG_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SignedG_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SignedG_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SignedG_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SignedG_Department));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SignedG_ReceiveDP", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SignedG_ReceiveDP));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SignedG_CCDepartment", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SignedG_CCDepartment));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SignedG_Telephone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SignedG_Telephone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SignedG_Fax", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SignedG_Fax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SignedG_Subject", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SignedG_Subject));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SignedG_CaseNo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SignedG_CaseNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SignedG_Dealer", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SignedG_Dealer));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SignedG_Address", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SignedG_Address));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SignedG_Owner", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SignedG_Owner));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SignedG_Buyer", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SignedG_Buyer));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SignedG_LoanBank", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SignedG_LoanBank));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SignedG_Lmoney", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SignedG_Lmoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SignedG_Dmoney", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SignedG_Dmoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SignedG_Cmoney", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SignedG_Cmoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SignedG_Reason", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SignedG_Reason));

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
            cmdToExecute.CommandText = "dbo.[pr_SignedG_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SignedG]"
                                + "         SET [OfficeAutomation_Document_SignedG_ApplyID] = @OfficeAutomation_Document_SignedG_ApplyID"
                                + "         ,[OfficeAutomation_Document_SignedG_Department] = @OfficeAutomation_Document_SignedG_Department"
                                + "         ,[OfficeAutomation_Document_SignedG_ReceiveDP] = @OfficeAutomation_Document_SignedG_ReceiveDP"
                                + "         ,[OfficeAutomation_Document_SignedG_CCDepartment] = @OfficeAutomation_Document_SignedG_CCDepartment"
                                + "         ,[OfficeAutomation_Document_SignedG_Telephone] = @OfficeAutomation_Document_SignedG_Telephone"
                                + "         ,[OfficeAutomation_Document_SignedG_Fax] = @OfficeAutomation_Document_SignedG_Fax"
                                + "         ,[OfficeAutomation_Document_SignedG_Subject] = @OfficeAutomation_Document_SignedG_Subject"
                                + "         ,[OfficeAutomation_Document_SignedG_CaseNo] = @OfficeAutomation_Document_SignedG_CaseNo"
                                + "         ,[OfficeAutomation_Document_SignedG_Dealer] = @OfficeAutomation_Document_SignedG_Dealer"
                                + "         ,[OfficeAutomation_Document_SignedG_Address] = @OfficeAutomation_Document_SignedG_Address"
                                + "         ,[OfficeAutomation_Document_SignedG_Owner] = @OfficeAutomation_Document_SignedG_Owner"
                                + "         ,[OfficeAutomation_Document_SignedG_Buyer] = @OfficeAutomation_Document_SignedG_Buyer"
                                + "         ,[OfficeAutomation_Document_SignedG_LoanBank] = @OfficeAutomation_Document_SignedG_LoanBank"
                                + "         ,[OfficeAutomation_Document_SignedG_Lmoney] = @OfficeAutomation_Document_SignedG_Lmoney"
                                + "         ,[OfficeAutomation_Document_SignedG_Dmoney] = @OfficeAutomation_Document_SignedG_Dmoney"
                                + "         ,[OfficeAutomation_Document_SignedG_Cmoney] = @OfficeAutomation_Document_SignedG_Cmoney"
                                + "         ,[OfficeAutomation_Document_SignedG_Reason] = @OfficeAutomation_Document_SignedG_Reason"
                                + "         WHERE [OfficeAutomation_Document_SignedG_ID]=@OfficeAutomation_Document_SignedG_ID"
                                + "         AND [OfficeAutomation_Document_SignedG_MainID]=@OfficeAutomation_Document_SignedG_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_SignedG)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SignedG_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SignedG_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SignedG_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SignedG_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SignedG_ReceiveDP", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SignedG_ReceiveDP));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SignedG_CCDepartment", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SignedG_CCDepartment));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SignedG_Telephone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SignedG_Telephone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SignedG_Fax", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SignedG_Fax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SignedG_Subject", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SignedG_Subject));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SignedG_CaseNo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SignedG_CaseNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SignedG_Dealer", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SignedG_Dealer));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SignedG_Address", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SignedG_Address));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SignedG_Owner", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SignedG_Owner));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SignedG_Buyer", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SignedG_Buyer));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SignedG_LoanBank", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SignedG_LoanBank));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SignedG_Lmoney", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SignedG_Lmoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SignedG_Dmoney", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SignedG_Dmoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SignedG_Cmoney", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SignedG_Cmoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SignedG_Reason", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SignedG_Reason));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SignedG_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SignedG_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SignedG_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SignedG_MainID));

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
