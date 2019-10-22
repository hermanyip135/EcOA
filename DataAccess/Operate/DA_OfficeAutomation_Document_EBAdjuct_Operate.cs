using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_EBAdjuct_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_EBAdjuct _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_EBAdjuct]"
                                                        + "           ([OfficeAutomation_Document_EBAdjuct_ID]"
                                                        + "           ,[OfficeAutomation_Document_EBAdjuct_MainID]"
                                                        + "           ,[OfficeAutomation_Document_EBAdjuct_Apply]"
                                                        + "           ,[OfficeAutomation_Document_EBAdjuct_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_EBAdjuct_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_EBAdjuct_ApplyName]"
                                                        + "           ,[OfficeAutomation_Document_EBAdjuct_Department]"
                                                        + "           ,[OfficeAutomation_Document_EBAdjuct_BonusC1]"
                                                        + "           ,[OfficeAutomation_Document_EBAdjuct_ProjectPCMomey]"
                                                        + "           ,[OfficeAutomation_Document_EBAdjuct_ProjectEBMomey]"
                                                        + "           ,[OfficeAutomation_Document_EBAdjuct_Bonus4]"
                                                        + "           ,[OfficeAutomation_Document_EBAdjuct_ValidityBeginDate]"
                                                        + "           ,[OfficeAutomation_Document_EBAdjuct_ValidityEndDate]"
                                                        + "           ,[OfficeAutomation_Document_EBAdjuct_Bonus5]"
                                                        + "           ,[OfficeAutomation_Document_EBAdjuct_BonusSituation]"
                                                        + "           ,[OfficeAutomation_Document_EBAdjuct_WholeName]"
                                                        + "           ,[OfficeAutomation_Document_EBAdjuct_Position]"
                                                        + "           ,[OfficeAutomation_Document_EBAdjuct_Phone]"
                                                        + "           ,[OfficeAutomation_Document_EBAdjuct_AccountName]"
                                                        + "           ,[OfficeAutomation_Document_EBAdjuct_No]"
                                                        + "           ,[OfficeAutomation_Document_EBAdjuct_IsTax]"
                                                        + "           ,[OfficeAutomation_Document_EBAdjuct_BonusMoney]"
                                                        + "           ,[OfficeAutomation_Document_EBAdjuct_IsConfirm]"
                                                        + "           ,[OfficeAutomation_Document_EBAdjuct_SubmitDate]"

                                                        + "           ,[OfficeAutomation_Document_EBAdjuct_BonusSituationValue]"
                                                        + "           ,[OfficeAutomation_Document_EBAdjuct_DiscountValue]"
                                                        + "           ,[OfficeAutomation_Document_EBAdjuct_CashPrize]"
                                                        + "           ,[OfficeAutomation_Document_EBAdjuct_CalculationMethod]"
                                                        + "           ,[OfficeAutomation_Document_EBAdjuct_BonusSituationRemarks]"
                                                        + "  )"
                                                        + " VALUES"
                                                        + "           (@OfficeAutomation_Document_EBAdjuct_ID"
                                                        + "           ,@OfficeAutomation_Document_EBAdjuct_MainID"
                                                        + "           ,@OfficeAutomation_Document_EBAdjuct_Apply"
                                                        + "           ,@OfficeAutomation_Document_EBAdjuct_ApplyDate"
                                                        + "           ,@OfficeAutomation_Document_EBAdjuct_ApplyID"
                                                        + "           ,@OfficeAutomation_Document_EBAdjuct_ApplyName"
                                                        + "           ,@OfficeAutomation_Document_EBAdjuct_Department"
                                                        + "           ,@OfficeAutomation_Document_EBAdjuct_BonusC1"
                                                        + "           ,@OfficeAutomation_Document_EBAdjuct_ProjectPCMomey"
                                                        + "           ,@OfficeAutomation_Document_EBAdjuct_ProjectEBMomey"
                                                        + "           ,@OfficeAutomation_Document_EBAdjuct_Bonus4"
                                                        + "           ,@OfficeAutomation_Document_EBAdjuct_ValidityBeginDate"
                                                        + "           ,@OfficeAutomation_Document_EBAdjuct_ValidityEndDate"
                                                        + "           ,@OfficeAutomation_Document_EBAdjuct_Bonus5"
                                                        + "           ,@OfficeAutomation_Document_EBAdjuct_BonusSituation"
                                                        + "           ,@OfficeAutomation_Document_EBAdjuct_WholeName"
                                                        + "           ,@OfficeAutomation_Document_EBAdjuct_Position"
                                                        + "           ,@OfficeAutomation_Document_EBAdjuct_Phone"
                                                        + "           ,@OfficeAutomation_Document_EBAdjuct_AccountName"
                                                        + "           ,@OfficeAutomation_Document_EBAdjuct_No"
                                                        + "           ,@OfficeAutomation_Document_EBAdjuct_IsTax"
                                                        + "           ,@OfficeAutomation_Document_EBAdjuct_BonusMoney"
                                                        + "           ,@OfficeAutomation_Document_EBAdjuct_IsConfirm"
                                                        + "           ,@OfficeAutomation_Document_EBAdjuct_SubmitDate"
                                                        + "           ,@OfficeAutomation_Document_EBAdjuct_BonusSituationValue"
                                                        + "           ,@OfficeAutomation_Document_EBAdjuct_DiscountValue"
                                                        + "           ,@OfficeAutomation_Document_EBAdjuct_CashPrize"
                                                        + "           ,@OfficeAutomation_Document_EBAdjuct_CalculationMethod"
                                                        + "           ,@OfficeAutomation_Document_EBAdjuct_BonusSituationRemarks"
                                                        +"           )";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_EBAdjuct)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_ApplyName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_ApplyName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_Department));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_BonusC1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_BonusC1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_ProjectPCMomey", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_ProjectPCMomey));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_ProjectEBMomey", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_ProjectEBMomey));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_Bonus4", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_Bonus4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_ValidityBeginDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_ValidityBeginDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_ValidityEndDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_ValidityEndDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_Bonus5", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_Bonus5));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_BonusSituation", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_BonusSituation));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_WholeName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_WholeName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_Position", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_Position));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_Phone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_Phone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_AccountName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_AccountName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_No", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_No));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_IsTax", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_IsTax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_BonusMoney", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_BonusMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_IsConfirm", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_IsConfirm));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_SubmitDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_SubmitDate));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_BonusSituationValue", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_BonusSituationValue));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_DiscountValue", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_DiscountValue));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_CashPrize", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_CashPrize));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_CalculationMethod", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_CalculationMethod));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_BonusSituationRemarks", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_BonusSituationRemarks));

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
            cmdToExecute.CommandText = "dbo.[pr_EBAdjuct_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_EBAdjuct]"
                                + "         SET [OfficeAutomation_Document_EBAdjuct_ApplyID] = @OfficeAutomation_Document_EBAdjuct_ApplyID"
                                + "         ,[OfficeAutomation_Document_EBAdjuct_ApplyName] = @OfficeAutomation_Document_EBAdjuct_ApplyName"
                                + "         ,[OfficeAutomation_Document_EBAdjuct_Department] = @OfficeAutomation_Document_EBAdjuct_Department"

                                + "         ,[OfficeAutomation_Document_EBAdjuct_BonusC1] = @OfficeAutomation_Document_EBAdjuct_BonusC1"
                                + "         ,[OfficeAutomation_Document_EBAdjuct_ProjectPCMomey] = @OfficeAutomation_Document_EBAdjuct_ProjectPCMomey"
                                + "         ,[OfficeAutomation_Document_EBAdjuct_ProjectEBMomey] = @OfficeAutomation_Document_EBAdjuct_ProjectEBMomey"
                                + "         ,[OfficeAutomation_Document_EBAdjuct_Bonus4] = @OfficeAutomation_Document_EBAdjuct_Bonus4"
                                + "         ,[OfficeAutomation_Document_EBAdjuct_ValidityBeginDate] = @OfficeAutomation_Document_EBAdjuct_ValidityBeginDate"
                                + "         ,[OfficeAutomation_Document_EBAdjuct_ValidityEndDate] = @OfficeAutomation_Document_EBAdjuct_ValidityEndDate"
                                + "         ,[OfficeAutomation_Document_EBAdjuct_Bonus5] = @OfficeAutomation_Document_EBAdjuct_Bonus5"
                                + "         ,[OfficeAutomation_Document_EBAdjuct_BonusSituation] = @OfficeAutomation_Document_EBAdjuct_BonusSituation"
                                + "         ,[OfficeAutomation_Document_EBAdjuct_WholeName] = @OfficeAutomation_Document_EBAdjuct_WholeName"
                                + "         ,[OfficeAutomation_Document_EBAdjuct_Position] = @OfficeAutomation_Document_EBAdjuct_Position"
                                + "         ,[OfficeAutomation_Document_EBAdjuct_Phone] = @OfficeAutomation_Document_EBAdjuct_Phone"
                                + "         ,[OfficeAutomation_Document_EBAdjuct_AccountName] = @OfficeAutomation_Document_EBAdjuct_AccountName"
                                + "         ,[OfficeAutomation_Document_EBAdjuct_No] = @OfficeAutomation_Document_EBAdjuct_No"
                                + "         ,[OfficeAutomation_Document_EBAdjuct_IsTax] = @OfficeAutomation_Document_EBAdjuct_IsTax"
                                + "         ,[OfficeAutomation_Document_EBAdjuct_BonusMoney] = @OfficeAutomation_Document_EBAdjuct_BonusMoney"
                                + "         ,[OfficeAutomation_Document_EBAdjuct_IsConfirm] = @OfficeAutomation_Document_EBAdjuct_IsConfirm"
                                + "         ,[OfficeAutomation_Document_EBAdjuct_SubmitDate] = @OfficeAutomation_Document_EBAdjuct_SubmitDate"

                                + "         ,[OfficeAutomation_Document_EBAdjuct_BonusSituationValue] = @OfficeAutomation_Document_EBAdjuct_BonusSituationValue"
                                + "         ,[OfficeAutomation_Document_EBAdjuct_DiscountValue] = @OfficeAutomation_Document_EBAdjuct_DiscountValue"
                                + "         ,[OfficeAutomation_Document_EBAdjuct_CashPrize] = @OfficeAutomation_Document_EBAdjuct_CashPrize"
                                + "         ,[OfficeAutomation_Document_EBAdjuct_CalculationMethod] = @OfficeAutomation_Document_EBAdjuct_CalculationMethod"
                                + "         ,[OfficeAutomation_Document_EBAdjuct_BonusSituationRemarks] = @OfficeAutomation_Document_EBAdjuct_BonusSituationRemarks"
                                + "         WHERE [OfficeAutomation_Document_EBAdjuct_ID]=@OfficeAutomation_Document_EBAdjuct_ID"
                                + "         AND [OfficeAutomation_Document_EBAdjuct_MainID]=@OfficeAutomation_Document_EBAdjuct_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_EBAdjuct)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_ApplyName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_ApplyName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_BonusC1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_BonusC1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_ProjectPCMomey", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_ProjectPCMomey));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_ProjectEBMomey", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_ProjectEBMomey));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_Bonus4", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_Bonus4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_ValidityBeginDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_ValidityBeginDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_ValidityEndDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_ValidityEndDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_Bonus5", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_Bonus5));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_BonusSituation", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_BonusSituation));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_WholeName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_WholeName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_Position", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_Position));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_Phone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_Phone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_AccountName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_AccountName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_No", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_No));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_IsTax", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_IsTax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_BonusMoney", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_BonusMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_IsConfirm", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_IsConfirm));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_SubmitDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_SubmitDate));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_BonusSituationValue", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_BonusSituationValue));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_DiscountValue", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_DiscountValue));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_CashPrize", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_CashPrize));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_CalculationMethod", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_CalculationMethod));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_BonusSituationRemarks", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_BonusSituationRemarks));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_EBAdjuct_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_EBAdjuct_MainID));

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
