using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_WrongSave_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_WrongSave _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_WrongSave]"
                                                        + "           ([OfficeAutomation_Document_WrongSave_ID]"
                                                        + "           ,[OfficeAutomation_Document_WrongSave_MainID]"
                                                        + "           ,[OfficeAutomation_Document_WrongSave_Apply]"
                                                        + "           ,[OfficeAutomation_Document_WrongSave_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_WrongSave_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_WrongSave_Department]"
                                                        + "           ,[OfficeAutomation_Document_WrongSave_Address]"
                                                        + "           ,[OfficeAutomation_Document_WrongSave_ADNo]"
                                                        + "           ,[OfficeAutomation_Document_WrongSave_WSDate]"
                                                        + "           ,[OfficeAutomation_Document_WrongSave_KindOfM]"
                                                        + "           ,[OfficeAutomation_Document_WrongSave_BigSMoney]"
                                                        + "           ,[OfficeAutomation_Document_WrongSave_SmallSMoney]"
                                                        + "           ,[OfficeAutomation_Document_WrongSave_KindOfWS]"
                                                        + "           ,[OfficeAutomation_Document_WrongSave_KindOfWSA]"
                                                        + "           ,[OfficeAutomation_Document_WrongSave_KindOfWSB]"
                                                        + "           ,[OfficeAutomation_Document_WrongSave_KindOfWSC]"
                                                        + "           ,[OfficeAutomation_Document_WrongSave_KindOfWSD]"
                                                        + "           ,[OfficeAutomation_Document_WrongSave_KShouldS]"
                                                        + "           ,[OfficeAutomation_Document_WrongSave_KShouldSA]"
                                                        + "           ,[OfficeAutomation_Document_WrongSave_KShouldSB]"
                                                        + "           ,[OfficeAutomation_Document_WrongSave_KShouldSC]"
                                                        + "           ,[OfficeAutomation_Document_WrongSave_KShouldSD]"
                                                        + "           ,[OfficeAutomation_Document_WrongSave_Wname]"
                                                        + "           ,[OfficeAutomation_Document_WrongSave_Wposition]"
                                                        + "           ,[OfficeAutomation_Document_WrongSave_PayeeNum]"
                                                        + "           ,[OfficeAutomation_Document_WrongSave_PayeeBankName]"
                                                        + "           ,[OfficeAutomation_Document_WrongSave_PayeeName]"
                                                        + "           ,[OfficeAutomation_Document_WrongSave_Opinion])"
                                                        + " VALUES"
                                                        + "           (@OfficeAutomation_Document_WrongSave_ID"
                                                        + "           ,@OfficeAutomation_Document_WrongSave_MainID"
                                                        + "           ,@OfficeAutomation_Document_WrongSave_Apply"
                                                        + "           ,@OfficeAutomation_Document_WrongSave_ApplyDate"
                                                        + "           ,@OfficeAutomation_Document_WrongSave_ApplyID"
                                                        + "           ,@OfficeAutomation_Document_WrongSave_Department"
                                                        + "           ,@OfficeAutomation_Document_WrongSave_Address"
                                                        + "           ,@OfficeAutomation_Document_WrongSave_ADNo"
                                                        + "           ,@OfficeAutomation_Document_WrongSave_WSDate"
                                                        + "           ,@OfficeAutomation_Document_WrongSave_KindOfM"
                                                        + "           ,@OfficeAutomation_Document_WrongSave_BigSMoney"
                                                        + "           ,@OfficeAutomation_Document_WrongSave_SmallSMoney"
                                                        + "           ,@OfficeAutomation_Document_WrongSave_KindOfWS"
                                                        + "           ,@OfficeAutomation_Document_WrongSave_KindOfWSA"
                                                        + "           ,@OfficeAutomation_Document_WrongSave_KindOfWSB"
                                                        + "           ,@OfficeAutomation_Document_WrongSave_KindOfWSC"
                                                        + "           ,@OfficeAutomation_Document_WrongSave_KindOfWSD"
                                                        + "           ,@OfficeAutomation_Document_WrongSave_KShouldS"
                                                        + "           ,@OfficeAutomation_Document_WrongSave_KShouldSA"
                                                        + "           ,@OfficeAutomation_Document_WrongSave_KShouldSB"
                                                        + "           ,@OfficeAutomation_Document_WrongSave_KShouldSC"
                                                        + "           ,@OfficeAutomation_Document_WrongSave_KShouldSD"
                                                        + "           ,@OfficeAutomation_Document_WrongSave_Wname"
                                                        + "           ,@OfficeAutomation_Document_WrongSave_Wposition"
                                                        + "           ,@OfficeAutomation_Document_WrongSave_PayeeNum"
                                                        + "           ,@OfficeAutomation_Document_WrongSave_PayeeBankName"
                                                        + "           ,@OfficeAutomation_Document_WrongSave_PayeeName"
                                                        + "           ,@OfficeAutomation_Document_WrongSave_Opinion)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_WrongSave)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_Department));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_Address", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_Address));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_ADNo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_ADNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_WSDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_WSDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_KindOfM", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_KindOfM));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_BigSMoney", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_BigSMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_SmallSMoney", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_SmallSMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_KindOfWS", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_KindOfWS));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_KindOfWSA", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_KindOfWSA));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_KindOfWSB", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_KindOfWSB));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_KindOfWSC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_KindOfWSC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_KindOfWSD", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_KindOfWSD));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_KShouldS", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_KShouldS));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_KShouldSA", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_KShouldSA));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_KShouldSB", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_KShouldSB));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_KShouldSC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_KShouldSC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_KShouldSD", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_KShouldSD));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_Wname", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_Wname));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_Wposition", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_Wposition));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_PayeeNum", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_PayeeNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_PayeeBankName", SqlDbType.NVarChar, 60, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_PayeeBankName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_PayeeName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_PayeeName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_Opinion", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_Opinion));

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
            cmdToExecute.CommandText = "dbo.[pr_WrongSave_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_WrongSave]"
                                + "         SET [OfficeAutomation_Document_WrongSave_ApplyID] = @OfficeAutomation_Document_WrongSave_ApplyID"
                                + "         ,[OfficeAutomation_Document_WrongSave_Department] = @OfficeAutomation_Document_WrongSave_Department"
                                + "         ,[OfficeAutomation_Document_WrongSave_Address] = @OfficeAutomation_Document_WrongSave_Address"
                                + "         ,[OfficeAutomation_Document_WrongSave_ADNo] = @OfficeAutomation_Document_WrongSave_ADNo"
                                + "         ,[OfficeAutomation_Document_WrongSave_WSDate] = @OfficeAutomation_Document_WrongSave_WSDate"
                                + "         ,[OfficeAutomation_Document_WrongSave_KindOfM] = @OfficeAutomation_Document_WrongSave_KindOfM"
                                + "         ,[OfficeAutomation_Document_WrongSave_BigSMoney] = @OfficeAutomation_Document_WrongSave_BigSMoney"
                                + "         ,[OfficeAutomation_Document_WrongSave_SmallSMoney] = @OfficeAutomation_Document_WrongSave_SmallSMoney"
                                + "         ,[OfficeAutomation_Document_WrongSave_KindOfWS] = @OfficeAutomation_Document_WrongSave_KindOfWS"
                                + "         ,[OfficeAutomation_Document_WrongSave_KindOfWSA] = @OfficeAutomation_Document_WrongSave_KindOfWSA"
                                + "         ,[OfficeAutomation_Document_WrongSave_KindOfWSB] = @OfficeAutomation_Document_WrongSave_KindOfWSB"
                                + "         ,[OfficeAutomation_Document_WrongSave_KindOfWSC] = @OfficeAutomation_Document_WrongSave_KindOfWSC"
                                + "         ,[OfficeAutomation_Document_WrongSave_KindOfWSD] = @OfficeAutomation_Document_WrongSave_KindOfWSD"
                                + "         ,[OfficeAutomation_Document_WrongSave_KShouldS] = @OfficeAutomation_Document_WrongSave_KShouldS"
                                + "         ,[OfficeAutomation_Document_WrongSave_KShouldSA] = @OfficeAutomation_Document_WrongSave_KShouldSA"
                                + "         ,[OfficeAutomation_Document_WrongSave_KShouldSB] = @OfficeAutomation_Document_WrongSave_KShouldSB"
                                + "         ,[OfficeAutomation_Document_WrongSave_KShouldSC] = @OfficeAutomation_Document_WrongSave_KShouldSC"
                                + "         ,[OfficeAutomation_Document_WrongSave_KShouldSD] = @OfficeAutomation_Document_WrongSave_KShouldSD"
                                + "         ,[OfficeAutomation_Document_WrongSave_Wname] = @OfficeAutomation_Document_WrongSave_Wname"
                                + "         ,[OfficeAutomation_Document_WrongSave_Wposition] = @OfficeAutomation_Document_WrongSave_Wposition"
                                + "         ,[OfficeAutomation_Document_WrongSave_PayeeNum] = @OfficeAutomation_Document_WrongSave_PayeeNum"
                                 + "         ,[OfficeAutomation_Document_WrongSave_PayeeBankName] = @OfficeAutomation_Document_WrongSave_PayeeBankName"
                                  + "         ,[OfficeAutomation_Document_WrongSave_PayeeName] = @OfficeAutomation_Document_WrongSave_PayeeName"
                                + "         ,[OfficeAutomation_Document_WrongSave_Opinion] = @OfficeAutomation_Document_WrongSave_Opinion"
                                + "         WHERE [OfficeAutomation_Document_WrongSave_ID]=@OfficeAutomation_Document_WrongSave_ID"
                                + "         AND [OfficeAutomation_Document_WrongSave_MainID]=@OfficeAutomation_Document_WrongSave_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_WrongSave)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_Address", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_Address));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_ADNo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_ADNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_WSDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_WSDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_KindOfM", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_KindOfM));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_BigSMoney", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_BigSMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_SmallSMoney", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_SmallSMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_KindOfWS", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_KindOfWS));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_KindOfWSA", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_KindOfWSA));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_KindOfWSB", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_KindOfWSB));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_KindOfWSC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_KindOfWSC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_KindOfWSD", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_KindOfWSD));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_KShouldS", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_KShouldS));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_KShouldSA", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_KShouldSA));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_KShouldSB", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_KShouldSB));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_KShouldSC", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_KShouldSC));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_KShouldSD", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_KShouldSD));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_Wname", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_Wname));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_Wposition", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_Wposition));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_PayeeNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_PayeeNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_PayeeBankName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_PayeeBankName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_PayeeName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_PayeeName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_Opinion", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_Opinion));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_WrongSave_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WrongSave_MainID));

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
