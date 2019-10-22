using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SqlClient;
using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Tourism_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_Tourism _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Tourism]"
                                                        + "           ([OfficeAutomation_Document_Tourism_ID]"
                                                        + "           ,[OfficeAutomation_Document_Tourism_MainID]"
                                                        + "           ,[OfficeAutomation_Document_Tourism_Apply]"
                                                        + "           ,[OfficeAutomation_Document_Tourism_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_Tourism_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_Tourism_Department]"
                                                        + "           ,[OfficeAutomation_Document_Tourism_Subject]"
                                                        + "           ,[OfficeAutomation_Document_Tourism_ReplyPhone]"
                                                        + "           ,[OfficeAutomation_Document_Tourism_Reason]"
                                                        + "           ,[OfficeAutomation_Document_Tourism_ActivityData]"
                                                        + "           ,[OfficeAutomation_Document_Tourism_ActivityEndData]"
                                                        + "           ,[OfficeAutomation_Document_Tourism_ActivityPlace]"
                                                        + "           ,[OfficeAutomation_Document_Tourism_Insurance]"
                                                        + "           ,[OfficeAutomation_Document_Tourism_NoInsurance]"
                                                        + "           ,[OfficeAutomation_Document_Tourism_Operating]"
                                                        + "           ,[OfficeAutomation_Document_Tourism_OperatingArrange]"
                                                        + "           ,[OfficeAutomation_Document_Tourism_Area]"
                                                        + "           ,[OfficeAutomation_Document_Tourism_Organizer]"
                                                        + "           ,[OfficeAutomation_Document_Tourism_OtherMemo]"
                                                        + "           ,[OfficeAutomation_Document_Tourism_Attendance])"
                                                        + " VALUES"
                                                        + "           (@OfficeAutomation_Document_Tourism_ID"
                                                        + "           ,@OfficeAutomation_Document_Tourism_MainID"
                                                        + "           ,@OfficeAutomation_Document_Tourism_Apply"
                                                        + "           ,@OfficeAutomation_Document_Tourism_ApplyDate"
                                                        + "           ,@OfficeAutomation_Document_Tourism_ApplyID"
                                                        + "           ,@OfficeAutomation_Document_Tourism_Department"
                                                        + "           ,@OfficeAutomation_Document_Tourism_Subject"
                                                        + "           ,@OfficeAutomation_Document_Tourism_ReplyPhone"
                                                        + "           ,@OfficeAutomation_Document_Tourism_Reason"
                                                        + "           ,@OfficeAutomation_Document_Tourism_ActivityData"
                                                        + "           ,@OfficeAutomation_Document_Tourism_ActivityEndData"
                                                        + "           ,@OfficeAutomation_Document_Tourism_ActivityPlace"
                                                        + "           ,@OfficeAutomation_Document_Tourism_Insurance"
                                                        + "           ,@OfficeAutomation_Document_Tourism_NoInsurance"
                                                        + "           ,@OfficeAutomation_Document_Tourism_Operating"
                                                        + "           ,@OfficeAutomation_Document_Tourism_OperatingArrange"
                                                        + "           ,@OfficeAutomation_Document_Tourism_Area"
                                                        + "           ,@OfficeAutomation_Document_Tourism_Organizer"
                                                        + "           ,@OfficeAutomation_Document_Tourism_OtherMemo"
                                                        + "           ,@OfficeAutomation_Document_Tourism_Attendance)";



            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_Tourism)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Tourism_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Tourism_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Tourism_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Tourism_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Tourism_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Tourism_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Tourism_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Tourism_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Tourism_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Tourism_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Tourism_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Tourism_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Tourism_Subject", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Tourism_Subject));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Tourism_ReplyPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Tourism_ReplyPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Tourism_Reason", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Tourism_Reason));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Tourism_ActivityData", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Tourism_ActivityData));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Tourism_ActivityEndData", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Tourism_ActivityEndData));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Tourism_ActivityPlace", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Tourism_ActivityPlace));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Tourism_Insurance", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Tourism_Insurance));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Tourism_NoInsurance", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Tourism_NoInsurance));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Tourism_Operating", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Tourism_Operating));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Tourism_OperatingArrange", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Tourism_OperatingArrange));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Tourism_Area", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Tourism_Area));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Tourism_Organizer", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Tourism_Organizer));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Tourism_OtherMemo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Tourism_OtherMemo));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Tourism_Attendance", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Tourism_Attendance));

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
            cmdToExecute.CommandText = "dbo.[pr_Tourism_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Tourism]"
                                + "         SET [OfficeAutomation_Document_Tourism_ApplyID] = @OfficeAutomation_Document_Tourism_ApplyID"
                                + "         ,[OfficeAutomation_Document_Tourism_Department] = @OfficeAutomation_Document_Tourism_Department"
                                + "         ,[OfficeAutomation_Document_Tourism_Subject] = @OfficeAutomation_Document_Tourism_Subject"
                                + "         ,[OfficeAutomation_Document_Tourism_ReplyPhone] = @OfficeAutomation_Document_Tourism_ReplyPhone"
                                + "         ,[OfficeAutomation_Document_Tourism_Reason] = @OfficeAutomation_Document_Tourism_Reason"
                                + "         ,[OfficeAutomation_Document_Tourism_ActivityData] = @OfficeAutomation_Document_Tourism_ActivityData"
                                + "         ,[OfficeAutomation_Document_Tourism_ActivityEndData] = @OfficeAutomation_Document_Tourism_ActivityEndData"
                                + "         ,[OfficeAutomation_Document_Tourism_ActivityPlace] = @OfficeAutomation_Document_Tourism_ActivityPlace"
                                + "         ,[OfficeAutomation_Document_Tourism_Insurance] = @OfficeAutomation_Document_Tourism_Insurance"
                                + "         ,[OfficeAutomation_Document_Tourism_NoInsurance] = @OfficeAutomation_Document_Tourism_NoInsurance"
                                + "         ,[OfficeAutomation_Document_Tourism_Operating] = @OfficeAutomation_Document_Tourism_Operating"
                                + "         ,[OfficeAutomation_Document_Tourism_OperatingArrange] = @OfficeAutomation_Document_Tourism_OperatingArrange"
                                + "         ,[OfficeAutomation_Document_Tourism_Area] = @OfficeAutomation_Document_Tourism_Area"
                                + "         ,[OfficeAutomation_Document_Tourism_Organizer] = @OfficeAutomation_Document_Tourism_Organizer"
                                + "         ,[OfficeAutomation_Document_Tourism_OtherMemo] = @OfficeAutomation_Document_Tourism_OtherMemo"
                                + "         ,[OfficeAutomation_Document_Tourism_Attendance] = @OfficeAutomation_Document_Tourism_Attendance"
                                + "         WHERE [OfficeAutomation_Document_Tourism_ID]=@OfficeAutomation_Document_Tourism_ID"
                                + "         AND [OfficeAutomation_Document_Tourism_MainID]=@OfficeAutomation_Document_Tourism_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_Tourism)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Tourism_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Tourism_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Tourism_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Tourism_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Tourism_Subject", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Tourism_Subject));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Tourism_ReplyPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Tourism_ReplyPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Tourism_Reason", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Tourism_Reason));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Tourism_ActivityData", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Tourism_ActivityData));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Tourism_ActivityEndData", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Tourism_ActivityEndData));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Tourism_ActivityPlace", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Tourism_ActivityPlace));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Tourism_Insurance", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Tourism_Insurance));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Tourism_NoInsurance", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Tourism_NoInsurance));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Tourism_Operating", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Tourism_Operating));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Tourism_OperatingArrange", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Tourism_OperatingArrange));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Tourism_Area", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Tourism_Area));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Tourism_Attendance", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Tourism_Attendance));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Tourism_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Tourism_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Tourism_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Tourism_MainID));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Tourism_Organizer", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Tourism_Organizer));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Tourism_OtherMemo", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Tourism_OtherMemo));

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
