using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Repair_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_Repair _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Repair]"
                                                        + "           ([OfficeAutomation_Document_Repair_ID]"
                                                        + "           ,[OfficeAutomation_Document_Repair_MainID]"
                                                        + "           ,[OfficeAutomation_Document_Repair_Apply]"
                                                        + "           ,[OfficeAutomation_Document_Repair_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_Repair_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_Repair_Department]"
                                                        + "           ,[OfficeAutomation_Document_Repair_SumBrand]"
                                                        + "           ,[OfficeAutomation_Document_Repair_SumUnit]"
                                                        + "           ,[OfficeAutomation_Document_Repair_SumPrice]"
                                                        + "           ,[OfficeAutomation_Document_Repair_SumNum]"
                                                        + "           ,[OfficeAutomation_Document_Repair_SumMoney]"
                                                        + "           ,[OfficeAutomation_Document_Repair_SummarySum]"
                                                        + "           ,[OfficeAutomation_Document_Repair_TaxBrand]"
                                                        + "           ,[OfficeAutomation_Document_Repair_TaxUnit]"
                                                        + "           ,[OfficeAutomation_Document_Repair_TaxPrice]"
                                                        + "           ,[OfficeAutomation_Document_Repair_TaxNum]"
                                                        + "           ,[OfficeAutomation_Document_Repair_TaxMoney]"
                                                        + "           ,[OfficeAutomation_Document_Repair_SummaryTax]"
                                                        + "           ,[OfficeAutomation_Document_Repair_CouBrand]"
                                                        + "           ,[OfficeAutomation_Document_Repair_CouUnit]"
                                                        + "           ,[OfficeAutomation_Document_Repair_CouPrice]"
                                                        + "           ,[OfficeAutomation_Document_Repair_CouNum]"
                                                        + "           ,[OfficeAutomation_Document_Repair_CouMoney]"
                                                        + "           ,[OfficeAutomation_Document_Repair_SummaryCou]"
                                                        + "           ,[OfficeAutomation_Document_Repair_RealBrand]"
                                                        + "           ,[OfficeAutomation_Document_Repair_RealUnit]"
                                                        + "           ,[OfficeAutomation_Document_Repair_RealPrice]"
                                                        + "           ,[OfficeAutomation_Document_Repair_RealNum]"
                                                        + "           ,[OfficeAutomation_Document_Repair_RealMoney]"
                                                        + "           ,[OfficeAutomation_Document_Repair_SummaryReal]"
                                                        + "           ,[OfficeAutomation_Document_Repair_Merchant]"
                                                        + "           ,[OfficeAutomation_Document_Repair_Conneter]"
                                                        + "           ,[OfficeAutomation_Document_Repair_Phone]"
                                                        + "           ,[OfficeAutomation_Document_Repair_Tax]"
                                                        + "           ,[OfficeAutomation_Document_Repair_Ctime]"
                                                        + "           ,[OfficeAutomation_Document_Repair_Cname]"
                                                        + "           ,[OfficeAutomation_Document_Repair_Email])"
                                                        + " VALUES"
                                                        + "           (@OfficeAutomation_Document_Repair_ID"
                                                        + "           ,@OfficeAutomation_Document_Repair_MainID"
                                                        + "           ,@OfficeAutomation_Document_Repair_Apply"
                                                        + "           ,@OfficeAutomation_Document_Repair_ApplyDate"
                                                        + "           ,@OfficeAutomation_Document_Repair_ApplyID"
                                                        + "           ,@OfficeAutomation_Document_Repair_Department"
                                                        + "           ,@OfficeAutomation_Document_Repair_SumBrand"
                                                        + "           ,@OfficeAutomation_Document_Repair_SumUnit"
                                                        + "           ,@OfficeAutomation_Document_Repair_SumPrice"
                                                        + "           ,@OfficeAutomation_Document_Repair_SumNum"
                                                        + "           ,@OfficeAutomation_Document_Repair_SumMoney"
                                                        + "           ,@OfficeAutomation_Document_Repair_SummarySum"
                                                        + "           ,@OfficeAutomation_Document_Repair_TaxBrand"
                                                        + "           ,@OfficeAutomation_Document_Repair_TaxUnit"
                                                        + "           ,@OfficeAutomation_Document_Repair_TaxPrice"
                                                        + "           ,@OfficeAutomation_Document_Repair_TaxNum"
                                                        + "           ,@OfficeAutomation_Document_Repair_TaxMoney"
                                                        + "           ,@OfficeAutomation_Document_Repair_SummaryTax"
                                                        + "           ,@OfficeAutomation_Document_Repair_CouBrand"
                                                        + "           ,@OfficeAutomation_Document_Repair_CouUnit"
                                                        + "           ,@OfficeAutomation_Document_Repair_CouPrice"
                                                        + "           ,@OfficeAutomation_Document_Repair_CouNum"
                                                        + "           ,@OfficeAutomation_Document_Repair_CouMoney"
                                                        + "           ,@OfficeAutomation_Document_Repair_SummaryCou"
                                                        + "           ,@OfficeAutomation_Document_Repair_RealBrand"
                                                        + "           ,@OfficeAutomation_Document_Repair_RealUnit"
                                                        + "           ,@OfficeAutomation_Document_Repair_RealPrice"
                                                        + "           ,@OfficeAutomation_Document_Repair_RealNum"
                                                        + "           ,@OfficeAutomation_Document_Repair_RealMoney"
                                                        + "           ,@OfficeAutomation_Document_Repair_SummaryReal"
                                                        + "           ,@OfficeAutomation_Document_Repair_Merchant"
                                                        + "           ,@OfficeAutomation_Document_Repair_Conneter"
                                                        + "           ,@OfficeAutomation_Document_Repair_Phone"
                                                        + "           ,@OfficeAutomation_Document_Repair_Tax"
                                                        + "           ,@OfficeAutomation_Document_Repair_Ctime"
                                                        + "           ,@OfficeAutomation_Document_Repair_Cname"
                                                        + "           ,@OfficeAutomation_Document_Repair_Email)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_Repair)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_Department));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_SumBrand", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_SumBrand));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_SumUnit", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_SumUnit));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_SumPrice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_SumPrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_SumNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_SumNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_SumMoney", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_SumMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_SummarySum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_SummarySum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_TaxBrand", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_TaxBrand));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_TaxUnit", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_TaxUnit));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_TaxPrice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_TaxPrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_TaxNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_TaxNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_TaxMoney", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_TaxMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_SummaryTax", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_SummaryTax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_CouBrand", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_CouBrand));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_CouUnit", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_CouUnit));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_CouPrice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_CouPrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_CouNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_CouNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_CouMoney", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_CouMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_SummaryCou", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_SummaryCou));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_RealBrand", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_RealBrand));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_RealUnit", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_RealUnit));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_RealPrice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_RealPrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_RealNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_RealNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_RealMoney", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_RealMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_SummaryReal", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_SummaryReal));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_Merchant", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_Merchant));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_Conneter", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_Conneter));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_Phone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_Phone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_Tax", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_Tax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_Ctime", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_Ctime));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_Cname", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_Cname));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_Email", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_Email));

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
            cmdToExecute.CommandText = "dbo.[pr_Repair_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Repair]"
                                + "         SET [OfficeAutomation_Document_Repair_ApplyID] = @OfficeAutomation_Document_Repair_ApplyID"
                                + "         ,[OfficeAutomation_Document_Repair_Department] = @OfficeAutomation_Document_Repair_Department"

                                + "         ,[OfficeAutomation_Document_Repair_SumBrand] = @OfficeAutomation_Document_Repair_SumBrand"
                                + "         ,[OfficeAutomation_Document_Repair_SumUnit] = @OfficeAutomation_Document_Repair_SumUnit"
                                + "         ,[OfficeAutomation_Document_Repair_SumPrice] = @OfficeAutomation_Document_Repair_SumPrice"
                                + "         ,[OfficeAutomation_Document_Repair_SumNum] = @OfficeAutomation_Document_Repair_SumNum"
                                + "         ,[OfficeAutomation_Document_Repair_SumMoney] = @OfficeAutomation_Document_Repair_SumMoney"
                                + "         ,[OfficeAutomation_Document_Repair_SummarySum] = @OfficeAutomation_Document_Repair_SummarySum"
                                + "         ,[OfficeAutomation_Document_Repair_TaxBrand] = @OfficeAutomation_Document_Repair_TaxBrand"
                                + "         ,[OfficeAutomation_Document_Repair_TaxUnit] = @OfficeAutomation_Document_Repair_TaxUnit"
                                + "         ,[OfficeAutomation_Document_Repair_TaxPrice] = @OfficeAutomation_Document_Repair_TaxPrice"
                                + "         ,[OfficeAutomation_Document_Repair_TaxNum] = @OfficeAutomation_Document_Repair_TaxNum"
                                + "         ,[OfficeAutomation_Document_Repair_TaxMoney] = @OfficeAutomation_Document_Repair_TaxMoney"
                                + "         ,[OfficeAutomation_Document_Repair_SummaryTax] = @OfficeAutomation_Document_Repair_SummaryTax"
                                + "         ,[OfficeAutomation_Document_Repair_CouBrand] = @OfficeAutomation_Document_Repair_CouBrand"
                                + "         ,[OfficeAutomation_Document_Repair_CouUnit] = @OfficeAutomation_Document_Repair_CouUnit"
                                + "         ,[OfficeAutomation_Document_Repair_CouPrice] = @OfficeAutomation_Document_Repair_CouPrice"
                                + "         ,[OfficeAutomation_Document_Repair_CouNum] = @OfficeAutomation_Document_Repair_CouNum"
                                + "         ,[OfficeAutomation_Document_Repair_CouMoney] = @OfficeAutomation_Document_Repair_CouMoney"
                                + "         ,[OfficeAutomation_Document_Repair_SummaryCou] = @OfficeAutomation_Document_Repair_SummaryCou"
                                + "         ,[OfficeAutomation_Document_Repair_RealBrand] = @OfficeAutomation_Document_Repair_RealBrand"
                                + "         ,[OfficeAutomation_Document_Repair_RealUnit] = @OfficeAutomation_Document_Repair_RealUnit"
                                + "         ,[OfficeAutomation_Document_Repair_RealPrice] = @OfficeAutomation_Document_Repair_RealPrice"
                                + "         ,[OfficeAutomation_Document_Repair_RealNum] = @OfficeAutomation_Document_Repair_RealNum"
                                + "         ,[OfficeAutomation_Document_Repair_RealMoney] = @OfficeAutomation_Document_Repair_RealMoney"
                                + "         ,[OfficeAutomation_Document_Repair_SummaryReal] = @OfficeAutomation_Document_Repair_SummaryReal"
                                + "         ,[OfficeAutomation_Document_Repair_Merchant] = @OfficeAutomation_Document_Repair_Merchant"
                                + "         ,[OfficeAutomation_Document_Repair_Conneter] = @OfficeAutomation_Document_Repair_Conneter"
                                + "         ,[OfficeAutomation_Document_Repair_Phone] = @OfficeAutomation_Document_Repair_Phone"
                                + "         ,[OfficeAutomation_Document_Repair_Tax] = @OfficeAutomation_Document_Repair_Tax"
                                + "         ,[OfficeAutomation_Document_Repair_Ctime] = @OfficeAutomation_Document_Repair_Ctime"
                                + "         ,[OfficeAutomation_Document_Repair_Cname] = @OfficeAutomation_Document_Repair_Cname"
                                + "         ,[OfficeAutomation_Document_Repair_Email] = @OfficeAutomation_Document_Repair_Email"

                                + "         WHERE [OfficeAutomation_Document_Repair_ID]=@OfficeAutomation_Document_Repair_ID"
                                + "         AND [OfficeAutomation_Document_Repair_MainID]=@OfficeAutomation_Document_Repair_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_Repair)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_Department));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_SumBrand", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_SumBrand));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_SumUnit", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_SumUnit));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_SumPrice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_SumPrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_SumNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_SumNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_SumMoney", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_SumMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_SummarySum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_SummarySum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_TaxBrand", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_TaxBrand));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_TaxUnit", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_TaxUnit));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_TaxPrice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_TaxPrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_TaxNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_TaxNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_TaxMoney", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_TaxMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_SummaryTax", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_SummaryTax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_CouBrand", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_CouBrand));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_CouUnit", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_CouUnit));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_CouPrice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_CouPrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_CouNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_CouNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_CouMoney", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_CouMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_SummaryCou", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_SummaryCou));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_RealBrand", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_RealBrand));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_RealUnit", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_RealUnit));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_RealPrice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_RealPrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_RealNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_RealNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_RealMoney", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_RealMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_SummaryReal", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_SummaryReal));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_Merchant", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_Merchant));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_Conneter", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_Conneter));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_Phone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_Phone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_Tax", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_Tax));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_Ctime", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_Ctime));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_Cname", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_Cname));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_Email", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_Email));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Repair_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Repair_MainID));

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
