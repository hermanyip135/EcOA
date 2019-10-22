using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_CostOfActivity_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_CostOfActivity _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_CostOfActivity]"
                                                        + "           ([OfficeAutomation_Document_CostOfActivity_ID]"
                                                        + "           ,[OfficeAutomation_Document_CostOfActivity_MainID]"
                                                        + "           ,[OfficeAutomation_Document_CostOfActivity_Apply]"
                                                        + "           ,[OfficeAutomation_Document_CostOfActivity_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_CostOfActivity_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_CostOfActivity_Department]"
                                                        + "           ,[OfficeAutomation_Document_CostOfActivity_Phone]"
                                                        + "           ,[OfficeAutomation_Document_CostOfActivity_Subject]"
                                                        + "           ,[OfficeAutomation_Document_CostOfActivity_InDepartment]"
                                                        + "           ,[OfficeAutomation_Document_CostOfActivity_Area]"
                                                        + "           ,[OfficeAutomation_Document_CostOfActivity_Year]"
                                                        + "           ,[OfficeAutomation_Document_CostOfActivity_Man1]"
                                                        + "           ,[OfficeAutomation_Document_CostOfActivity_Fear1]"
                                                        + "           ,[OfficeAutomation_Document_CostOfActivity_Man2]"
                                                        + "           ,[OfficeAutomation_Document_CostOfActivity_Fear2]"
                                                        + "           ,[OfficeAutomation_Document_CostOfActivity_Man3]"
                                                        + "           ,[OfficeAutomation_Document_CostOfActivity_Fear3]"
                                                        + "           ,[OfficeAutomation_Document_CostOfActivity_Man4]"
                                                        + "           ,[OfficeAutomation_Document_CostOfActivity_Fear4]"
                                                        + "           ,[OfficeAutomation_Document_CostOfActivity_Man5]"
                                                        + "           ,[OfficeAutomation_Document_CostOfActivity_Fear5]"
                                                        + "           ,[OfficeAutomation_Document_CostOfActivity_Man6]"
                                                        + "           ,[OfficeAutomation_Document_CostOfActivity_Fear6]"
                                                         + "           ,[OfficeAutomation_Document_CostOfActivity_Cycle]"
                                                        + "           ,[OfficeAutomation_Document_CostOfActivity_Summary])"
                                                        + " VALUES"
                                                        + "           (@OfficeAutomation_Document_CostOfActivity_ID"
                                                        + "           ,@OfficeAutomation_Document_CostOfActivity_MainID"
                                                        + "           ,@OfficeAutomation_Document_CostOfActivity_Apply"
                                                        + "           ,@OfficeAutomation_Document_CostOfActivity_ApplyDate"
                                                        + "           ,@OfficeAutomation_Document_CostOfActivity_ApplyID"
                                                        + "           ,@OfficeAutomation_Document_CostOfActivity_Department"
                                                        + "           ,@OfficeAutomation_Document_CostOfActivity_Phone"
                                                        + "           ,@OfficeAutomation_Document_CostOfActivity_Subject"
                                                        + "           ,@OfficeAutomation_Document_CostOfActivity_InDepartment"
                                                        + "           ,@OfficeAutomation_Document_CostOfActivity_Area"
                                                        + "           ,@OfficeAutomation_Document_CostOfActivity_Year"
                                                        + "           ,@OfficeAutomation_Document_CostOfActivity_Man1"
                                                        + "           ,@OfficeAutomation_Document_CostOfActivity_Fear1"
                                                        + "           ,@OfficeAutomation_Document_CostOfActivity_Man2"
                                                        + "           ,@OfficeAutomation_Document_CostOfActivity_Fear2"
                                                        + "           ,@OfficeAutomation_Document_CostOfActivity_Man3"
                                                        + "           ,@OfficeAutomation_Document_CostOfActivity_Fear3"
                                                        + "           ,@OfficeAutomation_Document_CostOfActivity_Man4"
                                                        + "           ,@OfficeAutomation_Document_CostOfActivity_Fear4"
                                                        + "           ,@OfficeAutomation_Document_CostOfActivity_Man5"
                                                        + "           ,@OfficeAutomation_Document_CostOfActivity_Fear5"
                                                        + "           ,@OfficeAutomation_Document_CostOfActivity_Man6"
                                                        + "           ,@OfficeAutomation_Document_CostOfActivity_Fear6"
                                                        + "           ,@OfficeAutomation_Document_CostOfActivity_Cycle"
                                                        + "           ,@OfficeAutomation_Document_CostOfActivity_Summary)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_CostOfActivity)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_Phone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_Phone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_Subject", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_Subject));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_InDepartment", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_InDepartment));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_Area", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_Area));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_Year", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_Year));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_Man1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_Man1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_Fear1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_Fear1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_Man2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_Man2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_Fear2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_Fear2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_Man3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_Man3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_Fear3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_Fear3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_Man4", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_Man4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_Fear4", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_Fear4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_Man5", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_Man5));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_Fear5", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_Fear5));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_Man6", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_Man6));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_Fear6", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_Fear6));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_Cycle", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_Cycle));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_Summary", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_Summary));

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
            cmdToExecute.CommandText = "dbo.[pr_CostOfActivity_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_CostOfActivity]"
                                + "         SET [OfficeAutomation_Document_CostOfActivity_ApplyID] = @OfficeAutomation_Document_CostOfActivity_ApplyID"
                                + "         ,[OfficeAutomation_Document_CostOfActivity_Department] = @OfficeAutomation_Document_CostOfActivity_Department"
                                + "         ,[OfficeAutomation_Document_CostOfActivity_Phone] = @OfficeAutomation_Document_CostOfActivity_Phone"
                                + "         ,[OfficeAutomation_Document_CostOfActivity_Subject] = @OfficeAutomation_Document_CostOfActivity_Subject"
                                + "         ,[OfficeAutomation_Document_CostOfActivity_InDepartment] = @OfficeAutomation_Document_CostOfActivity_InDepartment"
                                + "         ,[OfficeAutomation_Document_CostOfActivity_Area] = @OfficeAutomation_Document_CostOfActivity_Area"
                                + "         ,[OfficeAutomation_Document_CostOfActivity_Year] = @OfficeAutomation_Document_CostOfActivity_Year"
                                + "         ,[OfficeAutomation_Document_CostOfActivity_Man1] = @OfficeAutomation_Document_CostOfActivity_Man1"
                                + "         ,[OfficeAutomation_Document_CostOfActivity_Fear1] = @OfficeAutomation_Document_CostOfActivity_Fear1"
                                + "         ,[OfficeAutomation_Document_CostOfActivity_Man2] = @OfficeAutomation_Document_CostOfActivity_Man2"
                                + "         ,[OfficeAutomation_Document_CostOfActivity_Fear2] = @OfficeAutomation_Document_CostOfActivity_Fear2"
                                + "         ,[OfficeAutomation_Document_CostOfActivity_Man3] = @OfficeAutomation_Document_CostOfActivity_Man3"
                                + "         ,[OfficeAutomation_Document_CostOfActivity_Fear3] = @OfficeAutomation_Document_CostOfActivity_Fear3"
                                + "         ,[OfficeAutomation_Document_CostOfActivity_Man4] = @OfficeAutomation_Document_CostOfActivity_Man4"
                                + "         ,[OfficeAutomation_Document_CostOfActivity_Fear4] = @OfficeAutomation_Document_CostOfActivity_Fear4"
                                + "         ,[OfficeAutomation_Document_CostOfActivity_Man5] = @OfficeAutomation_Document_CostOfActivity_Man5"
                                + "         ,[OfficeAutomation_Document_CostOfActivity_Fear5] = @OfficeAutomation_Document_CostOfActivity_Fear5"
                                + "         ,[OfficeAutomation_Document_CostOfActivity_Man6] = @OfficeAutomation_Document_CostOfActivity_Man6"
                                + "         ,[OfficeAutomation_Document_CostOfActivity_Fear6] = @OfficeAutomation_Document_CostOfActivity_Fear6"
                                 + "         ,[OfficeAutomation_Document_CostOfActivity_Cycle] = @OfficeAutomation_Document_CostOfActivity_Cycle"
                                + "         ,[OfficeAutomation_Document_CostOfActivity_Summary] = @OfficeAutomation_Document_CostOfActivity_Summary"
                                + "         WHERE [OfficeAutomation_Document_CostOfActivity_ID]=@OfficeAutomation_Document_CostOfActivity_ID"
                                + "         AND [OfficeAutomation_Document_CostOfActivity_MainID]=@OfficeAutomation_Document_CostOfActivity_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_CostOfActivity)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_Phone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_Phone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_Subject", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_Subject));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_InDepartment", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_InDepartment));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_Area", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_Area));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_Year", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_Year));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_Man1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_Man1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_Fear1", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_Fear1));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_Man2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_Man2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_Fear2", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_Fear2));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_Man3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_Man3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_Fear3", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_Fear3));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_Man4", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_Man4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_Fear4", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_Fear4));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_Man5", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_Man5));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_Fear5", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_Fear5));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_Man6", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_Man6));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_Fear6", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_Fear6));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_Cycle", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_Cycle));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_Summary", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_Summary));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CostOfActivity_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CostOfActivity_MainID));

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
