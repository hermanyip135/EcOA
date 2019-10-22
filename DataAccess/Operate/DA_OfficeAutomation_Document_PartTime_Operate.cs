using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_PartTime_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_PartTime _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_PartTime]"
                                                        + "           ([OfficeAutomation_Document_PartTime_ID]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_MainID]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_Apply]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_Department]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_1taC]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_2taC]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_3taC]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_4taC]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_5taC]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_6taC]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_7taC]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_8taC]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_9taC]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_DealOfficeTypeIDs]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_10taC]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_11taC]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_12taC]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_13taC]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_14taC]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_15taC]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_16taC]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_17taC]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_18taC]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_19taC]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_20taC]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_21taC]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_22taC]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_23taC]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_24taC]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_25taC]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_26taC]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_27taC]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_28taC]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_29taC]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_30taC]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_31taC]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_32taC]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_33taC]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_34taC]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_35taC]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_36taC]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_37taC]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_38taC]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_39taC]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_40taC]"
                                                        + "           ,[OfficeAutomation_Document_PartTime_41taC])"
                                                        + " VALUES"
                                                        + "           (@OfficeAutomation_Document_PartTime_ID"
                                                        + "           ,@OfficeAutomation_Document_PartTime_MainID"
                                                        + "           ,@OfficeAutomation_Document_PartTime_Apply"
                                                        + "           ,@OfficeAutomation_Document_PartTime_ApplyDate"
                                                        + "           ,@OfficeAutomation_Document_PartTime_ApplyID"
                                                        + "           ,@OfficeAutomation_Document_PartTime_Department"
                                                        + "           ,@OfficeAutomation_Document_PartTime_1taC"
                                                        + "           ,@OfficeAutomation_Document_PartTime_2taC"
                                                        + "           ,@OfficeAutomation_Document_PartTime_3taC"
                                                        + "           ,@OfficeAutomation_Document_PartTime_4taC"
                                                        + "           ,@OfficeAutomation_Document_PartTime_5taC"
                                                        + "           ,@OfficeAutomation_Document_PartTime_6taC"
                                                        + "           ,@OfficeAutomation_Document_PartTime_7taC"
                                                        + "           ,@OfficeAutomation_Document_PartTime_8taC"
                                                        + "           ,@OfficeAutomation_Document_PartTime_9taC"
                                                        + "           ,@OfficeAutomation_Document_PartTime_DealOfficeTypeIDs"
                                                        + "           ,@OfficeAutomation_Document_PartTime_10taC"
                                                        + "           ,@OfficeAutomation_Document_PartTime_11taC"
                                                        + "           ,@OfficeAutomation_Document_PartTime_12taC"
                                                        + "           ,@OfficeAutomation_Document_PartTime_13taC"
                                                        + "           ,@OfficeAutomation_Document_PartTime_14taC"
                                                        + "           ,@OfficeAutomation_Document_PartTime_15taC"
                                                        + "           ,@OfficeAutomation_Document_PartTime_16taC"
                                                        + "           ,@OfficeAutomation_Document_PartTime_17taC"
                                                        + "           ,@OfficeAutomation_Document_PartTime_18taC"
                                                        + "           ,@OfficeAutomation_Document_PartTime_19taC"
                                                        + "           ,@OfficeAutomation_Document_PartTime_20taC"
                                                        + "           ,@OfficeAutomation_Document_PartTime_21taC"
                                                        + "           ,@OfficeAutomation_Document_PartTime_22taC"
                                                        + "           ,@OfficeAutomation_Document_PartTime_23taC"
                                                        + "           ,@OfficeAutomation_Document_PartTime_24taC"
                                                        + "           ,@OfficeAutomation_Document_PartTime_25taC"
                                                        + "           ,@OfficeAutomation_Document_PartTime_26taC"
                                                        + "           ,@OfficeAutomation_Document_PartTime_27taC"
                                                        + "           ,@OfficeAutomation_Document_PartTime_28taC"
                                                        + "           ,@OfficeAutomation_Document_PartTime_29taC"
                                                        + "           ,@OfficeAutomation_Document_PartTime_30taC"
                                                        + "           ,@OfficeAutomation_Document_PartTime_31taC"
                                                        + "           ,@OfficeAutomation_Document_PartTime_32taC"
                                                        + "           ,@OfficeAutomation_Document_PartTime_33taC"
                                                        + "           ,@OfficeAutomation_Document_PartTime_34taC"
                                                        + "           ,@OfficeAutomation_Document_PartTime_35taC"
                                                        + "           ,@OfficeAutomation_Document_PartTime_36taC"
                                                        + "           ,@OfficeAutomation_Document_PartTime_37taC"
                                                        + "           ,@OfficeAutomation_Document_PartTime_38taC"
                                                        + "           ,@OfficeAutomation_Document_PartTime_39taC"
                                                        + "           ,@OfficeAutomation_Document_PartTime_40taC"
                                                        + "           ,@OfficeAutomation_Document_PartTime_41taC)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_PartTime)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_Department));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_1taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_1taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_2taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_2taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_3taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_3taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_4taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_4taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_5taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_5taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_6taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_6taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_7taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_7taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_8taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_8taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_9taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_9taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_DealOfficeTypeIDs", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_DealOfficeTypeIDs));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_10taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_10taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_11taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_11taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_12taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_12taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_13taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_13taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_14taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_14taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_15taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_15taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_16taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_16taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_17taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_17taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_18taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_18taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_19taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_19taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_20taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_20taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_21taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_21taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_22taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_22taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_23taC", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_23taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_24taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_24taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_25taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_25taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_26taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_26taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_27taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_27taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_28taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_28taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_29taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_29taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_30taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_30taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_31taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_31taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_32taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_32taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_33taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_33taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_34taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_34taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_35taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_35taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_36taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_36taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_37taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_37taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_38taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_38taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_39taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_39taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_40taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_40taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_41taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_41taC));

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
            cmdToExecute.CommandText = "dbo.[pr_PartTime_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_PartTime]"
                                + "         SET [OfficeAutomation_Document_PartTime_ApplyID] = @OfficeAutomation_Document_PartTime_ApplyID"
                                + "         ,[OfficeAutomation_Document_PartTime_Department] = @OfficeAutomation_Document_PartTime_Department"
                                + "         ,[OfficeAutomation_Document_PartTime_1taC] = @OfficeAutomation_Document_PartTime_1taC"
                                + "         ,[OfficeAutomation_Document_PartTime_2taC] = @OfficeAutomation_Document_PartTime_2taC"
                                + "         ,[OfficeAutomation_Document_PartTime_3taC] = @OfficeAutomation_Document_PartTime_3taC"
                                + "         ,[OfficeAutomation_Document_PartTime_4taC] = @OfficeAutomation_Document_PartTime_4taC"
                                + "         ,[OfficeAutomation_Document_PartTime_5taC] = @OfficeAutomation_Document_PartTime_5taC"
                                + "         ,[OfficeAutomation_Document_PartTime_6taC] = @OfficeAutomation_Document_PartTime_6taC"
                                + "         ,[OfficeAutomation_Document_PartTime_7taC] = @OfficeAutomation_Document_PartTime_7taC"
                                + "         ,[OfficeAutomation_Document_PartTime_8taC] = @OfficeAutomation_Document_PartTime_8taC"
                                + "         ,[OfficeAutomation_Document_PartTime_9taC] = @OfficeAutomation_Document_PartTime_9taC"
                                + "         ,[OfficeAutomation_Document_PartTime_DealOfficeTypeIDs] = @OfficeAutomation_Document_PartTime_DealOfficeTypeIDs"
                                + "         ,[OfficeAutomation_Document_PartTime_10taC] = @OfficeAutomation_Document_PartTime_10taC"
                                + "         ,[OfficeAutomation_Document_PartTime_11taC] = @OfficeAutomation_Document_PartTime_11taC"
                                + "         ,[OfficeAutomation_Document_PartTime_12taC] = @OfficeAutomation_Document_PartTime_12taC"
                                + "         ,[OfficeAutomation_Document_PartTime_13taC] = @OfficeAutomation_Document_PartTime_13taC"
                                + "         ,[OfficeAutomation_Document_PartTime_14taC] = @OfficeAutomation_Document_PartTime_14taC"
                                + "         ,[OfficeAutomation_Document_PartTime_15taC] = @OfficeAutomation_Document_PartTime_15taC"
                                + "         ,[OfficeAutomation_Document_PartTime_16taC] = @OfficeAutomation_Document_PartTime_16taC"
                                + "         ,[OfficeAutomation_Document_PartTime_17taC] = @OfficeAutomation_Document_PartTime_17taC"
                                + "         ,[OfficeAutomation_Document_PartTime_18taC] = @OfficeAutomation_Document_PartTime_18taC"
                                + "         ,[OfficeAutomation_Document_PartTime_19taC] = @OfficeAutomation_Document_PartTime_19taC"
                                + "         ,[OfficeAutomation_Document_PartTime_20taC] = @OfficeAutomation_Document_PartTime_20taC"
                                + "         ,[OfficeAutomation_Document_PartTime_21taC] = @OfficeAutomation_Document_PartTime_21taC"
                                + "         ,[OfficeAutomation_Document_PartTime_22taC] = @OfficeAutomation_Document_PartTime_22taC"
                                + "         ,[OfficeAutomation_Document_PartTime_23taC] = @OfficeAutomation_Document_PartTime_23taC"
                                + "         ,[OfficeAutomation_Document_PartTime_24taC] = @OfficeAutomation_Document_PartTime_24taC"
                                + "         ,[OfficeAutomation_Document_PartTime_25taC] = @OfficeAutomation_Document_PartTime_25taC"
                                + "         ,[OfficeAutomation_Document_PartTime_26taC] = @OfficeAutomation_Document_PartTime_26taC"
                                + "         ,[OfficeAutomation_Document_PartTime_27taC] = @OfficeAutomation_Document_PartTime_27taC"
                                + "         ,[OfficeAutomation_Document_PartTime_28taC] = @OfficeAutomation_Document_PartTime_28taC"
                                + "         ,[OfficeAutomation_Document_PartTime_29taC] = @OfficeAutomation_Document_PartTime_29taC"
                                + "         ,[OfficeAutomation_Document_PartTime_30taC] = @OfficeAutomation_Document_PartTime_30taC"
                                + "         ,[OfficeAutomation_Document_PartTime_31taC] = @OfficeAutomation_Document_PartTime_31taC"
                                + "         ,[OfficeAutomation_Document_PartTime_32taC] = @OfficeAutomation_Document_PartTime_32taC"
                                + "         ,[OfficeAutomation_Document_PartTime_33taC] = @OfficeAutomation_Document_PartTime_33taC"
                                + "         ,[OfficeAutomation_Document_PartTime_34taC] = @OfficeAutomation_Document_PartTime_34taC"
                                + "         ,[OfficeAutomation_Document_PartTime_35taC] = @OfficeAutomation_Document_PartTime_35taC"
                                + "         ,[OfficeAutomation_Document_PartTime_36taC] = @OfficeAutomation_Document_PartTime_36taC"
                                + "         ,[OfficeAutomation_Document_PartTime_37taC] = @OfficeAutomation_Document_PartTime_37taC"
                                + "         ,[OfficeAutomation_Document_PartTime_38taC] = @OfficeAutomation_Document_PartTime_38taC"
                                + "         ,[OfficeAutomation_Document_PartTime_39taC] = @OfficeAutomation_Document_PartTime_39taC"
                                + "         ,[OfficeAutomation_Document_PartTime_40taC] = @OfficeAutomation_Document_PartTime_40taC"
                                + "         ,[OfficeAutomation_Document_PartTime_41taC] = @OfficeAutomation_Document_PartTime_41taC"
                                + "         WHERE [OfficeAutomation_Document_PartTime_ID]=@OfficeAutomation_Document_PartTime_ID"
                                + "         AND [OfficeAutomation_Document_PartTime_MainID]=@OfficeAutomation_Document_PartTime_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_PartTime)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_Department));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_1taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_1taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_2taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_2taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_3taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_3taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_4taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_4taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_5taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_5taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_6taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_6taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_7taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_7taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_8taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_8taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_9taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_9taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_DealOfficeTypeIDs", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_DealOfficeTypeIDs));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_10taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_10taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_11taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_11taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_12taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_12taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_13taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_13taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_14taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_14taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_15taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_15taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_16taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_16taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_17taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_17taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_18taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_18taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_19taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_19taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_20taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_20taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_21taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_21taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_22taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_22taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_23taC", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_23taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_24taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_24taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_25taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_25taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_26taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_26taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_27taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_27taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_28taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_28taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_29taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_29taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_30taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_30taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_31taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_31taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_32taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_32taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_33taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_33taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_34taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_34taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_35taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_35taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_36taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_36taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_37taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_37taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_38taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_38taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_39taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_39taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_40taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_40taC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_41taC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_41taC));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_PartTime_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_PartTime_MainID));

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
