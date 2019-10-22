using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Agent_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Agent _objMessage = null;
        #endregion

        #region 修改记录
        /// <summary>
        /// 修改记录
        /// </summary>
        /// <returns></returns>
        public override bool Update(object obj)
        {

            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = " UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Agent]"
                                                        + "       SET [OfficeAutomation_Agent_Agent] = @sOfficeAutomation_Agent_Agent"
                                                        + "            ,[OfficeAutomation_Agent_AgentID] = @sOfficeAutomation_Agent_AgentID"
                                                        + "            ,[OfficeAutomation_Agent_Start] = @dtOfficeAutomation_Agent_Start"
                                                        + "            ,[OfficeAutomation_Agent_End] = @dtOfficeAutomation_Agent_End"
                                                        + "            ,[OfficeAutomation_Agent_IsEnable] = @bOfficeAutomation_Agent_IsEnable"
                                                        + " WHERE [OfficeAutomation_Agent_ID] = @iOfficeAutomation_Agent_ID";
           

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Agent)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Agent_Agent", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Agent_Agent));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Agent_AgentID", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Agent_AgentID));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Agent_Start", SqlDbType.DateTime2, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Agent_Start));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Agent_End", SqlDbType.DateTime2, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Agent_End));
                cmdToExecute.Parameters.Add(new SqlParameter("@bOfficeAutomation_Agent_IsEnable", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Agent_IsEnable));
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Agent_ID", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Agent_ID));

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

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Agent]"
                                                        + "           (OfficeAutomation_Agent_Auditor"
                                                        + "           ,OfficeAutomation_Agent_AuditorID"
                                                        + "           ,OfficeAutomation_Agent_Agent"
                                                        + "           ,OfficeAutomation_Agent_AgentID"
                                                        + "           ,OfficeAutomation_Agent_Start"
                                                        + "           ,OfficeAutomation_Agent_End"
                                                        + "           ,OfficeAutomation_Agent_IsEnable"
                                                        + "           ,OfficeAutomaiton_Agent_CreateTime)"
                                                        + "     VALUES"
                                                        + "           (@sOfficeAutomation_Agent_Auditor"
                                                        + "           ,@sOfficeAutomation_Agent_AuditorID"
                                                        + "           ,@sOfficeAutomation_Agent_Agent"
                                                        + "           ,@sOfficeAutomation_Agent_AgentID"
                                                        + "           ,@dtOfficeAutomation_Agent_Start"
                                                        + "           ,@dtOfficeAutomation_Agent_End"
                                                        + "           ,@bOfficeAutomation_Agent_IsEnable"
                                                        + "           ,@dtOfficeAutomaiton_Agent_CreateTime)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Agent)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Agent_Auditor", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Agent_Auditor));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Agent_AuditorID", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Agent_AuditorID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Agent_Agent", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Agent_Agent));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Agent_AgentID", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Agent_AgentID));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Agent_Start", SqlDbType.DateTime2, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Agent_Start));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Agent_End", SqlDbType.DateTime2, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Agent_End));
                cmdToExecute.Parameters.Add(new SqlParameter("@bOfficeAutomation_Agent_IsEnable", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Agent_IsEnable));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomaiton_Agent_CreateTime", SqlDbType.DateTime2, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DateTime.Now));

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
        /// 
        /// </summary>
        /// <param name="obj">int 主键</param>
        /// <returns></returns>
        public override bool Delete(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Agent]"
                                                        + "         WHERE  [OfficeAutomation_Agent_ID] = @iOfficeAutomation_Agent_ID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Agent_ID", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, obj));

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
