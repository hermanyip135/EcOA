using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_SysLogist_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_SysLogist _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SysLogist]"
                                                        + "           ([OfficeAutomation_Document_SysLogist_ID]"
                                                        + "           ,[OfficeAutomation_Document_SysLogist_MainID]"
                                                        + "           ,[OfficeAutomation_Document_SysLogist_DepartmentID]"
                                                        + "           ,[OfficeAutomation_Document_SysLogist_Department]"
                                                        + "           ,[OfficeAutomation_Document_SysLogist_Apply]"
                                                        + "           ,[OfficeAutomation_Document_SysLogist_ApplyDepHeader]"
                                                        + "           ,[OfficeAutomation_Document_SysLogist_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_SysLogist_HopeDate]"
                                                        + "           ,[OfficeAutomation_Document_SysLogist_SystemName]"
                                                        + "           ,[OfficeAutomation_Document_SysLogist_ReqContent])"
                //+ "           ,[OfficeAutomation_Document_SysLogist_Follower]"
                //+ "           ,[OfficeAutomation_Document_SysLogist_PlanTime])"
                                                        + "     VALUES"
                                                        + "           (@guidOfficeAutomation_Document_SysLogist_ID"
                                                        + "           ,@guidOfficeAutomation_Document_SysLogist_MainID"
                                                        + "           ,@guidOfficeAutomation_Document_SysLogist_DepartmentID"
                                                        + "           ,@sOfficeAutomation_Document_SysLogist_Department"
                                                        + "           ,@sOfficeAutomation_Document_SysLogist_Apply"
                                                        + "           ,@sOfficeAutomation_Document_SysLogist_ApplyDepHeader"
                                                        + "           ,@dtOfficeAutomation_Document_SysLogist_ApplyDate"
                                                        + "           ,@dtOfficeAutomation_Document_SysLogist_HopeDate"
                                                        + "           ,@sOfficeAutomation_Document_SysLogist_SystemName"
                                                        + "           ,@sOfficeAutomation_Document_SysLogist_ReqContent)";
            //+ "           ,@sOfficeAutomation_Document_SysLogist_Follower"
            //+ "           ,@sOfficeAutomation_Document_SysLogist_PlanTime)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_SysLogist)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_SysLogist_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysLogist_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_SysLogist_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysLogist_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_SysLogist_DepartmentID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysLogist_DepartmentID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_SysLogist_Department", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysLogist_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_SysLogist_Apply", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysLogist_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_SysLogist_ApplyDepHeader", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysLogist_ApplyDepHeader));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_SysLogist_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysLogist_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_SysLogist_HopeDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysLogist_HopeDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_SysLogist_SystemName", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysLogist_SystemName));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_SysLogist_ReqContent", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysLogist_ReqContent));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_SysLogist_Follower", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysLogist_Follower));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_SysLogist_PlanTime", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysLogist_PlanTime));

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
            cmdToExecute.CommandText = "dbo.[pr_SysLogist_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SysLogist]"
                                + "   SET [OfficeAutomation_Document_SysLogist_DepartmentID] = @guidOfficeAutomation_Document_SysLogist_DepartmentID"
                                + "         ,[OfficeAutomation_Document_SysLogist_Department] = @sOfficeAutomation_Document_SysLogist_Department"
                                + "         ,[OfficeAutomation_Document_SysLogist_Apply] = @sOfficeAutomation_Document_SysLogist_Apply"
                                + "         ,[OfficeAutomation_Document_SysLogist_ApplyDepHeader] = @sOfficeAutomation_Document_SysLogist_ApplyDepHeader"
                                + "         ,[OfficeAutomation_Document_SysLogist_ApplyDate] = @dtOfficeAutomation_Document_SysLogist_ApplyDate"
                                + "         ,[OfficeAutomation_Document_SysLogist_HopeDate] = @dtOfficeAutomation_Document_SysLogist_HopeDate"
                                + "         ,[OfficeAutomation_Document_SysLogist_SystemName] = @sOfficeAutomation_Document_SysLogist_SystemName"
                                + "         ,[OfficeAutomation_Document_SysLogist_ReqContent] = @sOfficeAutomation_Document_SysLogist_ReqContent"
                //+ "         ,[OfficeAutomation_Document_SysLogist_Follower] = @sOfficeAutomation_Document_SysLogist_Follower"
                //+ "         ,[OfficeAutomation_Document_SysLogist_PlanTime] = @sOfficeAutomation_Document_SysLogist_PlanTime"
                                + " WHERE [OfficeAutomation_Document_SysLogist_ID]=@guidOfficeAutomation_Document_SysLogist_ID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_SysLogist)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_SysLogist_DepartmentID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysLogist_DepartmentID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_SysLogist_Department", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysLogist_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_SysLogist_Apply", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysLogist_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_SysLogist_ApplyDepHeader", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysLogist_ApplyDepHeader));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_SysLogist_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysLogist_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_SysLogist_HopeDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysLogist_HopeDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_SysLogist_SystemName", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysLogist_SystemName));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_SysLogist_ReqContent", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysLogist_ReqContent));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_SysLogist_Follower", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysLogist_Follower));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_SysLogist_PlanTime", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysLogist_PlanTime));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_SysLogist_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysLogist_ID));

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
