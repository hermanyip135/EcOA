using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_CPNShoot_Inherit:DA_OfficeAutomation_Document_CPNShoot_Operate
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_CPNShoot _objMessage = null;
        #endregion

        #region 签名时更新接单人等内容
        public bool UpdateForSign(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_CPNShoot]"
                                + "         SET [OfficeAutomation_Document_CPNShoot_MarketDepSuggestion] = @OfficeAutomation_Document_CPNShoot_MarketDepSuggestion"
                                + "         ,[OfficeAutomation_Document_CPNShoot_AcceptDate] = @OfficeAutomation_Document_CPNShoot_AcceptDate"
                                + "         ,[OfficeAutomation_Document_CPNShoot_Accepter] = @OfficeAutomation_Document_CPNShoot_Accepter"
                                + "         ,[OfficeAutomation_Document_CPNShoot_Producer] = @OfficeAutomation_Document_CPNShoot_Producer"
                                + "         ,[OfficeAutomation_Document_CPNShoot_ExpectDate] = @OfficeAutomation_Document_CPNShoot_ExpectDate"
                                + "         ,[OfficeAutomation_Document_CPNShoot_ExpectOnlineDate] = @OfficeAutomation_Document_CPNShoot_ExpectOnlineDate"
                                + "         WHERE [OfficeAutomation_Document_CPNShoot_ID]=@OfficeAutomation_Document_CPNShoot_ID"
                                + "         AND [OfficeAutomation_Document_CPNShoot_MainID]=@OfficeAutomation_Document_CPNShoot_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_CPNShoot)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CPNShoot_MarketDepSuggestion", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CPNShoot_MarketDepSuggestion));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CPNShoot_AcceptDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CPNShoot_AcceptDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CPNShoot_Accepter", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CPNShoot_Accepter));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CPNShoot_Producer", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CPNShoot_Producer));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CPNShoot_ExpectDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CPNShoot_ExpectDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CPNShoot_ExpectOnlineDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CPNShoot_ExpectOnlineDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CPNShoot_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CPNShoot_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CPNShoot_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CPNShoot_MainID));

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

        #region 更新完成情况
        /// <summary>
        /// 更新完成情况
        /// </summary>
        /// <param name="completeresult">完成结果（1是未完成，2是已完成）</param>
        /// <param name="nocompletedesc">未完成描述</param>
        /// <param name="id">主表id</param>
        /// <returns></returns>
        public bool updateCompleteResultByID(string completeresult,string nocompletedesc,string id)
        {
            string sql = "update t_OfficeAutomation_Document_CPNShoot set OfficeAutomation_Document_CPNShoot_CompleteResult='" + completeresult + "',OfficeAutomation_Document_CPNShoot_NoCompelteDescript='" + nocompletedesc + "' where OfficeAutomation_Document_CPNShoot_ID='" + id + "'";
            return RunNoneSQL(sql);
        }
        #endregion
    }
}
