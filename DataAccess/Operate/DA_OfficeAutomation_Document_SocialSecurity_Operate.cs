using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_SocialSecurity_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_SocialSecurity _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SocialSecurity]"
                                                        + "           ([OfficeAutomation_Document_SocialSecurity_ID]"
                                                        + "           ,[OfficeAutomation_Document_SocialSecurity_MainID]"
                                                        + "           ,[OfficeAutomation_Document_SocialSecurity_Apply]"
                                                        + "           ,[OfficeAutomation_Document_SocialSecurity_ApplyDate]"
                                                        + "           ,[OfficeAutomation_Document_SocialSecurity_ApplyID]"
                                                        + "           ,[OfficeAutomation_Document_SocialSecurity_Department]"
                                                        + "           ,[OfficeAutomation_Document_SocialSecurity_Name]"
                                                        + "           ,[OfficeAutomation_Document_SocialSecurity_Code]"
                                                        + "           ,[OfficeAutomation_Document_SocialSecurity_EnterDate]"
                                                        + "           ,[OfficeAutomation_Document_SocialSecurity_Position]"
                                                        + "           ,[OfficeAutomation_Document_SocialSecurity_Rank]"
                                                        + "           ,[OfficeAutomation_Document_SocialSecurity_Results]"
                                                        + "           ,[OfficeAutomation_Document_SocialSecurity_Describe])"
                                                        + " VALUES"
                                                        + "           (@OfficeAutomation_Document_SocialSecurity_ID"
                                                        + "           ,@OfficeAutomation_Document_SocialSecurity_MainID"
                                                        + "           ,@OfficeAutomation_Document_SocialSecurity_Apply"
                                                        + "           ,@OfficeAutomation_Document_SocialSecurity_ApplyDate"
                                                        + "           ,@OfficeAutomation_Document_SocialSecurity_ApplyID"
                                                        + "           ,@OfficeAutomation_Document_SocialSecurity_Department"
                                                        + "           ,@OfficeAutomation_Document_SocialSecurity_Name"
                                                        + "           ,@OfficeAutomation_Document_SocialSecurity_Code"
                                                        + "           ,@OfficeAutomation_Document_SocialSecurity_EnterDate"
                                                        + "           ,@OfficeAutomation_Document_SocialSecurity_Position"
                                                        + "           ,@OfficeAutomation_Document_SocialSecurity_Rank"
                                                        + "           ,@OfficeAutomation_Document_SocialSecurity_Results"
                                                        + "           ,@OfficeAutomation_Document_SocialSecurity_Describe)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_SocialSecurity)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SocialSecurity_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SocialSecurity_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SocialSecurity_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SocialSecurity_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SocialSecurity_Apply", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SocialSecurity_Apply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SocialSecurity_ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SocialSecurity_ApplyDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SocialSecurity_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SocialSecurity_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SocialSecurity_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SocialSecurity_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SocialSecurity_Name", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SocialSecurity_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SocialSecurity_Code", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SocialSecurity_Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SocialSecurity_EnterDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SocialSecurity_EnterDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SocialSecurity_Position", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SocialSecurity_Position));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SocialSecurity_Rank", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SocialSecurity_Rank));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SocialSecurity_Results", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SocialSecurity_Results));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SocialSecurity_Describe", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SocialSecurity_Describe));

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
            cmdToExecute.CommandText = "dbo.[pr_SocialSecurity_Delete]";
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SocialSecurity]"
                                + "         SET [OfficeAutomation_Document_SocialSecurity_ApplyID] = @OfficeAutomation_Document_SocialSecurity_ApplyID"
                                + "         ,[OfficeAutomation_Document_SocialSecurity_Department] = @OfficeAutomation_Document_SocialSecurity_Department"
                                + "         ,[OfficeAutomation_Document_SocialSecurity_Name] = @OfficeAutomation_Document_SocialSecurity_Name"
                                + "         ,[OfficeAutomation_Document_SocialSecurity_Code] = @OfficeAutomation_Document_SocialSecurity_Code"
                                + "         ,[OfficeAutomation_Document_SocialSecurity_EnterDate] = @OfficeAutomation_Document_SocialSecurity_EnterDate"
                                + "         ,[OfficeAutomation_Document_SocialSecurity_Position] = @OfficeAutomation_Document_SocialSecurity_Position"
                                + "         ,[OfficeAutomation_Document_SocialSecurity_Rank] = @OfficeAutomation_Document_SocialSecurity_Rank"
                                + "         ,[OfficeAutomation_Document_SocialSecurity_Results] = @OfficeAutomation_Document_SocialSecurity_Results"
                                + "         ,[OfficeAutomation_Document_SocialSecurity_Describe] = @OfficeAutomation_Document_SocialSecurity_Describe"
                                + "         WHERE [OfficeAutomation_Document_SocialSecurity_ID]=@OfficeAutomation_Document_SocialSecurity_ID"
                                + "         AND [OfficeAutomation_Document_SocialSecurity_MainID]=@OfficeAutomation_Document_SocialSecurity_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_SocialSecurity)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SocialSecurity_ApplyID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SocialSecurity_ApplyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SocialSecurity_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SocialSecurity_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SocialSecurity_Name", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SocialSecurity_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SocialSecurity_Code", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SocialSecurity_Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SocialSecurity_EnterDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SocialSecurity_EnterDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SocialSecurity_Position", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SocialSecurity_Position));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SocialSecurity_Rank", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SocialSecurity_Rank));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SocialSecurity_Results", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SocialSecurity_Results));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SocialSecurity_Describe", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SocialSecurity_Describe));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SocialSecurity_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SocialSecurity_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SocialSecurity_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_SocialSecurity_MainID));

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

        public bool UpdateMoney(string mid, string s)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SocialSecurity]"
                                + "         SET [OfficeAutomation_Document_SocialSecurity_Money] = @OfficeAutomation_Document_SocialSecurity_Money"
                                + "         WHERE [OfficeAutomation_Document_SocialSecurity_MainID]=@OfficeAutomation_Document_SocialSecurity_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            //this._objMessage = (DataEntity.T_OfficeAutomation_Document_SocialSecurity)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SocialSecurity_Money", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, s));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SocialSecurity_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed,new Guid(mid)));

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

        public bool UpdateSureTime(string mid, string s)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_SocialSecurity]"
                                + "         SET [OfficeAutomation_Document_SocialSecurity_SureTime] = @OfficeAutomation_Document_SocialSecurity_SureTime"
                                + "         WHERE [OfficeAutomation_Document_SocialSecurity_MainID]=@OfficeAutomation_Document_SocialSecurity_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            //this._objMessage = (DataEntity.T_OfficeAutomation_Document_SocialSecurity)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SocialSecurity_SureTime", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, s));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_SocialSecurity_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, new Guid(mid)));

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
