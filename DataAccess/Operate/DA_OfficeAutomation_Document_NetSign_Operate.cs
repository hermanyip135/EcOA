using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_NetSign_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_NetSign _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_NetSign]"
                                                        + "           ([OfficeAutomation_Document_NetSign_ID]"
                                                        + "           ,[OfficeAutomation_Document_NetSign_MainID]"
                                                        + "           ,[OfficeAutomation_Document_NetSign_Apply]"
                                                        + "           ,[OfficeAutomation_Document_NetSign_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_NetSign_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_NetSign_Department]"
                                                        + "           ,[OfficeAutomation_Document_NetSign_KindOfApply]"
                                                        + "           ,[OfficeAutomation_Document_NetSign_HHManage]"
                                                        + "           ,[OfficeAutomation_Document_NetSign_BudingAddress]"
                                                        + "           ,[OfficeAutomation_Document_NetSign_TakeBranch]"
                                                        + "           ,[OfficeAutomation_Document_NetSign_ZYFollows]"
                                                        + "           ,[OfficeAutomation_Document_NetSign_SendBank]"
                                                        + "           ,[OfficeAutomation_Document_NetSign_Borrower]"
                                                        + "           ,[OfficeAutomation_Document_NetSign_Price]"
                                                        + "           ,[OfficeAutomation_Document_NetSign_DealPrice]"
                                                        + "           ,[OfficeAutomation_Document_NetSign_Loan]"
                                                        + "           ,[OfficeAutomation_Document_NetSign_Company1]"
                                                        + "           ,[OfficeAutomation_Document_NetSign_Assessment1]"
                                                        + "           ,[OfficeAutomation_Document_NetSign_Company2]"
                                                        + "           ,[OfficeAutomation_Document_NetSign_Assessment2]"
                                                        + "           ,[OfficeAutomation_Document_NetSign_Company3]"
                                                        + "           ,[OfficeAutomation_Document_NetSign_Assessment3]"
                                                        + "           ,[OfficeAutomation_Document_NetSign_Space]"
                                                        + "           ,[OfficeAutomation_Document_NetSign_Describe])"
                                                        + " VALUES"
                                                        + "           (@OfficeAutomation_Document_NetSign_ID"
                                                        + "           ,@OfficeAutomation_Document_NetSign_MainID"
                                                        + "           ,@OfficeAutomation_Document_NetSign_Apply"
                                                        + "           ,@OfficeAutomation_Document_NetSign_ApplyDate"
                                                        + "           ,@OfficeAutomation_Document_NetSign_ApplyID"
                                                        + "           ,@OfficeAutomation_Document_NetSign_Department"
                                                        + "           ,@OfficeAutomation_Document_NetSign_KindOfApply"
                                                        + "           ,@OfficeAutomation_Document_NetSign_HHManage"
                                                        + "           ,@OfficeAutomation_Document_NetSign_BudingAddress"
                                                        + "           ,@OfficeAutomation_Document_NetSign_TakeBranch"
                                                        + "           ,@OfficeAutomation_Document_NetSign_ZYFollows"
                                                        + "           ,@OfficeAutomation_Document_NetSign_SendBank"
                                                        + "           ,@OfficeAutomation_Document_NetSign_Borrower"
                                                        + "           ,@OfficeAutomation_Document_NetSign_Price"
                                                        + "           ,@OfficeAutomation_Document_NetSign_DealPrice"
                                                        + "           ,@OfficeAutomation_Document_NetSign_Loan"
                                                        + "           ,@OfficeAutomation_Document_NetSign_Company1"
                                                        + "           ,@OfficeAutomation_Document_NetSign_Assessment1"
                                                        + "           ,@OfficeAutomation_Document_NetSign_Company2"
                                                        + "           ,@OfficeAutomation_Document_NetSign_Assessment2"
                                                        + "           ,@OfficeAutomation_Document_NetSign_Company3"
                                                        + "           ,@OfficeAutomation_Document_NetSign_Assessment3"
                                                        + "           ,@OfficeAutomation_Document_NetSign_Space"
                                                        + "           ,@OfficeAutomation_Document_NetSign_Describe)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_NetSign)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_KindOfApply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_KindOfApply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_HHManage", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_HHManage));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_BudingAddress", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_BudingAddress));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_TakeBranch", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_TakeBranch));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_ZYFollows", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_ZYFollows));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_SendBank", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_SendBank));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_Borrower", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_Borrower));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_Price", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_Price));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_DealPrice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_DealPrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_Loan", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_Loan));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_Company1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_Company1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_Assessment1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_Assessment1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_Company2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_Company2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_Assessment2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_Assessment2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_Company3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_Company3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_Assessment3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_Assessment3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_Space", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_Space));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_Describe", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_Describe));

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
            cmdToExecute.CommandText = "dbo.[pr_NetSign_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_NetSign]"
                                + "         SET [OfficeAutomation_Document_NetSign_ApplyID] = @OfficeAutomation_Document_NetSign_ApplyID"
                                + "         ,[OfficeAutomation_Document_NetSign_Department] = @OfficeAutomation_Document_NetSign_Department"
                                + "         ,[OfficeAutomation_Document_NetSign_KindOfApply] = @OfficeAutomation_Document_NetSign_KindOfApply"
                                + "         ,[OfficeAutomation_Document_NetSign_HHManage] = @OfficeAutomation_Document_NetSign_HHManage"
                                + "         ,[OfficeAutomation_Document_NetSign_BudingAddress] = @OfficeAutomation_Document_NetSign_BudingAddress"
                                + "         ,[OfficeAutomation_Document_NetSign_TakeBranch] = @OfficeAutomation_Document_NetSign_TakeBranch"
                                + "         ,[OfficeAutomation_Document_NetSign_ZYFollows] = @OfficeAutomation_Document_NetSign_ZYFollows"
                                + "         ,[OfficeAutomation_Document_NetSign_SendBank] = @OfficeAutomation_Document_NetSign_SendBank"
                                + "         ,[OfficeAutomation_Document_NetSign_Borrower] = @OfficeAutomation_Document_NetSign_Borrower"
                                + "         ,[OfficeAutomation_Document_NetSign_Price] = @OfficeAutomation_Document_NetSign_Price"
                                + "         ,[OfficeAutomation_Document_NetSign_DealPrice] = @OfficeAutomation_Document_NetSign_DealPrice"
                                + "         ,[OfficeAutomation_Document_NetSign_Loan] = @OfficeAutomation_Document_NetSign_Loan"
                                + "         ,[OfficeAutomation_Document_NetSign_Company1] = @OfficeAutomation_Document_NetSign_Company1"
                                + "         ,[OfficeAutomation_Document_NetSign_Assessment1] = @OfficeAutomation_Document_NetSign_Assessment1"
                                + "         ,[OfficeAutomation_Document_NetSign_Company2] = @OfficeAutomation_Document_NetSign_Company2"
                                + "         ,[OfficeAutomation_Document_NetSign_Assessment2] = @OfficeAutomation_Document_NetSign_Assessment2"
                                + "         ,[OfficeAutomation_Document_NetSign_Company3] = @OfficeAutomation_Document_NetSign_Company3"
                                + "         ,[OfficeAutomation_Document_NetSign_Assessment3] = @OfficeAutomation_Document_NetSign_Assessment3"
                                + "         ,[OfficeAutomation_Document_NetSign_Describe] = @OfficeAutomation_Document_NetSign_Describe"
                                + "         ,[OfficeAutomation_Document_NetSign_Space] = @OfficeAutomation_Document_NetSign_Space"
                                + "         WHERE [OfficeAutomation_Document_NetSign_ID]=@OfficeAutomation_Document_NetSign_ID"
                                + "         AND [OfficeAutomation_Document_NetSign_MainID]=@OfficeAutomation_Document_NetSign_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_NetSign)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_KindOfApply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_KindOfApply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_HHManage", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_HHManage));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_BudingAddress", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_BudingAddress));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_TakeBranch", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_TakeBranch));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_ZYFollows", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_ZYFollows));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_SendBank", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_SendBank));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_Borrower", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_Borrower));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_Price", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_Price));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_DealPrice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_DealPrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_Loan", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_Loan));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_Company1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_Company1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_Assessment1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_Assessment1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_Company2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_Company2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_Assessment2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_Assessment2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_Company3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_Company3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_Assessment3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_Assessment3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_Describe", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_Describe));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_Space", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_Space));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NetSign_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NetSign_MainID));

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
