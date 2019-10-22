using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Budgetab_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_Budgetab _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Budgetab]"
                                                        + "           ([OfficeAutomation_Document_Budgetab_ID]"
                                                        + "           ,[OfficeAutomation_Document_Budgetab_MainID]"
                                                        + "           ,[OfficeAutomation_Document_Budgetab_Apply]"
                                                        + "           ,[OfficeAutomation_Document_Budgetab_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_Budgetab_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_Budgetab_Department]"
                                                        + "           ,[OfficeAutomation_Document_Budgetab_Phone]"
                                                        + "           ,[OfficeAutomation_Document_Budgetab_AProject]"
                                                        + "           ,[OfficeAutomation_Document_Budgetab_Akind]"
                                                        + "           ,[OfficeAutomation_Document_Budgetab_Aitem]"
                                                        + "           ,[OfficeAutomation_Document_Budgetab_AdjustableKind]"
                                                        + "           ,[OfficeAutomation_Document_Budgetab_AdjustableItem]"
                                                        + "           ,[OfficeAutomation_Document_Budgetab_Price]"
                                                        + "           ,[OfficeAutomation_Document_Budgetab_AdvertisingItem]"
                                                        + "           ,[OfficeAutomation_Document_Budgetab_AdvertisingPrice]"
                                                        + "           ,[OfficeAutomation_Document_Budgetab_PrintingItem]"
                                                        + "           ,[OfficeAutomation_Document_Budgetab_PrintingPrice]"
                                                        + "           ,[OfficeAutomation_Document_Budgetab_MaterialItem]"
                                                        + "           ,[OfficeAutomation_Document_Budgetab_MaterialPrice]"
                                                        + "           ,[OfficeAutomation_Document_Budgetab_ActivityItem]"
                                                        + "           ,[OfficeAutomation_Document_Budgetab_ActivityPrice]"
                                                        + "           ,[OfficeAutomation_Document_Budgetab_AnotherItem]"
                                                        + "           ,[OfficeAutomation_Document_Budgetab_AnotherPrice]"
                                                        + "           ,[OfficeAutomation_Document_Budgetab_Reason]"
                                                        + "           ,[OfficeAutomation_Document_Budgetab_Statement])"
                                                        + " VALUES"
                                                        + "           (@OfficeAutomation_Document_Budgetab_ID"
                                                        + "           ,@OfficeAutomation_Document_Budgetab_MainID"
                                                        + "           ,@OfficeAutomation_Document_Budgetab_Apply"
                                                        + "           ,@OfficeAutomation_Document_Budgetab_ApplyDate"
                                                        + "           ,@OfficeAutomation_Document_Budgetab_ApplyID"
                                                        + "           ,@OfficeAutomation_Document_Budgetab_Department"
                                                        + "           ,@OfficeAutomation_Document_Budgetab_Phone"
                                                        + "           ,@OfficeAutomation_Document_Budgetab_AProject"
                                                        + "           ,@OfficeAutomation_Document_Budgetab_Akind"
                                                        + "           ,@OfficeAutomation_Document_Budgetab_Aitem"
                                                        + "           ,@OfficeAutomation_Document_Budgetab_AdjustableKind"
                                                        + "           ,@OfficeAutomation_Document_Budgetab_AdjustableItem"
                                                        + "           ,@OfficeAutomation_Document_Budgetab_Price"
                                                        + "           ,@OfficeAutomation_Document_Budgetab_AdvertisingItem"
                                                        + "           ,@OfficeAutomation_Document_Budgetab_AdvertisingPrice"
                                                        + "           ,@OfficeAutomation_Document_Budgetab_PrintingItem"
                                                        + "           ,@OfficeAutomation_Document_Budgetab_PrintingPrice"
                                                        + "           ,@OfficeAutomation_Document_Budgetab_MaterialItem"
                                                        + "           ,@OfficeAutomation_Document_Budgetab_MaterialPrice"
                                                        + "           ,@OfficeAutomation_Document_Budgetab_ActivityItem"
                                                        + "           ,@OfficeAutomation_Document_Budgetab_ActivityPrice"
                                                        + "           ,@OfficeAutomation_Document_Budgetab_AnotherItem"
                                                        + "           ,@OfficeAutomation_Document_Budgetab_AnotherPrice"
                                                        + "           ,@OfficeAutomation_Document_Budgetab_Reason"
                                                        + "           ,@OfficeAutomation_Document_Budgetab_Statement)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_Budgetab)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_Department));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_Phone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_Phone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_AProject", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_AProject));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_Akind", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_Akind));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_Aitem", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_Aitem));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_AdjustableKind", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_AdjustableKind));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_AdjustableItem", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_AdjustableItem));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_Price", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_Price));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_AdvertisingItem", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_AdvertisingItem));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_AdvertisingPrice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_AdvertisingPrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_PrintingItem", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_PrintingItem));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_PrintingPrice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_PrintingPrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_MaterialItem", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_MaterialItem));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_MaterialPrice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_MaterialPrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_ActivityItem", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_ActivityItem));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_ActivityPrice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_ActivityPrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_AnotherItem", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_AnotherItem));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_AnotherPrice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_AnotherPrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_Reason", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_Reason));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_Statement", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_Statement));

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
            cmdToExecute.CommandText = "dbo.[pr_Budgetab_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Budgetab]"
                                + "         SET [OfficeAutomation_Document_Budgetab_ApplyID] = @OfficeAutomation_Document_Budgetab_ApplyID"
                                + "         ,[OfficeAutomation_Document_Budgetab_Department] = @OfficeAutomation_Document_Budgetab_Department"
                                + "         ,[OfficeAutomation_Document_Budgetab_Phone] = @OfficeAutomation_Document_Budgetab_Phone"
                                + "         ,[OfficeAutomation_Document_Budgetab_AProject] = @OfficeAutomation_Document_Budgetab_AProject"
                                + "         ,[OfficeAutomation_Document_Budgetab_Akind] = @OfficeAutomation_Document_Budgetab_Akind"
                                + "         ,[OfficeAutomation_Document_Budgetab_Aitem] = @OfficeAutomation_Document_Budgetab_Aitem"
                                + "         ,[OfficeAutomation_Document_Budgetab_AdjustableKind] = @OfficeAutomation_Document_Budgetab_AdjustableKind"
                                + "         ,[OfficeAutomation_Document_Budgetab_AdjustableItem] = @OfficeAutomation_Document_Budgetab_AdjustableItem"
                                + "         ,[OfficeAutomation_Document_Budgetab_Price] = @OfficeAutomation_Document_Budgetab_Price"
                                + "         ,[OfficeAutomation_Document_Budgetab_AdvertisingItem] = @OfficeAutomation_Document_Budgetab_AdvertisingItem"
                                + "         ,[OfficeAutomation_Document_Budgetab_AdvertisingPrice] = @OfficeAutomation_Document_Budgetab_AdvertisingPrice"
                                + "         ,[OfficeAutomation_Document_Budgetab_PrintingItem] = @OfficeAutomation_Document_Budgetab_PrintingItem"
                                + "         ,[OfficeAutomation_Document_Budgetab_PrintingPrice] = @OfficeAutomation_Document_Budgetab_PrintingPrice"
                                + "         ,[OfficeAutomation_Document_Budgetab_MaterialItem] = @OfficeAutomation_Document_Budgetab_MaterialItem"
                                + "         ,[OfficeAutomation_Document_Budgetab_MaterialPrice] = @OfficeAutomation_Document_Budgetab_MaterialPrice"
                                + "         ,[OfficeAutomation_Document_Budgetab_ActivityItem] = @OfficeAutomation_Document_Budgetab_ActivityItem"
                                + "         ,[OfficeAutomation_Document_Budgetab_ActivityPrice] = @OfficeAutomation_Document_Budgetab_ActivityPrice"
                                + "         ,[OfficeAutomation_Document_Budgetab_AnotherItem] = @OfficeAutomation_Document_Budgetab_AnotherItem"
                                + "         ,[OfficeAutomation_Document_Budgetab_AnotherPrice] = @OfficeAutomation_Document_Budgetab_AnotherPrice"
                                + "         ,[OfficeAutomation_Document_Budgetab_Reason] = @OfficeAutomation_Document_Budgetab_Reason"
                                + "         ,[OfficeAutomation_Document_Budgetab_Statement] = @OfficeAutomation_Document_Budgetab_Statement"
                                + "         WHERE [OfficeAutomation_Document_Budgetab_ID]=@OfficeAutomation_Document_Budgetab_ID"
                                + "         AND [OfficeAutomation_Document_Budgetab_MainID]=@OfficeAutomation_Document_Budgetab_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_Budgetab)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_Phone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_Phone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_AProject", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_AProject));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_Akind", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_Akind));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_Aitem", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_Aitem));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_AdjustableKind", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_AdjustableKind));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_AdjustableItem", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_AdjustableItem));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_Price", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_Price));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_AdvertisingItem", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_AdvertisingItem));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_AdvertisingPrice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_AdvertisingPrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_PrintingItem", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_PrintingItem));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_PrintingPrice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_PrintingPrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_MaterialItem", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_MaterialItem));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_MaterialPrice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_MaterialPrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_ActivityItem", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_ActivityItem));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_ActivityPrice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_ActivityPrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_AnotherItem", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_AnotherItem));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_AnotherPrice", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_AnotherPrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_Reason", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_Reason));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_Statement", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_Statement));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Budgetab_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Budgetab_MainID));

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
