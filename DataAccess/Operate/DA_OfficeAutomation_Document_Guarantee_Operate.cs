using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Guarantee_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_Guarantee _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Guarantee]"
                                                        + "           ([OfficeAutomation_Document_Guarantee_ID]"
                                                        + "           ,[OfficeAutomation_Document_Guarantee_MainID]"
                                                        + "           ,[OfficeAutomation_Document_Guarantee_Apply]"
                                                        + "           ,[OfficeAutomation_Document_Guarantee_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_Guarantee_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_Guarantee_Department]"
                                                        + "           ,[OfficeAutomation_Document_Guarantee_ReceiveDP]"
                                                        + "           ,[OfficeAutomation_Document_Guarantee_CCDepartment]"
                                                        + "           ,[OfficeAutomation_Document_Guarantee_Telephone]"
                                                        + "           ,[OfficeAutomation_Document_Guarantee_Fax]"
                                                        + "           ,[OfficeAutomation_Document_Guarantee_Subject]"
                                                        + "           ,[OfficeAutomation_Document_Guarantee_CaseNo]"
                                                        + "           ,[OfficeAutomation_Document_Guarantee_Dealer]"
                                                        + "           ,[OfficeAutomation_Document_Guarantee_Address]"
                                                        + "           ,[OfficeAutomation_Document_Guarantee_Owner]"
                                                        + "           ,[OfficeAutomation_Document_Guarantee_Buyer]"
                                                        + "           ,[OfficeAutomation_Document_Guarantee_LoanBank]"
                                                        + "           ,[OfficeAutomation_Document_Guarantee_Cmoney]"
                                                        + "           ,[OfficeAutomation_Document_Guarantee_Lmoney]"
                                                        + "           ,[OfficeAutomation_Document_Guarantee_Dmoney]"
                                                        + "           ,[OfficeAutomation_Document_Guarantee_Reason]"
                                                        + "           ,[OfficeAutomation_Document_Guarantee_CMPaier]"
                                                        + "           ,[OfficeAutomation_Document_Guarantee_Ccoast]"
                                                        + "           ,[OfficeAutomation_Document_Guarantee_Process]"
                                                        + "           ,[OfficeAutomation_Document_Guarantee_Period])"
                                                        + " VALUES"
                                                        + "           (@OfficeAutomation_Document_Guarantee_ID"
                                                        + "           ,@OfficeAutomation_Document_Guarantee_MainID"
                                                        + "           ,@OfficeAutomation_Document_Guarantee_Apply"
                                                        + "           ,@OfficeAutomation_Document_Guarantee_ApplyDate"
                                                        + "           ,@OfficeAutomation_Document_Guarantee_ApplyID"
                                                        + "           ,@OfficeAutomation_Document_Guarantee_Department"
                                                        + "           ,@OfficeAutomation_Document_Guarantee_ReceiveDP"
                                                        + "           ,@OfficeAutomation_Document_Guarantee_CCDepartment"
                                                        + "           ,@OfficeAutomation_Document_Guarantee_Telephone"
                                                        + "           ,@OfficeAutomation_Document_Guarantee_Fax"
                                                        + "           ,@OfficeAutomation_Document_Guarantee_Subject"
                                                        + "           ,@OfficeAutomation_Document_Guarantee_CaseNo"
                                                        + "           ,@OfficeAutomation_Document_Guarantee_Dealer"
                                                        + "           ,@OfficeAutomation_Document_Guarantee_Address"
                                                        + "           ,@OfficeAutomation_Document_Guarantee_Owner"
                                                        + "           ,@OfficeAutomation_Document_Guarantee_Buyer"
                                                        + "           ,@OfficeAutomation_Document_Guarantee_LoanBank"
                                                        + "           ,@OfficeAutomation_Document_Guarantee_Cmoney"
                                                        + "           ,@OfficeAutomation_Document_Guarantee_Lmoney"
                                                        + "           ,@OfficeAutomation_Document_Guarantee_Dmoney"
                                                        + "           ,@OfficeAutomation_Document_Guarantee_Reason"
                                                        + "           ,@OfficeAutomation_Document_Guarantee_CMPaier"
                                                        + "           ,@OfficeAutomation_Document_Guarantee_Ccoast"
                                                        + "           ,@OfficeAutomation_Document_Guarantee_Process"
                                                        + "           ,@OfficeAutomation_Document_Guarantee_Period)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_Guarantee)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_Department));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_ReceiveDP", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_ReceiveDP));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_CCDepartment", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_CCDepartment));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_Telephone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_Telephone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_Fax", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_Fax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_Subject", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_Subject));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_CaseNo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_CaseNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_Dealer", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_Dealer));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_Address", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_Address));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_Owner", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_Owner));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_Buyer", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_Buyer));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_LoanBank", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_LoanBank));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_Cmoney", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_Cmoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_Lmoney", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_Lmoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_Dmoney", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_Dmoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_Reason", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_Reason));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_CMPaier", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_CMPaier));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_Ccoast", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_Ccoast));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_Process", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_Process));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_Period", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_Period));

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
            cmdToExecute.CommandText = "dbo.[pr_Guarantee_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Guarantee]"
                                + "         SET [OfficeAutomation_Document_Guarantee_ApplyID] = @OfficeAutomation_Document_Guarantee_ApplyID"
                                + "         ,[OfficeAutomation_Document_Guarantee_Department] = @OfficeAutomation_Document_Guarantee_Department"
                                + "         ,[OfficeAutomation_Document_Guarantee_ReceiveDP] = @OfficeAutomation_Document_Guarantee_ReceiveDP"
                                + "         ,[OfficeAutomation_Document_Guarantee_CCDepartment] = @OfficeAutomation_Document_Guarantee_CCDepartment"
                                + "         ,[OfficeAutomation_Document_Guarantee_Telephone] = @OfficeAutomation_Document_Guarantee_Telephone"
                                + "         ,[OfficeAutomation_Document_Guarantee_Fax] = @OfficeAutomation_Document_Guarantee_Fax"
                                + "         ,[OfficeAutomation_Document_Guarantee_Subject] = @OfficeAutomation_Document_Guarantee_Subject"
                                + "         ,[OfficeAutomation_Document_Guarantee_CaseNo] = @OfficeAutomation_Document_Guarantee_CaseNo"
                                + "         ,[OfficeAutomation_Document_Guarantee_Dealer] = @OfficeAutomation_Document_Guarantee_Dealer"
                                + "         ,[OfficeAutomation_Document_Guarantee_Address] = @OfficeAutomation_Document_Guarantee_Address"
                                + "         ,[OfficeAutomation_Document_Guarantee_Owner] = @OfficeAutomation_Document_Guarantee_Owner"
                                + "         ,[OfficeAutomation_Document_Guarantee_Buyer] = @OfficeAutomation_Document_Guarantee_Buyer"
                                + "         ,[OfficeAutomation_Document_Guarantee_LoanBank] = @OfficeAutomation_Document_Guarantee_LoanBank"
                                + "         ,[OfficeAutomation_Document_Guarantee_Cmoney] = @OfficeAutomation_Document_Guarantee_Cmoney"
                                + "         ,[OfficeAutomation_Document_Guarantee_Lmoney] = @OfficeAutomation_Document_Guarantee_Lmoney"
                                + "         ,[OfficeAutomation_Document_Guarantee_Dmoney] = @OfficeAutomation_Document_Guarantee_Dmoney"
                                + "         ,[OfficeAutomation_Document_Guarantee_Reason] = @OfficeAutomation_Document_Guarantee_Reason"
                                + "         ,[OfficeAutomation_Document_Guarantee_CMPaier] = @OfficeAutomation_Document_Guarantee_CMPaier"
                                + "         ,[OfficeAutomation_Document_Guarantee_Ccoast] = @OfficeAutomation_Document_Guarantee_Ccoast"
                                + "         ,[OfficeAutomation_Document_Guarantee_Process] = @OfficeAutomation_Document_Guarantee_Process"
                                + "         ,[OfficeAutomation_Document_Guarantee_Period] = @OfficeAutomation_Document_Guarantee_Period"
                                + "         WHERE [OfficeAutomation_Document_Guarantee_ID]=@OfficeAutomation_Document_Guarantee_ID"
                                + "         AND [OfficeAutomation_Document_Guarantee_MainID]=@OfficeAutomation_Document_Guarantee_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_Guarantee)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_ReceiveDP", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_ReceiveDP));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_CCDepartment", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_CCDepartment));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_Telephone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_Telephone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_Fax", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_Fax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_Subject", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_Subject));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_CaseNo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_CaseNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_Dealer", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_Dealer));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_Address", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_Address));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_Owner", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_Owner));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_Buyer", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_Buyer));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_LoanBank", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_LoanBank));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_Cmoney", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_Cmoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_Lmoney", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_Lmoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_Dmoney", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_Dmoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_Reason", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_Reason));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_CMPaier", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_CMPaier));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_Ccoast", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_Ccoast));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_Process", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_Process));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_Period", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_Period));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Guarantee_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Guarantee_MainID));

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
