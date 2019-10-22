using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_SysReq_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_SysReq _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SysReq]"
                                                        + "           ([OfficeAutomation_Document_SysReq_ID]"
                                                        + "           ,[OfficeAutomation_Document_SysReq_MainID]"
                                                        + "           ,[OfficeAutomation_Document_SysReq_DepartmentID]"
                                                        + "           ,[OfficeAutomation_Document_SysReq_Department]"
                                                        + "           ,[OfficeAutomation_Document_SysReq_Apply]"
                                                        + "           ,[OfficeAutomation_Document_SysReq_ApplyDepHeader]"
                                                        + "           ,[OfficeAutomation_Document_SysReq_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_SysReq_HopeDate]"
                                                        + "           ,[OfficeAutomation_Document_SysReq_SystemName]"
                                                        + "           ,[OfficeAutomation_Document_SysReq_ReqContent])"
                                                        //+ "           ,[OfficeAutomation_Document_SysReq_Follower]"
                                                        //+ "           ,[OfficeAutomation_Document_SysReq_PlanTime])"
                                                        + "     VALUES"
                                                        + "           (@guidOfficeAutomation_Document_SysReq_ID"
                                                        + "           ,@guidOfficeAutomation_Document_SysReq_MainID"
                                                        + "           ,@guidOfficeAutomation_Document_SysReq_DepartmentID"
                                                        + "           ,@sOfficeAutomation_Document_SysReq_Department"
                                                        + "           ,@sOfficeAutomation_Document_SysReq_Apply"
                                                        + "           ,@sOfficeAutomation_Document_SysReq_ApplyDepHeader"
                                                        + "           ,@dtOfficeAutomation_Document_SysReq_ApplyDate"
                                                        + "           ,@dtOfficeAutomation_Document_SysReq_HopeDate"
                                                        + "           ,@sOfficeAutomation_Document_SysReq_SystemName"
                                                        + "           ,@sOfficeAutomation_Document_SysReq_ReqContent)";
                                                        //+ "           ,@sOfficeAutomation_Document_SysReq_Follower"
                                                        //+ "           ,@sOfficeAutomation_Document_SysReq_PlanTime)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_SysReq)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_SysReq_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysReq_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_SysReq_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysReq_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_SysReq_DepartmentID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysReq_DepartmentID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_SysReq_Department", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysReq_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_SysReq_Apply", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysReq_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_SysReq_ApplyDepHeader", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysReq_ApplyDepHeader));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_SysReq_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysReq_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_SysReq_HopeDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysReq_HopeDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_SysReq_SystemName", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysReq_SystemName));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_SysReq_ReqContent", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysReq_ReqContent));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_SysReq_Follower", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysReq_Follower));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_SysReq_PlanTime", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysReq_PlanTime));

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
            cmdToExecute.CommandText = "dbo.[pr_SysReq_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SysReq]"
                                + "   SET [OfficeAutomation_Document_SysReq_DepartmentID] = @guidOfficeAutomation_Document_SysReq_DepartmentID"
                                + "         ,[OfficeAutomation_Document_SysReq_Department] = @sOfficeAutomation_Document_SysReq_Department"
                                + "         ,[OfficeAutomation_Document_SysReq_Apply] = @sOfficeAutomation_Document_SysReq_Apply"
                                + "         ,[OfficeAutomation_Document_SysReq_ApplyDepHeader] = @sOfficeAutomation_Document_SysReq_ApplyDepHeader"
                                + "         ,[OfficeAutomation_Document_SysReq_ApplyDate] = @dtOfficeAutomation_Document_SysReq_ApplyDate"
                                + "         ,[OfficeAutomation_Document_SysReq_HopeDate] = @dtOfficeAutomation_Document_SysReq_HopeDate"
                                + "         ,[OfficeAutomation_Document_SysReq_SystemName] = @sOfficeAutomation_Document_SysReq_SystemName"
                                + "         ,[OfficeAutomation_Document_SysReq_ReqContent] = @sOfficeAutomation_Document_SysReq_ReqContent"
                                //+ "         ,[OfficeAutomation_Document_SysReq_Follower] = @sOfficeAutomation_Document_SysReq_Follower"
                                //+ "         ,[OfficeAutomation_Document_SysReq_PlanTime] = @sOfficeAutomation_Document_SysReq_PlanTime"
                                + " WHERE [OfficeAutomation_Document_SysReq_ID]=@guidOfficeAutomation_Document_SysReq_ID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_SysReq)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_SysReq_DepartmentID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysReq_DepartmentID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_SysReq_Department", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysReq_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_SysReq_Apply", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysReq_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_SysReq_ApplyDepHeader", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysReq_ApplyDepHeader));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_SysReq_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysReq_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_SysReq_HopeDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysReq_HopeDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_SysReq_SystemName", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysReq_SystemName));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_SysReq_ReqContent", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysReq_ReqContent));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_SysReq_Follower", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysReq_Follower));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_SysReq_PlanTime", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysReq_PlanTime));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_SysReq_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SysReq_ID));
                
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
