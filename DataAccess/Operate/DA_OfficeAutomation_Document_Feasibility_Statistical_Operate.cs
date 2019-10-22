using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_Feasibility_Statistical_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_Feasibility_Statistical _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Feasibility_Statistical]"
                                                        + "           ([OfficeAutomation_Document_Feasibility_Statistical_ID]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_Statistical_MainID]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_Statistical_Bname]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_Statistical_GzspsNum]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_Statistical_GzspsRate]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_Statistical_RichNum]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_Statistical_RichRate]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_Statistical_EveryNum]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_Statistical_EveryRate]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_Statistical_YuFengNum]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_Statistical_YuFengRate]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_Statistical_OtherNum]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_Statistical_OtherRate]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_Statistical_FreeNum]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_Statistical_FreeRate]"
                                                        + "           ,[OfficeAutomation_Document_Feasibility_Statistical_AllSum])"
                                                        + "     VALUES"
                                                        + "           (@OfficeAutomation_Document_Feasibility_Statistical_ID"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_Statistical_MainID"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_Statistical_Bname"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_Statistical_GzspsNum"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_Statistical_GzspsRate"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_Statistical_RichNum"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_Statistical_RichRate"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_Statistical_EveryNum"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_Statistical_EveryRate"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_Statistical_YuFengNum"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_Statistical_YuFengRate"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_Statistical_OtherNum"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_Statistical_OtherRate"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_Statistical_FreeNum"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_Statistical_FreeRate"
                                                        + "           ,@OfficeAutomation_Document_Feasibility_Statistical_AllSum)";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_Feasibility_Statistical)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Statistical_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Statistical_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Statistical_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Statistical_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Statistical_Bname", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Statistical_Bname));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Statistical_GzspsNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Statistical_GzspsNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Statistical_GzspsRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Statistical_GzspsRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Statistical_RichNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Statistical_RichNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Statistical_RichRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Statistical_RichRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Statistical_EveryNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Statistical_EveryNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Statistical_EveryRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Statistical_EveryRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Statistical_YuFengNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Statistical_YuFengNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Statistical_YuFengRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Statistical_YuFengRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Statistical_OtherNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Statistical_OtherNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Statistical_OtherRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Statistical_OtherRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Statistical_FreeNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Statistical_FreeNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Statistical_FreeRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Statistical_FreeRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Statistical_AllSum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Statistical_AllSum));

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

            cmdToExecute.CommandText = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Feasibility_Statistical]"
                                + " WHERE [OfficeAutomation_Document_Feasibility_Statistical_MainID]=@sOfficeAutomation_Document_Feasibility_Statistical_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sOfficeAutomation_Document_Feasibility_Statistical_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, new Guid(mainID)));

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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_Feasibility_Statistical]"
                                                        + "     SET [OfficeAutomation_Document_Feasibility_Statistical_Bname]=@OfficeAutomation_Document_Feasibility_Statistical_Bname"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_Statistical_GzspsNum]=@OfficeAutomation_Document_Feasibility_Statistical_GzspsNum"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_Statistical_GzspsRate]=@OfficeAutomation_Document_Feasibility_Statistical_GzspsRate"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_Statistical_RichNum]=@OfficeAutomation_Document_Feasibility_Statistical_RichNum"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_Statistical_RichRate]=@OfficeAutomation_Document_Feasibility_Statistical_RichRate"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_Statistical_EveryNum]=@OfficeAutomation_Document_Feasibility_Statistical_EveryNum"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_Statistical_EveryRate]=@OfficeAutomation_Document_Feasibility_Statistical_EveryRate"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_Statistical_YuFengNum]=@OfficeAutomation_Document_Feasibility_Statistical_YuFengNum"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_Statistical_YuFengRate]=@OfficeAutomation_Document_Feasibility_Statistical_YuFengRate"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_Statistical_OtherNum]=@OfficeAutomation_Document_Feasibility_Statistical_OtherNum"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_Statistical_OtherRate]=@OfficeAutomation_Document_Feasibility_Statistical_OtherRate"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_Statistical_FreeNum]=@OfficeAutomation_Document_Feasibility_Statistical_FreeNum"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_Statistical_FreeRate]=@OfficeAutomation_Document_Feasibility_Statistical_FreeRate"
                                                        + "            ,[OfficeAutomation_Document_Feasibility_Statistical_AllSum]=@OfficeAutomation_Document_Feasibility_Statistical_AllSum"
                                                        + " WHERE [OfficeAutomation_Document_Feasibility_Statistical_ID]=@OfficeAutomation_Document_Feasibility_Statistical_ID"
                                                        + "     AND [OfficeAutomation_Document_Feasibility_Statistical_MainID] = @OfficeAutomation_Document_Feasibility_Statistical_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_Feasibility_Statistical)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Statistical_Bname", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Statistical_Bname));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Statistical_GzspsNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Statistical_GzspsNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Statistical_GzspsRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Statistical_GzspsRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Statistical_RichNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Statistical_RichNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Statistical_RichRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Statistical_RichRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Statistical_EveryNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Statistical_EveryNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Statistical_EveryRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Statistical_EveryRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Statistical_YuFengNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Statistical_YuFengNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Statistical_YuFengRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Statistical_YuFengRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Statistical_OtherNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Statistical_OtherNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Statistical_OtherRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Statistical_OtherRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Statistical_FreeNum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Statistical_FreeNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Statistical_FreeRate", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Statistical_FreeRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Statistical_AllSum", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Statistical_AllSum));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Statistical_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Statistical_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_Feasibility_Statistical_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_Feasibility_Statistical_MainID));

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
