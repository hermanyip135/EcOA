using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using DataEntity;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Message_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Message _objMessage = null;
        private DataEntity.T_OfficeAutomation_Main _objMessageMain = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Message]"
                                                        //+ "           ([OfficeAutomation_Message_ID]"
                                                        + "           ([OfficeAutomation_Message_Title]"
                                                        + "           ,[OfficeAutomation_Message_Body]"
                                                        + "           ,[OfficeAutomation_Message_MessBody]"
                                                        + "           ,[OfficeAutomation_Message_ToEmail]"
                                                        + "           ,[OfficeAutomation_Message_HtmlFlag]"
                                                        + "           ,[OfficeAutomation_Message_PostFlag]"
                                                        //+ "           ,[OfficeAutomation_Message_PostDate]"
                                                        + "           ,[OfficeAutomation_Message_CreateDate])"
                                                        + "     VALUES"
                                                        //+ "           (@iOfficeAutomation_Message_ID"
                                                        + "           (@sOfficeAutomation_Message_Title"
                                                        + "           ,@sOfficeAutomation_Message_Body"
                                                        + "           ,@sOfficeAutomation_Message_MessBody"
                                                        + "           ,@sOfficeAutomation_Message_ToEmail"
                                                        + "           ,@bOfficeAutomation_Message_HtmlFlag"
                                                        + "           ,@bOfficeAutomation_Message_PostFlag"
                                                        //+ "           ,@dtOfficeAutomation_Message_PostDate"
                                                        + "           ,@dtOfficeAutomation_Message_CreateDate)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Message)obj;

            try
            {
                //cmdToExecute.Parameters.Add(new SqlParameter("@iOfficeAutomation_Message_ID", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Message_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Message_Title", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Message_Title));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Message_Body", this._objMessage.OfficeAutomation_Message_Body));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Message_MessBody", this._objMessage.OfficeAutomation_Message_MessBody));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Message_ToEmail", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Message_ToEmail));
                cmdToExecute.Parameters.Add(new SqlParameter("@bOfficeAutomation_Message_HtmlFlag", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, true));
                cmdToExecute.Parameters.Add(new SqlParameter("@bOfficeAutomation_Message_PostFlag", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, false));
                //cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Message_PostDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Message_PostDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@dtOfficeAutomation_Message_CreateDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DateTime.Now));

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

        #region 插入备份记录
        /// <summary>
        /// 插入备份记录
        /// </summary>
        /// <returns></returns>
        public bool InsertMainBackUp(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO DB_ECOA_BACK.[dbo].[t_OfficeAutomation_Main]"
                                                        + "           ([OfficeAutomation_Main_ID]"
                                                        + "           ,[OfficeAutomation_SerialNumber]"
                                                        + "           ,[OfficeAutomation_DocumentID]"
                                                        + "           ,[OfficeAutomation_Main_FlowStateID]"
                                                        + "           ,[OfficeAutomation_Main_AuditorIDsSum]"
                                                        + "           ,[OfficeAutomation_Main_AuditorNamesSum]"
                                                        + "           ,[OfficeAutomation_Main_IsBackUp])"
                                                        + "     VALUES"
                                                        + "           (@OfficeAutomation_Main_ID"
                                                        + "           ,@OfficeAutomation_SerialNumber"
                                                        + "           ,@OfficeAutomation_DocumentID"
                                                        + "           ,@OfficeAutomation_Main_FlowStateID"
                                                        + "           ,@OfficeAutomation_Main_AuditorIDsSum"
                                                        + "           ,@OfficeAutomation_Main_AuditorNamesSum"
                                                        + "           ,@OfficeAutomation_Main_IsBackUp)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessageMain = (DataEntity.T_OfficeAutomation_Main)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Main_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessageMain.OfficeAutomation_Main_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_SerialNumber", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessageMain.OfficeAutomation_SerialNumber));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_DocumentID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessageMain.OfficeAutomation_DocumentID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Main_FlowStateID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessageMain.OfficeAutomation_Main_FlowStateID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Main_AuditorIDsSum", SqlDbType.NVarChar, 800, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessageMain.OfficeAutomation_Main_AuditorIDsSum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Main_AuditorNamesSum", SqlDbType.NVarChar, 800, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessageMain.OfficeAutomation_Main_AuditorNamesSum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Main_IsBackUp", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessageMain.OfficeAutomation_Main_IsBackUp));

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
