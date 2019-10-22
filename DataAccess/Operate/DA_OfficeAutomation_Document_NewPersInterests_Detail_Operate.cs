using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Operate
{
    public class DA_OfficeAutomation_Document_NewPersInterests_Detail_Operate : SqlInteractionBase
    {
        #region 自定义变量
        private DataEntity.T_OfficeAutomation_Document_NewPersInterests_Detail _objMessage = null;
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = "INSERT INTO [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_NewPersInterests_Detail]"
                                                        + "           ([OfficeAutomation_Document_NewPersInterests_Detail_ID]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_Detail_MainID]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_Detail_RelativesName]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_Detail_InDepartment]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_Detail_Position]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_Detail_Relationship]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_Detail_rdInApply]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_Detail_ApplyForID]"
                                                        + "           ,[OfficeAutomation_Document_NewPersInterests_Detail_txtTfid]"
                                                        + "            )"
                                                        + "     VALUES"
                                                        + "           (@guidOfficeAutomation_Document_NewPersInterests_Detail_ID"
                                                        + "           ,@guidOfficeAutomation_Document_NewPersInterests_Detail_MainID"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_Detail_RelativesName"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_Detail_InDepartment"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_Detail_Position"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_Detail_Relationship"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_Detail_rdInApply"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_Detail_ApplyForID"
                                                        + "           ,@OfficeAutomation_Document_NewPersInterests_Detail_txtTfid"
                                                        + "           )";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_NewPersInterests_Detail)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_NewPersInterests_Detail_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_Detail_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_NewPersInterests_Detail_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_Detail_MainID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_Detail_RelativesName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_Detail_RelativesName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_Detail_InDepartment", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_Detail_InDepartment));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_Detail_Position", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_Detail_Position));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_Detail_Relationship", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_Detail_Relationship));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_Detail_rdInApply", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_Detail_rdInApply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_Detail_ApplyForID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_Detail_ApplyForID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_Detail_txtTfid", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_Detail_txtTfid));
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

            cmdToExecute.CommandText = "UPDATE [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_NewPersInterests_Detail]"
                                + "   SET [OfficeAutomation_Document_NewPersInterests_Detail_RelativesName] =@OfficeAutomation_Document_NewPersInterests_Detail_RelativesName"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_Detail_InDepartment] = @OfficeAutomation_Document_NewPersInterests_Detail_InDepartment"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_Detail_Position] = @OfficeAutomation_Document_NewPersInterests_Detail_Position"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_Detail_Relationship] = @OfficeAutomation_Document_NewPersInterests_Detail_Relationship"

                                + "         ,[OfficeAutomation_Document_NewPersInterests_Detail_rdInApply] = @OfficeAutomation_Document_NewPersInterests_Detail_rdInApply"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_Detail_ApplyForID] = @OfficeAutomation_Document_NewPersInterests_Detail_ApplyForID"
                                + "         ,[OfficeAutomation_Document_NewPersInterests_Detail_txtTfid] = @OfficeAutomation_Document_NewPersInterests_Detail_txtTfid"
                                + " WHERE [OfficeAutomation_Document_NewPersInterests_Detail_ID]=@OfficeAutomation_Document_NewPersInterests_Detail_ID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            this._objMessage = (DataEntity.T_OfficeAutomation_Document_NewPersInterests_Detail)obj;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_Detail_RelativesName", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_Detail_RelativesName));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_Detail_InDepartment", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_Detail_InDepartment));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_Detail_Position", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_Detail_Position));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_Detail_Relationship", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_Detail_Relationship));

                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_Detail_rdInApply", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_Detail_rdInApply));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_Detail_ApplyForID", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_Detail_ApplyForID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_Detail_txtTfid", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_Detail_txtTfid));
                cmdToExecute.Parameters.Add(new SqlParameter("@OfficeAutomation_Document_NewPersInterests_Detail_ID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, this._objMessage.OfficeAutomation_Document_NewPersInterests_Detail_ID));


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

            cmdToExecute.CommandText = "DELETE FROM [DB_EcOfficeAutomation].[dbo].[t_OfficeAutomation_Document_NewPersInterests_Detail]"
                                + " WHERE [OfficeAutomation_Document_NewPersInterests_Detail_MainID]=@guidOfficeAutomation_Document_NewPersInterests_Detail_MainID";

            cmdToExecute.CommandType = CommandType.Text;

            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@guidOfficeAutomation_Document_NewPersInterests_Detail_MainID", SqlDbType.UniqueIdentifier, 36, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, new Guid(mainID)));

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
