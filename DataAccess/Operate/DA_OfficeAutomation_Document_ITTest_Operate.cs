using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_ITTest_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_ITTest _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ITTest]"
                                                        + "           ([OfficeAutomation_Document_ITTest_ID]"
                                                        + "           ,[OfficeAutomation_Document_ITTest_MainID]"
                                                        + "           ,[OfficeAutomation_Document_ITTest_Apply]"
                                                        + "           ,[OfficeAutomation_Document_ITTest_HopeDate]"
                                                        + "           ,[OfficeAutomation_Document_ITTest_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_ITTest_ReqContent]"
                                                        + "           ,[OfficeAutomation_Document_ITTest_ReqReply]"
                                                       // + "           ,[OfficeAutomation_Document_ITTest_ReqReplyDate]"
                                                        + "           ,[OfficeAutomation_Document_ITTest_SystemName]"
                                                        + "           ,[OfficeAutomation_Document_ITTest_DepartmentID]"
                                                        + "           ,[officeAutomation_Document_ITTest_Department]"
                                                        + "           ,[OfficeAutomation_Document_ITTest_Receiver])"
                                                        + "     VALUES"
                                                        + "           (@guidOfficeAutomation_Document_ITTest_ID"
                                                        + "           ,@guidOfficeAutomation_Document_ITTest_MainID"
                                                        + "           ,@OfficeAutomation_Document_ITTest_Apply"
                                                        + "           ,@OfficeAutomation_Document_ITTest_HopeDate"
                                                        + "           ,@OfficeAutomation_Document_ITTest_ApplyDate  "
                                                        + "           ,@OfficeAutomation_Document_ITTest_ReqContent"
                                                        + "           ,@OfficeAutomation_Document_ITTest_ReqReply"
                                                       // + "           ,@OfficeAutomation_Document_ITTest_ReqReplyDate"
                                                        + "           ,@OfficeAutomation_Document_ITTest_SystemName"
                                                        + "           ,@OfficeAutomation_Document_ITTest_DepartmentID"
                                                        + "           ,@officeAutomation_Document_ITTest_Department"
                                                        + "           ,@OfficeAutomation_Document_ITTest_Receiver)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_ITTest)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_ITTest_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITTest_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_ITTest_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITTest_MainID));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ITTest_Apply", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITTest_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ITTest_HopeDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITTest_HopeDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ITTest_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITTest_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ITTest_ReqContent", SqlDbType.NVarChar, 999999, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITTest_ReqContent));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ITTest_ReqReply", SqlDbType.NVarChar, 999999, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITTest_ReqReply));
             //   cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ITTest_ReqReplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITTest_ReqReplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ITTest_SystemName", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITTest_SystemName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ITTest_DepartmentID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITTest_DepartmentID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ITTest_Department", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITTest_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ITTest_Receiver", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITTest_Receiver));
            


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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ITTest]"
                                + "   SET [OfficeAutomation_Document_ITTest_Apply] =@OfficeAutomation_Document_ITTest_Apply"
                               // + "         ,[OfficeAutomation_Document_ITTest_HopeDate] = @OfficeAutomation_Document_ITTest_HopeDate"
                              //  + "         ,[OfficeAutomation_Document_ITTest_ApplyDate] = @OfficeAutomation_Document_ITTest_ApplyDate"
                                + "         ,[OfficeAutomation_Document_ITTest_ReqContent] = @OfficeAutomation_Document_ITTest_ReqContent"
                               // + "         ,[OfficeAutomation_Document_ITTest_ReqReply] = @OfficeAutomation_Document_ITTest_ReqReply"
                               // + "         ,[OfficeAutomation_Document_ITTest_ReqReplyDate] = @OfficeAutomation_Document_ITTest_ReqReplyDate"
                                + "         ,[OfficeAutomation_Document_ITTest_SystemName] = @OfficeAutomation_Document_ITTest_SystemName"
                                + "         ,[OfficeAutomation_Document_ITTest_DepartmentID] = @OfficeAutomation_Document_ITTest_DepartmentID"
                                + "         ,[OfficeAutomation_Document_ITTest_Department] = @OfficeAutomation_Document_ITTest_Department"
                                + "         ,[OfficeAutomation_Document_ITTest_Receiver] = @OfficeAutomation_Document_ITTest_Receiver"
                                + " WHERE [OfficeAutomation_Document_ITTest_ID]=@guidOfficeAutomation_Document_ITTest_ID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_ITTest)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_ITTest_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITTest_ID));
             //   cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_ITTest_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITTest_MainID));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ITTest_Apply", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITTest_Apply));
               // cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ITTest_HopeDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITTest_HopeDate));
              //  cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ITTest_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITTest_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ITTest_ReqContent", SqlDbType.NVarChar, 999999, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITTest_ReqContent));
              //  cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ITTest_ReqReply", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITTest_ReqReply));
              //  cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ITTest_ReqReplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITTest_ReqReplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ITTest_SystemName", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITTest_SystemName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ITTest_DepartmentID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITTest_DepartmentID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ITTest_Department", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITTest_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_ITTest_Receiver", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_ITTest_Receiver));

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

            cmdToExecute.CommandText = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ITTest]"
                                + " WHERE [OfficeAutomation_Document_ITTest_MainID]=@guidOfficeAutomation_Document_ITTest_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_ITTest_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, new Guid(mainID)));

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

        public bool DeleteByID(string ID)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_ITTest]"
                                + " WHERE [OfficeAutomation_Document_ITTest_ID]=@guidOfficeAutomation_Document_ITTest_ID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_ITTest_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, new Guid(ID)));

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
