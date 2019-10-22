using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_OpenProve_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_OpenProve _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_OpenProve]"
                                                        + "           ([OfficeAutomation_Document_OpenProve_ID]"
                                                        + "           ,[OfficeAutomation_Document_OpenProve_MainID]"
                                                        + "           ,[OfficeAutomation_Document_OpenProve_Apply]"
                                                        + "           ,[OfficeAutomation_Document_OpenProve_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_OpenProve_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_OpenProve_Department]"
                                                        + "           ,[OfficeAutomation_Document_OpenProve_Code]"
                                                        + "           ,[OfficeAutomation_Document_OpenProve_Name]"
                                                        + "           ,[OfficeAutomation_Document_OpenProve_EnterDate]"
                                                        + "           ,[OfficeAutomation_Document_OpenProve_Position]"
                                                        + "           ,[OfficeAutomation_Document_OpenProve_Rank])"
                                                        + " VALUES"
                                                        + "           (@OfficeAutomation_Document_OpenProve_ID"
                                                        + "           ,@OfficeAutomation_Document_OpenProve_MainID"
                                                        + "           ,@OfficeAutomation_Document_OpenProve_Apply"
                                                        + "           ,@OfficeAutomation_Document_OpenProve_ApplyDate"
                                                        + "           ,@OfficeAutomation_Document_OpenProve_ApplyID"
                                                        + "           ,@OfficeAutomation_Document_OpenProve_Department"
                                                        + "           ,@OfficeAutomation_Document_OpenProve_Code"
                                                        + "           ,@OfficeAutomation_Document_OpenProve_Name"
                                                        + "           ,@OfficeAutomation_Document_OpenProve_EnterDate"
                                                        + "           ,@OfficeAutomation_Document_OpenProve_Position"
                                                        + "           ,@OfficeAutomation_Document_OpenProve_Rank)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_OpenProve)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OpenProve_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OpenProve_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OpenProve_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OpenProve_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OpenProve_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OpenProve_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OpenProve_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OpenProve_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OpenProve_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OpenProve_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OpenProve_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OpenProve_Department));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OpenProve_Code", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OpenProve_Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OpenProve_Name", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OpenProve_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OpenProve_EnterDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OpenProve_EnterDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OpenProve_Position", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OpenProve_Position));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OpenProve_Rank", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OpenProve_Rank));

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
            cmdToExecute.CommandText = "dbo.[pr_OpenProve_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_OpenProve]"
                                + "         SET [OfficeAutomation_Document_OpenProve_ApplyID] = @OfficeAutomation_Document_OpenProve_ApplyID"
                                + "         ,[OfficeAutomation_Document_OpenProve_Department] = @OfficeAutomation_Document_OpenProve_Department"
                                + "         ,[OfficeAutomation_Document_OpenProve_Code] = @OfficeAutomation_Document_OpenProve_Code"
                                + "         ,[OfficeAutomation_Document_OpenProve_Name] = @OfficeAutomation_Document_OpenProve_Name"
                                + "         ,[OfficeAutomation_Document_OpenProve_EnterDate] = @OfficeAutomation_Document_OpenProve_EnterDate"
                                + "         ,[OfficeAutomation_Document_OpenProve_Position] = @OfficeAutomation_Document_OpenProve_Position"
                                + "         ,[OfficeAutomation_Document_OpenProve_Rank] = @OfficeAutomation_Document_OpenProve_Rank"
                                + "         WHERE [OfficeAutomation_Document_OpenProve_ID]=@OfficeAutomation_Document_OpenProve_ID"
                                + "         AND [OfficeAutomation_Document_OpenProve_MainID]=@OfficeAutomation_Document_OpenProve_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_OpenProve)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OpenProve_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OpenProve_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OpenProve_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OpenProve_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OpenProve_Code", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OpenProve_Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OpenProve_Name", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OpenProve_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OpenProve_EnterDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OpenProve_EnterDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OpenProve_Position", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OpenProve_Position));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OpenProve_Rank", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OpenProve_Rank));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OpenProve_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OpenProve_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_OpenProve_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_OpenProve_MainID));

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
