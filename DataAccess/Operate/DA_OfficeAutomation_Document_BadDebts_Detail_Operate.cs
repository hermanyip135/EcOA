using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_BadDebts_Detail_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_BadDebts_Detail _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_BadDebts_Detail]"
                                                        + "           ([OfficeAutomation_Document_BadDebts_Detail_ID]"
                                                        + "           ,[OfficeAutomation_Document_BadDebts_Detail_MainID]"
                                                        + "           ,[OfficeAutomation_Document_BadDebts_Detail_ReportID]"
                                                        + "           ,[OfficeAutomation_Document_BadDebts_Detail_Address]"
                                                        + "           ,[OfficeAutomation_Document_BadDebts_Detail_Owner]"
                                                        + "           ,[OfficeAutomation_Document_BadDebts_Detail_Client]"
                                                        + "           ,[OfficeAutomation_Document_BadDebts_Detail_OwnerBadMoney]"
                                                        + "           ,[OfficeAutomation_Document_BadDebts_Detail_ClientBadMoney]"
                                                        + "           ,[OfficeAutomation_Document_BadDebts_Detail_BadReason]"
                                                        + "           ,[OfficeAutomation_Document_BadDebts_Detail_IsSpecialAdjust]"
                                                        + "           ,[OfficeAutomation_Document_BadDebts_Detail_IsAutoBad]"
                                                        + "           ,[OfficeAutomation_Document_BadDebts_Detail_AutoBadDate]"
                                                        + "           ,[OfficeAutomation_Document_BadDebts_Detail_DealDate]"
                                                        + "           ,[OfficeAutomation_Document_BadDebts_Detail_BadDate]"
                                                        + "           ,[OfficeAutomation_Document_BadDebts_Detail_Area]"
                                                        + "           ,[OfficeAutomation_Document_BadDebts_Detail_No])"
                                                        + "     VALUES"
                                                        + "           (@guidOfficeAutomation_Document_BadDebts_Detail_ID"
                                                        + "           ,@guidOfficeAutomation_Document_BadDebts_Detail_MainID"
                                                        + "           ,@sOfficeAutomation_Document_BadDebts_Detail_ReportID"
                                                        + "           ,@sOfficeAutomation_Document_BadDebts_Detail_Address"
                                                        + "           ,@OfficeAutomation_Document_BadDebts_Detail_Owner"
                                                        + "           ,@OfficeAutomation_Document_BadDebts_Detail_Client"
                                                        + "           ,@dcmOfficeAutomation_Document_BadDebts_Detail_OwnerBadMoney"
                                                        + "           ,@dcmOfficeAutomation_Document_BadDebts_Detail_ClientBadMoney"
                                                        + "           ,@sOfficeAutomation_Document_BadDebts_Detail_BadReason"
                                                        + "           ,@bOfficeAutomation_Document_BadDebts_Detail_IsSpecialAdjust"
                                                        + "           ,@OfficeAutomation_Document_BadDebts_Detail_IsAutoBad"
                                                        + "           ,@OfficeAutomation_Document_BadDebts_Detail_AutoBadDate"
                                                        + "           ,@OfficeAutomation_Document_BadDebts_Detail_DealDate"
                                                        + "           ,@OfficeAutomation_Document_BadDebts_Detail_BadDate"
                                                        + "           ,@OfficeAutomation_Document_BadDebts_Detail_Area"
                                                        + "           ,@OfficeAutomation_Document_BadDebts_Detail_No)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_BadDebts_Detail)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_BadDebts_Detail_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_Detail_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_BadDebts_Detail_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_Detail_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BadDebts_Detail_ReportID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_Detail_ReportID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BadDebts_Detail_Address", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_Detail_Address));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BadDebts_Detail_Owner", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_Detail_Owner));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BadDebts_Detail_Client", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_Detail_Client));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcmOfficeAutomation_Document_BadDebts_Detail_OwnerBadMoney", SqlDbType.Decimal, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_Detail_OwnerBadMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcmOfficeAutomation_Document_BadDebts_Detail_ClientBadMoney", SqlDbType.Decimal, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_Detail_ClientBadMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BadDebts_Detail_BadReason", SqlDbType.NVarChar, System.Int32.MaxValue, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_Detail_BadReason));
                cmdToExecute.Parameters.Add(new SqlParameter("@bOfficeAutomation_Document_BadDebts_Detail_IsSpecialAdjust", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_Detail_IsSpecialAdjust));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BadDebts_Detail_IsAutoBad", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_Detail_IsAutoBad));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BadDebts_Detail_AutoBadDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_Detail_AutoBadDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BadDebts_Detail_DealDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_Detail_DealDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BadDebts_Detail_BadDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_Detail_BadDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BadDebts_Detail_Area", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_Detail_Area));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BadDebts_Detail_No", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_Detail_No));

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

            cmdToExecute.CommandText = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_BadDebts_Detail]"
                                + " WHERE [OfficeAutomation_Document_BadDebts_Detail_MainID]=@guidOfficeAutomation_Document_BadDebts_Detail_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_BadDebts_Detail_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, new Guid(mainID)));

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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_BadDebts_Detail]"
                                                        + "     SET  [OfficeAutomation_Document_BadDebts_Detail_ReportID]=@sOfficeAutomation_Document_BadDebts_Detail_ReportID"
                                                        + "            ,[OfficeAutomation_Document_BadDebts_Detail_Address]=@sOfficeAutomation_Document_BadDebts_Detail_Address"
                                                        + "            ,[OfficeAutomation_Document_BadDebts_Detail_Owner]=@OfficeAutomation_Document_BadDebts_Detail_Owner"
                                                        + "            ,[OfficeAutomation_Document_BadDebts_Detail_Client]=@OfficeAutomation_Document_BadDebts_Detail_Client"
                                                        + "            ,[OfficeAutomation_Document_BadDebts_Detail_OwnerBadMoney]=@dcmOfficeAutomation_Document_BadDebts_Detail_OwnerBadMoney"
                                                        + "            ,[OfficeAutomation_Document_BadDebts_Detail_ClientBadMoney]=@dcmOfficeAutomation_Document_BadDebts_Detail_ClientBadMoney"
                                                        + "            ,[OfficeAutomation_Document_BadDebts_Detail_BadReason]=@sOfficeAutomation_Document_BadDebts_Detail_BadReason"
                                                        + "            ,[OfficeAutomation_Document_BadDebts_Detail_IsSpecialAdjust]=@bOfficeAutomation_Document_BadDebts_Detail_IsSpecialAdjust"
                                                        + "            ,[OfficeAutomation_Document_BadDebts_Detail_IsAutoBad]=@OfficeAutomation_Document_BadDebts_Detail_IsAutoBad"
                                                        + "            ,[OfficeAutomation_Document_BadDebts_Detail_AutoBadDate]=@OfficeAutomation_Document_BadDebts_Detail_AutoBadDate"
                                                        + "            ,[OfficeAutomation_Document_BadDebts_Detail_DealDate]=@OfficeAutomation_Document_BadDebts_Detail_DealDate"
                                                        + "            ,[OfficeAutomation_Document_BadDebts_Detail_BadDate]=@OfficeAutomation_Document_BadDebts_Detail_BadDate"
                                                        + "            ,[OfficeAutomation_Document_BadDebts_Detail_Area]=@OfficeAutomation_Document_BadDebts_Detail_Area"
                                                        + "            ,[OfficeAutomation_Document_BadDebts_Detail_No]=@OfficeAutomation_Document_BadDebts_Detail_No"
                                                        + " WHERE [OfficeAutomation_Document_BadDebts_Detail_ID]=@guidOfficeAutomation_Document_BadDebts_Detail_ID"
                                                        + "     AND [OfficeAutomation_Document_BadDebts_Detail_MainID] = @guidOfficeAutomation_Document_BadDebts_Detail_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_BadDebts_Detail)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BadDebts_Detail_ReportID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_Detail_ReportID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BadDebts_Detail_Address", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_Detail_Address));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BadDebts_Detail_Owner", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_Detail_Owner));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BadDebts_Detail_Client", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_Detail_Client));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcmOfficeAutomation_Document_BadDebts_Detail_OwnerBadMoney", SqlDbType.Decimal, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_Detail_OwnerBadMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcmOfficeAutomation_Document_BadDebts_Detail_ClientBadMoney", SqlDbType.Decimal, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_Detail_ClientBadMoney));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_BadDebts_Detail_BadReason", SqlDbType.NVarChar, System.Int32.MaxValue, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_Detail_BadReason));
                cmdToExecute.Parameters.Add(new SqlParameter("@bOfficeAutomation_Document_BadDebts_Detail_IsSpecialAdjust", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_Detail_IsSpecialAdjust));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BadDebts_Detail_IsAutoBad", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_Detail_IsAutoBad));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BadDebts_Detail_AutoBadDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_Detail_AutoBadDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BadDebts_Detail_DealDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_Detail_DealDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BadDebts_Detail_BadDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_Detail_BadDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BadDebts_Detail_Area", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_Detail_Area));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_BadDebts_Detail_No", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_Detail_No));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_BadDebts_Detail_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_Detail_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_BadDebts_Detail_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_BadDebts_Detail_MainID));

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
