using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_SpecialCase_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_SpecialCase _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SpecialCase]"
                                                        + "           ([OfficeAutomation_Document_SpecialCase_ID]"
                                                        + "           ,[OfficeAutomation_Document_SpecialCase_MainID]"
                                                        + "           ,[OfficeAutomation_Document_SpecialCase_Apply]"
                                                        + "           ,[OfficeAutomation_Document_SpecialCase_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_SpecialCase_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_SpecialCase_Department]"
                                                        + "           ,[OfficeAutomation_Document_SpecialCase_BranchNo]"
                                                        + "           ,[OfficeAutomation_Document_SpecialCase_Phone]"
                                                        + "           ,[OfficeAutomation_Document_SpecialCase_FollowDepartment]"
                                                        + "           ,[OfficeAutomation_Document_SpecialCase_FollowSomebody]"
                                                        + "           ,[OfficeAutomation_Document_SpecialCase_Location]"
                                                        + "           ,[OfficeAutomation_Document_SpecialCase_Master]"
                                                        + "           ,[OfficeAutomation_Document_SpecialCase_Buyer]"
                                                        + "           ,[OfficeAutomation_Document_SpecialCase_Loan]"
                                                        + "           ,[OfficeAutomation_Document_SpecialCase_QuickPut]"
                                                        + "           ,[OfficeAutomation_Document_SpecialCase_GuaranteeCompany]"
                                                        + "           ,[OfficeAutomation_Document_SpecialCase_PayWay]"
                                                        + "           ,[OfficeAutomation_Document_SpecialCase_ApplyNo]"
                                                        + "           ,[OfficeAutomation_Document_SpecialCase_TimeoutApply]"
                                                        + "           ,[OfficeAutomation_Document_SpecialCase_ForPeople]"
                                                        + "           ,[OfficeAutomation_Document_SpecialCase_AutoHandle]"
                                                        + "           ,[OfficeAutomation_Document_SpecialCase_CaseRemark]"
                                                        + "           ,[OfficeAutomation_Document_SpecialCase_HousingTransactions]"
                                                        + "           ,[OfficeAutomation_Document_SpecialCase_DealWithProgress]"
                                                        + "           ,[OfficeAutomation_Document_SpecialCase_Midway]"
                                                        + "           ,[OfficeAutomation_Document_SpecialCase_PutUp]"
                                                        + "           ,[OfficeAutomation_Document_SpecialCase_AnotherPutUp]"
                                                        + "           ,[OfficeAutomation_Document_SpecialCase_4PointGuaranteeCompany]"
                                                        + "           ,[OfficeAutomation_Document_SpecialCase_CompanyEarnings]"
                                                        + "           ,[OfficeAutomation_Document_SpecialCase_EarningsAmount]"
                                                        + "           ,[OfficeAutomation_Document_SpecialCase_TheKindOfFormalities]"
                                                        + "           ,[OfficeAutomation_Document_SpecialCase_Certificate]"
                                                     //   + "           ,[OfficeAutomation_Document_SpecialCase_NotarialDeed]"
                                                   //     + "           ,[OfficeAutomation_Document_SpecialCase_CommissionedPersonnel]"
                                                   //     + "           ,[OfficeAutomation_Document_SpecialCase_Clause]"
                                                        + "           ,[OfficeAutomation_Document_SpecialCase_NotNeat]"
                                                        + "           ,[OfficeAutomation_Document_SpecialCase_JieFeeDate]"
                                                        + "           ,[OfficeAutomation_Document_SpecialCase_credit]"
                                                    //    + "           ,[OfficeAutomation_Document_SpecialCase_Another]"
                                                        + "           ,[OfficeAutomation_Document_SpecialCase_Situation]"
                                                        + "           ,[OfficeAutomation_Document_SpecialCase_BorrowDate]"
                                                        + "           ,[OfficeAutomation_Document_SpecialCase_BorrowS]"
                                                        + "           ,[OfficeAutomation_Document_SpecialCase_ReturnDate])"
                                                        + " VALUES"
                                                        + "           (@OfficeAutomation_Document_SpecialCase_ID"
                                                        + "           ,@OfficeAutomation_Document_SpecialCase_MainID"
                                                        + "           ,@OfficeAutomation_Document_SpecialCase_Apply"
                                                        + "           ,@OfficeAutomation_Document_SpecialCase_ApplyDate"
                                                        + "           ,@OfficeAutomation_Document_SpecialCase_ApplyID"
                                                        + "           ,@OfficeAutomation_Document_SpecialCase_Department"
                                                        + "           ,@OfficeAutomation_Document_SpecialCase_BranchNo"
                                                        + "           ,@OfficeAutomation_Document_SpecialCase_Phone"
                                                        + "           ,@OfficeAutomation_Document_SpecialCase_FollowDepartment"
                                                        + "           ,@OfficeAutomation_Document_SpecialCase_FollowSomebody"
                                                        + "           ,@OfficeAutomation_Document_SpecialCase_Location"
                                                        + "           ,@OfficeAutomation_Document_SpecialCase_Master"
                                                        + "           ,@OfficeAutomation_Document_SpecialCase_Buyer"
                                                        + "           ,@OfficeAutomation_Document_SpecialCase_Loan"
                                                        + "           ,@OfficeAutomation_Document_SpecialCase_QuickPut"
                                                        + "           ,@OfficeAutomation_Document_SpecialCase_GuaranteeCompany"
                                                        + "           ,@OfficeAutomation_Document_SpecialCase_PayWay"
                                                        + "           ,@OfficeAutomation_Document_SpecialCase_ApplyNo"
                                                        + "           ,@OfficeAutomation_Document_SpecialCase_TimeoutApply"
                                                        + "           ,@OfficeAutomation_Document_SpecialCase_ForPeople"
                                                        + "           ,@OfficeAutomation_Document_SpecialCase_AutoHandle"
                                                        + "           ,@OfficeAutomation_Document_SpecialCase_CaseRemark"
                                                        + "           ,@OfficeAutomation_Document_SpecialCase_HousingTransactions"
                                                        + "           ,@OfficeAutomation_Document_SpecialCase_DealWithProgress"
                                                        + "           ,@OfficeAutomation_Document_SpecialCase_Midway"
                                                        + "           ,@OfficeAutomation_Document_SpecialCase_PutUp"
                                                        + "           ,@OfficeAutomation_Document_SpecialCase_AnotherPutUp"
                                                        + "           ,@OfficeAutomation_Document_SpecialCase_4PointGuaranteeCompany"
                                                        + "           ,@OfficeAutomation_Document_SpecialCase_CompanyEarnings"
                                                        + "           ,@OfficeAutomation_Document_SpecialCase_EarningsAmount"
                                                        + "           ,@OfficeAutomation_Document_SpecialCase_TheKindOfFormalities"
                                                        + "           ,@OfficeAutomation_Document_SpecialCase_Certificate"
                                                     //   + "           ,@OfficeAutomation_Document_SpecialCase_NotarialDeed"
                                                    //    + "           ,@OfficeAutomation_Document_SpecialCase_CommissionedPersonnel"
                                                     //   + "           ,@OfficeAutomation_Document_SpecialCase_Clause"
                                                        + "           ,@OfficeAutomation_Document_SpecialCase_NotNeat"
                                                        + "           ,@OfficeAutomation_Document_SpecialCase_JieFeeDate"
                                                        + "           ,@OfficeAutomation_Document_SpecialCase_credit"
                                                  //      + "           ,@OfficeAutomation_Document_SpecialCase_Another"
                                                        + "           ,@OfficeAutomation_Document_SpecialCase_Situation"
                                                        + "           ,@OfficeAutomation_Document_SpecialCase_BorrowDate"
                                                        + "           ,@OfficeAutomation_Document_SpecialCase_BorrowS"
                                                        + "           ,@OfficeAutomation_Document_SpecialCase_ReturnDate)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_SpecialCase)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_Department));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_BranchNo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_BranchNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_Phone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_Phone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_FollowDepartment", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_FollowDepartment));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_FollowSomebody", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_FollowSomebody));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_Location", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_Location));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_Master", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_Master));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_Buyer", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_Buyer));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_Loan", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_Loan));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_QuickPut", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_QuickPut));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_GuaranteeCompany", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_GuaranteeCompany));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_PayWay", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_PayWay));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_ApplyNo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_ApplyNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_TimeoutApply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_TimeoutApply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_ForPeople", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_ForPeople));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_AutoHandle", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_AutoHandle));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_CaseRemark", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_CaseRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_HousingTransactions", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_HousingTransactions));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_DealWithProgress", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_DealWithProgress));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_Midway", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_Midway));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_PutUp", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_PutUp));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_AnotherPutUp", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_AnotherPutUp));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_4PointGuaranteeCompany", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_4PointGuaranteeCompany));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_CompanyEarnings", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_CompanyEarnings));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_EarningsAmount", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_EarningsAmount));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_TheKindOfFormalities", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_TheKindOfFormalities));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_Certificate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_Certificate));
             //   cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_NotarialDeed", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_NotarialDeed));
             //   cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_CommissionedPersonnel", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_CommissionedPersonnel));
              //  cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_Clause", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_Clause));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_NotNeat", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_NotNeat));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_JieFeeDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_JieFeeDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_credit", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_credit));
            //    cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_Another", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_Another));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_Situation", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_Situation));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_BorrowDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_BorrowDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_BorrowS", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_BorrowS));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_ReturnDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_ReturnDate));

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
            cmdToExecute.CommandText = "dbo.[pr_SpecialCase_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SpecialCase]"
                                + "         SET [OfficeAutomation_Document_SpecialCase_ApplyID] = @OfficeAutomation_Document_SpecialCase_ApplyID"
                                + "         ,[OfficeAutomation_Document_SpecialCase_Department] = @OfficeAutomation_Document_SpecialCase_Department"
                                + "         ,[OfficeAutomation_Document_SpecialCase_BranchNo] = @OfficeAutomation_Document_SpecialCase_BranchNo"
                                + "         ,[OfficeAutomation_Document_SpecialCase_Phone] = @OfficeAutomation_Document_SpecialCase_Phone"
                                + "         ,[OfficeAutomation_Document_SpecialCase_FollowDepartment] = @OfficeAutomation_Document_SpecialCase_FollowDepartment"
                                + "         ,[OfficeAutomation_Document_SpecialCase_FollowSomebody] = @OfficeAutomation_Document_SpecialCase_FollowSomebody"
                                + "         ,[OfficeAutomation_Document_SpecialCase_Location] = @OfficeAutomation_Document_SpecialCase_Location"
                                + "         ,[OfficeAutomation_Document_SpecialCase_Master] = @OfficeAutomation_Document_SpecialCase_Master"
                                + "         ,[OfficeAutomation_Document_SpecialCase_Buyer] = @OfficeAutomation_Document_SpecialCase_Buyer"
                                + "         ,[OfficeAutomation_Document_SpecialCase_Loan] = @OfficeAutomation_Document_SpecialCase_Loan"
                                + "         ,[OfficeAutomation_Document_SpecialCase_QuickPut] = @OfficeAutomation_Document_SpecialCase_QuickPut"
                                + "         ,[OfficeAutomation_Document_SpecialCase_GuaranteeCompany] = @OfficeAutomation_Document_SpecialCase_GuaranteeCompany"
                                + "         ,[OfficeAutomation_Document_SpecialCase_PayWay] = @OfficeAutomation_Document_SpecialCase_PayWay"
                                + "         ,[OfficeAutomation_Document_SpecialCase_ApplyNo] = @OfficeAutomation_Document_SpecialCase_ApplyNo"
                                + "         ,[OfficeAutomation_Document_SpecialCase_TimeoutApply] = @OfficeAutomation_Document_SpecialCase_TimeoutApply"
                                + "         ,[OfficeAutomation_Document_SpecialCase_ForPeople] = @OfficeAutomation_Document_SpecialCase_ForPeople"
                                + "         ,[OfficeAutomation_Document_SpecialCase_AutoHandle] = @OfficeAutomation_Document_SpecialCase_AutoHandle"
                                + "         ,[OfficeAutomation_Document_SpecialCase_CaseRemark] = @OfficeAutomation_Document_SpecialCase_CaseRemark"
                                + "         ,[OfficeAutomation_Document_SpecialCase_HousingTransactions] = @OfficeAutomation_Document_SpecialCase_HousingTransactions"
                                + "         ,[OfficeAutomation_Document_SpecialCase_DealWithProgress] = @OfficeAutomation_Document_SpecialCase_DealWithProgress"
                                + "         ,[OfficeAutomation_Document_SpecialCase_Midway] = @OfficeAutomation_Document_SpecialCase_Midway"
                                + "         ,[OfficeAutomation_Document_SpecialCase_PutUp] = @OfficeAutomation_Document_SpecialCase_PutUp"
                                + "         ,[OfficeAutomation_Document_SpecialCase_AnotherPutUp] = @OfficeAutomation_Document_SpecialCase_AnotherPutUp"
                                + "         ,[OfficeAutomation_Document_SpecialCase_4PointGuaranteeCompany] = @OfficeAutomation_Document_SpecialCase_4PointGuaranteeCompany"
                                + "         ,[OfficeAutomation_Document_SpecialCase_CompanyEarnings] = @OfficeAutomation_Document_SpecialCase_CompanyEarnings"
                                + "         ,[OfficeAutomation_Document_SpecialCase_EarningsAmount] = @OfficeAutomation_Document_SpecialCase_EarningsAmount"
                                + "         ,[OfficeAutomation_Document_SpecialCase_TheKindOfFormalities] = @OfficeAutomation_Document_SpecialCase_TheKindOfFormalities"
                                + "         ,[OfficeAutomation_Document_SpecialCase_Certificate] = @OfficeAutomation_Document_SpecialCase_Certificate"
                             //   + "         ,[OfficeAutomation_Document_SpecialCase_NotarialDeed] = @OfficeAutomation_Document_SpecialCase_NotarialDeed"
                            //    + "         ,[OfficeAutomation_Document_SpecialCase_CommissionedPersonnel] = @OfficeAutomation_Document_SpecialCase_CommissionedPersonnel"
                            //    + "         ,[OfficeAutomation_Document_SpecialCase_Clause] = @OfficeAutomation_Document_SpecialCase_Clause"
                                + "         ,[OfficeAutomation_Document_SpecialCase_NotNeat] = @OfficeAutomation_Document_SpecialCase_NotNeat"
                                + "         ,[OfficeAutomation_Document_SpecialCase_JieFeeDate] = @OfficeAutomation_Document_SpecialCase_JieFeeDate"
                                + "         ,[OfficeAutomation_Document_SpecialCase_credit] = @OfficeAutomation_Document_SpecialCase_credit"
                           //     + "         ,[OfficeAutomation_Document_SpecialCase_Another] = @OfficeAutomation_Document_SpecialCase_Another"
                                + "         ,[OfficeAutomation_Document_SpecialCase_Situation] = @OfficeAutomation_Document_SpecialCase_Situation"
                                + "         ,[OfficeAutomation_Document_SpecialCase_BorrowDate] = @OfficeAutomation_Document_SpecialCase_BorrowDate"
                                + "         ,[OfficeAutomation_Document_SpecialCase_BorrowS] = @OfficeAutomation_Document_SpecialCase_BorrowS"
                                + "         ,[OfficeAutomation_Document_SpecialCase_ReturnDate] = @OfficeAutomation_Document_SpecialCase_ReturnDate"
                                + "         WHERE [OfficeAutomation_Document_SpecialCase_ID]=@OfficeAutomation_Document_SpecialCase_ID"
                                + "         AND [OfficeAutomation_Document_SpecialCase_MainID]=@OfficeAutomation_Document_SpecialCase_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_SpecialCase)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_BranchNo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_BranchNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_Phone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_Phone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_FollowDepartment", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_FollowDepartment));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_FollowSomebody", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_FollowSomebody));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_Location", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_Location));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_Master", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_Master));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_Buyer", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_Buyer));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_Loan", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_Loan));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_QuickPut", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_QuickPut));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_GuaranteeCompany", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_GuaranteeCompany));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_PayWay", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_PayWay));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_ApplyNo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_ApplyNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_TimeoutApply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_TimeoutApply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_ForPeople", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_ForPeople));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_AutoHandle", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_AutoHandle));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_CaseRemark", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_CaseRemark));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_HousingTransactions", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_HousingTransactions));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_DealWithProgress", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_DealWithProgress));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_Midway", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_Midway));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_PutUp", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_PutUp));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_AnotherPutUp", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_AnotherPutUp));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_4PointGuaranteeCompany", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_4PointGuaranteeCompany));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_CompanyEarnings", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_CompanyEarnings));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_EarningsAmount", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_EarningsAmount));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_TheKindOfFormalities", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_TheKindOfFormalities));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_Certificate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_Certificate));
               // cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_NotarialDeed", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_NotarialDeed));
               // cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_CommissionedPersonnel", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_CommissionedPersonnel));
               /// cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_Clause", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_Clause));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_NotNeat", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_NotNeat));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_JieFeeDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_JieFeeDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_credit", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_credit));
            //    cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_Another", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_Another));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_Situation", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_Situation));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_BorrowDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_BorrowDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_BorrowS", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_BorrowS));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_ReturnDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_ReturnDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SpecialCase_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SpecialCase_MainID));

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
