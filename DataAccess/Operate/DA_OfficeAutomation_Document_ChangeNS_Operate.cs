using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_ChangeNS_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_ChangeNS _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ChangeNS]"
                                                        + "           ([OfficeAutomation_Document_ChangeNS_ID]"
                                                        + "           ,[OfficeAutomation_Document_ChangeNS_MainID]"
                                                        + "           ,[OfficeAutomation_Document_ChangeNS_Apply]"
                                                        + "           ,[OfficeAutomation_Document_ChangeNS_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_ChangeNS_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_ChangeNS_Department]"
                                                        + "           ,[OfficeAutomation_Document_ChangeNS_Phone]"
                                                        + "           ,[OfficeAutomation_Document_ChangeNS_Area]"
                                                        + "           ,[OfficeAutomation_Document_ChangeNS_Location]"
                                                        + "           ,[OfficeAutomation_Document_ChangeNS_Master]"
                                                        + "           ,[OfficeAutomation_Document_ChangeNS_Buyers]"
                                                        + "           ,[OfficeAutomation_Document_ChangeNS_IsContract]"
                                                        + "           ,[OfficeAutomation_Document_ChangeNS_IsCommission]"
                                                        + "           ,[OfficeAutomation_Document_ChangeNS_CDate]"
                                                        + "           ,[OfficeAutomation_Document_ChangeNS_SpecialApply]"
                                                        + "           ,[OfficeAutomation_Document_ChangeNS_PayWay]"
                                                        + "           ,[OfficeAutomation_Document_ChangeNS_WhoKeep]"
                                                        + "           ,[OfficeAutomation_Document_ChangeNS_SurePrice]"
                                                        + "           ,[OfficeAutomation_Document_ChangeNS_CompareP]"
                                                        + "           ,[OfficeAutomation_Document_ChangeNS_HandleDate]"
                                                        + "           ,[OfficeAutomation_Document_ChangeNS_Others]"
                                                        + "           ,[OfficeAutomation_Document_ChangeNS_Detailed]"
                                                        + "           ,[OfficeAutomation_Document_ChangeNS_CNS]"
                                                        + "           ,[OfficeAutomation_Document_ChangeNS_Relationship]"
                                                        + "           ,[OfficeAutomation_Document_ChangeNS_PriceChange]"
                                                        + "           ,[OfficeAutomation_Document_ChangeNS_CompareOfChange])"
                                                        + " VALUES"
                                                        + "           (@OfficeAutomation_Document_ChangeNS_ID"
                                                        + "           ,@OfficeAutomation_Document_ChangeNS_MainID"
                                                        + "           ,@OfficeAutomation_Document_ChangeNS_Apply"
                                                        + "           ,@OfficeAutomation_Document_ChangeNS_ApplyDate"
                                                        + "           ,@OfficeAutomation_Document_ChangeNS_ApplyID"
                                                        + "           ,@OfficeAutomation_Document_ChangeNS_Department"
                                                        + "           ,@OfficeAutomation_Document_ChangeNS_Phone"
                                                        + "           ,@OfficeAutomation_Document_ChangeNS_Area"
                                                        + "           ,@OfficeAutomation_Document_ChangeNS_Location"
                                                        + "           ,@OfficeAutomation_Document_ChangeNS_Master"
                                                        + "           ,@OfficeAutomation_Document_ChangeNS_Buyers"
                                                        + "           ,@OfficeAutomation_Document_ChangeNS_IsContract"
                                                        + "           ,@OfficeAutomation_Document_ChangeNS_IsCommission"
                                                        + "           ,@OfficeAutomation_Document_ChangeNS_CDate"
                                                        + "           ,@OfficeAutomation_Document_ChangeNS_SpecialApply"
                                                        + "           ,@OfficeAutomation_Document_ChangeNS_PayWay"
                                                        + "           ,@OfficeAutomation_Document_ChangeNS_WhoKeep"
                                                        + "           ,@OfficeAutomation_Document_ChangeNS_SurePrice"
                                                        + "           ,@OfficeAutomation_Document_ChangeNS_CompareP"
                                                        + "           ,@OfficeAutomation_Document_ChangeNS_HandleDate"
                                                        + "           ,@OfficeAutomation_Document_ChangeNS_Others"
                                                        + "           ,@OfficeAutomation_Document_ChangeNS_Detailed"
                                                        + "           ,@OfficeAutomation_Document_ChangeNS_CNS"
                                                        + "           ,@OfficeAutomation_Document_ChangeNS_Relationship"
                                                        + "           ,@OfficeAutomation_Document_ChangeNS_PriceChange"
                                                        + "           ,@OfficeAutomation_Document_ChangeNS_CompareOfChange)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_ChangeNS)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_Department));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_Phone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_Phone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_Area", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_Area));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_Location", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_Location));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_Master", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_Master));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_Buyers", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_Buyers));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_IsContract", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_IsContract));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_IsCommission", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_IsCommission));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_CDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_CDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_SpecialApply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_SpecialApply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_PayWay", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_PayWay));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_WhoKeep", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_WhoKeep));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_SurePrice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_SurePrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_CompareP", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_CompareP));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_HandleDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_HandleDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_Others", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_Others));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_Detailed", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_Detailed));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_CNS", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_CNS));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_Relationship", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_Relationship));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_PriceChange", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_PriceChange));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_CompareOfChange", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_CompareOfChange));

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
            cmdToExecute.CommandText = "dbo.[pr_ChangeNS_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ChangeNS]"
                                + "         SET [OfficeAutomation_Document_ChangeNS_ApplyID] = @OfficeAutomation_Document_ChangeNS_ApplyID"
                                + "         ,[OfficeAutomation_Document_ChangeNS_Department] = @OfficeAutomation_Document_ChangeNS_Department"
                                + "         ,[OfficeAutomation_Document_ChangeNS_Phone] = @OfficeAutomation_Document_ChangeNS_Phone"
                                + "         ,[OfficeAutomation_Document_ChangeNS_Area] = @OfficeAutomation_Document_ChangeNS_Area"
                                + "         ,[OfficeAutomation_Document_ChangeNS_Location] = @OfficeAutomation_Document_ChangeNS_Location"
                                + "         ,[OfficeAutomation_Document_ChangeNS_Master] = @OfficeAutomation_Document_ChangeNS_Master"
                                + "         ,[OfficeAutomation_Document_ChangeNS_Buyers] = @OfficeAutomation_Document_ChangeNS_Buyers"
                                + "         ,[OfficeAutomation_Document_ChangeNS_IsContract] = @OfficeAutomation_Document_ChangeNS_IsContract"
                                + "         ,[OfficeAutomation_Document_ChangeNS_IsCommission] = @OfficeAutomation_Document_ChangeNS_IsCommission"
                                + "         ,[OfficeAutomation_Document_ChangeNS_CDate] = @OfficeAutomation_Document_ChangeNS_CDate"
                                + "         ,[OfficeAutomation_Document_ChangeNS_SpecialApply] = @OfficeAutomation_Document_ChangeNS_SpecialApply"
                                + "         ,[OfficeAutomation_Document_ChangeNS_PayWay] = @OfficeAutomation_Document_ChangeNS_PayWay"
                                + "         ,[OfficeAutomation_Document_ChangeNS_WhoKeep] = @OfficeAutomation_Document_ChangeNS_WhoKeep"
                                + "         ,[OfficeAutomation_Document_ChangeNS_SurePrice] = @OfficeAutomation_Document_ChangeNS_SurePrice"
                                + "         ,[OfficeAutomation_Document_ChangeNS_CompareP] = @OfficeAutomation_Document_ChangeNS_CompareP"
                                + "         ,[OfficeAutomation_Document_ChangeNS_HandleDate] = @OfficeAutomation_Document_ChangeNS_HandleDate"
                                + "         ,[OfficeAutomation_Document_ChangeNS_Others] = @OfficeAutomation_Document_ChangeNS_Others"
                                + "         ,[OfficeAutomation_Document_ChangeNS_Detailed] = @OfficeAutomation_Document_ChangeNS_Detailed"
                                + "         ,[OfficeAutomation_Document_ChangeNS_CNS] = @OfficeAutomation_Document_ChangeNS_CNS"
                                + "         ,[OfficeAutomation_Document_ChangeNS_Relationship] = @OfficeAutomation_Document_ChangeNS_Relationship"
                                + "         ,[OfficeAutomation_Document_ChangeNS_PriceChange] = @OfficeAutomation_Document_ChangeNS_PriceChange"
                                + "         ,[OfficeAutomation_Document_ChangeNS_CompareOfChange] = @OfficeAutomation_Document_ChangeNS_CompareOfChange"
                                + "         WHERE [OfficeAutomation_Document_ChangeNS_ID]=@OfficeAutomation_Document_ChangeNS_ID"
                                + "         AND [OfficeAutomation_Document_ChangeNS_MainID]=@OfficeAutomation_Document_ChangeNS_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_ChangeNS)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_Phone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_Phone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_Area", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_Area));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_Location", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_Location));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_Master", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_Master));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_Buyers", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_Buyers));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_IsContract", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_IsContract));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_IsCommission", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_IsCommission));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_CDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_CDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_SpecialApply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_SpecialApply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_PayWay", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_PayWay));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_WhoKeep", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_WhoKeep));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_SurePrice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_SurePrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_CompareP", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_CompareP));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_HandleDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_HandleDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_Others", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_Others));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_Detailed", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_Detailed));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_CNS", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_CNS));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_Relationship", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_Relationship));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_PriceChange", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_PriceChange));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_CompareOfChange", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_CompareOfChange));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ChangeNS_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ChangeNS_MainID));

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
