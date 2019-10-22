using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_CommissionOfMonth_Detail_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_CommissionOfMonth_Detail _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_CommissionOfMonth_Detail]"
                                                        + "           ([OfficeAutomation_Document_CommissionOfMonth_Detail_ID]"
                                                        + "           ,[OfficeAutomation_Document_CommissionOfMonth_Detail_MainID]"
                                                        + "           ,[OfficeAutomation_Document_CommissionOfMonth_Detail_Department]"
                                                        + "           ,[OfficeAutomation_Document_CommissionOfMonth_Detail_Name]"
                                                        + "           ,[OfficeAutomation_Document_CommissionOfMonth_Detail_Code]"
                                                        + "           ,[OfficeAutomation_Document_CommissionOfMonth_Detail_EnterDate]"
                                                        + "           ,[OfficeAutomation_Document_CommissionOfMonth_Detail_Position]"
                                                        + "           ,[OfficeAutomation_Document_CommissionOfMonth_Detail_Rank]"
                                                        + "           ,[OfficeAutomation_Document_CommissionOfMonth_Detail_Results])"
                                                        + "     VALUES"
                                                        + "           (@OfficeAutomation_Document_CommissionOfMonth_Detail_ID"
                                                        + "           ,@OfficeAutomation_Document_CommissionOfMonth_Detail_MainID"
                                                        + "           ,@OfficeAutomation_Document_CommissionOfMonth_Detail_Department"
                                                        + "           ,@OfficeAutomation_Document_CommissionOfMonth_Detail_Name"
                                                        + "           ,@OfficeAutomation_Document_CommissionOfMonth_Detail_Code"
                                                        + "           ,@OfficeAutomation_Document_CommissionOfMonth_Detail_EnterDate"
                                                        + "           ,@OfficeAutomation_Document_CommissionOfMonth_Detail_Position"
                                                        + "           ,@OfficeAutomation_Document_CommissionOfMonth_Detail_Rank"
                                                        + "           ,@OfficeAutomation_Document_CommissionOfMonth_Detail_Results)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_CommissionOfMonth_Detail)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionOfMonth_Detail_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionOfMonth_Detail_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionOfMonth_Detail_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionOfMonth_Detail_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionOfMonth_Detail_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionOfMonth_Detail_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionOfMonth_Detail_Name", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionOfMonth_Detail_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionOfMonth_Detail_Code", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionOfMonth_Detail_Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionOfMonth_Detail_EnterDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionOfMonth_Detail_EnterDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionOfMonth_Detail_Position", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionOfMonth_Detail_Position));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionOfMonth_Detail_Rank", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionOfMonth_Detail_Rank));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionOfMonth_Detail_Results", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionOfMonth_Detail_Results));

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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_CommissionOfMonth_Detail]"
                                + "   SET [OfficeAutomation_Document_CommissionOfMonth_Detail_Department] =@OfficeAutomation_Document_CommissionOfMonth_Detail_Department"
                                + "         ,[OfficeAutomation_Document_CommissionOfMonth_Detail_Name] =@OfficeAutomation_Document_CommissionOfMonth_Detail_Name"
                                + "         ,[OfficeAutomation_Document_CommissionOfMonth_Detail_Code] =@OfficeAutomation_Document_CommissionOfMonth_Detail_Code"
                                + "         ,[OfficeAutomation_Document_CommissionOfMonth_Detail_EnterDate] =@OfficeAutomation_Document_CommissionOfMonth_Detail_EnterDate"
                                + "         ,[OfficeAutomation_Document_CommissionOfMonth_Detail_Position] =@OfficeAutomation_Document_CommissionOfMonth_Detail_Position"
                                + "         ,[OfficeAutomation_Document_CommissionOfMonth_Detail_Rank] =@OfficeAutomation_Document_CommissionOfMonth_Detail_Rank"
                                + "         ,[OfficeAutomation_Document_CommissionOfMonth_Detail_Results] =@OfficeAutomation_Document_CommissionOfMonth_Detail_Results"
                                + " WHERE [OfficeAutomation_Document_CommissionOfMonth_Detail_ID]=@OfficeAutomation_Document_CommissionOfMonth_Detail_ID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_CommissionOfMonth_Detail)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionOfMonth_Detail_Department", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionOfMonth_Detail_Department));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionOfMonth_Detail_Name", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionOfMonth_Detail_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionOfMonth_Detail_Code", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionOfMonth_Detail_Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionOfMonth_Detail_EnterDate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionOfMonth_Detail_EnterDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionOfMonth_Detail_Position", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionOfMonth_Detail_Position));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionOfMonth_Detail_Rank", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionOfMonth_Detail_Rank));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionOfMonth_Detail_Results", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionOfMonth_Detail_Results));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_CommissionOfMonth_Detail_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_CommissionOfMonth_Detail_ID));

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

            cmdToExecute.CommandText = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_CommissionOfMonth_Detail]"
                                + " WHERE [OfficeAutomation_Document_CommissionOfMonth_Detail_MainID]=@guidOfficeAutomation_Document_CommissionOfMonth_Detail_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_CommissionOfMonth_Detail_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, new Guid(mainID)));

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
