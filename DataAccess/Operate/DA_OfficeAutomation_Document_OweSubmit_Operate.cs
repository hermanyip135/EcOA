using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_OweSubmit_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_OweSubmit _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_OweSubmit]"
                                                        + "           ([OfficeAutomation_Document_OweSubmit_ID]"
                                                        + "           ,[OfficeAutomation_Document_OweSubmit_MainID]"
                                                        + "           ,[OfficeAutomation_Document_OweSubmit_Apply]"
                                                        + "           ,[OfficeAutomation_Document_OweSubmit_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_OweSubmit_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_OweSubmit_Department]"
                                                        + "           ,[OfficeAutomation_Document_OweSubmit_Subject]"
                                                        + "           ,[OfficeAutomation_Document_OweSubmit_ReplyPhone]"
                                                        + "           ,[OfficeAutomation_Document_OweSubmit_Name]"
                                                        + "           ,[OfficeAutomation_Document_OweSubmit_Branch]"
                                                        + "           ,[OfficeAutomation_Document_OweSubmit_Position]"
                                                        + "           ,[OfficeAutomation_Document_OweSubmit_InductionDate]"
                                                        + "           ,[OfficeAutomation_Document_OweSubmit_Detail]"
                                                        + "           ,[OfficeAutomation_Document_OweSubmit_Certificate]"
                                                        + "           ,[OfficeAutomation_Document_OweSubmit_Affiliated]"
                                                        + "           ,[OfficeAutomation_Document_OweSubmit_Why]"
                                                        + "           ,[OfficeAutomation_Document_OweSubmit_SupplementaryDate]"
                                                        + "           ,[OfficeAutomation_Document_OweSubmit_Opinion]"
                                                        + "           ,[OfficeAutomation_Document_OweSubmit_Hukouxz]"
                                                        + "           ,[OfficeAutomation_Document_OweSubmit_Hujidz]"
                                                        + "           ,[OfficeAutomation_Document_OweSubmit_HouseholderName])"
                                                        + "     VALUES"

                                                        + "           (@OfficeAutomation_Document_OweSubmit_ID"
                                                        + "           ,@OfficeAutomation_Document_OweSubmit_MainID"
                                                        + "           ,@OfficeAutomation_Document_OweSubmit_Apply"
                                                        + "           ,@OfficeAutomation_Document_OweSubmit_ApplyDate"
                                                        + "           ,@OfficeAutomation_Document_OweSubmit_ApplyID"
                                                        + "           ,@OfficeAutomation_Document_OweSubmit_Department"
                                                        + "           ,@OfficeAutomation_Document_OweSubmit_Subject"
                                                        + "           ,@OfficeAutomation_Document_OweSubmit_ReplyPhone"
                                                        + "           ,@OfficeAutomation_Document_OweSubmit_Name"
                                                        + "           ,@OfficeAutomation_Document_OweSubmit_Branch"
                                                        + "           ,@OfficeAutomation_Document_OweSubmit_Position"
                                                        + "           ,@OfficeAutomation_Document_OweSubmit_InductionDate"
                                                        + "           ,@OfficeAutomation_Document_OweSubmit_Detail"
                                                        + "           ,@OfficeAutomation_Document_OweSubmit_Certificate"
                                                        + "           ,@OfficeAutomation_Document_OweSubmit_Affiliated"
                                                        + "           ,@OfficeAutomation_Document_OweSubmit_Why"
                                                        + "           ,@OfficeAutomation_Document_OweSubmit_SupplementaryDate"
                                                        + "           ,@OfficeAutomation_Document_OweSubmit_Opinion"
                                                        + "           ,@OfficeAutomation_Document_OweSubmit_Hukouxz"
                                                        + "           ,@OfficeAutomation_Document_OweSubmit_Hujidz"
                                                        + "           ,@OfficeAutomation_Document_OweSubmit_HouseholderName)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_OweSubmit)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OweSubmit_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OweSubmit_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OweSubmit_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OweSubmit_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OweSubmit_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OweSubmit_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OweSubmit_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OweSubmit_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OweSubmit_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OweSubmit_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OweSubmit_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OweSubmit_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OweSubmit_Subject", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OweSubmit_Subject));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OweSubmit_ReplyPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OweSubmit_ReplyPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OweSubmit_Name", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OweSubmit_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OweSubmit_Branch", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OweSubmit_Branch));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OweSubmit_Position", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OweSubmit_Position));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OweSubmit_InductionDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OweSubmit_InductionDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OweSubmit_Detail", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OweSubmit_Detail));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OweSubmit_Certificate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OweSubmit_Certificate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OweSubmit_Affiliated", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OweSubmit_Affiliated));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OweSubmit_Why", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OweSubmit_Why));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OweSubmit_SupplementaryDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OweSubmit_SupplementaryDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OweSubmit_Opinion", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OweSubmit_Opinion));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OweSubmit_Hukouxz", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OweSubmit_Hukouxz));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OweSubmit_Hujidz", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OweSubmit_Hujidz));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OweSubmit_HouseholderName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OweSubmit_HouseholderName));

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
            cmdToExecute.CommandText = "dbo.[pr_OweSubmit_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_OweSubmit]"
                                                        + "     SET   [OfficeAutomation_Document_OweSubmit_ApplyID]=@OfficeAutomation_Document_OweSubmit_ApplyID"
                                                        + "            ,[OfficeAutomation_Document_OweSubmit_Department]=@OfficeAutomation_Document_OweSubmit_Department"
                                                        + "            ,[OfficeAutomation_Document_OweSubmit_Subject]=@OfficeAutomation_Document_OweSubmit_Subject"
                                                        + "            ,[OfficeAutomation_Document_OweSubmit_ReplyPhone]=@OfficeAutomation_Document_OweSubmit_ReplyPhone"
                                                        + "            ,[OfficeAutomation_Document_OweSubmit_Name]=@OfficeAutomation_Document_OweSubmit_Name"
                                                        + "            ,[OfficeAutomation_Document_OweSubmit_Branch]=@OfficeAutomation_Document_OweSubmit_Branch"
                                                        + "            ,[OfficeAutomation_Document_OweSubmit_Position]=@OfficeAutomation_Document_OweSubmit_Position"
                                                        + "            ,[OfficeAutomation_Document_OweSubmit_InductionDate]=@OfficeAutomation_Document_OweSubmit_InductionDate"
                                                        + "            ,[OfficeAutomation_Document_OweSubmit_Detail]=@OfficeAutomation_Document_OweSubmit_Detail"
                                                        + "            ,[OfficeAutomation_Document_OweSubmit_Certificate]=@OfficeAutomation_Document_OweSubmit_Certificate"
                                                        + "            ,[OfficeAutomation_Document_OweSubmit_Affiliated]=@OfficeAutomation_Document_OweSubmit_Affiliated"
                                                        + "            ,[OfficeAutomation_Document_OweSubmit_Why]=@OfficeAutomation_Document_OweSubmit_Why"
                                                        + "            ,[OfficeAutomation_Document_OweSubmit_SupplementaryDate]=@OfficeAutomation_Document_OweSubmit_SupplementaryDate"
                                                        + "            ,[OfficeAutomation_Document_OweSubmit_Opinion]=@OfficeAutomation_Document_OweSubmit_Opinion"
                                                        + "            ,[OfficeAutomation_Document_OweSubmit_Hukouxz]=@OfficeAutomation_Document_OweSubmit_Hukouxz"
                                                        + "            ,[OfficeAutomation_Document_OweSubmit_Hujidz]=@OfficeAutomation_Document_OweSubmit_Hujidz"
                                                        + "            ,[OfficeAutomation_Document_OweSubmit_HouseholderName]=@OfficeAutomation_Document_HouseholderName"
                                                        + " WHERE [OfficeAutomation_Document_OweSubmit_ID]=@OfficeAutomation_Document_OweSubmit_ID"
                                                        + "     AND [OfficeAutomation_Document_OweSubmit_MainID] = @OfficeAutomation_Document_OweSubmit_MainID";



            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_OweSubmit)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OweSubmit_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OweSubmit_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OweSubmit_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OweSubmit_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OweSubmit_Subject", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OweSubmit_Subject));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OweSubmit_ReplyPhone", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OweSubmit_ReplyPhone));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OweSubmit_Name", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OweSubmit_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OweSubmit_Branch", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OweSubmit_Branch));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OweSubmit_Position", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OweSubmit_Position));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OweSubmit_InductionDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OweSubmit_InductionDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OweSubmit_Detail", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OweSubmit_Detail));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OweSubmit_Certificate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OweSubmit_Certificate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OweSubmit_Affiliated", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OweSubmit_Affiliated));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OweSubmit_Why", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OweSubmit_Why));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OweSubmit_SupplementaryDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OweSubmit_SupplementaryDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OweSubmit_Opinion", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OweSubmit_Opinion));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OweSubmit_Hukouxz", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OweSubmit_Hukouxz));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OweSubmit_Hujidz", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OweSubmit_Hujidz));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_HouseholderName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OweSubmit_HouseholderName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OweSubmit_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OweSubmit_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OweSubmit_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OweSubmit_MainID));

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
