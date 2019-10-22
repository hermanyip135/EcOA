using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_WirelessFixedLine_Detail_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_WirelessFixedLine_Detail _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_WirelessFixedLine_Detail]"
                                                        + "           ([OfficeAutomation_Document_WirelessFixedLine_Detail_ID]"
                                                        + "           ,[OfficeAutomation_Document_WirelessFixedLine_Detail_MainID]"
                                                        + "           ,[OfficeAutomation_Document_WirelessFixedLine_Detail_Division]"
                                                        + "           ,[OfficeAutomation_Document_WirelessFixedLine_Detail_Name]"
                                                        + "           ,[OfficeAutomation_Document_WirelessFixedLine_Detail_Number]"
                                                        + "           ,[OfficeAutomation_Document_WirelessFixedLine_Detail_Time]"
                                                        + "           ,[OfficeAutomation_Document_WirelessFixedLine_Detail_EndTime])"
                                                        + "     VALUES"
                                                        + "           (@sOfficeAutomation_Document_WirelessFixedLine_Detail_ID"
                                                        + "           ,@sOfficeAutomation_Document_WirelessFixedLine_Detail_MainID"
                                                        + "           ,@sOfficeAutomation_Document_WirelessFixedLine_Detail_Division"
                                                        + "           ,@sOfficeAutomation_Document_WirelessFixedLine_Detail_Name"
                                                        + "           ,@sOfficeAutomation_Document_WirelessFixedLine_Detail_Number"
                                                        + "           ,@sOfficeAutomation_Document_WirelessFixedLine_Detail_Time"
                                                        + "           ,@sOfficeAutomation_Document_WirelessFixedLine_Detail_EndTime)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_WirelessFixedLine_Detail)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_WirelessFixedLine_Detail_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WirelessFixedLine_Detail_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_WirelessFixedLine_Detail_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WirelessFixedLine_Detail_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_WirelessFixedLine_Detail_Division", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WirelessFixedLine_Detail_Division));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_WirelessFixedLine_Detail_Name", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WirelessFixedLine_Detail_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_WirelessFixedLine_Detail_Number", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WirelessFixedLine_Detail_Number));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_WirelessFixedLine_Detail_Time", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WirelessFixedLine_Detail_Time));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_WirelessFixedLine_Detail_EndTime", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WirelessFixedLine_Detail_EndTime));

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

            cmdToExecute.CommandText = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_WirelessFixedLine_Detail]"
                                + " WHERE [OfficeAutomation_Document_WirelessFixedLine_Detail_MainID]=@sOfficeAutomation_Document_WirelessFixedLine_Detail_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_WirelessFixedLine_Detail_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, new Guid(mainID)));

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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_WirelessFixedLine_Detail]"
                                                        + "     SET  [OfficeAutomation_Document_WirelessFixedLine_Detail_Division]=@sOfficeAutomation_Document_WirelessFixedLine_Detail_Division"
                                                        + "            ,[OfficeAutomation_Document_WirelessFixedLine_Detail_Name]=@sOfficeAutomation_Document_WirelessFixedLine_Detail_Name"
                                                        + "            ,[OfficeAutomation_Document_WirelessFixedLine_Detail_Number]=@sOfficeAutomation_Document_WirelessFixedLine_Detail_Number"
                                                        + "            ,[OfficeAutomation_Document_WirelessFixedLine_Detail_Time]=@sOfficeAutomation_Document_WirelessFixedLine_Detail_Time"
                                                        + "            ,[OfficeAutomation_Document_WirelessFixedLine_Detail_EndTime]=@sOfficeAutomation_Document_WirelessFixedLine_Detail_EndTime"
                                                        + " WHERE [OfficeAutomation_Document_WirelessFixedLine_Detail_ID]=@sOfficeAutomation_Document_WirelessFixedLine_Detail_ID"
                                                        + "     AND [OfficeAutomation_Document_WirelessFixedLine_Detail_MainID] = @sOfficeAutomation_Document_WirelessFixedLine_Detail_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_WirelessFixedLine_Detail)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_WirelessFixedLine_Detail_Division", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WirelessFixedLine_Detail_Division));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_WirelessFixedLine_Detail_Name", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WirelessFixedLine_Detail_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_WirelessFixedLine_Detail_Number", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WirelessFixedLine_Detail_Number));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_WirelessFixedLine_Detail_Time", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WirelessFixedLine_Detail_Time));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_WirelessFixedLine_Detail_EndTime", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WirelessFixedLine_Detail_EndTime));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_WirelessFixedLine_Detail_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WirelessFixedLine_Detail_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_WirelessFixedLine_Detail_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_WirelessFixedLine_Detail_MainID));

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
