using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_SysPower_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_SysPower _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SysPower]"
                                                        + "           ([OfficeAutomation_Document_SysPower_ID]"
                                                        + "           ,[OfficeAutomation_Document_SysPower_MainID]"
                                                        + "           ,[OfficeAutomation_Document_SysPower_DepartmentID]"
                                                        + "           ,[OfficeAutomation_Document_SysPower_Department]"
                                                        + "           ,[OfficeAutomation_Document_SysPower_Apply]"
                                                        + "           ,[OfficeAutomation_Document_SysPower_Phone]"
                                                        + "           ,[OfficeAutomation_Document_SysPower_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_SysPower_ReqContent]"
                                                        + "           ,[OfficeAutomation_Document_SysPower_Deal])"
                                                        + "     VALUES"
                                                        + "           (@guidOfficeAutomation_Document_SysPower_ID"
                                                        + "           ,@guidOfficeAutomation_Document_SysPower_MainID"
                                                        + "           ,@guidOfficeAutomation_Document_SysPower_DepartmentID"
                                                        + "           ,@sOfficeAutomation_Document_SysPower_Department"
                                                        + "           ,@sOfficeAutomation_Document_SysPower_Apply"
                                                        + "           ,@sOfficeAutomation_Document_SysPower_Phone"
                                                        + "           ,@dtOfficeAutomation_Document_SysPower_ApplyDate"
                                                        + "           ,@sOfficeAutomation_Document_SysPower_ReqContent"
                                                        + "           ,@sOfficeAutomation_Document_SysPower_Deal)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_SysPower)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_SysPower_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysPower_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_SysPower_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysPower_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_SysPower_DepartmentID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysPower_DepartmentID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_SysPower_Department", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysPower_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_SysPower_Apply", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysPower_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_SysPower_Phone", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysPower_Phone));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_SysPower_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysPower_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_SysPower_ReqContent", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysPower_ReqContent));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_SysPower_Deal", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysPower_Deal));
              
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
            cmdToExecute.CommandText = "dbo.[pr_SysPower_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SysPower]"
                                + "   SET [OfficeAutomation_Document_SysPower_DepartmentID] = @guidOfficeAutomation_Document_SysPower_DepartmentID"
                                + "         ,[OfficeAutomation_Document_SysPower_Department] = @sOfficeAutomation_Document_SysPower_Department"
                                + "         ,[OfficeAutomation_Document_SysPower_Apply] = @sOfficeAutomation_Document_SysPower_Apply"
                                + "         ,[OfficeAutomation_Document_SysPower_Phone] = @sOfficeAutomation_Document_SysPower_Phone"
                                + "         ,[OfficeAutomation_Document_SysPower_ApplyDate] = @dtOfficeAutomation_Document_SysPower_ApplyDate"
                                + "         ,[OfficeAutomation_Document_SysPower_ReqContent] = @sOfficeAutomation_Document_SysPower_ReqContent"
                                + "         ,[OfficeAutomation_Document_SysPower_Deal] = @sOfficeAutomation_Document_SysPower_Deal"
                                + " WHERE [OfficeAutomation_Document_SysPower_ID]=@guidOfficeAutomation_Document_SysPower_ID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_SysPower)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_SysPower_DepartmentID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysPower_DepartmentID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_SysPower_Department", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysPower_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_SysPower_Apply", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysPower_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_SysPower_Phone", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysPower_Phone));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_SysPower_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysPower_ApplyDate));
               cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_SysPower_ReqContent", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysPower_ReqContent));
               cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_SysPower_Deal", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysPower_Deal));
               cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_SysPower_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysPower_ID));
                
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
