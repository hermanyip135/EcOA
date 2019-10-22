using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_ITSpecialModify_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_ITSpecialModify _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ITSpecialModify]"
                                                        + "           ([OfficeAutomation_Document_ITSpecialModify_ID]"
                                                        + "           ,[OfficeAutomation_Document_ITSpecialModify_MainID]"
                                                        + "           ,[OfficeAutomation_Document_ITSpecialModify_DepartmentID]"
                                                        + "           ,[OfficeAutomation_Document_ITSpecialModify_Department]"
                                                        + "           ,[OfficeAutomation_Document_ITSpecialModify_Apply]"
                                                        + "           ,[OfficeAutomation_Document_ITSpecialModify_ApplyDepHeader]"
                                                        + "           ,[OfficeAutomation_Document_ITSpecialModify_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_ITSpecialModify_HopeDate]"
                                                        + "           ,[OfficeAutomation_Document_ITSpecialModify_SystemName]"
                                                        + "           ,[OfficeAutomation_Document_ITSpecialModify_ReqContent])"
                //+ "           ,[OfficeAutomation_Document_ITSpecialModify_Follower]"
                //+ "           ,[OfficeAutomation_Document_ITSpecialModify_PlanTime])"
                                                        + "     VALUES"
                                                        + "           (@guidOfficeAutomation_Document_ITSpecialModify_ID"
                                                        + "           ,@guidOfficeAutomation_Document_ITSpecialModify_MainID"
                                                        + "           ,@guidOfficeAutomation_Document_ITSpecialModify_DepartmentID"
                                                        + "           ,@sOfficeAutomation_Document_ITSpecialModify_Department"
                                                        + "           ,@sOfficeAutomation_Document_ITSpecialModify_Apply"
                                                        + "           ,@sOfficeAutomation_Document_ITSpecialModify_ApplyDepHeader"
                                                        + "           ,@dtOfficeAutomation_Document_ITSpecialModify_ApplyDate"
                                                        + "           ,@dtOfficeAutomation_Document_ITSpecialModify_HopeDate"
                                                        + "           ,@sOfficeAutomation_Document_ITSpecialModify_SystemName"
                                                        + "           ,@sOfficeAutomation_Document_ITSpecialModify_ReqContent)";
            //+ "           ,@sOfficeAutomation_Document_ITSpecialModify_Follower"
            //+ "           ,@sOfficeAutomation_Document_ITSpecialModify_PlanTime)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_ITSpecialModify)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_ITSpecialModify_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITSpecialModify_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_ITSpecialModify_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITSpecialModify_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_ITSpecialModify_DepartmentID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITSpecialModify_DepartmentID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITSpecialModify_Department", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITSpecialModify_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITSpecialModify_Apply", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITSpecialModify_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITSpecialModify_ApplyDepHeader", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITSpecialModify_ApplyDepHeader));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_ITSpecialModify_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITSpecialModify_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_ITSpecialModify_HopeDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITSpecialModify_HopeDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITSpecialModify_SystemName", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITSpecialModify_SystemName));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITSpecialModify_ReqContent", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITSpecialModify_ReqContent));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITSpecialModify_Follower", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITSpecialModify_Follower));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITSpecialModify_PlanTime", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITSpecialModify_PlanTime));

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
            cmdToExecute.CommandText = "dbo.[pr_ITSpecialModify_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ITSpecialModify]"
                                + "   SET [OfficeAutomation_Document_ITSpecialModify_DepartmentID] = @guidOfficeAutomation_Document_ITSpecialModify_DepartmentID"
                                + "         ,[OfficeAutomation_Document_ITSpecialModify_Department] = @sOfficeAutomation_Document_ITSpecialModify_Department"
                                + "         ,[OfficeAutomation_Document_ITSpecialModify_Apply] = @sOfficeAutomation_Document_ITSpecialModify_Apply"
                                + "         ,[OfficeAutomation_Document_ITSpecialModify_ApplyDepHeader] = @sOfficeAutomation_Document_ITSpecialModify_ApplyDepHeader"
                                + "         ,[OfficeAutomation_Document_ITSpecialModify_ApplyDate] = @dtOfficeAutomation_Document_ITSpecialModify_ApplyDate"
                                + "         ,[OfficeAutomation_Document_ITSpecialModify_HopeDate] = @dtOfficeAutomation_Document_ITSpecialModify_HopeDate"
                                + "         ,[OfficeAutomation_Document_ITSpecialModify_SystemName] = @sOfficeAutomation_Document_ITSpecialModify_SystemName"
                                + "         ,[OfficeAutomation_Document_ITSpecialModify_ReqContent] = @sOfficeAutomation_Document_ITSpecialModify_ReqContent"
                //+ "         ,[OfficeAutomation_Document_ITSpecialModify_Follower] = @sOfficeAutomation_Document_ITSpecialModify_Follower"
                //+ "         ,[OfficeAutomation_Document_ITSpecialModify_PlanTime] = @sOfficeAutomation_Document_ITSpecialModify_PlanTime"
                                + " WHERE [OfficeAutomation_Document_ITSpecialModify_ID]=@guidOfficeAutomation_Document_ITSpecialModify_ID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_ITSpecialModify)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_ITSpecialModify_DepartmentID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITSpecialModify_DepartmentID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITSpecialModify_Department", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITSpecialModify_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITSpecialModify_Apply", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITSpecialModify_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITSpecialModify_ApplyDepHeader", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITSpecialModify_ApplyDepHeader));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_ITSpecialModify_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITSpecialModify_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Document_ITSpecialModify_HopeDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITSpecialModify_HopeDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITSpecialModify_SystemName", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITSpecialModify_SystemName));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITSpecialModify_ReqContent", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITSpecialModify_ReqContent));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITSpecialModify_Follower", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITSpecialModify_Follower));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_ITSpecialModify_PlanTime", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITSpecialModify_PlanTime));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_ITSpecialModify_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITSpecialModify_ID));

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
