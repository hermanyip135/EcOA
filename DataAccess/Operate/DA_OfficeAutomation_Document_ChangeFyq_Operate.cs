using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_ChangeFyq_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_ChangeFyq _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ChangeFyq]"
                                                        + "           ([OfficeAutomation_Document_ChangeFyq_ID]"
                                                        + "           ,[OfficeAutomation_Document_ChangeFyq_MainID]"
                                                        + "           ,[OfficeAutomation_Document_ChangeFyq_Apply]"
                                                        + "           ,[OfficeAutomation_Document_ChangeFyq_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_ChangeFyq_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_ChangeFyq_Department]"
                                                        + "           ,[OfficeAutomation_Document_ChangeFyq_Phone]"
                                                        + "           ,[OfficeAutomation_Document_ChangeFyq_Area]"
                                                        + "           ,[OfficeAutomation_Document_ChangeFyq_Location]"
                                                        + "           ,[OfficeAutomation_Document_ChangeFyq_Master]"
                                                        + "           ,[OfficeAutomation_Document_ChangeFyq_Buyers]"
                                                        + "           ,[OfficeAutomation_Document_ChangeFyq_IsContract]"
                                                        + "           ,[OfficeAutomation_Document_ChangeFyq_IsCommission]"
                                                        + "           ,[OfficeAutomation_Document_ChangeFyq_CDate]"
                                                        + "           ,[OfficeAutomation_Document_ChangeFyq_SpecialApply]"
                                                        + "           ,[OfficeAutomation_Document_ChangeFyq_PayWay]"
                                                        + "           ,[OfficeAutomation_Document_ChangeFyq_WhoKeep]"
                                                        + "           ,[OfficeAutomation_Document_ChangeFyq_SurePrice]"
                                                        + "           ,[OfficeAutomation_Document_ChangeFyq_CompareP]"
                                                        + "           ,[OfficeAutomation_Document_ChangeFyq_HandleDate]"
                                                        + "           ,[OfficeAutomation_Document_ChangeFyq_Others]"
                                                        + "           ,[OfficeAutomation_Document_ChangeFyq_Detailed]"
                                                        + "           ,[OfficeAutomation_Document_ChangeFyq_CNS]"
                                                        + "           ,[OfficeAutomation_Document_ChangeFyq_Relationship]"
                                                        + "           ,[OfficeAutomation_Document_ChangeFyq_PriceChange]"
                                                        + "           ,[OfficeAutomation_Document_ChangeFyq_CompareOfChange])"
                                                        + " VALUES"
                                                        + "           (@OfficeAutomation_Document_ChangeFyq_ID"
                                                        + "           ,@OfficeAutomation_Document_ChangeFyq_MainID"
                                                        + "           ,@OfficeAutomation_Document_ChangeFyq_Apply"
                                                        + "           ,@OfficeAutomation_Document_ChangeFyq_ApplyDate"
                                                        + "           ,@OfficeAutomation_Document_ChangeFyq_ApplyID"
                                                        + "           ,@OfficeAutomation_Document_ChangeFyq_Department"
                                                        + "           ,@OfficeAutomation_Document_ChangeFyq_Phone"
                                                        + "           ,@OfficeAutomation_Document_ChangeFyq_Area"
                                                        + "           ,@OfficeAutomation_Document_ChangeFyq_Location"
                                                        + "           ,@OfficeAutomation_Document_ChangeFyq_Master"
                                                        + "           ,@OfficeAutomation_Document_ChangeFyq_Buyers"
                                                        + "           ,@OfficeAutomation_Document_ChangeFyq_IsContract"
                                                        + "           ,@OfficeAutomation_Document_ChangeFyq_IsCommission"
                                                        + "           ,@OfficeAutomation_Document_ChangeFyq_CDate"
                                                        + "           ,@OfficeAutomation_Document_ChangeFyq_SpecialApply"
                                                        + "           ,@OfficeAutomation_Document_ChangeFyq_PayWay"
                                                        + "           ,@OfficeAutomation_Document_ChangeFyq_WhoKeep"
                                                        + "           ,@OfficeAutomation_Document_ChangeFyq_SurePrice"
                                                        + "           ,@OfficeAutomation_Document_ChangeFyq_CompareP"
                                                        + "           ,@OfficeAutomation_Document_ChangeFyq_HandleDate"
                                                        + "           ,@OfficeAutomation_Document_ChangeFyq_Others"
                                                        + "           ,@OfficeAutomation_Document_ChangeFyq_Detailed"
                                                        + "           ,@OfficeAutomation_Document_ChangeFyq_CNS"
                                                        + "           ,@OfficeAutomation_Document_ChangeFyq_Relationship"
                                                        + "           ,@OfficeAutomation_Document_ChangeFyq_PriceChange"
                                                        + "           ,@OfficeAutomation_Document_ChangeFyq_CompareOfChange)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_ChangeFyq)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_Department));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_Phone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_Phone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_Area", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_Area));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_Location", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_Location));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_Master", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_Master));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_Buyers", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_Buyers));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_IsContract", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_IsContract));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_IsCommission", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_IsCommission));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_CDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_CDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_SpecialApply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_SpecialApply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_PayWay", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_PayWay));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_WhoKeep", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_WhoKeep));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_SurePrice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_SurePrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_CompareP", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_CompareP));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_HandleDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_HandleDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_Others", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_Others));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_Detailed", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_Detailed));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_CNS", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_CNS));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_Relationship", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_Relationship));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_PriceChange", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_PriceChange));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_CompareOfChange", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_CompareOfChange));

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
            cmdToExecute.CommandText = "dbo.[pr_ChangeFyq_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ChangeFyq]"
                                + "         SET [OfficeAutomation_Document_ChangeFyq_ApplyID] = @OfficeAutomation_Document_ChangeFyq_ApplyID"
                                + "         ,[OfficeAutomation_Document_ChangeFyq_Department] = @OfficeAutomation_Document_ChangeFyq_Department"
                                + "         ,[OfficeAutomation_Document_ChangeFyq_Phone] = @OfficeAutomation_Document_ChangeFyq_Phone"
                                + "         ,[OfficeAutomation_Document_ChangeFyq_Area] = @OfficeAutomation_Document_ChangeFyq_Area"
                                + "         ,[OfficeAutomation_Document_ChangeFyq_Location] = @OfficeAutomation_Document_ChangeFyq_Location"
                                + "         ,[OfficeAutomation_Document_ChangeFyq_Master] = @OfficeAutomation_Document_ChangeFyq_Master"
                                + "         ,[OfficeAutomation_Document_ChangeFyq_Buyers] = @OfficeAutomation_Document_ChangeFyq_Buyers"
                                + "         ,[OfficeAutomation_Document_ChangeFyq_IsContract] = @OfficeAutomation_Document_ChangeFyq_IsContract"
                                + "         ,[OfficeAutomation_Document_ChangeFyq_IsCommission] = @OfficeAutomation_Document_ChangeFyq_IsCommission"
                                + "         ,[OfficeAutomation_Document_ChangeFyq_CDate] = @OfficeAutomation_Document_ChangeFyq_CDate"
                                + "         ,[OfficeAutomation_Document_ChangeFyq_SpecialApply] = @OfficeAutomation_Document_ChangeFyq_SpecialApply"
                                + "         ,[OfficeAutomation_Document_ChangeFyq_PayWay] = @OfficeAutomation_Document_ChangeFyq_PayWay"
                                + "         ,[OfficeAutomation_Document_ChangeFyq_WhoKeep] = @OfficeAutomation_Document_ChangeFyq_WhoKeep"
                                + "         ,[OfficeAutomation_Document_ChangeFyq_SurePrice] = @OfficeAutomation_Document_ChangeFyq_SurePrice"
                                + "         ,[OfficeAutomation_Document_ChangeFyq_CompareP] = @OfficeAutomation_Document_ChangeFyq_CompareP"
                                + "         ,[OfficeAutomation_Document_ChangeFyq_HandleDate] = @OfficeAutomation_Document_ChangeFyq_HandleDate"
                                + "         ,[OfficeAutomation_Document_ChangeFyq_Others] = @OfficeAutomation_Document_ChangeFyq_Others"
                                + "         ,[OfficeAutomation_Document_ChangeFyq_Detailed] = @OfficeAutomation_Document_ChangeFyq_Detailed"
                                + "         ,[OfficeAutomation_Document_ChangeFyq_CNS] = @OfficeAutomation_Document_ChangeFyq_CNS"
                                + "         ,[OfficeAutomation_Document_ChangeFyq_Relationship] = @OfficeAutomation_Document_ChangeFyq_Relationship"
                                + "         ,[OfficeAutomation_Document_ChangeFyq_PriceChange] = @OfficeAutomation_Document_ChangeFyq_PriceChange"
                                + "         ,[OfficeAutomation_Document_ChangeFyq_CompareOfChange] = @OfficeAutomation_Document_ChangeFyq_CompareOfChange"
                                + "         WHERE [OfficeAutomation_Document_ChangeFyq_ID]=@OfficeAutomation_Document_ChangeFyq_ID"
                                + "         AND [OfficeAutomation_Document_ChangeFyq_MainID]=@OfficeAutomation_Document_ChangeFyq_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_ChangeFyq)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_Phone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_Phone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_Area", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_Area));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_Location", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_Location));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_Master", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_Master));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_Buyers", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_Buyers));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_IsContract", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_IsContract));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_IsCommission", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_IsCommission));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_CDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_CDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_SpecialApply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_SpecialApply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_PayWay", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_PayWay));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_WhoKeep", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_WhoKeep));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_SurePrice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_SurePrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_CompareP", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_CompareP));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_HandleDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_HandleDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_Others", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_Others));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_Detailed", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_Detailed));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_CNS", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_CNS));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_Relationship", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_Relationship));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_PriceChange", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_PriceChange));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_CompareOfChange", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_CompareOfChange));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeFyq_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeFyq_MainID));

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
