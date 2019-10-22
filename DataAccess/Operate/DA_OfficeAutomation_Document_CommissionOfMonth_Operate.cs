using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_CommissionOfMonth_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_CommissionOfMonth _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_CommissionOfMonth]"
                                                        + "           ([OfficeAutomation_Document_CommissionOfMonth_ID]"
                                                        + "           ,[OfficeAutomation_Document_CommissionOfMonth_MainID]"
                                                        + "           ,[OfficeAutomation_Document_CommissionOfMonth_Apply]"
                                                        + "           ,[OfficeAutomation_Document_CommissionOfMonth_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_CommissionOfMonth_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_CommissionOfMonth_Department]"
                                                        + "           ,[OfficeAutomation_Document_CommissionOfMonth_Name]"
                                                        + "           ,[OfficeAutomation_Document_CommissionOfMonth_Code]"
                                                        + "           ,[OfficeAutomation_Document_CommissionOfMonth_EnterDate]"
                                                        + "           ,[OfficeAutomation_Document_CommissionOfMonth_Position]"
                                                        + "           ,[OfficeAutomation_Document_CommissionOfMonth_Rank]"
                                                        + "           ,[OfficeAutomation_Document_CommissionOfMonth_Results]"
                                                        + "           ,[OfficeAutomation_Document_CommissionOfMonth_Describe])"
                                                        + " VALUES"
                                                        + "           (@OfficeAutomation_Document_CommissionOfMonth_ID"
                                                        + "           ,@OfficeAutomation_Document_CommissionOfMonth_MainID"
                                                        + "           ,@OfficeAutomation_Document_CommissionOfMonth_Apply"
                                                        + "           ,@OfficeAutomation_Document_CommissionOfMonth_ApplyDate"
                                                        + "           ,@OfficeAutomation_Document_CommissionOfMonth_ApplyID"
                                                        + "           ,@OfficeAutomation_Document_CommissionOfMonth_Department"
                                                        + "           ,@OfficeAutomation_Document_CommissionOfMonth_Name"
                                                        + "           ,@OfficeAutomation_Document_CommissionOfMonth_Code"
                                                        + "           ,@OfficeAutomation_Document_CommissionOfMonth_EnterDate"
                                                        + "           ,@OfficeAutomation_Document_CommissionOfMonth_Position"
                                                        + "           ,@OfficeAutomation_Document_CommissionOfMonth_Rank"
                                                        + "           ,@OfficeAutomation_Document_CommissionOfMonth_Results"
                                                        + "           ,@OfficeAutomation_Document_CommissionOfMonth_Describe)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_CommissionOfMonth)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionOfMonth_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionOfMonth_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionOfMonth_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionOfMonth_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionOfMonth_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionOfMonth_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionOfMonth_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionOfMonth_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionOfMonth_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionOfMonth_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionOfMonth_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionOfMonth_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionOfMonth_Name", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionOfMonth_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionOfMonth_Code", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionOfMonth_Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionOfMonth_EnterDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionOfMonth_EnterDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionOfMonth_Position", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionOfMonth_Position));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionOfMonth_Rank", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionOfMonth_Rank));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionOfMonth_Results", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionOfMonth_Results));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionOfMonth_Describe", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionOfMonth_Describe));

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
            cmdToExecute.CommandText = "dbo.[pr_CommissionOfMonth_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_CommissionOfMonth]"
                                + "         SET [OfficeAutomation_Document_CommissionOfMonth_ApplyID] = @OfficeAutomation_Document_CommissionOfMonth_ApplyID"
                                + "         ,[OfficeAutomation_Document_CommissionOfMonth_Department] = @OfficeAutomation_Document_CommissionOfMonth_Department"
                                + "         ,[OfficeAutomation_Document_CommissionOfMonth_Name] = @OfficeAutomation_Document_CommissionOfMonth_Name"
                                + "         ,[OfficeAutomation_Document_CommissionOfMonth_Code] = @OfficeAutomation_Document_CommissionOfMonth_Code"
                                + "         ,[OfficeAutomation_Document_CommissionOfMonth_EnterDate] = @OfficeAutomation_Document_CommissionOfMonth_EnterDate"
                                + "         ,[OfficeAutomation_Document_CommissionOfMonth_Position] = @OfficeAutomation_Document_CommissionOfMonth_Position"
                                + "         ,[OfficeAutomation_Document_CommissionOfMonth_Rank] = @OfficeAutomation_Document_CommissionOfMonth_Rank"
                                + "         ,[OfficeAutomation_Document_CommissionOfMonth_Results] = @OfficeAutomation_Document_CommissionOfMonth_Results"
                                + "         ,[OfficeAutomation_Document_CommissionOfMonth_Describe] = @OfficeAutomation_Document_CommissionOfMonth_Describe"
                                + "         WHERE [OfficeAutomation_Document_CommissionOfMonth_ID]=@OfficeAutomation_Document_CommissionOfMonth_ID"
                                + "         AND [OfficeAutomation_Document_CommissionOfMonth_MainID]=@OfficeAutomation_Document_CommissionOfMonth_MainID";



            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_CommissionOfMonth)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionOfMonth_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionOfMonth_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionOfMonth_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionOfMonth_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionOfMonth_Name", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionOfMonth_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionOfMonth_Code", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionOfMonth_Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionOfMonth_EnterDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionOfMonth_EnterDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionOfMonth_Position", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionOfMonth_Position));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionOfMonth_Rank", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionOfMonth_Rank));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionOfMonth_Results", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionOfMonth_Results));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionOfMonth_Describe", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionOfMonth_Describe));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionOfMonth_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionOfMonth_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionOfMonth_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionOfMonth_MainID));

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
